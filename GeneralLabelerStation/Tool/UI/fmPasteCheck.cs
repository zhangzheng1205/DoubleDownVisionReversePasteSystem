using NationalInstruments.Vision;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeneralLabelerStation.UI
{
    public partial class fmPasteCheck : Form
    {
        public fmPasteCheck()
        {
            InitializeComponent();
        }

        private void bGoMark1_Click(object sender, EventArgs e)
        {
            Form_Main.Instance.XYGoPos(mark1, Form_Main.VariableSys.VelMode_Current_Manual);
        }

        private void bGoMark2_Click(object sender, EventArgs e)
        {
            Form_Main.Instance.XYGoPos(mark2, Form_Main.VariableSys.VelMode_Current_Manual);
        }

        private void lMoveTo_Click(object sender, EventArgs e)
        {
            if(this.dataGridView1.Rows.Count >1 && this.dataGridView1.SelectedRows.Count >0)
            {
                PointF xy = new PointF();
                xy.X = float.Parse(this.dataGridView1.Rows[this.dataGridView1.SelectedRows[0].Index].Cells[1].Value.ToString());
                xy.Y = float.Parse(this.dataGridView1.Rows[this.dataGridView1.SelectedRows[0].Index].Cells[2].Value.ToString());
                Form_Main.Instance.XYGoPos(xy, Form_Main.VariableSys.VelMode_Current_Manual);
            }
        }

        private PointF mark1 = new PointF();
        private PointF mark2 = new PointF();

        private void fmPasteCheck_Load(object sender, EventArgs e)
        {
            this.bEnableOffset.Checked = false;
            this.gOffset.Visible = false;
            this.dataGridView1.Rows.Clear();

            if (Form_Main.Instance.JOB.bLocalMode)
            {
                try
                {
                    for (int i = 0; i < Form_Main.Instance.JOB.PASTEInfo.Length; ++i)
                    {
                        for(int j = 0; j < Form_Main.Instance.JOB.PASTEInfo[i].TransformedPoints.Length;++j)
                        {
                            this.dataGridView1.Rows.Add();
                            int rowcount = this.dataGridView1.Rows.Count - 2;
                            this.dataGridView1.Rows[rowcount].Cells[0].Value = i.ToString();
                            this.dataGridView1.Rows[rowcount].Cells[1].Value = (Form_Main.Instance.JOB.PASTEInfo[i].TransformedPoints[j].X + Form_Main.Instance.JOB.OffsetX[i]).ToString("F3");
                            this.dataGridView1.Rows[rowcount].Cells[2].Value = (Form_Main.Instance.JOB.PASTEInfo[i].TransformedPoints[j].Y + Form_Main.Instance.JOB.OffsetY[i]).ToString("F3");
                            this.dataGridView1.Rows[rowcount].Cells[3].Value = (Form_Main.Instance.JOB.UsedNz[i]).ToString();
                            try
                            {
                                PointF mark1 = Form_Main.Instance.Point2CCDCenter(Form_Main.Instance.JOB.Cam_Mark1Point[i], new PointContour(Form_Main.Instance.JOB.UpCCDResult1[i].X, Form_Main.Instance.JOB.UpCCDResult1[i].Y), 0);
                                this.dataGridView1.Rows[rowcount].Cells[4].Value = mark1.X.ToString("F3");
                                this.dataGridView1.Rows[rowcount].Cells[5].Value = mark1.Y.ToString("F3");
                            }
                            catch
                            {
                                this.dataGridView1.Rows[rowcount].Cells[4].Value = 0.ToString();
                                this.dataGridView1.Rows[rowcount].Cells[5].Value = 0.ToString();
                            }
                        }
                    }
                }
                catch { }
            }
            else
            {
                try
                {
                    mark1 = Form_Main.Instance.Point2CCDCenter(Form_Main.Instance.JOB.Cam_Mark1Point[0], new PointContour(Form_Main.Instance.UpCCDResult[0].X, Form_Main.Instance.UpCCDResult[0].Y), 0);
                    mark2 = Form_Main.Instance.Point2CCDCenter(Form_Main.Instance.JOB.Cam_Mark2Point[0], new PointContour(Form_Main.Instance.UpCCDResult[1].X, Form_Main.Instance.UpCCDResult[1].Y), 0);
                    this.lMark1X.Text = mark1.X.ToString("f3");
                    this.lMark1Y.Text = mark1.Y.ToString("f3");
                    this.lMark2X.Text = mark2.X.ToString("f3");
                    this.lMark2Y.Text = mark2.Y.ToString("f3");
                    for (int i = 0; i < Form_Main.Instance.JOB.PasteCount; ++i)
                    {
                        for (int j = 0; j < Form_Main.Instance.JOB.PASTEInfo[i].iPasteED.Length; ++j)
                        {
                            this.dataGridView1.Rows.Add();
                            this.dataGridView1.Rows[this.dataGridView1.RowCount-2].Cells[0].Value = j.ToString();
                            this.dataGridView1.Rows[this.dataGridView1.RowCount - 2].Cells[1].Value = Form_Main.Instance.JOB.PASTEInfo[i].TransformedPoints[j].X.ToString("F3");
                            this.dataGridView1.Rows[this.dataGridView1.RowCount-2].Cells[2].Value = Form_Main.Instance.JOB.PASTEInfo[i].TransformedPoints[j].Y.ToString("F3");

                            this.dataGridView1.Rows[this.dataGridView1.RowCount-2].Cells[3].Value = 0;
                            this.dataGridView1.Rows[this.dataGridView1.RowCount-2].Cells[4].Value = 0;
                            this.dataGridView1.Rows[this.dataGridView1.RowCount - 2].Cells[5].Value = 0;
                        }
                    }
                }
                catch { }
            }
        }
        private void bMoveMark_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dataGridView1.SelectedRows.Count > 0 && Form_Main.Instance.JOB.bLocalMode)
                {
                    int rowIndex = this.dataGridView1.SelectedRows[0].Index;
                    PointF mark = new PointF();
                    mark.X  = float.Parse(this.dataGridView1.Rows[rowIndex].Cells[4].Value.ToString());
                    mark.Y = float.Parse(this.dataGridView1.Rows[rowIndex].Cells[5].Value.ToString());

                    Form_Main.Instance.XYGoPos(mark, Form_Main.VariableSys.VelMode_Debug_Manual);
                }
            }
            catch { }
        }

        private void bEnableOffset_CheckedChanged(object sender, EventArgs e)
        {
            if (Form_Main.Instance.JOB.bLocalMode)
                this.gOffset.Visible = this.bEnableOffset.Checked;
        }

        private void bOffset_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count > 0 && Form_Main.Instance.JOB.bLocalMode)
            {
                int rowIndex = this.dataGridView1.SelectedRows[0].Index;
                try
                {
                    PointF paste = new PointF();
                    paste.X = float.Parse(this.dataGridView1.Rows[rowIndex].Cells[1].Value.ToString());
                    paste.Y = float.Parse(this.dataGridView1.Rows[rowIndex].Cells[2].Value.ToString());
                 
                    if ((MessageBox.Show($"偏移[{RealPaste.X - paste.X}, {RealPaste.Y - paste.Y}]是否修改该点位!!!", "警告", MessageBoxButtons.YesNo) == DialogResult.Yes))
                    {
                        Form_Main.Instance.JOB.OffsetX[rowIndex] = (RealPaste.X - paste.X) + Form_Main.Instance.JOB.OffsetX[rowIndex];
                        Form_Main.Instance.JOB.OffsetY[rowIndex] = (RealPaste.Y - paste.Y) + Form_Main.Instance.JOB.OffsetY[rowIndex];
                        this.dataGridView1.Rows[rowIndex].Cells[1].Value = RealPaste.X.ToString("f3");
                        this.dataGridView1.Rows[rowIndex].Cells[2].Value = RealPaste.Y.ToString("f3");
                        //Form_Main.Instance.RefreshDGV(rowIndex);
                    }
                }
                catch { }
            }
        }

        private PointF RealPaste = new PointF();
        private void bRecord_Click(object sender, EventArgs e)
        {
            RealPaste.X = (float)Form_Main.Instance.X.Pos;
            RealPaste.Y = (float)Form_Main.Instance.Y.Pos;
        }
    }
}
