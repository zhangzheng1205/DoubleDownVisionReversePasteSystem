using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using NationalInstruments.Vision;
using MathNet.Numerics;
using GeneralLabelerStation;
using GeneralLabelerStation.Common;
using HalconDotNet;
using System.IO;

namespace GeneralLabelerStation
{
    public partial class AxisOffsetItem : UserControl
    {
        public AxisOffsetItem()
        {
            InitializeComponent();
        }

        public bool IsX
        {
            get;
            set;
        }

        public double[] rx = null;
        public double[] x = null;

        public string Tilte
        {
            get
            {
                return this.gAxis.Text;
            }
            set
            {
                this.gAxis.Text = value;
            }
        }

        private void bStart_Click(object sender, EventArgs e)
        {
            if (Array == null)
            {
                MessageBox.Show("请先生成量测参数!!!");
                return;
            }

            if (Form_Main.Instance.imageSet.Roi.Count == 0 || Form_Main.Instance.imageSet.Roi[0].Shape.GetType() != typeof(RectangleContour))
            {
                MessageBox.Show("请正确绘制ROI!!!");
                return;
            }

            rx = new double[Array.Length];
            x = new double[Array.Length];

            double space = (double)this.numSpace.Value;

            double rate = 0;
            if (this.IsX)
            {
                double dist = HardwareOrgHelper.GetDist(Array.Last(), Array[0]);
                double dx = Array.Last().X - Array[0].X;
                rate = Math.Abs(dx / dist);
            }
            else
            {
                double dist = HardwareOrgHelper.GetDist(Array.Last(), Array[0]);
                double dy = Array.Last().Y - Array[0].Y;
                rate = Math.Abs(dy / dist);
            }
            short rMin = (short)this.numericUpDown1.Value;
            short rMax = (short)this.numericUpDown2.Value;

            Form_Main.Instance.XYGoPosTillStop(5000, Array[0], Form_Main.VariableSys.VelMode_Current_Manual);

            for (int i = 0; i < Array.Length; ++i)
            {
                Form_Main.Instance.XYGoPosTillStop(5000,Array[i], Form_Main.VariableSys.VelMode_Current_Manual);
                PointF xy = GoAndCheck(rMin, rMax);

                double val = this.IsX ? xy.X : xy.Y;

                // 再计算
                if (i == 0)
                {
                    x[0] = val;
                }
                else
                {
                    x[i] = x[0] + (val - x[0]) * rate;
                    rx[i] = x[i] - (x[0] + space * i * rate);
                    this.dAxis.Rows[i].Cells[1].Value = (rx[i]).ToString("f3");
                }
            }
        }

        private PointF GoAndCheck(short min, short max)
        {
            CommonHelper.DoEvent(500);
            return (VisionDetect?.Invoke(min, max)).Item1;
        }

        private Polynomial poly = null;
        private void bFit_Click(object sender, EventArgs e)
        {
            this.button2.Enabled = true;
            if (this.IsX)
            {
                HardwareOrgHelper.Instance.HardWare.X = (double[])x;
                HardwareOrgHelper.Instance.HardWare.RX = (double[])rx;
                HardwareOrgHelper.Instance.HardWare.XPoly = new Polynomial();
            }
            else
            {
                HardwareOrgHelper.Instance.HardWare.Y = (double[])x;
                HardwareOrgHelper.Instance.HardWare.RY = (double[])rx;
                HardwareOrgHelper.Instance.HardWare.YPoly = new Polynomial();
            }
            HardwareOrgHelper.Save();

            poly = Polynomial.Fit(x, rx, (int)this.numPow.Value);
            this.argList.Items.Clear();
            for(int i  =0; i< poly.Coefficients.Length;++i)
            {
                this.argList.Items.Add(poly.Coefficients[i].ToString());
            }
            this.bEnable.Enabled = true;
        }

