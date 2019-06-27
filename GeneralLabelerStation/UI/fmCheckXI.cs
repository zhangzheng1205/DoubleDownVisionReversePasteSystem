using GeneralLabelerStation.Camera;
using GeneralLabelerStation.Param;
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

namespace GeneralLabelerStation.UI
{
    public partial class fmCheckXI : Form
    {
        public fmCheckXI(DataGridView FeederCtrl,int feederNo, Form_Main parent = null)
        {
            InitializeComponent();
            this.parent = parent;
            this.feederNo = feederNo;
            this.Feeder = this.parent.Feeder[this.feederNo];
            this.FeederCtrl = FeederCtrl;
        }

        private int Nozzle = 0;

        private int feederNo = 0;
        private Variable.FEEDER Feeder = null;
        private Form_Main parent = null;

        private PointF suckPos = new PointF();

        private DataGridView FeederCtrl = null;

        private void fmCheckXI_Load(object sender, EventArgs e)
        {
            this.cbLabelIndex.Items.Clear();
            for (int i = 0; i < this.FeederCtrl.Rows.Count-1; ++i)
                this.cbLabelIndex.Items.Add((i + 1).ToString());

            this.nSuckPosX.Value = (decimal)this.Feeder.StandardSuckPos.X;
            this.nSuckPosY.Value = (decimal)this.Feeder.StandardSuckPos.Y;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PointF curPos = Form_Main.VariableSys.pReadyPoint;
            CameraDefine.Instance[CAM.Bottom1]._Session.Snap(parent.imageSet.Image);

            Variable.CamReturn cam = Form_Main.Instance.Auto_Detect1(ref this.Feeder.Label, parent.imageSet.Image, CAM.Bottom1, 0);

            if (cam.IsOK)
            {
                PointF temp = parent.Point2CCDCenter(curPos, new PointContour(cam.X, cam.Y), CAM.Bottom1);
                PointF rotateCenter = parent.Point2CCDCenter(curPos, Form_Main.VariableSys.pDownRotateCenter[0], CAM.Bottom1);
                suckPos.X = temp.X - rotateCenter.X;
                suckPos.Y = temp.Y - rotateCenter.Y;
                this.nSuckPosX.Value = (decimal)suckPos.X;
                this.nSuckPosY.Value = (decimal)suckPos.Y;
            }
        }


        private void bChange_Click(object sender, EventArgs e)
        {
            this.Feeder.StandardSuckPos = new PointF((float)this.nSuckPosX.Value, (float)this.nSuckPosY.Value); 
        }

        private void bUpdate_Click(object sender, EventArgs e)
        {
            int labelIndex = this.cbLabelIndex.SelectedIndex;
            PointF camPoint = new PointF();
            camPoint.X = float.Parse(this.FeederCtrl.Rows[labelIndex].Cells[0].Value.ToString());
            camPoint.Y = float.Parse(this.FeederCtrl.Rows[labelIndex].Cells[1].Value.ToString());
            camPoint.X += ((float)this.nOffsetX.Value - this.Feeder.StandardSuckPos.X);
            camPoint.Y += (this.Feeder.StandardSuckPos.Y - (float)this.nOffsetY.Value);
            this.FeederCtrl.Rows[labelIndex].Cells[0].Value = camPoint.X.ToString("f3");
            this.FeederCtrl.Rows[labelIndex].Cells[1].Value = camPoint.Y.ToString("f3");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            parent.All_ZGoSafeTillStop(3000, Form_Main.VariableSys.VelMode_Current_Manual);
            parent.XYGoPosTillStop(5000, Form_Main.VariableSys.pReadyPoint, Form_Main.VariableSys.VelMode_Current_Manual);
        }

        private void bAutoSet_Click(object sender, EventArgs e)
        {
            if (this.cbLabelIndex.SelectedIndex < 0) return;
            int labelIndex = this.cbLabelIndex.SelectedIndex;

            //Task.Factory.StartNew(() =>
            //{
            try
            {
                var vel = Form_Main.VariableSys.VelMode_Current_Manual;
                parent.All_ZGoSafeTillStop(3000, vel);
                parent.XYGoPosTillStop(5000, Form_Main.VariableSys.pReadyPoint, vel);
                parent.Turn.GoPosTillStop(5000, Form_Main.VariableSys.dTurnXIAngle, vel);

                PointF camPt = new PointF();
                camPt.X = float.Parse(this.FeederCtrl.Rows[labelIndex].Cells[0].Value.ToString());
                camPt.Y = float.Parse(this.FeederCtrl.Rows[labelIndex].Cells[1].Value.ToString());

                PointF nzPt = parent.Nz1ToOther(camPt, this.Nozzle);
                double zHeight = this.Feeder.XIHeight[labelIndex][this.Nozzle];
                double xiAngle = this.Feeder.XI_Degree[this.Nozzle];
                Z_RunParam zParam = parent.Z_RunParamMap[(uint)this.Nozzle];
                R_RunParam rParam = parent.R_RunParamMap[(uint)this.Nozzle];

                zParam.PO_vaccum.ResetIO();
                zParam.XI_vaccum.ResetIO();

                parent.XYGoPosTillStop(5000, nzPt, vel);
                rParam.GoPosTillStop(5000, xiAngle, vel);

                if (this.Feeder.bReachXI)
                    zParam.XI_vaccum.SetIO();
                else
                    zParam.XI_vaccum.ResetIO();

                zParam.GoPosTillStop(5000, zHeight, vel);
                zParam.XI_vaccum.SetIO();
                Thread.Sleep(Form_Main.VariableSys.iDelay_BeforeXI);

                CAM camera = Form_Main.Nozzle2Cam(this.Nozzle);

                parent.LightON_Down_PASTE1(ref this.Feeder.Label);
                parent.SetShutter((int)this.Feeder.Label.Shutter1, camera);
                parent.All_ZGoSafeTillStop(5000, vel);
                parent.XYGoPosTillStop(5000, Form_Main.VariableSys.pReadyPoint, vel);
                parent.Turn.GoPosTillStop(5000, Form_Main.VariableSys.dTurnPasteAngle, vel);

                // 拍照
                Thread.Sleep(Form_Main.VariableSys.iDownCamDelay);
                PointF curPos = Form_Main.VariableSys.pReadyPoint;
                CameraDefine.Instance[camera]._Session.Snap(parent.imageSet.Image);

                Variable.CamReturn cam = Form_Main.Instance.Auto_Detect1(ref this.Feeder.Label, parent.imageSet.Image, camera, this.Nozzle);

                if (cam.IsOK)
                {
                    // 识别出来的位置
                    PointF temp = parent.Point2CCDCenter(curPos, new PointContour(cam.X, cam.Y), camera);
                    PointF rotateCenter = parent.Point2CCDCenter(curPos, Form_Main.VariableSys.pDownRotateCenter[0], camera);

                    /// 识别与吸嘴旋转中心的误差
                    PointF offset = new PointF();
                    offset.X = temp.X - rotateCenter.X;
                    offset.Y = temp.Y - rotateCenter.Y;

                    this.nOffsetX.Value = (decimal)offset.X;
                    this.nOffsetY.Value = (decimal)offset.Y;
                }
            }
            catch { }
            //});
        }
    }
}
