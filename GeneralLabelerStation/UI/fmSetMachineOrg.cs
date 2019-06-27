using GeneralLabelerStation.Camera;
using GeneralLabelerStation.Common;
using NationalInstruments.Vision;
using System;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace GeneralLabelerStation.UI
{

    public partial class fmSetMachineOrg : Form
    {
        public fmSetMachineOrg()
        {
            InitializeComponent();

            SerializableHelper<MachineOrgConfig> helper = new SerializableHelper<MachineOrgConfig>(Config);
            Config = helper.DeXMLSerialize(System.AppDomain.CurrentDomain.BaseDirectory + "Configure\\MachineOrg.xml");
            Form_Main.Instance.LightON_U();
            Form_Main.Instance.SetShutter(Config.Exp, Camera.CAM.Top);
            this.tCircleX.Text = Config.OrgXY.X.ToString();
            this.tCircleY.Text = Config.OrgXY.Y.ToString();
            this.tMinR.Text = Config.MinR.ToString();
            this.tMaxR.Text = Config.MaxR.ToString();
            this.tExp.Text = Config.Exp.ToString();

            this.tD_MinR.Text = Config.D_MinR.ToString();
            this.tD_MaxR.Text = Config.D_MaxR.ToString();
            this.tD_Exp.Text = Config.D_Exp.ToString();

            this.tD_Org1X.Text = Config.D_Org1XY.X.ToString();
            this.tD_Org1Y.Text = Config.D_Org1XY.Y.ToString();

            this.tD_Org2X.Text = Config.D_Org2XY.X.ToString();
            this.tD_Org2Y.Text = Config.D_Org2XY.Y.ToString();

            this.nLimit.Value = (decimal)Config.UpLimit;
            this.nSpace.Value = (decimal)Config.CheckSpace;

            this.EnableMachineOrg.Checked = Config.EnableMachineOrg;
        }

        public MachineOrgConfig Config = new MachineOrgConfig();

        private void bUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                Config.OrgXY.X = float.Parse(this.tCircleX.Text);
                Config.OrgXY.Y = float.Parse(this.tCircleY.Text);
                Config.MinR = int.Parse(this.tMinR.Text);
                Config.MaxR = int.Parse(this.tMaxR.Text);
                Config.Exp = int.Parse(this.tExp.Text);

                Config.D_Exp = int.Parse(this.tD_Exp.Text);
                Config.D_MinR = int.Parse(this.tD_MinR.Text);
                Config.D_MaxR = int.Parse(this.tD_MaxR.Text);

                Config.D_Org1XY.X = float.Parse(this.tD_Org1X.Text);
                Config.D_Org1XY.Y = float.Parse(this.tD_Org1Y.Text);
                Config.D_Org2XY.X = float.Parse(this.tD_Org2X.Text);
                Config.D_Org2XY.Y = float.Parse(this.tD_Org2Y.Text);
                Config.CheckSpace = (int)this.nSpace.Value;
                Config.UpLimit = (double)this.nLimit.Value;

                Config.EnableMachineOrg = this.EnableMachineOrg.Checked;

                SerializableHelper<MachineOrgConfig> helper = new SerializableHelper<MachineOrgConfig>(Config);
                helper.XMLSerialize(System.AppDomain.CurrentDomain.BaseDirectory + "Configure\\MachineOrg.xml");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void bFindCircle_Click(object sender, EventArgs e)
        {
            short minr, maxr;
            short rtn = 0;
            PointContour a = new PointContour();
            double r = 0;
            minr = short.Parse(tMinR.Text);
            maxr = short.Parse(tMaxR.Text);
            rtn = Form_Main.Instance.CamDetect_Circle(Form_Main.Instance.imageSet.Image, Form_Main.Instance.imageSet.Roi, minr, maxr, ref a, ref r);

            if (rtn == 0)
            {
                tR.Text = r.ToString("f3");
                PointF cur = new PointF();
                cur.X = (float)Form_Main.Instance.X.Pos;
                cur.Y = (float)Form_Main.Instance.Y.Pos;
                PointF circle = Camera.CameraDefine.Instance[Camera.CAM.Top].ImagePt2WorldPt(cur, a);
                this.tCircleX.Text = circle.X.ToString("f3");
                this.tCircleY.Text = circle.Y.ToString("f3");
            }
        }

        private void bMove_Click(object sender, EventArgs e)
        {
            try
            {
                Form_Main.Instance.XYGoPos(new PointF(float.Parse(this.tCircleX.Text),
                    float.Parse(this.tCircleY.Text)), Form_Main.VariableSys.VelMode_Debug_Manual);
            }
            catch { }
        }

        private void bDetectOrg1_Click(object sender, EventArgs e)
        {
            short minr, maxr;
            short rtn = 0;
            PointContour a = new PointContour();
            double r = 0;
            minr = short.Parse(tD_MinR.Text);
            maxr = short.Parse(tD_MaxR.Text);
            rtn = Form_Main.Instance.CamDetect_Circle(Form_Main.Instance.imageSet.Image, Form_Main.Instance.imageSet.Roi, minr, maxr, ref a, ref r);

            if (rtn == 0)
            {
                label6.Text = r.ToString("f3");
                PointF cur = new PointF();
                cur.X = (float)Form_Main.Instance.X.Pos;
                cur.Y = (float)Form_Main.Instance.Y.Pos;
                PointF circle = Camera.CameraDefine.Instance[Camera.CAM.Bottom1].ImagePt2WorldPt(cur, a);
                this.tD_Org1X.Text = circle.X.ToString("f3");
                this.tD_Org1Y.Text = circle.Y.ToString("f3");
            }
        }

        private void bDetectOrg2_Click(object sender, EventArgs e)
        {
            short minr, maxr;
            short rtn = 0;
            PointContour a = new PointContour();
            double r = 0;
            minr = short.Parse(tD_MinR.Text);
            maxr = short.Parse(tD_MaxR.Text);
            rtn = Form_Main.Instance.CamDetect_Circle(Form_Main.Instance.imageSet.Image, Form_Main.Instance.imageSet.Roi, minr, maxr, ref a, ref r);

            if (rtn == 0)
            {
                label6.Text = r.ToString("f3");
                PointF cur = new PointF();
                cur.X = (float)Form_Main.Instance.X.Pos;
                cur.Y = (float)Form_Main.Instance.Y.Pos;
                PointF circle = Camera.CameraDefine.Instance[Camera.CAM.Bottom1].ImagePt2WorldPt(cur, a);
                this.tD_Org2X.Text = circle.X.ToString("f3");
                this.tD_Org2Y.Text = circle.Y.ToString("f3");
            }
        }

        private void bMove_Org1_Click(object sender, EventArgs e)
        {
            try
            {
                Form_Main.Instance.XYGoPos(new PointF(float.Parse(this.tD_Org1X.Text),
                    float.Parse(this.tD_Org1Y.Text)), Form_Main.VariableSys.VelMode_Debug_Manual);
            }
            catch { }
        }

        private void bMove_Org2_Click(object sender, EventArgs e)
        {
            try
            {
                Form_Main.Instance.XYGoPos(new PointF(float.Parse(this.tD_Org2X.Text),
                    float.Parse(this.tD_Org2Y.Text)), Form_Main.VariableSys.VelMode_Debug_Manual);
            }
            catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region 对外接口
        public static void AutoCheck()
        {
            MachineOrgConfig MachineCFG = new MachineOrgConfig();
            SerializableHelper<MachineOrgConfig> helper = new SerializableHelper<MachineOrgConfig>(MachineCFG);
            MachineCFG = helper.DeXMLSerialize(System.AppDomain.CurrentDomain.BaseDirectory + "Configure\\MachineOrg.xml");
            
            if (Form_Main.Instance.RunMode != 1)
            {
                try
                {
                    PointF circle = new PointF();
                    double offsetX = 0;
                    double offsetY = 0;
                    PointContour center = null;
                    RectangleContour roi = null;
                    VisionImage img = null;
                    double rCenter = 0;
                    var machine = Form_Main.Instance;
                    var config = Form_Main.VariableSys;
                    var vel = config.VelMode_Current_Manual;

                    if (!machine.All_ZGoSafeTillStop(3000, vel)) new Exception("Z轴回原点失败");

                    short rtn = machine.XYGoPosTillStop(3000, config.pReadyPoint, vel);
                    if (rtn != 0) throw new Exception("移动XY到位失败");

                    rtn += machine.Turn.GoPosTillStop(3000, config.dTurnXIAngle, vel);
                    if (rtn != 0) throw new Exception("移动翻转到位失败");

                    machine.LightON_U();
                    machine.SetShutter(MachineCFG.Exp, CAM.Top);

                    // 到机械原点
                    rtn += machine.XYGoPosTillStop(3000, MachineCFG.OrgXY, vel);
                    if (rtn != 0) throw new Exception("移动XY到位失败");
                    Thread.Sleep(1000);
                    img = CameraDefine.Instance[CAM.Top]._Session.Snap(machine.imageSet.Image);

                    roi = new RectangleContour(0, 0, img.Width, img.Height);
                    center = new PointContour();
                    rCenter = 0;
                    rtn = Form_Main.Instance.CamDetect_Circle(img
     , roi.ConvertToRoi(), (short)MachineCFG.MinR, (short)MachineCFG.MaxR, ref center, ref rCenter);

                    if (rtn != 0) throw new Exception("抓取XY机械原点失败");

                    circle = CameraDefine.Instance[CAM.Top].ImagePt2WorldPt(MachineCFG.OrgXY, center);
                    offsetX = circle.X - MachineCFG.OrgXY.X;
                    offsetY = circle.Y - MachineCFG.OrgXY.Y;

                    if (Math.Abs(offsetX) > MachineCFG.UpLimit || Math.Abs(offsetY) > MachineCFG.UpLimit)
                    {
                        new Exception($"XY 机械原点检验成功,误差过大 X:{offsetX:N3} Y:{offsetY:N3}");
                    }

                    File.AppendAllText("D://机械原点校验数据.csv", $"XY机械原点误差,{offsetX:N3},{offsetY:N3},");
                    // 到翻转头
                    Thread.Sleep(500);

                    machine.LightON_D();
                    machine.SetShutter(MachineCFG.D_Exp, CAM.Bottom1);

                    #region 检验翻转头机械原点1
                    rtn += machine.XYGoPosTillStop(3000, MachineCFG.D_Org1XY, vel);
                    if (rtn != 0) throw new Exception("移动XY到位失败");

                    Thread.Sleep(1000);
                    img = CameraDefine.Instance[CAM.Bottom1]._Session.Snap(machine.imageSet.Image);
                    roi = new RectangleContour(0, 0, img.Width, img.Height);
                    center = new PointContour();
                    rCenter = 0;
                    rtn = Form_Main.Instance.CamDetect_Circle(img
     , roi.ConvertToRoi(), (short)MachineCFG.D_MinR, (short)MachineCFG.D_MaxR, ref center, ref rCenter);

                    if (rtn != 0) throw new Exception("抓取翻转头1机械原点失败");

                    circle = CameraDefine.Instance[CAM.Bottom1].ImagePt2WorldPt(MachineCFG.D_Org1XY, center);
                    offsetX = circle.X - MachineCFG.D_Org1XY.X;
                    offsetY = circle.Y - MachineCFG.D_Org1XY.Y;

                    if (Math.Abs(offsetX) > MachineCFG.UpLimit || Math.Abs(offsetY) > MachineCFG.UpLimit)
                    {
                        throw new Exception($"翻转头机械1原点检验成功,误差过大 X:{offsetX:N3} Y:{offsetY:N3}");
                    }

                    File.AppendAllText("D://机械原点校验数据.csv", $"翻转头机械1原点误差,{offsetX:N3},{offsetY:N3},");

                    #endregion

                    #region 检验翻转头机械原点2
                    rtn += machine.XYGoPosTillStop(3000, MachineCFG.D_Org2XY, vel);
                    if (rtn != 0) throw new Exception("移动XY到位失败");

                    Thread.Sleep(1000);
                    img = CameraDefine.Instance[CAM.Bottom1]._Session.Snap(machine.imageSet.Image);
                    roi = new RectangleContour(0, 0, img.Width, img.Height);
                    center = new PointContour();
                    rCenter = 0;
                    rtn += Form_Main.Instance.CamDetect_Circle(img
     , roi.ConvertToRoi(), (short)MachineCFG.D_MinR, (short)MachineCFG.D_MaxR, ref center, ref rCenter);

                    if (rtn != 0) throw new Exception("抓取翻转头2机械原点失败");

                    circle = CameraDefine.Instance[CAM.Bottom1].ImagePt2WorldPt(MachineCFG.D_Org2XY, center);
                    offsetX = circle.X - MachineCFG.D_Org2XY.X;
                    offsetY = circle.Y - MachineCFG.D_Org2XY.Y;

                    if (Math.Abs(offsetX) > MachineCFG.UpLimit || Math.Abs(offsetY) > MachineCFG.UpLimit)
                    {
                        throw new Exception($"翻转头机械2原点检验成功,误差过大 X:{offsetX:N3} Y:{offsetY:N3}");
                    }
                    File.AppendAllText("D://机械原点校验数据.csv", $"翻转头机械2原点误差,{offsetX:N3},{offsetY:N3}\r\n");
                }
                catch(Exception ex){
                    File.AppendAllText("D://机械原点校验数据.csv", $"失败原因{ex.Message}\r\n");
                }

                #endregion
            }
        }
        #endregion

        private void button2_Click(object sender, EventArgs e)
        {
            AutoCheck();
        }
    }

    public class MachineOrgConfig
    {
        public bool EnableMachineOrg = false;

        public PointF OrgXY = new PointF();

        public int MinR = 3;

        public int MaxR = 100;

        public int Exp = 100;

        public int D_MinR = 3;

        public int D_MaxR = 100;

        public int D_Exp = 100;

        public PointF D_Org1XY = new PointF();

        public PointF D_Org2XY = new PointF();

        public int CheckSpace = 8;

        public double UpLimit = 0.05;
    }
}
