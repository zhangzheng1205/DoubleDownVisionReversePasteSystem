using NationalInstruments.Vision;
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
using GeneralLabelerStation;
using GeneralLabelerStation.Camera;

namespace GeneralLabelerStation.UI
{
    public partial class frmPasteReCheck : Form
    {
        public frmPasteReCheck()
        {
            InitializeComponent();

            if (Form_Main.Instance.RUN_PASTEInfo != null && Form_Main.Instance.RUN_PASTEInfo.Length > 0
                && Form_Main.Instance.JOB.PasteName != null && Form_Main.Instance.JOB.PasteName.Length > 0)
            {
                PasteInfoList = new Variable.PASTAE[Form_Main.Instance.JOB.PasteName.Length];
                for (int i = 0; i < Form_Main.Instance.JOB.PasteName.Length; ++i)
                {
                    bool isOk = false;
                    PasteInfoList[i] = Form_Main.Instance.ReadXls2Paste(Variable.sPath_SYS_PASTE + "\\" + Form_Main.Instance.JOB.PasteName[i], ref isOk);
                    if (!isOk)
                    {
                        PasteInfoList = null;
                        return;
                    }
                }
            }
        }

        private Variable.PASTAE[] PasteInfoList = null;
        public bool CanShow
        {
            get
            {
                return this.PasteInfoList != null && this.PasteInfoList.Length > 0;
            }
        }

        private void frmPasteReCheck_Load(object sender, EventArgs e)
        {
            this.btnRevoke.Enabled = false;
            if (Form_Main.Instance.RUN_PASTEInfo == null && Form_Main.Instance.RUN_PASTEInfo.Length == 0
                && Form_Main.Instance.JOB.PasteName == null && Form_Main.Instance.JOB.PasteName.Length == 0)
                return;

            this.dGVMark.Rows.Clear();
            this.dGVMark.Rows.Add(Form_Main.Instance.JOB.PasteCount);

            for (int pcbIndex = 0; pcbIndex < Form_Main.Instance.JOB.PasteCount; ++pcbIndex)
            {
                // Mark点数据读取
                this.dGVMark.Rows[pcbIndex].Cells[0].Value = pcbIndex + 1;
                PointF mark1 = new PointF();
                PointF mark2 = new PointF();

                bool isMarked = false;
                if (Form_Main.Instance.JOB.UpCCDResult1 != null && Form_Main.Instance.JOB.UpCCDResult1.Length == Form_Main.Instance.JOB.PasteCount)
                {
                    mark1 = Form_Main.Instance.Point2CCDCenter(Form_Main.Instance.JOB.Cam_Mark1Point[pcbIndex],
                   new PointContour(Form_Main.Instance.JOB.UpCCDResult1[pcbIndex].X, Form_Main.Instance.JOB.UpCCDResult1[pcbIndex].Y), 0);

                    mark2 = Form_Main.Instance.Point2CCDCenter(Form_Main.Instance.JOB.Cam_Mark2Point[pcbIndex],
               new PointContour(Form_Main.Instance.JOB.UpCCDResult2[pcbIndex].X, Form_Main.Instance.JOB.UpCCDResult2[pcbIndex].Y), 0);

                    isMarked = true;
                }
                else
                {
                    mark1 = Form_Main.Instance.JOB.Cam_Mark1Point[pcbIndex];
                    mark2 = Form_Main.Instance.JOB.Cam_Mark2Point[pcbIndex];
                }



                this.dGVMark.Rows[pcbIndex].Cells[1].Value = $"{mark1.X:N2},{mark1.Y:N2}";
                this.dGVMark.Rows[pcbIndex].Cells[2].Value = $"{mark2.X:N2},{mark2.Y:N2}";

                for (int pcsIndex = 0; pcsIndex < Form_Main.Instance.RUN_PASTEInfo[pcbIndex].PastePoints.Length; ++pcsIndex)
                {
                    int rowIndex = this.dGVPaste.Rows.Add();
                    this.dGVPaste.Rows[rowIndex].Cells[0].Value = pcbIndex + 1;
                    this.dGVPaste.Rows[rowIndex].Cells[1].Value = pcsIndex + 1;

                    this.dGVPaste.Rows[rowIndex].Cells[2].Value =
                                     $"{Form_Main.Instance.JOB.PASTEInfo[pcbIndex].TransformedPoints[pcsIndex].X:N2},{Form_Main.Instance.JOB.PASTEInfo[pcbIndex].TransformedPoints[pcsIndex].Y:N2}";
                    this.dGVPaste.Rows[rowIndex].Cells[3].Value = Form_Main.Instance.RUN_PASTEInfo[pcbIndex].NozzleIndex[pcsIndex].ToString();
                    this.dGVPaste.Rows[rowIndex].Cells[4].Value = Form_Main.Instance.RUN_PASTEInfo[pcbIndex].PasteAngle[pcsIndex].ToString();
                    this.dGVPaste.Rows[rowIndex].Cells[5].Value = Form_Main.Instance.RUN_PASTEInfo[pcbIndex].OffsetX_Single[pcsIndex].ToString();
                    this.dGVPaste.Rows[rowIndex].Cells[6].Value = Form_Main.Instance.RUN_PASTEInfo[pcbIndex].OffsetY_Single[pcsIndex].ToString();
                }
            }
        }
        private void bGoMark1_Click(object sender, EventArgs e)
        {
            if (this.dGVMark.SelectedRows.Count > 0)
            {
                try
                {
                    int pcbIndex = this.dGVMark.SelectedRows[0].Index;
                    PointF mark = new PointF();
                    if (Form_Main.Instance.JOB.UpCCDResult1 != null && Form_Main.Instance.JOB.UpCCDResult1.Length == Form_Main.Instance.JOB.PasteCount)
                    {
                        mark = Form_Main.Instance.Point2CCDCenter(Form_Main.Instance.JOB.Cam_Mark1Point[pcbIndex],
                                   new PointContour(Form_Main.Instance.JOB.UpCCDResult1[pcbIndex].X, Form_Main.Instance.JOB.UpCCDResult1[pcbIndex].Y), 0);
                    }
                    else
                    {
                        mark = Form_Main.Instance.JOB.Cam_Mark1Point[pcbIndex];
                    }

                    Form_Main.Instance.XYGoPos(mark, Form_Main.VariableSys.VelMode_Current_Manual);
                }
                catch { }
            }
        }

