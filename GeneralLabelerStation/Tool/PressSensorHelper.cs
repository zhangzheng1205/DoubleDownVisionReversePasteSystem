using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using GeneralLabelerStation.Common;

namespace GeneralLabelerStation.Tool
{
    /// <summary>
    /// 压力传感器----立讯底部贴
    /// </summary>
    public class PressSensorHelper : Common.SingletionProvider<PressSensorHelper>
    {
        public PressSensorHelper()
        {
            VariableSys.PressSensorVersion = (short)Ini_Sys.IniReadNum("PressSensorType", "PressSensorVersion");
        }


        #region 需要保存变量
        public string SensorIP
        {
            get;
            set;
        } = "192.168.1.30";

        public int SensorProt
        {
            get;
            set;
        } = 8088;

        public static Variable VariableSys = new Variable();
        public IniFile Ini_Sys = new IniFile(Variable.sPath_BaseProgram + "\\Configure\\System.ini");

        /// <summary>
        /// 压力报警记录保存行数
        /// </summary>
        public int RecrodRowCount
        {
            get;
            set;
        } = 50;

        /// <summary>
        /// 固有压力
        /// </summary>
        public double[] NozzlePress = new double[4];

        /// <summary>
        /// 累计超压报警
        /// </summary>
        public int AlarmCount
        {
            get;
            set;
        } = 5;

        /// <summary>
        /// 报警g数
        /// </summary>
        public double AlarmLimit
        {
            get;
            set;
        } = 400;

        public int[] ZChannel = { 0, 1, 2, 3 };
        #endregion

        #region 中间变量
        [JsonIgnore]
        public Socket Socket = null;

        /// <summary>
        /// 实时压力
        /// </summary>
        [JsonIgnore]
        public double[] CurPress = new double[4];

        /// <summary>
        /// 贴附过程中压力
        /// </summary>
        [JsonIgnore]
        public double[] PastePress = new double[4];

        [JsonIgnore]
        public List<Label> ShowPasteLabel = new List<Label>();

        [JsonIgnore]
        public List<Label> ShowLabel = new List<Label>();

        [JsonIgnore]
        private object sendLock = new object();

        [JsonIgnore]
        public bool NeedConnected = true;

        [JsonIgnore]
        public bool IsCailb = false;
        #endregion

        #region 中间函数
        /// <summary>
        /// 重连接
        /// </summary>
        /// <returns></returns>
        public bool ReConnected()
        {
            try
            {
                lock (this.sendLock)
                {
                    IPAddress iPAddress = IPAddress.Parse(this.SensorIP);
                    IPEndPoint iPEnd = new IPEndPoint(iPAddress, this.SensorProt);
                    this.Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    this.Socket.ReceiveTimeout = 200;
                    this.Socket.Connect(iPEnd);
                    Thread.Sleep(100);
                    return true;
                }
            }
            catch { }
            return false;
        }

        /// <summary>
        /// 断开连接
        /// </summary>
        public void DisConnected()
        {
            if (this.Socket != null && this.Socket.Connected)
            {
                lock (this.sendLock)
                {
                    try
                    {
                        this.Socket.Disconnect(false);
                        Thread.Sleep(100);
                        this.Socket.Dispose();
                    }
                    catch { }
                }
            }
        }

        /// <summary>
        /// 开始
        /// </summary>
        public void Start()
        {
            if (this.Socket == null)
            {
                new Thread(ThreadRecive).Start();

            }
        }

        /// <summary>
        /// 查询1-12通道的 测量值
        /// </summary>
        public void SendGet()
        {
            if (this.Socket != null && this.Socket.Connected)
            {
                try
                {
                    byte[] sendByte = new byte[8];
                    if (VariableSys.PressSensorVersion == 1)
                    {
                        sendByte[0] = 0X01;
                        sendByte[1] = 0X03;
                        sendByte[2] = 0X00;
                        sendByte[3] = 0X00;
                        sendByte[4] = 0X00;
                        sendByte[5] = 0X06;
                        sendByte[6] = 0XC5;
                        sendByte[7] = 0XC8;
                    }
                    else
                    {
                        // CRC 校验需要改
                        sendByte[0] = 0X01;
                        sendByte[1] = 0X03;
                        sendByte[2] = 0X00;
                        sendByte[3] = 0X00;
                        sendByte[4] = 0X00;
                        sendByte[5] = 0X18;
                        sendByte[6] = 0X45;
                        sendByte[7] = 0XC0;
                    }
                    lock (this.sendLock)
                    {
                        this.Socket.Send(sendByte);
                    }
                }
                catch { }
            }
        }

