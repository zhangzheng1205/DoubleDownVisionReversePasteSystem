using GeneralLabelerStation.Tool;
using NationalInstruments.Vision;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GeneralLabelerStation.UI
{
    public partial class fmNozzleUpCamSet : Form
    {
        public fmNozzleUpCamSet()
        {
            InitializeComponent();
        }

        private void btnSetHandle_Z1_Click(object sender, EventArgs e)
        {
            PointF cur = Form_Main.Instance.XYPos;
            this.tHanlde_Z1_X.Text = cur.X.ToString();
            this.tHanlde_Z1_Y.Text = cur.Y.ToString();
            IniFile ini = new IniFile(Variable.sPath_Configure + "NozzleOffset.ini");
            ini.IniWriteValue("app", $"Nozzle{this.comboBox1.SelectedIndex + 1}OffsetX", this.tHanlde_Z1_X.Text);
            ini.IniWriteValue("app", $"Nozzle{this.comboBox1.SelectedIndex + 1}OffsetY", this.tHanlde_Z1_Y.Text);
        }

        private void bMove_Click(object sender, EventArgs e)
        {
            try
            {
                PointF pt = new PointF();
                pt.X = float.Parse(this.tHanlde_Z1_X.Text);
                pt.Y = float.Parse(this.tHanlde_Z1_Y.Text);
                Form_Main.Instance.XYGoPos(pt, Form_Main.VariableSys.VelMode_Current_Manual);
            }
            catch { }
        }

        private void chkUse_Z1_CheckedChanged(object sender, EventArgs e)
        {
            IniFile ini = new IniFile(Variable.sPath_Configure + "NozzleOffset.ini");
            ini.IniWriteValue("app", "EnableUseOffset", this.chkUse_Z.Checked.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("是否更新吸嘴配置信息!!!", "警告", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Form_Main.Instance.ReadNozzleOffsetCofing();
                Form_Main.Instance.ReadNozzlePasteOffsetConfig();

                NozzleOffsetItem.SaveToList(this.dataGridView1, (uint)this.comboBox1.SelectedIndex);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            IniFile ini = new IniFile(Variable.sPath_Configure + "NozzleOffset.ini");
            try
            {
                this.tHanlde_Z1_X.Text = ini.IniReadValue("app", $"Nozzle{this.comboBox1.SelectedIndex + 1}OffsetX");
                this.tHanlde_Z1_Y.Text = ini.IniReadValue("app", $"Nozzle{this.comboBox1.SelectedIndex + 1}OffsetY");

                if (NozzleOffsetItem.Items == null)
                    NozzleOffsetItem.Items = new Dictionary<uint, NozzleOffsetShceme>();
                if (!NozzleOffsetItem.Items.ContainsKey((uint)this.comboBox1.SelectedIndex))
                    NozzleOffsetItem.Items.Add((uint)this.comboBox1.SelectedIndex, new NozzleOffsetShceme());
                NozzleOffsetItem.ShowDataGrid(this.dataGridView1, (uint)this.comboBox1.SelectedIndex);
            }
            catch { }
        }

        private void bTest_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.comboBox1.SelectedIndex >= 3) return;

                PointF pt = new PointF();
                pt.X = float.Parse(this.tHanlde_Z1_X.Text);
                pt.Y = float.Parse(this.tHanlde_Z1_Y.Text);

                pt.X += Form_Main.Instance.NozzleCenterOffset[this.comboBox1.SelectedIndex + 1].X;
                pt.Y += Form_Main.Instance.NozzleCenterOffset[this.comboBox1.SelectedIndex + 1].Y;

                Form_Main.Instance.XYGoPos(pt, Form_Main.VariableSys.VelMode_Current_Manual);
            }
            catch { }
        }

        private void fmNozzleUpCamSet_Load(object sender, EventArgs e)
        {
            try
            {
                this.comboBox1.SelectedIndex = 0;
                IniFile ini = new IniFile(Variable.sPath_Configure +  "NozzleOffset.ini");
                this.chkUse_Z.Checked = ini.IniReadValue("app", "EnableUseOffset") == "False" ? false : true;
                this.EnableP2POffset.Checked = ini.IniReadValue("app", "EnableP2POffset") == "False" ? false : true;
                //this.tHanlde_Z1_X.Text = ini.IniReadValue("app", "Nozzle1OffsetX");
                //this.tHanlde_Z1_Y.Text = ini.IniReadValue("app", "Nozzle1OffsetY");
            }
            catch { }
        }

        private void bSetRealPasteXY_Click(object sender, EventArgs e)
        {
            IniFile ini = new IniFile(Variable.sPath_Configure + "NozzleOffset.ini");
        }

        private void EnableP2POffset_CheckedChanged(object sender, EventArgs e)
        {
            IniFile ini = new IniFile(Variable.sPath_Configure + "NozzleOffset.ini");
            ini.IniWriteValue("app", "EnableP2POffset", this.EnableP2POffset.Checked.ToString());
        }

        private void bAddRow_Click(object sender, EventArgs e)
        {
            int index = this.dataGridView1.Rows.Add();
            this.dataGridView1.Rows[index].Cells[0].Value = 0;
            this.dataGridView1.Rows[index].Cells[1].Value = 20;
            this.dataGridView1.Rows[index].Cells[2].Value = 0;
            this.dataGridView1.Rows[index].Cells[3].Value = 0;
        }

        private void bDelRow_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count > 0)
            {
                for(int i = 0; i < this.dataGridView1.SelectedRows.Count;++i)
                {
                    this.dataGridView1.Rows.RemoveAt(this.dataGridView1.SelectedRows[i].Index);
                }
            }
        }

        private PointF PastePt = new PointF();
        private PointF RealPt = new PointF();

        private void bRecordPaste_Click(object sender, EventArgs e)
        {
            PastePt.X = (float)Form_Main.Instance.X.Pos;
            PastePt.Y = (float)Form_Main.Instance.Y.Pos;
        }

        private void bRecordReal_Click(object sender, EventArgs e)
        {
            RealPt.X = (float)Form_Main.Instance.X.Pos;
            RealPt.Y = (float)Form_Main.Instance.Y.Pos;
        }

        private void bCal_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count > 0)
            {
                for (int i = 0; i < this.dataGridView1.SelectedRows.Count; ++i)
                {
                    double lastX = double.Parse(this.dataGridView1.Rows[this.dataGridView1.SelectedRows[i].Index].Cells[2].Value.ToString());
                    double lastY = double.Parse(this.dataGridView1.Rows[this.dataGridView1.SelectedRows[i].Index].Cells[3].Value.ToString());

                    this.dataGridView1.Rows[this.dataGridView1.SelectedRows[i].Index].Cells[2].Value = (PastePt.X - RealPt.X+lastX).ToString("f3");
                    this.dataGridView1.Rows[this.dataGridView1.SelectedRows[i].Index].Cells[3].Value = (PastePt.Y - RealPt.Y+lastY).ToString("f3");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                PointF pt2 = new PointF();
                pt2.X = float.Parse(this.tHanlde_Z1_X.Text);
                pt2.Y = float.Parse(this.tHanlde_Z1_Y.Text);

                PointF pt = new PointF();
                int zIndex = this.comboBox1.SelectedIndex;
                pt.X = pt2.X + Form_Main.Instance.NozzleCenterOffset[1].X;
                pt.Y = pt2.Y + Form_Main.Instance.NozzleCenterOffset[1].Y;

                Form_Main.Instance.XYGoPos(pt, Form_Main.VariableSys.VelMode_Debug_Manual);
            }
            catch { }
        }

        private PointF nz1 = new PointF();
        private PointF nz2 = new PointF();
        private PointF nz3 = new PointF();
        private PointF nz4 = new PointF();
        private bool isCaled1 = true;
        private bool isCaled2 = true;
        private bool isCaled3 = true;
        private bool isCaled4 = true;

        private void bNz1_Click(object sender, EventArgs e)
        {
            if(Form_Main.Instance.imageSet.Roi.Count > 0 && Form_Main.Instance.imageSet.Roi[0].Shape.GetType() == typeof(RectangleContour))
            {
                RectangleContour rect = (RectangleContour)Form_Main.Instance.imageSet.Roi[0].Shape;
                PointContour center = new PointContour();
                center.X = rect.Left + rect.Width / 2;
                center.Y = rect.Top + rect.Height / 2;
                PointF xyPos = new PointF((float)Form_Main.Instance.X.Pos, (float)Form_Main.Instance.Y.Pos);
                nz1 = Form_Main.Instance.Point2CCDCenter(xyPos, center, Camera.CAM.Bottom1);
                isCaled1 = true;
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (Form_Main.Instance.imageSet.Roi.Count > 0 && Form_Main.Instance.imageSet.Roi[0].Shape.GetType() == typeof(RectangleContour))
            {
                RectangleContour rect = (RectangleContour)Form_Main.Instance.imageSet.Roi[0].Shape;
                PointContour center = new PointContour();
                center.X = rect.Left + rect.Width / 2;
                center.Y = rect.Top + rect.Height / 2;
                PointF xyPos = new PointF((float)Form_Main.Instance.X.Pos, (float)Form_Main.Instance.Y.Pos);
                nz2 = Form_Main.Instance.Point2CCDCenter(xyPos, center, Camera.CAM.Bottom1);
                isCaled2 = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Form_Main.Instance.imageSet.Roi.Count > 0 && Form_Main.Instance.imageSet.Roi[0].Shape.GetType() == typeof(RectangleContour))
            {
                RectangleContour rect = (RectangleContour)Form_Main.Instance.imageSet.Roi[0].Shape;
                PointContour center = new PointContour();
                center.X = rect.Left + rect.Width / 2;
                center.Y = rect.Top + rect.Height / 2;
                PointF xyPos = new PointF((float)Form_Main.Instance.X.Pos, (float)Form_Main.Instance.Y.Pos);
                nz3 = Form_Main.Instance.Point2CCDCenter(xyPos, center, Camera.CAM.Bottom1);
                isCaled3 = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (Form_Main.Instance.imageSet.Roi.Count > 0 && Form_Main.Instance.imageSet.Roi[0].Shape.GetType() == typeof(RectangleContour))
            {
                RectangleContour rect = (RectangleContour)Form_Main.Instance.imageSet.Roi[0].Shape;
                PointContour center = new PointContour();
                center.X = rect.Left + rect.Width / 2;
                center.Y = rect.Top + rect.Height / 2;
                PointF xyPos = new PointF((float)Form_Main.Instance.X.Pos, (float)Form_Main.Instance.Y.Pos);
                nz4 = Form_Main.Instance.Point2CCDCenter(xyPos, center, Camera.CAM.Bottom1);
                isCaled4 = true;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!isCaled1)
            {
                MessageBox.Show("请先设定吸嘴1相对位置");
                return;
            }

            IniFile ini = new IniFile(Variable.sPath_Configure + "NozzleOffset.ini");
            PointF nz1Center = new PointF();
            nz1Center.X = (float)ini.IniReadNum("app", "Nozzle1OffsetX");
            nz1Center.Y = (float)ini.IniReadNum("app", "Nozzle1OffsetY");
            PointF nz2Center = new PointF();
            nz2Center.X = (float)ini.IniReadNum("app", "Nozzle2OffsetX");
            nz2Center.Y = (float)ini.IniReadNum("app", "Nozzle2OffsetY");
            PointF nz3Center = new PointF();
            nz3Center.X = (float)ini.IniReadNum("app", "Nozzle3OffsetX");
            nz3Center.Y = (float)ini.IniReadNum("app", "Nozzle3OffsetY");
            PointF nz4Center = new PointF();
            nz4Center.X = (float)ini.IniReadNum("app", "Nozzle4OffsetX");
            nz4Center.Y = (float)ini.IniReadNum("app", "Nozzle4OffsetY");

            double dx = nz1.X - nz1Center.X;
            double dy = nz1.Y - nz1Center.Y;

            if (isCaled2)
            {
                nz2Center.X = (float)(nz2Center.X - ((nz2.X - nz2Center.X) - dx));
                nz2Center.Y = (float)(nz2Center.Y - ((nz2.Y - nz2Center.Y) - dy));
                isCaled2 = false;
            }
            if (isCaled3)
            {
                nz3Center.X = (float)(nz3Center.X - ((nz3.X - nz3Center.X) - dx));
                nz3Center.Y = (float)(nz3Center.Y - ((nz3.Y - nz3Center.Y) - dy));
                isCaled3 = false;
            }
            if (isCaled4)
            {
                nz4Center.X = (float)(nz4Center.X - ((nz4.X - nz4Center.X) - dx));
                nz4Center.Y = (float)(nz4Center.Y - ((nz4.Y - nz4Center.Y) - dy));
                isCaled4 = false;
            }

            ini.IniWriteNumber("app", "Nozzle2OffsetX", nz2Center.X);
            ini.IniWriteNumber("app", "Nozzle2OffsetY", nz2Center.Y);
            ini.IniWriteNumber("app", "Nozzle3OffsetX", nz3Center.X);
            ini.IniWriteNumber("app", "Nozzle3OffsetY", nz3Center.Y);
            ini.IniWriteNumber("app", "Nozzle4OffsetX", nz4Center.X);
            ini.IniWriteNumber("app", "Nozzle4OffsetY", nz4Center.Y);
            Form_Main.Instance.ReadNozzleOffsetCofing();
        }
    }
}