        private void bGoMark2_Click(object sender, EventArgs e)
        {
            if (this.dGVMark.SelectedRows.Count > 0)
            {
                try
                {
                    int pcbIndex = this.dGVMark.SelectedRows[0].Index;
                    PointF mark = new PointF();
                    if (Form_Main.Instance.JOB.UpCCDResult2 != null && Form_Main.Instance.JOB.UpCCDResult2.Length == Form_Main.Instance.JOB.PasteCount)
                    {
                        mark = Form_Main.Instance.Point2CCDCenter(Form_Main.Instance.JOB.Cam_Mark2Point[pcbIndex],
                                   new PointContour(Form_Main.Instance.JOB.UpCCDResult2[pcbIndex].X, Form_Main.Instance.JOB.UpCCDResult2[pcbIndex].Y), 0);
                    }
                    else
                    {
                        mark = Form_Main.Instance.JOB.Cam_Mark2Point[pcbIndex];
                    }

                    Form_Main.Instance.XYGoPos(mark, Form_Main.VariableSys.VelMode_Current_Manual);
                }
                catch { }
            }
        }

        private void bGoPaste_Click(object sender, EventArgs e)
        {
            if (this.dGVPaste.SelectedRows.Count > 0)
            {
                int rowIndex = this.dGVPaste.SelectedRows[0].Index;
                int pcbIndex = int.Parse(this.dGVPaste.Rows[rowIndex].Cells[0].Value.ToString()) - 1;
                int pcsIndex = int.Parse(this.dGVPaste.Rows[rowIndex].Cells[1].Value.ToString()) - 1;
                Form_Main.Instance.XYGoPos(Form_Main.Instance.JOB.PASTEInfo[pcbIndex].TransformedPoints[pcsIndex], Form_Main.VariableSys.VelMode_Current_Manual);
                Form_Main.Instance.LightON_RedU();
                this.curPcbIndex = pcbIndex;
                this.curPcsIndex = pcsIndex;
                this.GoTo();
            }
        }