        public void SendZero(int channel)
        {
            if (this.Socket == null || !this.Socket.Connected)
                return;
            if (VariableSys.PressSensorVersion == 1)
            {
                byte[] sendByte = new byte[11];
                sendByte[0] = 0X01;
                sendByte[1] = 0X10;
                sendByte[2] = 0X03;
                sendByte[3] = 0XED;
                sendByte[4] = 0X00;
                sendByte[5] = 0X01;
                sendByte[6] = 0X02;
                sendByte[7] = 0X00;
                switch (channel)
                {
                    case 0:
                        sendByte[8] = 0X01;
                        sendByte[9] = 0X43;
                        sendByte[10] = 0XED;
                        break;
                    case 1:
                        sendByte[8] = 0X02;
                        sendByte[9] = 0X03;
                        sendByte[10] = 0XEC;
                        break;
                    case 2:
                        sendByte[8] = 0X03;
                        sendByte[9] = 0XC2;
                        sendByte[10] = 0X2C;
                        break;
                    case 3:
                        sendByte[8] = 0X04;
                        sendByte[9] = 0X83;
                        sendByte[10] = 0XEE;
                        break;
                }

                byte[] SendByteZero = new byte[11];
                SendByteZero[0] = 0X01;
                SendByteZero[1] = 0X10;
                SendByteZero[2] = 0X03;
                SendByteZero[3] = 0XEF;
                SendByteZero[4] = 0X00;
                SendByteZero[5] = 0X01;
                SendByteZero[6] = 0X02;
                SendByteZero[7] = 0X00;
                SendByteZero[8] = 0X01;
                SendByteZero[9] = 0X42;
                SendByteZero[10] = 0X0F;

                lock (this.sendLock)
                {

                    this.Socket.Send(sendByte);
                    Thread.Sleep(10);
                    this.Socket.Send(SendByteZero);
                    this.Socket.Send(sendByte);
                }
            }
            else
            {
                byte[] sendByte = new byte[9];
                sendByte[0] = 0X01;
                sendByte[1] = 0X10;
                sendByte[2] = 0X00;
                sendByte[3] = 0X18;
                sendByte[4] = 0X00;
                sendByte[5] = 0X18;

                for (int i = 0; i < 12; i += 4)
                {
                    if (channel == i)
                    {
                        sendByte[i] = 00;
                        sendByte[i + 1] = 00;
                        sendByte[i + 2] = 00;
                        sendByte[i + 3] = 01;
                    }
                    else
                    {
                        sendByte[i] = 00;
                        sendByte[i + 1] = 00;
                        sendByte[i + 2] = 00;
                        sendByte[i + 3] = 00;
                    }
                }
                sendByte[54] = 0X50;
                sendByte[55] = 0X5C;
                lock (this.sendLock)
                {
                    this.Socket.Send(sendByte);
                }
            }

        }

        public void SendZeroAll()
        {
            if (this.Socket == null || !this.Socket.Connected)
                return;
            byte[] sendByte = null;
            if (VariableSys.PressSensorVersion == 1)
            {
                sendByte = new byte[11];
                sendByte[0] = 0X01;
                sendByte[1] = 0X10;
                sendByte[2] = 0X03;
                sendByte[3] = 0XEF;
                sendByte[4] = 0X00;
                sendByte[5] = 0X01;
                sendByte[6] = 0X02;
                sendByte[7] = 0X00;
                sendByte[8] = 0X20;
                sendByte[9] = 0X82;
                sendByte[10] = 0X17;
            }
            else
            {
                sendByte = new byte[9];
                sendByte[0] = 0X01;
                sendByte[1] = 0X11;
                sendByte[2] = 0X00;
                sendByte[3] = 0XC8;
                sendByte[4] = 0X00;
                sendByte[5] = 0X01;
                sendByte[6] = 0X02;
                sendByte[7] = 0XB6;
                sendByte[8] = 0XB0;
            }
            lock (this.sendLock)
            {
                    this.Socket.Send(sendByte);
                    Thread.Sleep(20);
            }
        }

