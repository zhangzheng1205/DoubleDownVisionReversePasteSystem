using GeneralLabelerStation.Param;
using GeneralLabelerStation.Tool;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeneralLabelerStation.UI
{
    public partial class fmAdjustCamZ : Form
    {
        public fmAdjustCamZ()
        {
            InitializeComponent();
            AutoTimer.Tick += AutoTimer_Tick;
            AutoTimer.Interval = 1000;
        }

        private void AutoTimer_Tick(object sender, EventArgs e)
        {
            Count++;
            this.bAutoCal.Text = (120 - Count).ToString();
        }

        private void bCal_Click(object sender, EventArgs e)
        {
            Form_Main.Instance.imageSet.Image.WriteBmpFile("D://1.bmp");
            Thread.Sleep(50);
            double value = 0;
            VisionHelper.GetImageDefinitionValue("D://1.bmp", out value);
            this.tAppend.AppendText($"清晰度：{value} \n"); 
        }

        private System.Windows.Forms.Timer AutoTimer = new System.Windows.Forms.Timer();

        private int Count = 0;
        private void bAutoCal_Click(object sender, EventArgs e)
        {
            this.bAutoCal.Enabled = false;
            Count = 0;
            double last = 0;
            double value = 0;
            Variable.VelMode vel = new Variable.VelMode(0, 100, 300, 300);
            AutoTimer.Start();
            int JumpCount = 0;
            double MoveTirm = 1;
            double MaxValue = 0;
            double MaxZ = 0;
            bool first = true;
            if (this.cb_SelectNz.SelectedIndex >= 0)
            {
                Form_Main.Instance.imageSet.Image.WriteBmpFile("D://1.bmp");
                int Dir = 1; // 正向寻找

                Thread.Sleep(100);
                Application.DoEvents();
                VisionHelper.GetImageDefinitionValue("D://1.bmp", out last);
                Form_Main.Instance.Z_RunParamMap[(uint)this.cb_SelectNz.SelectedIndex].MoveTrim(Dir* MoveTirm, vel);
                MaxValue = last;
                MaxZ = Form_Main.Instance.Z_RunParamMap[(uint)this.cb_SelectNz.SelectedIndex].Pos;
                while (Count < 120)
                {
                    Thread.Sleep(100);
                    Application.DoEvents();
                    Form_Main.Instance.imageSet.Image.WriteBmpFile("D://1.bmp");

                    Thread.Sleep(100);
                    Application.DoEvents();
                    VisionHelper.GetImageDefinitionValue("D://1.bmp", out value);

                    if(value > MaxValue)
                    {
                        MaxValue = value;
                        MaxZ = Form_Main.Instance.Z_RunParamMap[(uint)this.cb_SelectNz.SelectedIndex].Pos;
                    }

                    if (value > last)
                    {
                        Form_Main.Instance.Z_RunParamMap[(uint)this.cb_SelectNz.SelectedIndex].MoveTrim(Dir * MoveTirm, vel);
                        Thread.Sleep(100);
                    }
                    else
                    {
                        Dir = -1*Dir;

                        if(!first)
                        {
                            JumpCount++;
                            if (JumpCount > 3)
                            {
                                JumpCount = 0;
                                MoveTirm = MoveTirm / 2;
                                if (MoveTirm < 0.1)
                                {
                                    // Find OK
                                    break;
                                }
                            }
                        }
                        first = false;
                    }

                    last = value;
                    this.tAppend.AppendText($"清晰度：{value} \n");
                }

                Thread.Sleep(100);
                Form_Main.Instance.Z_RunParamMap[(uint)this.cb_SelectNz.SelectedIndex].StopAxis();
                Form_Main.Instance.Z_RunParamMap[(uint)this.cb_SelectNz.SelectedIndex].CleSts();
                Form_Main.Instance.Z_RunParamMap[(uint)this.cb_SelectNz.SelectedIndex].GoPos(MaxZ, vel);
            }

            AutoTimer.Stop();

            this.bAutoCal.Enabled = true;
        }

        private void bAutoSet_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("是否以当前位置为贴附点进行，贴附高度确认！！", "Tips", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                PointF cur = new PointF();
                cur.X = (float)Form_Main.Instance.X.Pos;
                cur.Y = (float)Form_Main.Instance.Y.Pos;
                Variable.VelMode vel = new Variable.VelMode(0, 100, 300, 300);
                for(uint nz = 0; nz < Variable.NOZZLE_NUM; ++nz)
                {
                    Form_Main.Instance.XYGoPosTillStop(30000, Form_Main.Instance.NozzleToCamPoint(cur, (int)nz), vel);
                    Z_RunParam zparam = Form_Main.Instance.Z_RunParamMap[nz];
                    zparam.XI_vaccum.SetIO();
                    this.CalPasueHeight(zparam, ref cur, ref vel);
                    Thread.Sleep(500);
                    var ctl = (TextBox)(this.Controls.Find($"tZ{nz + 1}", true)[0]);
                    ctl.Text = zparam.Pos.ToString("f3");
                    zparam.GoSafePos(vel);
                    Thread.Sleep(2000);
                    zparam.XI_vaccum.ResetIO();
                }
            }
        }


        private void CalPasueHeight(Z_RunParam zParam, ref PointF cur, ref Variable.VelMode vel)
        {
            zParam.MoveTrim(zParam.MoveDir * 0.5, vel);
            Thread.Sleep(500);

            if (!zParam.Check_vaccum.GetIO())
            {
                this.CalPasueHeight(zParam, ref cur, ref vel);
            }
            else
            {
                return;
            }
        }
        private void bUpdate2Set_Click(object sender, EventArgs e)
        {
            for(uint nz = 0; nz < Variable.NOZZLE_NUM; ++nz)
            {
                try
                {
                    var ctl = (TextBox)(this.Controls.Find($"tZ{nz + 1}", true)[0]);
                    Z_RunParam zparam = Form_Main.Instance.Z_RunParamMap[nz];
                    zparam.PasteHeight = double.Parse(ctl.Text);
                    Form_Main.Instance.Ini_Sys.IniWriteNumber("Position", $"PasteHeightZ{nz + 1}", zparam.PasteHeight);
                }
                catch { return; }
            }
        }
    }
}
