using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NationalInstruments.Vision;
using GeneralLabelerStation.Tools;
using NationalInstruments.Vision.Analysis;
using System.IO;
using System.Xml.Serialization;
using GeneralLabelerStation.ZDT;

namespace GeneralLabelerStation.Tool
{
    public partial class fmBJZS_Tool : Form
    {
        public fmBJZS_Tool()
        {
            InitializeComponent();
        }

        public void ShowMesBean(BJZS_Config bean)
        {
            this.rbConnectAlarm.Checked = bean.ConnectAlarm;
            this.rbCodeFailAlarm.Checked = bean.DataAlarm;
            this.tbFeeder1No.Text = bean.FeederNo[0];
            this.tbFeeder2No.Text = bean.FeederNo[1];
            this.tbFeeder1Order.Text = bean.FeederOrder[0];
            this.tbFeeder2Order.Text = bean.FeederOrder[1];
            this.tbLeftFeeder.Text = bean.FeederID[0];
            this.tbRightFeeder.Text = bean.FeederID[1];
            this.ndTimeOut.Value = ZDTHelper.Instance.TimeOut;
            this.tBJZSAddress.Text = ZDTHelper.Instance.WebServiceAddress;
            this.tLineNo.Text = ZDTHelper.Instance.LineID;
            this.tMachineNO.Text = ZDTHelper.Instance.MachineID;
            this.combLocation.Text = ZDTHelper.Instance.Area;
            this.tFactoryArea.Text = ZDTHelper.Instance.FactoryID;
            this.tEmployeID.Text = ZDTHelper.Instance.EmployeeID;
            this.tEmployerNo.Text = ZDTHelper.Instance.EmployeeName;
            this.tFpcNo.Text = ZDTHelper.Instance.FpcNo;
            this.tReadCodeName.Text = bean.ReadCodeBean;
            this.nuRemainCount.Value = bean.AlarmCount;
            this.nuRemainTime.Value = bean.AlarmHour;
            this.chbEnableLimit.Checked = bean.EnableAlarmCount;
            this.chbEnableMaterialTime.Checked = bean.EnableAlarmHour;
            this.bEnableJY.Checked = ZDTHelper.Instance.EnableJY;
            this.bEnableBJZS.Checked = ZDTHelper.Instance.EnableBJZS;
            this.bEnableAlarmUpload.Checked = ZDTHelper.Instance.EnableAlarmUpload;
            this.tUser.Text = ZDTHelper.Instance.User;
            this.tPass.Text = ZDTHelper.Instance.PassWd;
            this.tReadCodeName.Items.AddRange(ReadCodeBean.GetList().ToArray());
        }

        private void fmBJZS_Tool_Load(object sender, EventArgs e)
        {
            this.ShowMesBean(ZDTHelper.Instance.BJZS_Config);
        }

        private void bBJZSUpdate_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("是否确定修改 对接信息!!!y/n", "警告",MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }

            BJZS_Config bean = new BJZS_Config();
            bean.ConnectAlarm = this.rbConnectAlarm.Checked;
            bean.DataAlarm = this.rbCodeFailAlarm.Checked;
            bean.FeederNo[0] = this.tbFeeder1No.Text;
            bean.FeederNo[1] = this.tbFeeder2No.Text;
            bean.FeederOrder[0] = this.tbFeeder1Order.Text;
            bean.FeederOrder[1] = this.tbFeeder2Order.Text;
            bean.FeederID[0] = this.tbLeftFeeder.Text;
            bean.FeederID[1] = this.tbRightFeeder.Text;
            ZDTHelper.Instance.TimeOut = (int)this.ndTimeOut.Value;
            ZDTHelper.Instance.WebServiceAddress = this.tBJZSAddress.Text;
            ZDTHelper.Instance.LineID = this.tLineNo.Text;
            ZDTHelper.Instance.MachineID = this.tMachineNO.Text;
            ZDTHelper.Instance.Area = this.combLocation.Text;
            ZDTHelper.Instance.FactoryID = this.tFactoryArea.Text;
            ZDTHelper.Instance.EmployeeID = this.tEmployeID.Text;
            ZDTHelper.Instance.EmployeeName = this.tEmployerNo.Text;
            ZDTHelper.Instance.FpcNo = this.tFpcNo.Text;
            
            bean.ReadCodeBean = this.tReadCodeName.Text;
            bean.AlarmCount = (int)this.nuRemainCount.Value;
            bean.AlarmHour = (int)this.nuRemainTime.Value;
            bean.EnableAlarmCount = this.chbEnableLimit.Checked;
            bean.EnableAlarmHour = this.chbEnableMaterialTime.Checked;
            ZDTHelper.Instance.EnableJY = this.bEnableJY.Checked;
            ZDTHelper.Instance.EnableBJZS = this.bEnableBJZS.Checked;
            ZDTHelper.Instance.EnableAlarmUpload = this.bEnableAlarmUpload.Checked;

            ZDTHelper.Instance.BJZS_Config = bean;
            ZDTHelper.Instance.User = this.tUser.Text;
            ZDTHelper.Instance.PassWd = this.tPass.Text;
            ZDTHelper.Save();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ZDTHelper.Instance.StartThread();
            ZDTHelper.Instance.UpdateAlarmMessage("机器报警测试");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ZDTHelper.Instance.UpdateProdctRejectMessage();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ZDTHelper.Instance.UpdateProdctPickMessage();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ZDTHelper.Instance.UpdateProdctMessage();
        }

        private void bEnableUrl_CheckedChanged(object sender, EventArgs e)
        {
            this.tBJZSAddress.Enabled = this.bEnableUrl.Checked;
        }

        private void chkUserPass_CheckedChanged(object sender, EventArgs e)
        {
            this.groupBox.Visible = this.chkUserPass.Checked;
        }
    }
}
