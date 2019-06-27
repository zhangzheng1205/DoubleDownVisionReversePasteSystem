using GeneralLabelerStation.Tool;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeneralLabelerStation.UI
{
    public partial class frmPressEdit : Form
    {
        public frmPressEdit()
        {
            InitializeComponent();
            timer.Interval = 50;
            timer.Tick += pressChangeEvent;
        }

        private void bConnect_Click(object sender, EventArgs e)
        {
            if(PressSensorHelper.Instance.Socket == null || !PressSensorHelper.Instance.Socket.Connected)
            {
                PressSensorHelper.Instance.NeedConnected = true;
                PressSensorHelper.Instance.ReConnected();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //PressSensorHelper.Instance.Start();
            PressSensorHelper.Instance.SendGet();
        }

        private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        private void pressChangeEvent(object sender, EventArgs e)
        {
            List<Label> label = new List<Label>();
            label.Add(this.lZ1);
            label.Add(this.lZ2);
            label.Add(this.lZ3);
            label.Add(this.lZ4);

            for (int i = 0; i < label.Count; ++i)
            {
                label[i].Text = $"Z{i + 1}:{PressSensorHelper.Instance.CurPress[i]:N2}";
                if (PressSensorHelper.Instance.CurPress[i] > PressSensorHelper.Instance.AlarmLimit)
                {
                    label[i].BackColor = Color.Red;
                }
                else
                {
                    label[i].BackColor = Color.LightGreen;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PressSensorHelper.Instance.SendZeroAll();
        }

        private void frmPressEdit_Load(object sender, EventArgs e)
        {
            timer.Start();
            this.numZ2Channel.Value = PressSensorHelper.Instance.ZChannel[1] + 1;
            this.numZ3Channel.Value = PressSensorHelper.Instance.ZChannel[2] + 1;
            this.numZ1Channel.Value = PressSensorHelper.Instance.ZChannel[0] + 1;
            this.numZ4Channel.Value = PressSensorHelper.Instance.ZChannel[3] + 1;
            this.numAlarmCount.Value = PressSensorHelper.Instance.AlarmCount;
            this.numAlarmRow.Value = PressSensorHelper.Instance.RecrodRowCount;
            this.tAlarmG.Text = PressSensorHelper.Instance.AlarmLimit.ToString("f3");
        }

        private void frmPressEdit_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer.Stop();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            PressSensorHelper.Instance.ClearAllPastePress();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            PressSensorHelper.Instance.ZChannel[0] = (int)this.numZ1Channel.Value - 1;
            PressSensorHelper.Instance.ZChannel[1] = (int)this.numZ2Channel.Value - 1;
            PressSensorHelper.Instance.ZChannel[2] = (int)this.numZ3Channel.Value - 1;
            PressSensorHelper.Instance.ZChannel[3] = (int)this.numZ4Channel.Value - 1;
            PressSensorHelper.Instance.AlarmCount = (int)this.numAlarmCount.Value;
            PressSensorHelper.Instance.RecrodRowCount = (int)this.numAlarmRow.Value;
            PressSensorHelper.Instance.AlarmLimit= double.Parse(this.tAlarmG.Text);
            PressSensorHelper.Save();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PressSensorHelper.Instance.NeedConnected = false;
            PressSensorHelper.Instance.DisConnected();
        }

        private void bAutoCalib_Click(object sender, EventArgs e)
        {
            uint nz = (uint)this.cbSelectNz.SelectedIndex;
            Task.Factory.StartNew(()=> {
                this.CailbNozzle(nz);
            });
        }

        private void CailbNozzle(uint zIndex)
        {
            var zparam = Form_Main.Instance.Z_RunParamMap[zIndex];
            this.Invoke(new Action(() => {
                this.listPress.Items.Clear();
            }));

            int len = 32;
            double[] press = new double[len]; 
            for(int i = 0; i < len; ++i)
            {
                PressSensorHelper.Instance.SendZeroAll();
                Thread.Sleep(200);
                PressSensorHelper.Instance.IsCailb = true;
                zparam.GoPosTillStop(3000,zparam.PasteHeight, Form_Main.VariableSys.VelMode_Current);
                Thread.Sleep(50);
                zparam.GoPosTillStop(3000, zparam.SafeHeigh, Form_Main.VariableSys.VelMode_Current);
                Thread.Sleep(200);
                PressSensorHelper.Instance.IsCailb = false;
                press[i] = PressSensorHelper.Instance.PastePress[zIndex];

                this.Invoke(new Action(() => {
                    this.listPress.Items.Add($"{press[i]:N2} g");
                }));
            }

            double sum = 0;
            for (int i = 0; i < len; ++i)
            {
                sum += press[i];
            }
            sum = sum / len;

            this.Invoke(new Action(() => {
                PressSensorHelper.Instance.NozzlePress[zIndex] = sum;
                this.tPastePress.Text = sum.ToString("f2");
            }));
        }

        private void cbSelectNz_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.tPastePress.Text = PressSensorHelper.Instance.NozzlePress[this.cbSelectNz.SelectedIndex].ToString("f2");
        }
    }
}
