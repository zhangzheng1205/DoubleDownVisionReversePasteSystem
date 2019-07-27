using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GeneralLabelerStation.Tools;
using System.Threading;
using System.IO;
using NationalInstruments.Vision;
using NationalInstruments.Vision.Analysis;
using NationalInstruments.Vision.Acquisition.Imaqdx;
using NationalInstruments.Vision.WindowsForms;
using HalconDotNet;
using System.Collections;
using System.Collections.ObjectModel;
using GeneralLabelerStation.Tool;

namespace GeneralLabelerStation.UI
{
    public partial class fmAutoCPKTest : Form
    {
        public fmAutoCPKTest()
        {
            InitializeComponent();
            this.InitInfo();
            this.LoadInfo();
            this.btnOptimize.Enabled = false;
        }

        /// <summary>
        /// CPK 测试 配置文件
        /// </summary>
        private IniFile cpkIni = null;

        /// <summary>
        /// 速度模式
        /// </summary>
        private Variable.VelMode variable = new Variable.VelMode(10, 100, 300, 300);

        /// <summary>
        /// 检测点
        /// </summary>
        private List<PointF> chkPoint = new List<PointF>();

        /// <summary>
        /// CPK 检测点
        /// </summary>
        public List<PointF> ChkPoint
        {
            get { return this.chkPoint; }
            set { this.chkPoint = value; }
        }

        /// <summary>
        /// 检测点
        /// </summary>
        private List<PointF> chkPoint_Jig = new List<PointF>();

        /// <summary>
        /// Jig 检测点
        /// </summary>
        public List<PointF> ChkPoint_Jig
        {
            get { return this.chkPoint_Jig; }
            set { this.chkPoint_Jig = value; }
        }

         /// <summary>
        /// 检测点
        /// </summary>
        private List<PointF> chkPoint_Jig_Machine = new List<PointF>();

        /// <summary>
        /// Jig 检测点
        /// </summary>
        public List<PointF> ChkPoint_Jig_Machine
        {
            get { return this.chkPoint_Jig_Machine; }
            set { this.chkPoint_Jig_Machine = value; }
        }

         /// <summary>
        /// 检测点
        /// </summary>
        private List<PointF> chkPoint_Jig_Act = new List<PointF>();

        /// <summary>
        /// Jig 检测点
        /// </summary>
        public List<PointF> ChkPoint_Jig_Act
        {
            get { return this.chkPoint_Jig_Act; }
            set { this.chkPoint_Jig_Act = value; }
        }




        private List<CPK_ResultItem> cpkResult = new List<CPK_ResultItem>();

        /// <summary>
        /// CPK 检测结果
        /// </summary>
        public List<CPK_ResultItem> CpkResult
        {
            get { return this.cpkResult; }
            set { this.cpkResult = value; }
        }

        /// <summary>
        /// 贴附信息路径
        /// </summary>
        private string pastePath;

        /// <summary>
        /// 贴附信息路径
        /// </summary>
        public string PastePath
        {
            get { return this.pastePath; }
            set { this.pastePath = value; }
        }

        /// <summary>
        /// 初始化 配置文件
        /// </summary>
        private void InitInfo()
        {
            if (!File.Exists(Variable.sPath_Configure + "CalibConfig.ini"))
            {
                IniFile ini = new IniFile(Variable.sPath_Configure + "CalibConfig.ini");

                ini.IniWriteValue("main", "PastePath", "");
                ini.IniWriteValue("main", "UsePaste", "False");
                ini.IniWriteValue("point", "OrgPosX", "0.000");
                ini.IniWriteValue("point", "OrgPosY", "0.000");
                ini.IniWriteValue("point", "Mark1PosX", "0.000");
                ini.IniWriteValue("point", "Mark1PosY", "0.000");
                ini.IniWriteValue("point", "Mark2PosX", "0.000");
                ini.IniWriteValue("point", "Mark2PosY", "0.000");

                ini.IniWriteValue("point", "Col", "0");
                ini.IniWriteValue("point", "Row", "0");

                ini.IniWriteValue("vision", "Strength", "40"); // 边缘强度

                ini.IniWriteValue("vision", "Gain", "1");
                ini.IniWriteValue("vision", "Offset", "0");
                ini.IniWriteValue("vision", "Cycle", "1");
                ini.IniWriteValue("main", "CPKXValue", "1.00");
                ini.IniWriteValue("main", "CPKYValue", "1.00");
                ini.IniWriteValue("main", "UsePaste", "False");
            }
        }

