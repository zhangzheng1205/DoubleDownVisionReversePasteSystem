using GeneralLabelerStation.Statistics;
using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GeneralLabelerStation.Tool
{
    /// <summary>
    /// 
    /// </summary>
    public class ZDTHelper:Common.SingletionProvider<ZDTHelper>
    {
        public ZDTHelper()
        {
            parameters.Add("SZ", new string[] { "TJ02", "TJ02", "TJ02", "TJ01" });
            parameters.Add("XFY", new string[] { "TJ02", "TJ02", "TJ02", "TJ01" });
            parameters.Add("QHD", new string[] { "TJ01", "TJ02", "TJ01", "TJ01" });
            parameters.Add("HA", new string[] { "TJ01", "TJ02", "TJ01", "TJ01" });
        }

        #region 固定配置
        /// <summary>
        /// 地址
        /// </summary>
        public string WebServiceAddress
        {
            get;
            set;
        } = "http://qhecpw001.eavarytech.com:8001/webserviceforQHD/service1.asmx";

        public string User
        {
            get;
            set;
        } = "test1";


        public string PassWd
        {
            get;
            set;
        } = "test1";

        /// <summary>
        /// 机器编号
        /// </summary>
        public string MachineID
        {
            get;
            set;
        } = "Hostar";

        /// <summary>
        /// 线别
        /// </summary>
        public string LineID
        {
            get;
            set;
        } = "底部贴-01";

        private string area = string.Empty;

        /// <summary>
        /// 地区
        /// </summary>
        public string Area
        {
            get
            {
                string areaID = "SZ";
                string[] items = this.area.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if (items != null && items.Count() > 0)
                {
                    areaID = items[0];
                }

                return areaID;
            }

            set
            {
                this.area = value;
            }
        }

        /// <summary>
        /// 厂区
        /// </summary>
        public string FactoryID
        {
            get;
            set;
        } = "QHD";

        /// <summary>
        /// 启用脚印系统
        /// </summary>
        public bool EnableJY
        {
            get;
            set;
        } = false;

        /// <summary>
        /// 启用背胶追溯
        /// </summary>
        public bool EnableBJZS
        {
            get;
            set;
        } = false;

        /// <summary>
        /// 启用报警上传
        /// </summary>
        public bool EnableAlarmUpload
        {
            get;
            set;
        } = false;

        /// <summary>
        /// 工令
        /// </summary>
        public string EmployeeName
        {

            get;
            set;
        } = "";

        /// <summary>
        /// 工号
        /// </summary>
        public string EmployeeID
        {
            get;
            set;
        } = "";

        /// <summary>
        /// 超时
        /// </summary>
        public int TimeOut
        {
            get;
            set;
        } = 500;

        /// <summary>
        /// 料号
        /// </summary>
        public string FpcNo
        {
            get;
            set;
        }

        public string[] GetMesData()
        {
            string[] data = new string[15];
            data[0] = this.Area;
            data[1] = this.FactoryID;
            data[2] = this.LineID;
            data[3] = this.MachineID;
            data[4] = string.IsNullOrEmpty(this.EmployeeID) ? "NULL" : this.EmployeeID;
            data[5] = string.IsNullOrEmpty(this.EmployeeName) ? "NULL" : this.EmployeeName;
            data[6] = "NULL";
            data[7] = "NULL";
            data[8] = "NULL";
            data[9] = "NULL";
            data[10] = "NULL";
            data[11] = "NULL";
            data[12] = "NULL";
            data[13] = "NULL";
            data[14] = "NULL";
            return data;
        }

        #endregion

        /// <summary>
        /// 背胶追溯系统配置文件
        /// </summary>
        public BJZS_Config BJZS_Config = new BJZS_Config();

        /// <summary>
        /// 脚应系统配置文件
        /// </summary>
        public JY_Config JY_Config = new JY_Config();

        /// <summary>
        /// 报警上传系统配置文件
        /// </summary>
        public AlarmUpload_Config AlarmUpload_Config = new AlarmUpload_Config();

        [JsonIgnore]
        private Dictionary<string, string[]> parameters = new Dictionary<string, string[]>();

        [JsonIgnore]
        private ZDT.Service1SoapClient mesClient = null;
        [JsonIgnore]
        public Socket RemoteClient;
        [JsonIgnore]
        public System.Net.IPEndPoint localpoint;
        [JsonIgnore]
        public System.Net.IPEndPoint remotepoint;
        [JsonIgnore]
        public System.Net.EndPoint RemoteEndPoint;

        public void ReloadClient()
        {
            if (string.IsNullOrEmpty(this.WebServiceAddress))
            {
                mesClient = new GeneralLabelerStation.ZDT.Service1SoapClient();
            }
            else
            {
                mesClient = new GeneralLabelerStation.ZDT.Service1SoapClient("Service1Soap", this.WebServiceAddress);
            }
            this.StartThread();
        }

        public static void Load()
        {
            Common.SerializableHelper<ZDTHelper> helper = new Common.SerializableHelper<ZDTHelper>();
            ZDTHelper.Instance = helper.DeJsonSerialize(Variable.sPath_Configure + "ZDT.json");

            if (ZDTHelper.Instance == null)
                ZDTHelper.Instance = new ZDTHelper();

            if (ZDTHelper.Instance.JY_Config.ReadCodeBean != string.Empty)
            {
                ZDTHelper.Instance.SPICodeBean = ReadCodeBean.Load(ZDTHelper.Instance.JY_Config.ReadCodeBean);
            }

            if (ZDTHelper.Instance.BJZS_Config.ReadCodeBean != string.Empty)
            {
                ZDTHelper.Instance.TrayCodeBean = ReadCodeBean.Load(ZDTHelper.Instance.BJZS_Config.ReadCodeBean);
            }
        }

        public static void Save()
        {
            Common.SerializableHelper<ZDTHelper> helper = new Common.SerializableHelper<ZDTHelper>(ZDTHelper.Instance);
            helper.JsonSerialize(Variable.sPath_Configure + "ZDT.json");


            if (ZDTHelper.Instance.JY_Config.ReadCodeBean != string.Empty)
            {
                ZDTHelper.Instance.SPICodeBean = ReadCodeBean.Load(ZDTHelper.Instance.JY_Config.ReadCodeBean);
            }

            if (ZDTHelper.Instance.BJZS_Config.ReadCodeBean != string.Empty)
            {
                ZDTHelper.Instance.TrayCodeBean = ReadCodeBean.Load(ZDTHelper.Instance.BJZS_Config.ReadCodeBean);
            }
        }

        #region 脚印系统
        /// <summary>
        /// 获得SPI Badmark
        /// </summary>
        /// <param name="linkCode"></param>
        /// <param name="panelSide"></param>
        /// <returns></returns>
        public string GetReturnSPIBarmark(string linkCode, string panelSide)
        {
            return mesClient.ReturnSPIBarmark(linkCode, panelSide);
        }

        /// <summary>
        /// 读SPI方案
        /// </summary>
        [JsonIgnore]
        public ReadCodeBean SPICodeBean
        {
            get;
            set;
        } = new ReadCodeBean();
        #endregion

        #region 背胶追溯系统
        public DataTable GetFeederInfo()
        {
            DataTable dt = null;
            Task thread = Task.Factory.StartNew(() =>
            {
                try
                {
                    DataSet ds = mesClient.getDataFromSer("HOSTAR", "ALM-900D", this.MachineID, this.parameters[this.Area][0], this.parameters[this.Area][1], this.LineID, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));

                    Form_Main.Instance.PutInLog(Variable.sPath_ZDTMESLog, "背胶管控", $"HOSTAR, ALM-900D, {this.MachineID}, {this.parameters[this.Area][0]}, {this.parameters[this.Area][1]}, {this.LineID}, {DateTime.Now.ToString("yyyy / MM / dd HH: mm:ss")}");
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        dt = ds.Tables[0];
                    }
                }
                catch (Exception a)
                {
                }
            });

            if (!thread.Wait(ZDTHelper.Instance.TimeOut))
            {
                dt = null;
            }

            return dt;
        }

        public string UploadData(string feederData)
        {
            string result = string.Empty;
            Form_Main.Instance.PutInLog(Variable.sPath_ZDTMESLog, "背胶管控", feederData);
            try
            {
                DataSet ds1 = mesClient.getDataFromSer("HOSTAR", "ALM-900D", this.MachineID, this.parameters[this.Area][2], this.parameters[this.Area][3], feederData, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                if (ds1 == null || ds1.Tables == null || ds1.Tables.Count <= 0 || ds1.Tables[0].Rows == null || ds1.Tables[0].Rows.Count <= 0)
                {
                    result = "【追溯系统返回数据为空】";
                }
                else
                {
                    result = ds1.Tables[0].Rows[0][0].ToString();
                    if (result == "1")
                    {
                        result = string.Empty;
                    }
                }
            }
            catch
            {
                result = "【追溯系统方法调用异常】";
            }

            Form_Main.Instance.PutInLog(Variable.sPath_ZDTMESLog, "背胶管控", result);
            return result;
        }

        /// <summary>
        /// 读 载具 方案
        /// </summary>
        public ReadCodeBean TrayCodeBean
        {
            get;
            set;
        } = new ReadCodeBean();
        #endregion

        #region 上传系统
        /// <summary>
        /// 报警数据上传
        /// </summary>
        /// <param name="message"></param>
        /// <param name="value"></param>
        public void UpdateAlarmMessage(string message)
        {
            this.AddDataBean("AlarmMsg", message);
        }

        /// <summary>
        /// 生产数据上传
        /// </summary>
        /// <param name="totalPanel"></param>
        /// <param name="totalPcs"></param>
        public void UpdateProdctMessage()
        {
            string parameter = "TotalPanel|TotalPcs|LineID|PanelID";
            string parameterValue = StatisticsHelper.Instance.Reoprt.Total.TotalPCB + "|" + StatisticsHelper.Instance.Reoprt.Total.TotalPCS + "|" + this.LineID + "|" + Form_Main.Instance.RUN_BadmarkCode;
            this.AddDataBean(parameter, parameterValue);
        }

        /// <summary>
        /// 抛料数据上传
        /// </summary>
        /// <param name="totalPcs"></param>
        /// <param name="nozzle1ThrowNg"></param>
        /// <param name="nozzle2ThrowNg"></param>
        public void UpdateProdctRejectMessage()
        {
            string parameter = "TotalPcs|RejectNozzle1|RejectNozzle2|RejectNozzle3|RejectNozzle4|RejectRate1|RejectRate2|RejectRate3|RejectRate4";
            int count = (StatisticsHelper.Instance.Reoprt.Total.TotalPCS + StatisticsHelper.Instance.Reoprt.Total.TotalDrop);

            double[] rate = new double[4];
            string value = count.ToString();
            string value2 = string.Empty;

            for (uint i = 0; i < 4; ++i)
            {
                if (StatisticsHelper.Instance.Reoprt.Total.TotalPick != 0)
                    rate[i] = StatisticsHelper.Instance.Reoprt.Total.ZDrop[i] / (double)(count);
                else
                    rate[i] = 0.0;

                value += $"|{StatisticsHelper.Instance.Reoprt.Total.ZDrop[i]}";
                value2 += $"|{rate[i]:N2}";
            }
            this.AddDataBean(parameter, value + value2);
        }

        /// <summary>
        /// 吸标失败上传
        /// </summary>
        /// <param name="totalPcs"></param>
        /// <param name="nozzle1PickNg"></param>
        /// <param name="nozzle2PickNg"></param>
        public void UpdateProdctPickMessage()
        {
            string parameter = "TotalPcs|PickNGNozzle1|PickNGNozzle2|PickNGNozzle3|PickNGNozzle4|PickNGRate1|PickNGRate2|PickNGRate3|PickNGRate4";
            double[] rate = new double[4];
            string value = StatisticsHelper.Instance.Reoprt.Total.TotalPick.ToString();
            string value2 = string.Empty;
            for(uint i = 0; i < 4; ++i)
            {
                if (StatisticsHelper.Instance.Reoprt.Total.TotalPick != 0)
                    rate[i] = StatisticsHelper.Instance.Reoprt.Total.ZPickFial[i] / (double)(StatisticsHelper.Instance.Reoprt.Total.TotalPick);
                else
                    rate[i] = 0.0;

                value += $"|{StatisticsHelper.Instance.Reoprt.Total.ZPickFial[i]}";
                value2 += $"|{rate[i]:N2}";
            }
            this.AddDataBean(parameter, value+value2);
        }

        private ConcurrentQueue<UploadMessageBean> uploadMessageQueue = new ConcurrentQueue<UploadMessageBean>();

        public void AddDataBean(string parameter, string parameterValue)
        {
            this.uploadMessageQueue.Enqueue(new UploadMessageBean(parameter, parameterValue, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
        }

        [JsonIgnore]
        public bool TerminalThread = true;

        public void StartThread()
        {
            if (TerminalThread)
            {
                TerminalThread = false;
                new Thread(this.ThreadMethod).Start();
            }
        }

        private void ThreadMethod()
        {
            while (!this.TerminalThread)
            {
                Thread.Sleep(100);
                if (uploadMessageQueue.Count > 0)
                {
                    UploadMessageBean bean = null;
                    if(this.uploadMessageQueue.TryDequeue(out bean))
                    {
                        if(this.EnableAlarmUpload)
                        {
                            try
                            {
                                //"sfcabar", "sfcabar*168"
                                string result = mesClient.sendDataToSer(ZDTHelper.Instance.User, ZDTHelper.Instance.PassWd, this.MachineID, bean.Parameter, bean.ParameterValue, bean.DateTimeString);
                                Form_Main.Instance.PutInLog(Variable.sPath_ZDTMESLog, "上传信息", "[" + bean.DateTimeString + "]:[" + result + "]--[" + bean.Parameter + "][" + bean.ParameterValue + "]");
                            }
                            catch
                            {
                            }
                        }
                    }
                }
            }
        }
        #endregion
    }

    public class UploadMessageBean
    {
        public UploadMessageBean()
        {
            this.Parameter = string.Empty;
            this.ParameterValue = string.Empty;
            this.DateTimeString = string.Empty;
        }

        public UploadMessageBean(string parameter, string parameterValue, string dateTime)
        {
            this.Parameter = parameter;
            this.ParameterValue = parameterValue;
            this.DateTimeString = dateTime;
        }
        public string Parameter
        {
            get;
            set;
        }

        public string ParameterValue
        {
            get;
            set;
        }

        public string DateTimeString
        {
            get;
            set;
        }
    }
}