        private void bUpGrab_Click(object sender, EventArgs e)
        {
            CameraDefine.Instance[CAM.Top]._Session.Snap(this.imageSet.Image);
        }

        private int curPcbIndex = 0;
        private int curPcsIndex = 0;
        private void bPrev_Click(object sender, EventArgs e)
        {
            this.dGVPaste.Rows[curPcsIndex].DefaultCellStyle.BackColor = Color.White;
            curPcsIndex--;
            if (curPcsIndex < 0)
            {
                curPcsIndex = 0;
                curPcbIndex--;
                if (curPcbIndex < 0)
                    curPcbIndex = 0;
            }
            this.dGVPaste.Rows[curPcsIndex].DefaultCellStyle.BackColor = Color.DarkBlue;
            this.GoTo();
        }

        private void GoTo()
        {
            Form_Main.Instance.XYGoPosTillStop(5000, Form_Main.Instance.JOB.PASTEInfo[curPcbIndex].TransformedPoints[curPcsIndex], Form_Main.VariableSys.VelMode_Current_Manual);
            Thread.Sleep(200);
            var image = CameraDefine.Instance[CAM.Top]._Session.Snap(this.imageSet.Image);
            this.lCur.Text = $"当前第 [{curPcbIndex + 1}] 板第 [{curPcsIndex + 1}] 个";
            if (bShowCross)
            {
                this.imageSet.Image.Overlays.Default.AddLine(new LineContour(new PointContour(this.imageSet.Image.Width / 2, 0),
                           new PointContour(this.imageSet.Image.Width / 2, this.imageSet.Image.Height)), Rgb32Value.RedColor);
                this.imageSet.Image.Overlays.Default.AddLine(new LineContour(new PointContour(0, this.imageSet.Image.Height / 2),
                new PointContour(this.imageSet.Image.Width, this.imageSet.Image.Height / 2)), Rgb32Value.RedColor);
            }

            this.bSetToSelect.BackColor = Color.Red;
        }
        private void bNext_Click(object sender, EventArgs e)
        {
            curPcsIndex++;
            if (curPcsIndex >= Form_Main.Instance.JOB.PASTEInfo[curPcbIndex].iPasteED.Length)
            {
                curPcsIndex = 0;
                curPcbIndex++;
                if (curPcbIndex >= Form_Main.Instance.JOB.PasteCount)
                    curPcbIndex--;
            }
            this.dGVPaste.Rows[curPcsIndex].DefaultCellStyle.BackColor = Color.BlueViolet;
            this.GoTo();
        }

        private bool GetRealPoint = false;
        private PointContour RealPt = new PointContour();
        private void bGetPaste_Click(object sender, EventArgs e)
        {
            GetRealPoint = true;
            this.GetNeedPt = false;
        }

        private bool GetNeedPt = false;
        private PointContour NeedPt = new PointContour();

        private void imageSet_ImageMouseMove(object sender, NationalInstruments.Vision.WindowsForms.ImageMouseEventArgs e)
        {
            this.imageSet.Image.Overlays.Default.Clear();
            double angle = (double)this.numericUpDown1.Value;

            if (bShowCross)
            {
                PointContour center = new PointContour(this.imageSet.Image.Width / 2, this.imageSet.Image.Height / 2);
                this.showCross(angle, center, Rgb32Value.RedColor);
            }

            if (GetRealPoint)
                RealPt = e.Point;
            else if (GetNeedPt)
                NeedPt = e.Point;

            this.showCross(angle, RealPt, Rgb32Value.YellowColor);
            this.showCross(angle, NeedPt, Rgb32Value.BlueColor);
        }