        /// <summary>
        /// 保存信息
        /// </summary>
        private void SaveInfo()
        {
            this.cpkIni.IniWriteValue("main", "PastePath", this.pastePath);

            this.cpkIni.IniWriteValue("point", "OrgPosX", this.textOrgX.Text);
            this.cpkIni.IniWriteValue("point", "OrgPosY", this.textOrgY.Text);

            this.cpkIni.IniWriteValue("point", "Mark1PosX", this.textMark1X.Text);
            this.cpkIni.IniWriteValue("point", "Mark1PosY", this.textMark1Y.Text);

            this.cpkIni.IniWriteValue("point", "Mark2PosX", this.textMark2X.Text);
            this.cpkIni.IniWriteValue("point", "Mark2PosY", this.textMark2Y.Text);

            this.cpkIni.IniWriteValue("point", "Col", this.textCol.Text);
            this.cpkIni.IniWriteValue("point", "Row", this.textRow.Text);

            this.cpkIni.IniWriteValue("vision", "Strength", this.tStrength.Text);

            this.cpkIni.IniWriteValue("vision", "Gain", this.tGainValue.Text);
            this.cpkIni.IniWriteValue("vision", "Offset", this.tOffsetValue.Text);
            this.cpkIni.IniWriteValue("vision", "Cycle", this.tHanldeCycle.Text);
            this.cpkIni.IniWriteValue("main", "CPKXValue", this.tCPKXValue.Text);
            this.cpkIni.IniWriteValue("main", "CPKYValue", this.tCPKYValue.Text);
            this.cpkIni.IniWriteValue("main", "UsePaste", this.chkUsePastePoint.Checked.ToString());

            this.cpkIni.IniWriteValue("calib", "CailbBaseX", this.tCailbBaseX.Text);
            this.cpkIni.IniWriteValue("calib", "CailbBaseY", this.tCailbBaseY.Text);

            this.cpkIni.IniWriteValue("calib", "MinRaduis", this.upCircleRmin.Text);
            this.cpkIni.IniWriteValue("calib", "MaxRaduis", this.upCircleRmax.Text);

            this.cpkIni.IniWriteValue("calib", "JigRow", this.tJigRow.Text);
            this.cpkIni.IniWriteValue("calib", "JigCol", this.tJigCol.Text);

            this.cpkIni.IniWriteValue("calib", "JigDistX", this.tJigDx.Text);
            this.cpkIni.IniWriteValue("calib", "JigDistY", this.tJigDy.Text);
        }

