using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GeneralLabelerStation.Tools;
using NationalInstruments.Vision.Analysis;
using NationalInstruments.Vision;
using System.Net.Sockets;
using System.IO;

namespace GeneralLabelerStation.Tool
{
    public partial class fmZDT_Tool : Form
    {
        public fmZDT_Tool()
        {
            InitializeComponent();
            try
            {
            }
            catch { }
        }

        private void bTestLink_Click(object sender, EventArgs e)
        { 
            try
            {
                string result = ZDTHelper.Instance.GetReturnSPIBarmark(this.tLinkCode.Text, this.cbSide.SelectedIndex == 0 ? "A" : "B");
                if (result == "NULL")
                {
                    MessageBox.Show("连接失败，请检查网络并确保 板子已过SPI："+result);
                }
                else
                {
                    this.tBadMarkNO.Text = result.Length.ToString();
                    MessageBox.Show("连接成功：" + result);
                }
            }
            catch (Exception ex) { MessageBox.Show("连接失败："+ex.Message); }
        }

        private void bUpdate_Click(object sender, EventArgs e)
        {
            var config = ZDTHelper.Instance.JY_Config;
            config.ReadCodeBean = this.cb_ReadCodeName.Text;
            config.MES_Side = (Form_Main.SIDE)this.cbSide.SelectedIndex;
            config.LocalIp = this.tIP_Local.Text;
            config.LocalPort = int.Parse(this.tPort_Local.Text);
            config.RemoteIp = this.tIP_Remote.Text;
            config.RemotePort = int.Parse(this.tPort_Remote.Text);
            config.bUseRemote = !this.rB_SPI.Checked;
            config.bAlarm = this.rB_Alarm.Checked;
            config.bPaste = this.rB_PasteAll.Checked;
            config.BadmarkLen = int.Parse(this.tBadMarkNO.Text);
            ZDTHelper.Save();
        }

        private void fmZDT_Tool_Load(object sender, EventArgs e)
        {
            var config = ZDTHelper.Instance.JY_Config;
            this.cb_ReadCodeName.Text = config.ReadCodeBean;
            this.cbSide.SelectedIndex = (int)config.MES_Side;
            this.tIP_Local.Text = config.LocalIp;
            this.tPort_Local.Text = config.LocalPort.ToString();
            this.tIP_Remote.Text = config.RemoteIp;
            this.tPort_Remote.Text = config.RemotePort.ToString();
            this.rB_SPI.Checked = !config.bUseRemote;
            this.rB_XPanel.Checked = config.bUseRemote;
            this.rB_Alarm.Checked = config.bAlarm;
            this.rB_DisAlarm.Checked = !config.bAlarm;
            this.rB_PasteNone.Checked = !config.bPaste;
            this.rB_PasteAll.Checked = config.bPaste;
            this.tBadMarkNO.Text = config.BadmarkLen.ToString();
            this.cb_ReadCodeName.Items.AddRange(ReadCodeBean.GetList().ToArray());
        }

        private void bTestLink2_Click(object sender, EventArgs e)
        {
            try
            {
                string command = "HELLO " + tLinkCode2.Text;
                byte[] data = Encoding.Default.GetBytes(command);
                ZDTHelper.Instance.RemoteClient.SendTo(data, data.Length, SocketFlags.None, ZDTHelper.Instance.RemoteEndPoint);
                data = new byte[1024];
                //ZDTHelper.Instance.RemoteClient.ReceiveFrom(data, ref Form_Main.Instance.RemoteEndPoint);
                ZDTHelper.Instance.RemoteClient.ReceiveTimeout = 1000;
                ZDTHelper.Instance.RemoteClient.Receive(data);
                string info = Encoding.Default.GetString(data);
                MessageBox.Show(info);
            }
            catch (Exception ex) { MessageBox.Show("连接失败：" + ex.Message); }
        }

        private void bTest_Click(object sender, EventArgs e)
        {
            try
            {
               var bean = ReadCodeBean.Load(this.cb_ReadCodeName.Text);

                VisionImage image = Form_Main.Instance.imageSet.Image;
                for (int i = 0; i < bean.Cycle; ++i)
                {
                    image = Form_Main.Instance.GainOffset(Form_Main.Instance.imageSet.Image, bean.Gain, bean.Offset);
                }

                Algorithms.Copy(image, Form_Main.Instance.imageSet.Image);

                this.tLinkCode.Text = ReadCodeHelper.ReadCode(Form_Main.Instance.imageSet.Image, bean.ROI.ConvertToRoi(), bean.CodeType);
            }
            catch
            {
                MessageBox.Show("读取失败");
            }
        }
    }
}