        public void showCross(double angle, PointContour center, Rgb32Value colcor)
        {
            double rate = angle / 180 * Math.PI;
            LineContour line1 = new LineContour(new PointContour(center.X - 2000 * Math.Sin(rate), center.Y - 2000 * Math.Cos(rate)),
              new PointContour(center.X + 2000 * Math.Sin(rate), center.Y + 2000 * Math.Cos(rate)));

            LineContour line2 = new LineContour(new PointContour(center.X + 2000 * Math.Cos(rate), center.Y - 2000 * Math.Sin(rate)),
           new PointContour(center.X - 2000 * Math.Cos(rate), center.Y + 2000 * Math.Sin(rate)));
            this.imageSet.Image.Overlays.Default.AddLine(line1, colcor);
            this.imageSet.Image.Overlays.Default.AddLine(line2, colcor);
        }

        private void imageSet_Resize(object sender, EventArgs e)
        {
            this.imageSet.ToolsShown = NationalInstruments.Vision.WindowsForms.ViewerTools.All;
            this.imageSet.ShowToolbar = true;
        }

        private bool bShowCross = true;
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            bShowCross = this.checkBox1.Checked;
        }

        private void imageSet_ImageMouseDown(object sender, NationalInstruments.Vision.WindowsForms.ImageMouseEventArgs e)
        {
            if (GetRealPoint || GetNeedPt)
            {
                GetRealPoint = false;
                GetNeedPt = false;
                double angle = (double)this.numericUpDown1.Value;
                double rate = angle / 180 * Math.PI;

                var cur = Form_Main.Instance.XYPos;
                PointF real = new PointF();
                PointF need = new PointF();
                real = Form_Main.Instance.Point2CCDCenter(cur, this.RealPt, CAM.Top);
                need = Form_Main.Instance.Point2CCDCenter(cur, this.NeedPt, CAM.Top);

                this.tOffsetX.Text = (need.X - real.X).ToString("f3");
                this.tOffsetY.Text = (need.Y - real.Y).ToString("f3");
            }
        }