        /// <summary>
        /// 读取信息
        /// </summary>
        private void LoadInfo()
        {   
            this.cpkIni = new IniFile(Variable.sPath_Configure + "CalibConfig.ini");
            this.PastePath = this.cpkIni.IniReadValue("main", "PastePath");
            this.chkUsePastePoint.Checked = this.cpkIni.IniReadValue("main", "UsePaste") == "False" ? false : true;
            this.textOrgX.Text = this.cpkIni.IniReadValue("point", "OrgPosX");
            this.textOrgY.Text = this.cpkIni.IniReadValue("point", "OrgPosY");

            this.textMark1X.Text = this.cpkIni.IniReadValue("point", "Mark1PosX");
            this.textMark1Y.Text = this.cpkIni.IniReadValue("point", "Mark1PosY");

            this.textMark2X.Text = this.cpkIni.IniReadValue("point", "Mark2PosX");
            this.textMark2Y.Text = this.cpkIni.IniReadValue("point", "Mark2PosY");

            this.textCol.Text = this.cpkIni.IniReadValue("point", "Col");
            this.textRow.Text = this.cpkIni.IniReadValue("point", "Row");

            this.tStrength.Text = this.cpkIni.IniReadValue("vision", "Strength");
            this.tGainValue.Text = this.cpkIni.IniReadValue("vision", "Gain");
            this.tOffsetValue.Text = this.cpkIni.IniReadValue("vision", "Offset");
            this.tHanldeCycle.Text = this.cpkIni.IniReadValue("vision", "Cycle");

            this.tCPKXValue.Text = this.cpkIni.IniReadValue("main", "CPKXValue");
            this.tCPKYValue.Text = this.cpkIni.IniReadValue("main", "CPKYValue");

            this.tCailbBaseX.Text = this.cpkIni.IniReadValue("calib", "CailbBaseX");
            this.tCailbBaseY.Text = this.cpkIni.IniReadValue("calib", "CailbBaseY");

            this.upCircleRmin.Text = this.cpkIni.IniReadValue("calib", "MinRaduis");
            this.upCircleRmax.Text = this.cpkIni.IniReadValue("calib", "MaxRaduis");

            this.tJigRow.Text = this.cpkIni.IniReadValue("calib", "JigRow");
            this.tJigCol.Text = this.cpkIni.IniReadValue("calib", "JigCol");

            this.tJigDx.Text = this.cpkIni.IniReadValue("calib", "JigDistX");
            this.tJigDy.Text = this.cpkIni.IniReadValue("calib", "JigDistY");


            try
            {
                //System.AppDomain.CurrentDomain.BaseDirectory + "Configure\\CPK.ini"
                this.image_Edit.Image.ReadVisionFile(Variable.sPath_Configure + "CPK_Template.png");

                this.ChkPoint.Clear();
                float orgX = float.Parse(this.textOrgX.Text);
                float orgY = float.Parse(this.textOrgY.Text);

                float mark1X = float.Parse(this.textMark1X.Text);
                float mark1Y = float.Parse(this.textMark1Y.Text);

                float mark2X = float.Parse(this.textMark2X.Text);
                float mark2Y = float.Parse(this.textMark2Y.Text);

                short col = short.Parse(this.textCol.Text);
                short row = short.Parse(this.textRow.Text);

                this.ChkPoint = CPKTools.ExpandtoAddPoints(new PointF(orgX, orgY), new PointF(mark1X, mark1Y), new PointF(mark2X, mark2Y), col, row);

            }
            catch
            {
                MessageBox.Show("读取坐标失败");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog folderBrowserDialog = new OpenFileDialog();

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {

                this.PastePath = folderBrowserDialog.FileName;

                // 读取 Paste 信息
                ExcelHelper helper = new ExcelHelper();
                helper.ExcelReadToCpkItem(this.PastePath, ref this.cpkResult);
                this.cpkIni.IniWriteValue("main", "PastePath", this.PastePath);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form_Main.Instance.All_ZGoSafe(this.variable);
            //Form_Main.Instance.LightON_RedU();
            Form_Main.Instance.StartGrabImage();
            ExcelHelper helper = new ExcelHelper();
            helper.ExcelReadToCpkItem(this.PastePath, ref this.cpkResult);
            if (!Directory.Exists("C://CPK"))
            {
                Directory.CreateDirectory("C://CPK");
            }
            // 设置相机可捕获状态
            // 切换光源
            // 设置曝光
            double gain = 1;
            double offset = 0;
            int cycle = 1;
            gain = double.Parse(this.tGainValue.Text);
            offset = double.Parse(this.tOffsetValue.Text);
            cycle = int.Parse(this.tHanldeCycle.Text);
            Thread thd = new Thread(() =>
            {
                if (this.chkUsePastePoint.Checked)
                {
                    for (int i = 0; i < this.CpkResult.Count; i++)
                    {
                        CPK_ResultItem item = this.CpkResult[i];
                        CPKTools.GetCPK(this.cpkIni, this.variable, gain, offset, cycle, ref item);
                        Form_Main.Instance.imageSet.Image.Type = ImageType.U8;
                        Form_Main.Instance.imageSet.Image.WriteBmpFile(string.Format("C://CPK//{0}.bmp", i));
                        Form_Main.Instance.imageSet.Image.Overlays.Default.Merge();
                        Form_Main.Instance.imageSet.Image.WritePngFile(string.Format("C://CPK//{0}.png", i));
                    }
                }
                else
                {
                    for (int i = 0; i < this.chkPoint.Count && i < this.CpkResult.Count; i++)
                    {
                        CPK_ResultItem item = this.CpkResult[i];
                        item.Pos = this.chkPoint[i];
                        CPKTools.GetCPK(this.cpkIni, this.variable, gain, offset, cycle, ref item);
                        Form_Main.Instance.imageSet.Image.Type = ImageType.U8;
                        Form_Main.Instance.imageSet.Image.Overlays.Default.Merge();
                        Form_Main.Instance.imageSet.Image.WritePngFile(string.Format("C://CPK//{0}.png", i+1));
                    }
                }

                MessageBox.Show("测量完成,请导出数据");
            });

            thd.Start();
            this.btnOptimize.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CPKTools.SaveReport(this.CpkResult);
        }

        /// <summary>
        /// 3点 阵列
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreatePoint_Click(object sender, EventArgs e)
        {
            float orgX = float.Parse(this.textOrgX.Text);
            float orgY = float.Parse(this.textOrgY.Text);

            float mark1X = float.Parse(this.textMark1X.Text);
            float mark1Y = float.Parse(this.textMark1Y.Text);

            float mark2X = float.Parse(this.textMark2X.Text);
            float mark2Y = float.Parse(this.textMark2Y.Text);

            short col = short.Parse(this.textCol.Text);
            short row = short.Parse(this.textRow.Text);

            this.ChkPoint = CPKTools.ExpandtoAddPoints(new PointF(orgX, orgY), new PointF(mark1X, mark1Y), new PointF(mark2X, mark2Y), col, row);
            this.SaveInfo();
        }

        private void btnStduyTemp_Click(object sender, EventArgs e)
        {
            CPKTools tools = new CPKTools();
            VisionImage align = new VisionImage();
            Form_Main.Instance.Extract_LearnGemetric(Form_Main.Instance.imageSet.Image, align);
            Algorithms.Copy(align, this.image_Edit.Image);
            // save image
            //System.AppDomain.CurrentDomain.BaseDirectory + "Configure\\
            align.WriteVisionFile(Variable.sPath_Configure + "CPK_Template.png");
        }

        private void btnFindTemp_Click(object sender, EventArgs e)
        {
            CPKTools tools = new CPKTools();
            VisionImage align = this.image_Edit.Image;

            VisionImage image = Form_Main.Instance.imageSet.Image;
            Roi roi = Form_Main.Instance.imageSet.Roi;
            short Score = 600;
            double MinR = -10;
            double MaxR = 10;
            short rtn = 0;
            Variable.CamReturn camReturn = new Variable.CamReturn();

            // 初步匹配
            rtn = Form_Main.Instance.CamDetect_SearchGeometric(image, align, roi, Score, 1, MinR, MaxR, 100, 100, 0, 25, ref camReturn, 0, 0);
            if (rtn != 0)
            {
                MessageBox.Show("寻找模板失败,请检查参数!!!");
            }

            // 记录ROI 的坐标
            if (roi.Count > 0)
            {
                RectangleContour rect = (RectangleContour)roi[0].Shape;
                // save rect
                string strRoi = string.Format("{0},{1},{2},{3}", rect.Top, rect.Left, rect.Width, rect.Height);
                this.cpkIni.IniWriteValue("vision", "TemplateRoi", strRoi);
            }
        }

        private void cbxCorner_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void chkUsePastePoint_CheckedChanged(object sender, EventArgs e)
        {
            this.cpkIni.IniWriteValue("main", "UsePaste", this.chkUsePastePoint.Checked.ToString());
        }

        private void btnSetOrg_Click(object sender, EventArgs e)
        {
            try
            {
                this.textOrgX.Text = Form_Main.Instance.X.Pos.ToString("F3");
                this.textOrgY.Text = Form_Main.Instance.Y.Pos.ToString("F3");
            }
            catch { }
        }

        private void btnSetMark2_Click(object sender, EventArgs e)
        {
            try
            {
                this.textMark2X.Text = Form_Main.Instance.X.Pos.ToString("f3");
                this.textMark2Y.Text = Form_Main.Instance.Y.Pos.ToString("f3");
            }
            catch { }
        }

        private void btnSetMark1_Click(object sender, EventArgs e)
        {
            try
            {
                this.textMark1X.Text = Form_Main.Instance.X.Pos.ToString("f3");
                this.textMark1Y.Text = Form_Main.Instance.Y.Pos.ToString("f3");
            }
            catch { }
        }


        /// <summary>
        /// 移动到
        /// </summary>
        /// <param name="x">输入框中X的值</param>
        /// <param name="y">输入框中Y的值</param>
        private void MoveTo(TextBox x, TextBox y)
        {
            try
            {
                PointF point = new PointF();
                point.X = float.Parse(x.Text);
                point.Y = float.Parse(y.Text);
                Form_Main.Instance.XYGoPos(point, this.variable);
            }
            catch { }
        }

        private void btnMoveOrg_Click(object sender, EventArgs e)
        {
            this.MoveTo(this.textOrgX, this.textOrgY);
        }

        private void btnMoveMark1_Click(object sender, EventArgs e)
        {
            this.MoveTo(this.textMark1X, this.textMark1Y);
        }

        private void btnMoveMark2_Click(object sender, EventArgs e)
        {
            this.MoveTo(this.textMark2X, this.textMark2Y);
        }

        private void btnFindCorner_Click(object sender, EventArgs e)
        {
            PointContour cross = new PointContour();
            LineContour line1 = new LineContour();
            LineContour line2 = new LineContour();
            CPKTools.FindCorss(this.cbxCorner.SelectedIndex, this.cpkIni, ref cross, ref line1, ref line2);
        }

        private void btnFindLine_Click(object sender, EventArgs e)
        {
            int selectSearchDir = 0;
            if (this.rBtn_L2R.Checked)
            {
                selectSearchDir = 0;
            }
            else if (this.rBtn_R2L.Checked)
            {
                selectSearchDir = 1;
            }
            else if (this.rBtn_U2D.Checked)
            {
                selectSearchDir = 2;
            }
            else
            {
                selectSearchDir = 3;
            }

            int selectMode = 0;
            if (this.rBtn_B2W.Checked)
            {
                selectMode = 0;
            }
            else
            {
                selectMode = 1;
            }

            RectangleContour roi = (RectangleContour)Form_Main.Instance.imageSet.Roi[0].Shape;

            VisionImage image = Form_Main.Instance.imageSet.Image;

            PointContour line_Start = new PointContour();
            PointContour line_End = new PointContour();

            short rtn = CPKTools.FitLine(image, roi, 40.0, selectSearchDir, selectMode, ref line_Start, ref line_End);

            if (rtn == 0)
            {
                string header = string.Format("vision{0}", this.cbxCorner.SelectedIndex);
                int selectLine = 0;

                if (this.rBtn_HLine1.Checked)
                {
                    selectLine = 0;
                }
                else if (this.rBtn_VLine1.Checked)
                {
                    selectLine = 1;
                }

                this.cpkIni.IniWriteValue(header, string.Format("SearchDirection{0}", selectLine), selectSearchDir.ToString());
                this.cpkIni.IniWriteValue(header, string.Format("EdgePolaritySearchMode{0}", selectLine), selectMode.ToString());

                string strRoi = string.Format("{0},{1},{2},{3}", roi.Left, roi.Top, roi.Width, roi.Height);
                this.cpkIni.IniWriteValue(header, string.Format("LineROI{0}", selectLine), strRoi);
            }
            else
            {
                MessageBox.Show("直线检测失败");
            }
        }

        private void btnHandleImage_Click(object sender, EventArgs e)
        {
            double gain = 1;
            double offset = 0;
            double cycle = 1;
            try
            {
                gain = double.Parse(this.tGainValue.Text);
                offset = double.Parse(this.tOffsetValue.Text);
                VisionImage image = Form_Main.Instance.imageSet.Image;
                for (int i = 0; i < cycle; ++i)
                {
                    image = Form_Main.Instance.GainOffset(image, gain, offset);
                }

                Algorithms.Copy(image, Form_Main.Instance.imageSet.Image);
                this.cpkIni.IniWriteValue("vision", "Gain", this.tGainValue.Text);
                this.cpkIni.IniWriteValue("vision", "Offset", this.tOffsetValue.Text);
                this.cpkIni.IniWriteValue("vision", "Cycle", this.tHanldeCycle.Text);
            }
            catch
            {
                MessageBox.Show("请输入正确数字", "提示");
            }

        }

        private void btnOptimize_Click(object sender, EventArgs e)
        {
            ExcelHelper tool = new ExcelHelper();
            double dx = double.Parse(this.tCPKXValue.Text);
            double dy = double.Parse(this.tCPKYValue.Text);
            this.cpkIni.IniWriteValue("main", "CPKXValue", this.tCPKXValue.Text);
            this.cpkIni.IniWriteValue("main", "CPKYValue", this.tCPKYValue.Text);

            if (tool.OptimizePasteByCPK(dx, dy, this.PastePath, this.cpkResult))
            {
                MessageBox.Show("优化成功!!");
            }
            else
            {
                MessageBox.Show("优化失败!!");
            }

            this.btnOptimize.Enabled = false;
        }

        private void btnFindCircle1_Click(object sender, EventArgs e)
        {
            if (Form_Main.Instance.imageSet.Roi.Count > 0 && Form_Main.Instance.imageSet.Roi[0].Shape.GetType() == typeof(RectangleContour))
            {
                short rMin = short.Parse(this.upCircleRmin.Text);
                short rMax = short.Parse(this.upCircleRmax.Text);
                PointContour center = new PointContour();
                double radius = 0;
                VisionImage image = Form_Main.Instance.GrabImage2View(Camera.CAM.Top);

                RectangleContour rect = (RectangleContour)Form_Main.Instance.imageSet.Roi[0].Shape;
                CPKTools.FindCircle(image, rect, rMin, rMax, ref center, ref radius, 0, 0, 0);
                this.upCurR.Text = radius.ToString();
            }
        }

        private Jig_ResultItem[,] CailbResult = null;

        private Thread Thd_Cailb = null;

        private void bStartChkCailb_Click(object sender, EventArgs e)
        {
            if (Thd_Cailb == null || !Thd_Cailb.IsAlive)
            {
                Thd_Cailb = new Thread(() =>
                {
                    #region 开始测量
                    try
                    {
                        Form_Main.Instance.StartGrabImage();

                        int row = int.Parse(this.tJigRow.Text); // 行
                        int col = int.Parse(this.tJigCol.Text); // 列
                        CailbResult = new Jig_ResultItem[row, col];
                        PointF basePoint = new PointF();
                        basePoint.X = float.Parse(this.tCailbBaseX.Text);
                        basePoint.Y = float.Parse(this.tCailbBaseY.Text);
                        double distX = float.Parse(this.tJigDx.Text);
                        double distY = float.Parse(this.tJigDy.Text);
                        RectangleContour rect = (RectangleContour)Form_Main.Instance.imageSet.Roi[0].Shape;
                        short rMin = short.Parse(this.upCircleRmin.Text);
                        short rMax = short.Parse(this.upCircleRmax.Text);
                        PointContour center = new PointContour();
                        double radius = 0;


                        double gain = 1;
                        double offset = 0;
                        double cycle = 1;

                        gain = double.Parse(this.tGainValue.Text);
                        offset = double.Parse(this.tOffsetValue.Text);
                        cycle = double.Parse(this.tHanldeCycle.Text);

                        for (int i = 0; i < row; i++)
                        {

                            for (int j = 0; j < col; j++)
                            {
                                Jig_ResultItem item = new Jig_ResultItem();
                                item.MachinePos = this.chkPoint[i * col + j];
                                //item.MachinePos.X = (float)(basePoint.X + distX * j);
                                //item.MachinePos.Y = (float)(basePoint.Y + distY * i);

                                // 移动到目标位
                                Form_Main.Instance.XYGoPosTillStop(20 * 1000, item.MachinePos, variable);

                                //Thread.Sleep(100);
                                // 获得上相机图像
                                VisionImage image = Form_Main.Instance.GrabImage2View(Camera.CAM.Top);

                                // 预处理
                                for (int time = 0; time < cycle; ++time)
                                {
                                    image = Form_Main.Instance.GainOffset(image, gain, offset);
                                }

                                Algorithms.Copy(image, Form_Main.Instance.imageSet.Image);

                                // 找圆
                                if (CPKTools.FindCircle(image, rect, rMin, rMax, ref center, ref radius, 0, 0, 0))
                                {
                                    item.Image_CircleCenter.X = (float)center.X;
                                    item.Image_CircleCenter.Y = (float)center.Y;
                                    item.Real_CircleCenter = Camera.CameraDefine.Instance[Camera.CAM.Top].ImagePt2WorldPt(item.MachinePos, center, 0);
                                }

                                image.Dispose();
                                CailbResult[i, j] = item;
                            }
                        }

                        // 计算 间距
                        for (int i = 0; i < row; i++)
                        {
                            for (int j = 0; j < col; j++)
                            {
                                if (CailbResult[i, j].Real_CircleCenter.X == 0 && CailbResult[i, j].Real_CircleCenter.Y == 0)
                                {
                                    CailbResult[i, j].RightDist = 0;
                                    CailbResult[i, j].DownDist = 0;
                                    continue;
                                }

                                if (j != 0 && j < col)// 右间距
                                {
                                    CailbResult[i, j].RightDist = CPKTools.GetDist(ref CailbResult[i, j].Real_CircleCenter, ref CailbResult[i, 0].Real_CircleCenter) - j * distX;
                                }

                                if (i != 0 && i < row)// 下间距
                                {
                                    CailbResult[i, j].DownDist = CPKTools.GetDist(ref CailbResult[i, j].Real_CircleCenter, ref CailbResult[0, j].Real_CircleCenter) - i * distY;
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    #endregion
                });

                Thd_Cailb.Start();
            }
        }

        private void bOutputCailb_Click(object sender, EventArgs e)
        {
            if (CailbResult != null)
            {
                #region 导出到Excel表
                int row = int.Parse(this.tJigRow.Text); // 行
                int col = int.Parse(this.tJigCol.Text); // 列
                double distX = float.Parse(this.tJigDx.Text);
                double distY = float.Parse(this.tJigDy.Text);
                // 计算 间距
                for (int i = 0; i < row; i++)
                {
                    for (int j = 0; j < col; j++)
                    {
                        if (CailbResult[i, j].Real_CircleCenter.X == 0 && CailbResult[i, j].Real_CircleCenter.Y == 0)
                        {
                            CailbResult[i, j].RightDist = 0;
                            CailbResult[i, j].DownDist = 0;
                            continue;
                        }

                        if (j != 0 && j < col)// 右间距
                        {
                            if (CailbResult[i, 0].Real_CircleCenter.X != 0 && CailbResult[i, 0].Real_CircleCenter.Y != 0)
                            {
                                CailbResult[i, j].RightDist = CPKTools.GetDist(ref CailbResult[i, j].Real_CircleCenter, ref CailbResult[i, 0].Real_CircleCenter) - j * distX;
                            }
                            else
                            {
                                CailbResult[i, j].RightDist = 0;
                            }
                        }

                        if (i != 0 && i < row)// 下间距
                        {
                            if (CailbResult[0, j].Real_CircleCenter.X != 0 && CailbResult[0, j].Real_CircleCenter.Y != 0)
                            {
                                CailbResult[i, j].DownDist = CPKTools.GetDist(ref CailbResult[i, j].Real_CircleCenter, ref CailbResult[0, j].Real_CircleCenter) - i * distY;
                            }
                            else
                            {
                                CailbResult[i, j].DownDist = 0;
                            }
                        }
                    }
                }

                CPKTools.SaveCailbReport(ref CailbResult, row, col);
                #endregion
            }
        }

        private void bSetCailbBase_Click(object sender, EventArgs e)
        {
            this.tCailbBaseX.Text = Form_Main.Instance.X.Pos.ToString("F3");
            this.tCailbBaseY.Text = Form_Main.Instance.Y.Pos.ToString("F3");
            
        }

        private void bMoveCailbBase_Click(object sender, EventArgs e)
        {
            try
            {
                PointF pot = new PointF();
                pot.X = float.Parse(this.tCailbBaseX.Text);
                pot.Y = float.Parse(this.tCailbBaseY.Text);
                Form_Main.Instance.XYGoPos(pot, this.variable);
            }
            catch
            {
                MessageBox.Show("输入数值不正确");
            }
        }

        private void bUpdateCailbParam_Click(object sender, EventArgs e)
        {
            this.SaveInfo();
        }

        //玻璃板校验2-yexing
        private void btnCreatePoint_Jig_Click(object sender, EventArgs e)
        {
            this.bStartChkCailb_Jig.Text = "开始测量";
            bRun = false;
            try
            {
                float orgX = float.Parse(this.textOrgX.Text);
                float orgY = float.Parse(this.textOrgY.Text);

                float mark1X = float.Parse(this.textMark1X.Text);
                float mark1Y = float.Parse(this.textMark1Y.Text);

                float mark2X = float.Parse(this.textMark2X.Text);
                float mark2Y = float.Parse(this.textMark2Y.Text);

                short col = short.Parse(this.textCol_Jig.Text);
                short row = short.Parse(this.textRow_Jig.Text);

                this.ChkPoint_Jig = CPKTools.ExpandtoAddPoints(new PointF(orgX, orgY), new PointF(mark1X, mark1Y), new PointF(mark2X, mark2Y), col, row);
                this.ChkPoint_Jig_Machine = new List<PointF>();
                this.ChkPoint_Jig_Act = new List<PointF>();
            }
            catch (Exception)//                            //+ "JigPicture\\"
            {

            }
        }

        private bool bRun = false;

        private void bStartChkCailb_Jig_Click(object sender, EventArgs e)
        {
            if(!bRun)
            {
                this.bStartChkCailb_Jig.Text = "正在测量...";
                ChkPoint_Jig_Act = new List<PointF>();
                bRun = true;
                double col = double.Parse(this.textCol_Jig.Text);
                double row = double.Parse(this.textRow_Jig.Text);
                double rMin = double.Parse(this.tMinR.Text);
                double rMax = double.Parse(this.tMaxR.Text);
                double gian = double.Parse(this.tGainValue.Text);
                double offset = double.Parse(this.tOffsetValue.Text);


                if (!Directory.Exists(Variable.sPath_SYS_Jig))
                {
                    Directory.CreateDirectory(Variable.sPath_SYS_Jig);
                }

                if (File.Exists(Variable.sPath_SYS_Jig + "Pt_Act.txt"))
                {
                    File.Delete(Variable.sPath_SYS_Jig + "Pt_Act.txt");
                }
                if (File.Exists(Variable.sPath_SYS_Jig + "Pt_Machine.txt"))
                {
                    File.Delete(Variable.sPath_SYS_Jig + "Pt_Machine.txt");
                }
                if (Thd_Cailb == null || !Thd_Cailb.IsAlive)
                {
                    Thd_Cailb = new Thread(() =>
                    {
                        Variable.CamReturn cam = new Variable.CamReturn();
                        Form_Main.Instance.StartGrabImage();

                        for (int i = 0; i < chkPoint_Jig.Count; i++)
                        {
                            #region 开始测量
                            try
                            {
                                if (!bRun)
                                {
                                    MessageBox.Show("停止侦测", "提示");
                                    return;
                                }

                                PointF Pt_Act = new PointF();
                                Pt_Act.X = (float)Math.Floor(i / col);
                                Pt_Act.Y = (float)(i - col * Pt_Act.X);
                                ChkPoint_Jig_Act.Add(Pt_Act);
                                PointF Pt_Machine = new PointF();
                                Form_Main.Instance.XYGoPosTillStop(20 * 1000, this.chkPoint_Jig[i], variable);
                                // 获得上相机图像
                                VisionImage image = Form_Main.Instance.GrabImage2View(Camera.CAM.Top);
                                image = Form_Main.Instance.GainOffset(image, gian, offset);
                                Algorithms.Copy(image, Form_Main.Instance.imageSet.Image);
                                PointContour centr = new PointContour();
                                double rad = 0;
                                if(VisionHelper.DetectCircle(Form_Main.Instance.imageSet.Image, Form_Main.Instance.imageSet.Roi, rMin, rMax, out centr, out rad))
                                {

                                    cam.X = centr.X;
                                    cam.Y = centr.Y;
                                    cam.IsOK = true;
                                    VisionHelper.ShowResult(Form_Main.Instance.imageSet, cam);
                                    Pt_Machine = Form_Main.Instance.Point2CCDCenter(this.chkPoint_Jig[i], new PointContour(cam.X, cam.Y), 0, 0);
                                }
                                else
                                {
                                    throw new Exception("寻找模板失败");
                                }
                                //if (VisionHelper.FindNccTemplate(Form_Main.Instance.imageSet.Image, Form_Main.Instance.imageSet.Roi, ModelID, 1, 0.5, 0, 0, 1, 1, ref cam))
                                //{
                                //    VisionHelper.ShowResult(Form_Main.Instance.imageSet, cam);
                                //    Pt_Machine = Form_Main.Instance.Point2CCDCenter(this.chkPoint_Jig[i], new PointContour(cam.X, cam.Y), 0);
                                //}
                                //else
                                //{
                                //    throw new Exception("寻找模板失败");
                                //}

                                ChkPoint_Jig_Act.Add(Pt_Machine);

                                StreamWriter sw = File.AppendText(Variable.sPath_SYS_Jig + "Pt_Act.txt");
                                sw.Write(Pt_Act.X.ToString("F3") + "," + Pt_Act.Y.ToString("F3") + "\r\n");
                                sw.Close();
                                StreamWriter sw1 = File.AppendText(Variable.sPath_SYS_Jig + "Pt_Machine.txt");
                                sw1.Write(Pt_Machine.X.ToString("F3") + "," + Pt_Machine.Y.ToString("F3") + "\r\n");
                                sw1.Close();
                            }
                            catch (Exception ex)
                            {
                                if (MessageBox.Show($"侦测失败:{ex.Message} 是否重新识别 Y/N ", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                                {
                                    i--;
                                    continue;
                                }
                                else
                                {
                                    MessageBox.Show("玻璃杯校验停止!!!");
                                    bRun = false;
                                    return;
                                }
                            }
                            #endregion
                        }
                    });

                    Thd_Cailb.Start();
                }
            }
            else
            {
                if(MessageBox.Show("是否停止测量", "警告", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    this.bStartChkCailb_Jig.Text = "开始测量";
                    bRun = false;
                }
            }
        }

        private void bOutputCailb_Jig_Click(object sender, EventArgs e)
        {

        }
        private HTuple ModelID;
        private void btnStduyTemp2_Click(object sender, EventArgs e)
        {
            VisionHelper.CreatNCCTemplate(Form_Main.Instance.imageSet.Image, Form_Main.Instance.imageSet.Roi, out ModelID);
            Form_Main.Instance.Extract_LearnPttern(Form_Main.Instance.imageSet.Image, image_Edit2.Image);
        }

        private void btnFindTemp2_Click(object sender, EventArgs e)
        {
            Variable.CamReturn cam = new Variable.CamReturn();
            if (VisionHelper.FindNccTemplate(Form_Main.Instance.imageSet.Image, Form_Main.Instance.imageSet.Roi, ModelID, 1, 0.6, 0, 0, 1, 1, ref cam))
            {
                VisionHelper.ShowResult(Form_Main.Instance.imageSet, cam);
                btnFindTemp2.BackColor = Color.Transparent;
            }
            else
            {
                btnFindTemp2.BackColor = Color.Red;
            }
        }

        private void bExport_Click(object sender, EventArgs e)
        {
            IniFile JigConfig = new IniFile(Variable.sPath_SYS_Jig + "\\JigConfig.ini");
            int col = short.Parse(this.textCol_Jig.Text);
            int row = short.Parse(this.textRow_Jig.Text);
            double colDist = double.Parse(this.tXDist.Text);
            double rowDist = double.Parse(this.tYDist.Text);

            JigConfig.IniWriteNumber("Config", "XCount", col);
            JigConfig.IniWriteNumber("Config", "YCount", row);
            JigConfig.IniWriteNumber("Config", "XDist", colDist);
            JigConfig.IniWriteNumber("Config", "YDist", rowDist);
            GlassHelper.galcali.LoadJigData(Variable.sPath_SYS_Jig);
        }

        private void fmAutoCPKTest_Load(object sender, EventArgs e)
        {

        }

        private void bDetectCircle_Click(object sender, EventArgs e)
        {
            if (Form_Main.Instance.imageSet.Roi.Count > 0 && Form_Main.Instance.imageSet.Roi[0].Shape.GetType() == typeof(RectangleContour))
            {
                short rMin = short.Parse(this.tMinR.Text);
                short rMax = short.Parse(this.tMaxR.Text);
                PointContour center = new PointContour();
                double radius = 0;
                VisionImage image = Form_Main.Instance.GrabImage2View(Camera.CAM.Top);

                RectangleContour rect = (RectangleContour)Form_Main.Instance.imageSet.Roi[0].Shape;
                CPKTools.FindCircle(image, rect, rMin, rMax, ref center, ref radius, 0, 0, 0);
                this.lR.Text = radius.ToString();
            }
        }
    }
}
