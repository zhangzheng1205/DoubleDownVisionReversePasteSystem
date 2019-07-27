using GeneralLabelerStation.Common;
using GeneralLabelerStation.ViewModle;
using NationalInstruments.Vision;
using NationalInstruments.Vision.Analysis;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeneralLabelerStation.UI
{
    public partial class fmLocalSet : Form
    {
        public fmLocalSet(string JOBName)
        {
            InitializeComponent();
            this.JOBName = JOBName;
        }

        private string JOBName = string.Empty;
        private GlobalMarkModule ViewModel = null;

        private void fmLocalSet_Load(object sender, EventArgs e)
        {
            this.dGV_Global.Rows.Add(2);

            if (File.Exists(JOBName))
            {
                Common.SerializableHelper<GlobalMarkModule> helper = new SerializableHelper<GlobalMarkModule>(ViewModel);
                ViewModel = helper.DeXMLSerialize(JOBName);
            }
            else
            {
                ViewModel = new GlobalMarkModule();
                ViewModel.Mark = new MarkEntiy[2];
                ViewModel.Mark[0] = new MarkEntiy();
                ViewModel.Mark[1] = new MarkEntiy();
            }

            UpdateToRow(0);
            UpdateToRow(1);
        }

        private void UpdateToRow(int index)
        {
            MarkEntiy entiy = ViewModel.Mark[index];
            this.dGV_Global.Rows[index].Cells[0].Value = (index+1).ToString();
            this.dGV_Global.Rows[index].Cells[1].Value = entiy.CamPos.X;
            this.dGV_Global.Rows[index].Cells[2].Value = entiy.CamPos.Y;
            this.dGV_Global.Rows[index].Cells[3].Value = entiy.MarkXY.X;
            this.dGV_Global.Rows[index].Cells[4].Value = entiy.MarkXY.Y;
            this.dGV_Global.Rows[index].Cells[5].Value = entiy.Gain;
            this.dGV_Global.Rows[index].Cells[6].Value = entiy.Offset;
            this.dGV_Global.Rows[index].Cells[7].Value = entiy.Light;
            this.dGV_Global.Rows[index].Cells[8].Value = entiy.Exp;
            this.dGV_Global.Rows[index].Cells[9].Value = entiy.ROI;
            this.dGV_Global.Rows[index].Cells[10].Value = entiy.MinR;
            this.dGV_Global.Rows[index].Cells[11].Value = entiy.MaxR;

            this.tBaseAngle.Text = ViewModel.BaseAngle.ToString("f3");
        }

        private void bUpdate_Click(object sender, EventArgs e)
        {
            if(JOBName != string.Empty)
            {
                Common.SerializableHelper<GlobalMarkModule> helper = new SerializableHelper<GlobalMarkModule>(ViewModel);
                helper.XMLSerialize(JOBName);
                if(Form_Main.Instance.JOB.iLocalAlign == 1)
                {
                    Form_Main.Instance.JOB.GlobalConfig = ViewModel;
                }
            }
        }

        private void bFindCircle_Click(object sender, EventArgs e)
        {
            if (this.dGV_Global.SelectedRows.Count > 0 &&
      this.dGV_Global.SelectedRows[0].Index <= this.dGV_Global.Rows.Count - 1
      && Form_Main.Instance.imageSet.Roi.Count > 0
      && Form_Main.Instance.imageSet.Roi[0].Shape.GetType() == typeof(RectangleContour))
            {
                int row = this.dGV_Global.SelectedRows[0].Index;
                MarkEntiy temp = ViewModel.Mark[row];
               
                short minr = short.Parse(tMinR.Text);
                short maxr = short.Parse(tMaxR.Text);
                temp.MinR = minr;
                temp.MaxR = maxr;

                PointContour a = new PointContour();
                double r = 0;
                short rtn = Form_Main.Instance.CamDetect_Circle(Form_Main.Instance.imageSet.Image, Form_Main.Instance.imageSet.Roi, minr, maxr, ref a, ref r);

                if(rtn == 0)
                {
                    var rect = (RectangleContour)Form_Main.Instance.imageSet.Roi[0].Shape;
                    string strRect = rect.Top.ToString("f3");
                    strRect += ",";
                    strRect += rect.Left.ToString("f3");
                    strRect += ",";
                    strRect += rect.Width.ToString("f3");
                    strRect += ",";
                    strRect += rect.Height.ToString("f3");
                    temp.ROI = strRect;

                    PointF xy = new PointF();
                    xy.X = (float)Form_Main.Instance.X.Pos;
                    xy.Y = (float)Form_Main.Instance.Y.Pos;

                    temp.MarkXY = Form_Main.Instance.Point2CCDCenter(xy, a, Camera.CAM.Top, 0);// Camera.CameraDefine.Instance[Camera.CAM.Top].ImagePt2WorldPt(xy, a, 0);

                    ViewModel.BaseAngle = Form_Main.Instance.getAngle(ViewModel.Mark[0].MarkXY.X, ViewModel.Mark[0].MarkXY.Y,
                        ViewModel.Mark[1].MarkXY.X, ViewModel.Mark[1].MarkXY.Y);
                    this.tBaseAngle.Text = ViewModel.BaseAngle.ToString("f3");
                    UpdateToRow(row);
                }
                else
                {
                    MessageBox.Show("侦测失败");
                }
            }
        }

        private void bRecrodCamXY_Click(object sender, EventArgs e)
        {
            if(this.dGV_Global.SelectedRows.Count > 0 &&
                 this.dGV_Global.SelectedRows[0].Index <= this.dGV_Global.Rows.Count - 1)
            {
                int row = this.dGV_Global.SelectedRows[0].Index;
                MarkEntiy temp = ViewModel.Mark[row];

                temp.CamPos.X = (float)Form_Main.Instance.X.Pos;
                temp.CamPos.Y = (float)Form_Main.Instance.Y.Pos;

                UpdateToRow(row);
            }
        }

        private void bRecrodLight_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dGV_Global.SelectedRows.Count > 0 &&
                 this.dGV_Global.SelectedRows[0].Index <= this.dGV_Global.Rows.Count - 1)
                {
                    int row = this.dGV_Global.SelectedRows[0].Index;
                    MarkEntiy temp = ViewModel.Mark[row];
          
                    Form_Main.Instance.UpdateLightPlan();

                    temp.Light = Form_Main.VariableSys.bRedU == true ? "1," : "0,";
                    temp.Light += Form_Main.VariableSys.bGreenU == true ? "1," : "0,";
                    temp.Light += Form_Main.VariableSys.bBlueU == true ? "1," : "0,";
                    temp.Light += Form_Main.VariableSys.dRedValue_U.ToString();
                    temp.Light += ",";
                    temp.Light += Form_Main.VariableSys.dGreenValue_U.ToString();
                    temp.Light += ",";
                    temp.Light += Form_Main.VariableSys.dBlueValue_U.ToString();
                    UpdateToRow(row);
                }
            }
            catch { }
        }

        private void bRecrodExp_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dGV_Global.SelectedRows.Count > 0 &&
                  this.dGV_Global.SelectedRows[0].Index <= this.dGV_Global.Rows.Count - 1)
                {
                    int row = this.dGV_Global.SelectedRows[0].Index;
                    MarkEntiy temp = ViewModel.Mark[row];

                    temp.Exp = int.Parse(Form_Main.Instance.ntCamShutter.Value.ToString());

                    UpdateToRow(row);
                }
            }
            catch
            { }
        }

        private void bHandle_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dGV_Global.SelectedRows.Count > 0 &&
      this.dGV_Global.SelectedRows[0].Index <= this.dGV_Global.Rows.Count - 1)
                {
                    int row = this.dGV_Global.SelectedRows[0].Index;
                    MarkEntiy temp = ViewModel.Mark[row];

                    temp.Gain = int.Parse(this.tGain.Text);
                    temp.Offset = int.Parse(this.tOffset.Text);
                    Algorithms.Copy(Form_Main.Instance.GainOffset(Form_Main.Instance.imageSet.Image, temp.Gain, temp.Offset),
                        Form_Main.Instance.imageSet.Image);

                    UpdateToRow(row);
                }
            }
            catch { }
        }

        private void bMoveCamPos_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dGV_Global.SelectedRows.Count > 0 &&
      this.dGV_Global.SelectedRows[0].Index <= this.dGV_Global.Rows.Count - 1)
                {
                    int row = this.dGV_Global.SelectedRows[0].Index;
                    MarkEntiy temp = ViewModel.Mark[row];

                    Form_Main.Instance.XYGoPos(temp.CamPos, new Variable.VelMode(0, 150, 300, 300));
                }
            }
            catch { }
        }

        private void dGV_Global_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dGV_Global.SelectedRows.Count > 0 &&
this.dGV_Global.SelectedRows[0].Index <= this.dGV_Global.Rows.Count - 1
&& this.ViewModel != null)
            {
                int row = this.dGV_Global.SelectedRows[0].Index;

                this.tMaxR.Text = this.ViewModel.Mark[row].MaxR.ToString();
                this.tMinR.Text = this.ViewModel.Mark[row].MinR.ToString();
                this.tGain.Text = this.ViewModel.Mark[row].Gain.ToString();
                this.tOffset.Text = this.ViewModel.Mark[row].Offset.ToString();
            }
        }
    }
}