        private void bSetToSelect_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"是否将应用该补偿值?Y/N", "警告", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.btnRevoke.Enabled = true;
                var action = new List<Tuple<int, int, double, double>>();
                try
                {
                    double dx = double.Parse(this.tOffsetX.Text);
                    double dy = double.Parse(this.tOffsetY.Text);
                    this.PasteInfoList[curPcbIndex].OffsetX_Single[curPcsIndex] += dx;
                    this.PasteInfoList[curPcbIndex].OffsetY_Single[curPcsIndex] += dy;
                    if (this.tOffsetX.Text != "0" || this.tOffsetY.Text != "0")
                    {
                        int pcsOffset = 0;
                        if (curPcbIndex != 0)
                        {
                            for (int i = 0; i < curPcbIndex; i++)
                            {
                                pcsOffset += Form_Main.Instance.RUN_PASTEInfo[i].PastePoints.Length;
                            }
                        }
                        this.dGVPaste.Rows[curPcsIndex + pcsOffset].Cells[5].Value = this.PasteInfoList[curPcbIndex].OffsetX_Single[curPcsIndex].ToString();
                        this.dGVPaste.Rows[curPcsIndex + pcsOffset].Cells[6].Value = this.PasteInfoList[curPcbIndex].OffsetY_Single[curPcsIndex].ToString();
                        action.Add(new Tuple<int, int, double, double>(curPcbIndex, curPcsIndex, dx, dy));
                        Actions.Push(action);
                        this.dGVPaste.Rows[curPcsIndex + pcsOffset].DefaultCellStyle.BackColor = Color.LightGreen;
                        this.bSetToSelect.BackColor = Color.LightGreen;
                    }
                    this.tOffsetX.Text = "0";
                    this.tOffsetY.Text = "0";
                }
                catch { }
            }
        }

        private void bUpdateToFlow_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"是否保存程式? Y/N", "警告", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                for (int i = 0; i < Form_Main.Instance.JOB.PasteCount; ++i)
                {
                    Form_Main.Instance.PasteInfo = this.PasteInfoList[i];
                    Form_Main.Instance.WriteXls2Data_Paste(Variable.sPath_SYS_PASTE + "\\" + Form_Main.Instance.JOB.PasteName[i]);
                }

                MessageBox.Show("检验保存成功,请清理重新导入程式!!!");
            }
        }

        private void bFull_Click(object sender, EventArgs e)
        {
            imageSet.ZoomToFit = true;
        }

        private void dGVPaste_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dGVPaste.SelectedRows.Count > 0)
            {
                try
                {
                    this.curPcbIndex = int.Parse(this.dGVPaste.Rows[this.dGVPaste.SelectedRows[0].Index].Cells[0].Value.ToString()) - 1;
                    this.curPcsIndex = int.Parse(this.dGVPaste.Rows[this.dGVPaste.SelectedRows[0].Index].Cells[1].Value.ToString()) - 1;
                    this.lCur.Text = $"当前第 [{curPcbIndex + 1}] 板第 [{curPcsIndex + 1}] 个";
                    this.bSetLike.BackColor = Color.Red;
                    this.bSetToSelect.BackColor = Color.Red;
                    this.bSetAll.BackColor = Color.Red;
                }
                catch { }
            }
        }

        private void bNeedPaste_Click(object sender, EventArgs e)
        {
            this.GetNeedPt = true;
            this.GetRealPoint = false;
        }


        private void bSetLike_Click(object sender, EventArgs e)
        {
            if (this.dGVPaste.SelectedRows.Count > 0)
            {
                this.btnRevoke.Enabled = true;
                var action = new List<Tuple<int, int, double, double>>();
                if (MessageBox.Show($"是否将该补偿值应用到与该贴附位的镜像位 ?Y/N", "警告", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //curPcbIndex板号-1;curPcsIndex穴位号-1
                    int nz = Form_Main.Instance.RUN_PASTEInfo[curPcbIndex].NozzleIndex[curPcsIndex];
                    double angle = Form_Main.Instance.RUN_PASTEInfo[curPcbIndex].PasteAngle[curPcsIndex];
                    for (int pcs = 0; pcs < Form_Main.Instance.RUN_PASTEInfo[curPcbIndex].PastePoints.Length; pcs++)
                    {
                        int curNz = Form_Main.Instance.RUN_PASTEInfo[curPcbIndex].NozzleIndex[pcs];
                        double curAngle = Form_Main.Instance.RUN_PASTEInfo[curPcbIndex].PasteAngle[pcs];
                        if (curNz == nz && Math.Abs(curAngle - angle) < 10)
                        {
                            double dx = double.Parse(this.tOffsetX.Text);
                            double dy = double.Parse(this.tOffsetY.Text);
                            this.PasteInfoList[curPcbIndex].OffsetX_Single[pcs] += dx;
                            this.PasteInfoList[curPcbIndex].OffsetY_Single[pcs] += dy;
                            if (this.tOffsetX.Text != "0" || this.tOffsetY.Text != "0")
                            {
                                int pcsOffset = 0;
                                if (curPcbIndex != 0)
                                {
                                    for (int i = 0; i < curPcbIndex; i++)
                                    {
                                        pcsOffset += Form_Main.Instance.RUN_PASTEInfo[i].PastePoints.Length;
                                    }
                                }
                                this.dGVPaste.Rows[pcs + pcsOffset].Cells[5].Value = this.PasteInfoList[curPcbIndex].OffsetX_Single[pcs].ToString();
                                this.dGVPaste.Rows[pcs + pcsOffset].Cells[6].Value = this.PasteInfoList[curPcbIndex].OffsetY_Single[pcs].ToString();
                                this.dGVPaste.Rows[pcs + pcsOffset].DefaultCellStyle.BackColor = Color.LightGreen;
                                this.bSetLike.BackColor = Color.LightGreen;
                                action.Add(new Tuple<int, int, double, double>(curPcbIndex, pcs, dx, dy));
                            }
                        }
                    }
                    this.tOffsetX.Text = "0";
                    this.tOffsetY.Text = "0";
                }
                Actions.Push(action);

            }
        }


        public Stack<List<Tuple<int, int, double, double>>> Actions = new Stack<List<Tuple<int, int, double, double>>>();

        private void button1_Click(object sender, EventArgs e)
        {
            double angle = Form_Main.Instance.RUN_PASTEInfo[curPcbIndex].PasteAngle[curPcsIndex];
            var action = new List<Tuple<int, int, double, double>>();
            if (MessageBox.Show($"是否将该补偿值应用到所有贴附位 ?Y/N", "警告", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.btnRevoke.Enabled = true;
                for (int pcb = 0; pcb < Form_Main.Instance.RUN_PASTEInfo.Length; pcb++)
                {
                    for (int pcs = 0; pcs < Form_Main.Instance.RUN_PASTEInfo[pcb].PastePoints.Length; pcs++)
                    {
                        double curAngle = Form_Main.Instance.RUN_PASTEInfo[curPcbIndex].PasteAngle[pcs];
                        if (Math.Abs(curAngle - angle) < 10 && curPcbIndex == pcb)
                        {
                            double dx = double.Parse(this.tOffsetX.Text);
                            double dy = double.Parse(this.tOffsetY.Text);
                            this.PasteInfoList[pcb].OffsetX_Single[pcs] += dx;
                            this.PasteInfoList[pcb].OffsetY_Single[pcs] += dy;
                            if (this.tOffsetX.Text != "0" || this.tOffsetY.Text != "0")
                            {
                                int pcsOffset = 0;
                                if (curPcbIndex != 0)
                                {
                                    for (int i = 0; i < curPcbIndex; i++)
                                    {
                                        pcsOffset += Form_Main.Instance.RUN_PASTEInfo[i].PastePoints.Length;
                                    }
                                }
                                this.dGVPaste.Rows[pcs + pcsOffset].Cells[5].Value = this.PasteInfoList[curPcbIndex].OffsetX_Single[pcs].ToString();
                                this.dGVPaste.Rows[pcs + pcsOffset].Cells[6].Value = this.PasteInfoList[curPcbIndex].OffsetY_Single[pcs].ToString();
                                this.dGVPaste.Rows[pcs + pcsOffset].DefaultCellStyle.BackColor = Color.LightGreen;
                                this.bSetAll.BackColor = Color.LightGreen;
                                action.Add(new Tuple<int, int, double, double>(pcb, pcs, dx, dy));
                            }
                        }
                    }
                }
                this.tOffsetX.Text = "0";
                this.tOffsetY.Text = "0";
            }
            Actions.Push(action);
        }
        private void btnRevoke_Click(object sender, EventArgs e)
        {
            if (Actions.Count != 0)
            {
                var list = Actions.Pop();
                for (int i = 0; i < list.Count; ++i)
                {
                    this.PasteInfoList[list[i].Item1].OffsetX_Single[list[i].Item2] -= list[i].Item3;
                    this.PasteInfoList[list[i].Item1].OffsetY_Single[list[i].Item2] -= list[i].Item4;
                    int pcsOffset = 0;
                    if (list[i].Item1 != 0)
                    {
                        for (int j = 0; j < list[i].Item1; j++)
                        {
                            pcsOffset += Form_Main.Instance.RUN_PASTEInfo[j].PastePoints.Length;
                        }
                    }
                    this.dGVPaste.Rows[list[i].Item2 + pcsOffset].Cells[5].Value = this.PasteInfoList[list[i].Item1].OffsetX_Single[list[i].Item2].ToString();
                    this.dGVPaste.Rows[list[i].Item2 + pcsOffset].Cells[6].Value = this.PasteInfoList[list[i].Item1].OffsetY_Single[list[i].Item2].ToString();
                    this.dGVPaste.Rows[list[i].Item2 + pcsOffset].DefaultCellStyle.BackColor = Color.White;
                    if (Actions.Count == 0)
                    {
                        this.btnRevoke.Enabled = false;
                        this.bSetLike.BackColor = Color.Red;
                        this.bSetAll.BackColor = Color.Red;
                        this.bSetToSelect.BackColor = Color.Red;
                    }
                }
            }
        }
    }
}