        /// <summary>
        /// 获得 压力值并解析
        /// </summary>
        /// <returns></returns>
        public void ParseValue()
        {
            try
            {
                byte[] recBytes = new byte[256];
                int bytes = this.Socket.Receive(recBytes, recBytes.Length, 0);
                if (recBytes[0] == 0x01 && recBytes[1] == 0x03)
                {
                    int count = 0;
                    double[] Temp = new double[12];
                    //
                    if (VariableSys.PressSensorVersion == 1)
                    {
                        for (int i = 7; i < 14; i += 2)
                        {
                            int r3 = 0;
                            int r4 = 0;
                            int IsPos = 1;
                            if (recBytes[i] > 128) // 负数
                            {
                                recBytes[i] = 0;
                            }

                            r3 = recBytes[i];
                            r4 = recBytes[i + 1];
                            Temp[count] = IsPos * (r3 * 255 + r4);
                            count++;
                        }
                    }
                    else
                    {
                        for (int i = 3; i < 19; i += 4)
                        {
                            int r3 = 0;
                            int r4 = 0;
                            int IsPos = 1;
                            if (recBytes[i] == 0xFF) // 负数
                            {
                                IsPos = -1;
                                recBytes[i] ^= 0xFF;
                                recBytes[i + 1] ^= 0xFF;
                                recBytes[i + 2] ^= 0xFF;
                                recBytes[i + 3] ^= 0xFF;
                                recBytes[i + 3] += 0x01;
                            }

                            r3 = recBytes[i + 2];
                            r4 = recBytes[i + 3];

                            Temp[count] = IsPos * (r3 * 255 + r4) / 10.0;
                            count++;
                        }
                    }
                    for (int i = 0; i < 4; ++i)
                    {
                        this.CurPress[i] = Math.Abs(Temp[this.ZChannel[i]]);

                        if (Form_Main.Instance.RunMode == 1)
                        {
                            if (this.CurPress[i] > 500)
                            {
                                this.CurPress[i] = 500 / this.CurPress[i] * 500;
                            }
                        }

                        if (Form_Main.Instance.FlowIndex >= 20312 &&
                            Form_Main.Instance.FlowIndex <= 20313)
                        {
                            if ((this.CurPress[i] - this.PastePress[i]) > 0.2)
                            {
                                this.PastePress[i] = this.CurPress[i];
                            }
                        }
                        else if (IsCailb)
                        {
                            if ((this.CurPress[i] - this.PastePress[i]) > 0.2)
                            {
                                this.PastePress[i] = this.CurPress[i];
                            }
                        }
                        else
                            this.PastePress[i] = this.CurPress[i];
                    }
                }
            }
            catch
            {
                this.DisConnected();
            }
        }

        public void ClearPastePress(int zIndex)
        {
            this.PastePress[zIndex] = 0;
        }

        public void ClearAllPastePress()
        {
            for (int i = 0; i < 4; ++i)
            {
                this.ClearPastePress(i);
            }
        }

        public void ThreadRecive()
        {
            while (!Form_Main.Instance.bSystemExit)
            {
                Thread.Sleep(15);

                if (this.NeedConnected && (this.Socket == null || !this.Socket.Connected))
                {
                    this.DisConnected();
                    this.ReConnected();
                }

                this.SendGet();
                ParseValue();
            }
        }

        public void Paste(DataGridView view, double press, int zIndex, int pcbIndex, int pasteIndex)
        {
            if (press >= this.AlarmLimit)
            {
                if (view.Rows.Count > this.RecrodRowCount)
                    view.Rows.Clear();

                int rowIndex = view.Rows.Add();
                view.Rows[rowIndex].Cells[0].Value = DateTime.Now.ToString();
                view.Rows[rowIndex].Cells[1].Value = (zIndex + 1).ToString();
                view.Rows[rowIndex].Cells[2].Value = press.ToString("f1");
                view.Rows[rowIndex].Cells[3].Value = $"{pcbIndex + 1}-{pasteIndex + 1}";
            }
        }

        #endregion

        public bool ShowPastePress(int nozzle, int pcbIndex, int pcsIndex)
        {
            double press = Math.Abs(this.PastePress[nozzle] - this.NozzlePress[nozzle]);
            bool isAlarm = press > this.AlarmLimit;
            Form_Main.Instance.Invoke(new Action(() =>
            {
                this.ShowPasteLabel[nozzle].Text = $"Z{nozzle + 1}压力:[{press:N1}]g";
                if (isAlarm)
                {
                    this.ShowPasteLabel[nozzle].BackColor = System.Drawing.Color.Red;
                    // 显示带主界面
                    this.Paste(Form_Main.Instance.dGVPress, press, nozzle, pcbIndex, pcsIndex);
                }
                else
                    this.ShowPasteLabel[nozzle].BackColor = System.Drawing.Color.LightGreen;
            }));

            //Form_Main.Instance.BeginInvoke(new Action(() => 
            //{
            //    // 存储到日志
            //}));

            return isAlarm;
        }

        public void ShowXIPress()
        {
            for (int i = 0; i < Variable.NOZZLE_NUM; ++i)
            {
                this.ShowLabel[i].Text = $"Z{i + 1}压力:[{this.CurPress[i]:N1}]g";
            }
        }

        public static void Load()
        {
            SerializableHelper<PressSensorHelper> helper = new SerializableHelper<PressSensorHelper>();
            PressSensorHelper.Instance = helper.DeJsonSerialize(Variable.sPath_Configure + "PressSensor.json");
            if (PressSensorHelper.Instance == null)
                PressSensorHelper.Instance = new PressSensorHelper();
        }

        public static void Save()
        {
            SerializableHelper<PressSensorHelper> helper = new SerializableHelper<PressSensorHelper>(PressSensorHelper.Instance);
            helper.JsonSerialize(Variable.sPath_Configure + "PressSensor.json");
        }
    }
}