        private void bEnable_Click(object sender, EventArgs e)
        {
            if (this.IsX)
            {
                HardwareOrgHelper.Instance.HardWare.X = x;
                HardwareOrgHelper.Instance.HardWare.RX = rx;
                HardwareOrgHelper.Instance.HardWare.XPoly = poly;
            }
            else
            {
                HardwareOrgHelper.Instance.HardWare.Y = x;
                HardwareOrgHelper.Instance.HardWare.RY = rx;
                HardwareOrgHelper.Instance.HardWare.YPoly = poly;
            }

            HardwareOrgHelper.Save();
            this.bEnable.Enabled = false;
        }

        private PointF start = new PointF();
        private PointF end = new PointF();
        private PointF[] Array = null;
        private void bSetStart_Click(object sender, EventArgs e)
        {
            this.start = Form_Main.Instance.XYPos;
        }

        private void bSetEnd_Click(object sender, EventArgs e)
        {
            this.end = Form_Main.Instance.XYPos;
        }

        private void bConfig_Click(object sender, EventArgs e)
        {
            Array = HardwareOrgHelper.Expand2AllPoints(this.start, this.start, this.end, this.start, (short)this.numPoint.Value, 1);
            this.dAxis.Rows.Clear();
            this.dAxis.Rows.Add(Array.Length);
            for (int i = 0; i < Array.Length; ++i)
            {
                this.dAxis.Rows[i].Cells[0].Value = $"{Array[i].X:n2},{Array[i].Y:n2}";
                this.dAxis.Rows[i].Cells[1].Value = 0;
            }
        }

        private void bGoSelect_Click(object sender, EventArgs e)
        {
            if (this.dAxis.SelectedRows.Count > 0 && Array != null)
            {
                Form_Main.Instance.XYGoPos(Array[this.dAxis.SelectedRows[0].Index], Form_Main.VariableSys.VelMode_Current_Manual);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                double v = double.Parse(this.textBox1.Text);
                double s = 0;
                if (this.IsX)
                    s = HardwareOrgHelper.Instance.HardWare.XPoly.Evaluate(v);
                else
                    s = HardwareOrgHelper.Instance.HardWare.YPoly.Evaluate(v);

                this.textBox2.Text = s.ToString("f3");
            }
            catch { }
        }

        private void AxisOffsetItem_Load(object sender, EventArgs e)
        {
            try
            {
                if (this.IsX)
                {
                    x = (double[])HardwareOrgHelper.Instance.HardWare.X;
                    rx = (double[])HardwareOrgHelper.Instance.HardWare.RX;
                    poly = HardwareOrgHelper.Instance.HardWare.XPoly;
                }
                else
                {
                    x = (double[])HardwareOrgHelper.Instance.HardWare.Y;
                    rx = (double[])HardwareOrgHelper.Instance.HardWare.RY;
                    poly = HardwareOrgHelper.Instance.HardWare.YPoly;
                }

                this.dAxis.Rows.Clear();
                if (x != null && rx != null && x.Length > 0)
                {
                    for (int i = 0; i < x.Length; ++i)
                    {
                        this.dAxis.Rows.Add();
                        this.dAxis.Rows[i].Cells[0].Value = x[i].ToString("f3");
                        this.dAxis.Rows[i].Cells[1].Value = rx[i].ToString("f3");
                    }
                }

                if (poly != null)
                {
                    this.argList.Items.Clear();
                    for (int i = 0; i < poly.Coefficients.Length; ++i)
                    {
                        this.argList.Items.Add(poly.Coefficients[i].ToString());
                    }
                }
            }
            catch { }
        }

        private void bDetect_Click(object sender, EventArgs e)
        {
            var temp = VisionDetect?.Invoke((short)this.numericUpDown1.Value, (short)this.numericUpDown2.Value);
            this.label8.Text = temp.Item2.ToString();
            Form_Main.Instance.XYGoPos(temp.Item1, Form_Main.VariableSys.VelMode_Current_Manual);
        }

        public static event Func<short, short,Tuple<PointF,double>> VisionDetect;

        private void button2_Click(object sender, EventArgs e)
        {
            if (x == null) return;
            File.Delete("D://机械.csv");
            for (int i = 0; i < x.Length; ++i)
            {
                File.AppendAllText("D://机械.csv", $"{x[i]:N3},{rx[i]:N3}\r\n");
            }

            MessageBox.Show("导出成功!!! D://机械.csv");
        }
    }
}
