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
            timer.Interval = 200;
            timer.Tick += pressChangeEvent;
        }

        private void bConnect_Click(object sender, EventArgs e)
        {
            if (PressSensorHelper.Instance.Socket != null && PressSensorHelper.Instance.Socket.Connected)
            {
                PressSensorHelper.Instance.DisConnected();
            }
            else
            {
                PressSensorHelper.Instance.ReConnected();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
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

            List<Label> label2 = new List<Label>();
            label2.Add(this.lZP1);
            label2.Add(this.lZP2);
            label2.Add(this.lZP3);
            label2.Add(this.lZP4);

            for (int i = 0; i < label.Count; ++i)
            {
                label[i].Text = $"Z{i + 1}:{PressSensorHelper.Instance.CurPress[i]:N2}";
                label2[i].Text = $"Z{i + 1}:{PressSensorHelper.Instance.PastePress[i]:N2}";
                if (PressSensorHelper.Instance.CurPress[i] > PressSensorHelper.Instance.AlarmLimit)
                {
                    label[i].BackColor = Color.Red;
                }
                else
                {
                    label[i].BackColor = Color.LightGreen;
                }

                if (PressSensorHelper.Instance.PastePress[i] > PressSensorHelper.Instance.AlarmLimit)
                {
                    label2[i].BackColor = Color.Red;
                }
                else
                {
                    label2[i].BackColor = Color.LightGreen;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer.Stop();
            Thread.Sleep(500);
            PressSensorHelper.Instance.SendZeroAll();
            Thread.Sleep(500);
            timer.Start();
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
    }
}
