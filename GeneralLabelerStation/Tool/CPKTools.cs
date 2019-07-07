using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;
using System.Windows.Forms;
using NationalInstruments.Vision;
using NationalInstruments.Vision.Analysis;
using NationalInstruments.Vision.Acquisition.Imaqdx;
using System.Drawing;
using System.Data;
using System.Collections.ObjectModel;
using GeneralLabelerStation;
using System.Diagnostics;
using GeneralLabelerStation.Camera;

namespace GeneralLabelerStation.Tools
{

    public class Jig_ResultItem
    {
        /// <summary>
        /// 在图像中 圆心的坐标
        /// </summary>
        public PointF Image_CircleCenter = new PointF(0, 0);

        /// <summary>
        /// 当前机台的坐标
        /// </summary>
        public PointF MachinePos = new PointF(0, 0);

        /// <summary>
        /// 圆心的机台坐标
        /// </summary>
        public PointF Real_CircleCenter = new PointF(0, 0);

        /// <summary>
        /// 右间距
        /// </summary>
        public double RightDist = 0;

        /// <summary>
        /// 下间距
        /// </summary>
        public double DownDist = 0;
    }

    /// <summary>
    /// CPK 数据项
    /// </summary>
    public class CPK_ResultItem
    {
        private double x1 = 0.0;
        private double x2 = 0.0;
        private double y1 = 0.0;
        private double y2 = 0.0;
        private PointF pos = new PointF();
        private int usedNozzle = 0;

        /// <summary>
        /// 拍照位
        /// </summary>
        public PointF Pos
        {
            set { this.pos = value; }
            get { return this.pos; }
        }

        /// <summary>
        /// 使用吸嘴
        /// </summary>
        public int UsedNozzle
        {
            set { this.usedNozzle = value; }
            get { return this.usedNozzle; }
        }

        /// <summary>
        /// Label 顶点到 边的X方向距离
        /// </summary>
        public double X1
        {
            get { return x1; }
            set { this.x1 = value; }
        }

        /// <summary>
        /// Label 顶点到 边的Y方向距离
        /// </summary>
        public double Y1
        {
            get { return y1; }
            set { this.y1 = value; }
        }

        /// <summary>
        /// Label 竖线末尾点 到 X方向距离
        /// </summary>
        public double X2
        {
            get { return this.x2; }
            set { this.x2 = value; }
        }

        /// <summary>
        /// Label 竖线末尾点 到 Y方向距离
        /// </summary>
        public double Y2
        {
            get { return this.y2; }
            set { this.y2 = value; }
        }
    }
    /// <summary>
    /// CPK 计算助手
    /// </summary>
    public class CPKTools
    {
        /// <summary>
        /// 存储 CPK 数据成 Excel 表格
        /// </summary>
        /// <param name="data">CPK 数据</param>
        public static void SaveReport(List<CPK_ResultItem> data)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Title = "[CPK数据]储存为";
            saveDialog.FileName = DateTime.Today.ToString("yyyy-mm-dd") + "_CPK";
            saveDialog.Title = "图片另存为";
            saveDialog.FileName = "CPK Data.xls";
            saveDialog.Filter = "表格(*.xls)|所有文件(*.*)";
            saveDialog.RestoreDirectory = true;
            if (saveDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            string path = saveDialog.FileName;
            ExcelHelper helper = new ExcelHelper();

            helper.ExcelToDataTable(System.AppDomain.CurrentDomain.BaseDirectory + "Configure\\CPK DATA.xls", path, data);
        }

        public static void SaveCailbReport(ref Jig_ResultItem[,] data, int jig_row, int jig_col)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Title = "[CPK数据]储存为";
            saveDialog.FileName = DateTime.Today.ToString("yyyy-mm-dd") + "_CPK";
            saveDialog.Title = "图片另存为";
            saveDialog.FileName = "Jig Cailb.xls";
            saveDialog.Filter = "表格(*.xls)|所有文件(*.*)";
            saveDialog.RestoreDirectory = true;
            if (saveDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            string path = saveDialog.FileName;
            ExcelHelper helper = new ExcelHelper();

            helper.CailbResultToExcel(Variable.sPath_Configure + "JigCailb.xls", path, ref data, jig_row, jig_col);

        }

        /// <summary>
        /// 寻找模板
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        public static bool FindTemplate(VisionImage image)
        {
            return false;
        }

        /// <summary>
        /// 扩展点
        /// </summary>
        /// <param name="Points2Expand">原有点</param>
        /// <param name="Origin">基础点</param>
        /// <param name="XCoord">X间距</param>
        /// <param name="YCoord">Y间距</param>
        /// <param name="col">列数</param>
        /// <param name="row">行数</param>
        /// <returns></returns>
        public static List<PointF> ExpandtoAddPoints(PointF Origin, PointF XCoord, PointF YCoord, short col, short row)
        {
            List<PointF> Expand2AddPoints = new List<PointF>();
            PointF TempX = new PointF();
            PointF TempY = new PointF();


            for (int j = 0; j < row; j++)
            {
                for (int i = 0; i < col; i++)
                {

                    PointF point = new PointF();
                    if (col == 1)
                    {
                        TempX.X = Origin.X;
                        TempX.Y = Origin.Y;
                    }
                    else
                    {
                        TempX.X = (XCoord.X - Origin.X) * i / (col - 1) + Origin.X;
                        TempX.Y = (XCoord.Y - Origin.Y) * i / (col - 1) + Origin.Y;
                    }

                    if (row == 1)
                    {
                        TempY.X = Origin.X;
                        TempY.Y = Origin.Y;
                    }
                    else
                    {
                        TempY.X = (YCoord.X - Origin.X) * j / (row - 1) + Origin.X;
                        TempY.Y = (YCoord.Y - Origin.Y) * j / (row - 1) + Origin.Y;
                    }

                    point.X = TempX.X + TempY.X - Origin.X;
                    point.Y = TempX.Y + TempY.Y - Origin.Y;

                    Expand2AddPoints.Add(point);
                }
            }
            return Expand2AddPoints;
        }


        public static short FitLine(VisionImage image, RectangleContour roi, double EdgeStength, int searchDir, int edgeMode, ref PointContour PointStart, ref PointContour PointEnd)//视觉抓边算法
        {
            SearchDirection SearchDirection = SearchDirection.BottomToTop;
            EdgePolaritySearchMode EdgeMode = EdgePolaritySearchMode.Falling;

            if (searchDir == 0)
            {
                SearchDirection = SearchDirection.LeftToRight;
            }
            else if (searchDir == 1)
            {
                SearchDirection = SearchDirection.RightToLeft;
            }
            else if (searchDir == 2)
            {
                SearchDirection = SearchDirection.TopToBottom;
            }
            else if (searchDir == 3)
            {
                SearchDirection = SearchDirection.BottomToTop;
            }

            if (edgeMode == 0)
            {
                EdgeMode = EdgePolaritySearchMode.Rising;
            }
            else if (edgeMode == 1)
            {
                EdgeMode = EdgePolaritySearchMode.Falling;
            }

            if (roi != null)
            {
                VisionImage imageTemp = new VisionImage();
                Algorithms.Extract(image, imageTemp, roi);
                Algorithms.ImageToImage(imageTemp, image, new PointContour(roi.Left, roi.Top));



                #region 抓边参数
                StraightEdgeOptions vaStraightEdgeOptions = new StraightEdgeOptions();
                vaStraightEdgeOptions.NumberOfLines = 1;
                vaStraightEdgeOptions.SearchMode = StraightEdgeSearchMode.FirstRakeEdges;
                vaStraightEdgeOptions.ScoreRange = new Range(0, 1024);
                vaStraightEdgeOptions.Orientation = 0;
                vaStraightEdgeOptions.AngleRange = 90;
                vaStraightEdgeOptions.AngleTolerance = 1;
                vaStraightEdgeOptions.StepSize = 3;
                vaStraightEdgeOptions.MinimumSignalToNoiseRatio = 0;
                vaStraightEdgeOptions.MinimumCoverage = 25;
                vaStraightEdgeOptions.HoughIterations = 5;
                // Set EdgeOptions
                EdgeOptions vaEdgeOptions = new EdgeOptions();
                vaEdgeOptions.Polarity = EdgeMode;
                vaEdgeOptions.KernelSize = 7;
                vaEdgeOptions.Width = 3;
                vaEdgeOptions.MinimumThreshold = EdgeStength;
                vaEdgeOptions.InterpolationType = InterpolationMethod.ZeroOrder;
                vaEdgeOptions.ColumnProcessingMode = ColumnProcessingMode.Average;
                #endregion

                try
                {
                    StraightEdgeReport report1 = Algorithms.StraightEdge2(image, roi.ConvertToRoi(), SearchDirection, vaEdgeOptions, vaStraightEdgeOptions, false);
                    if (report1.StraightEdges.Count > 0)
                    {
                        PointStart = report1.StraightEdges[0].StraightEdge.Start;
                        PointEnd = report1.StraightEdges[0].StraightEdge.End;
                        //image.Overlays.Default.Clear();
                        image.Overlays.Default.AddLine(new LineContour(report1.StraightEdges[0].StraightEdge.Start, report1.StraightEdges[0].StraightEdge.End));
                        return 0;
                    }
                }
                catch { }
            }

            PointStart.X = 0;
            PointStart.Y = 0;
            PointEnd.X = 0;
            PointEnd.Y = 0;
            return 1;
        }


        /// <summary>
        /// 第几条线
        /// </summary>
        /// <param name="lineNum">线号</param>
        /// <param name="cpkIni">配置信息</param>
        /// <param name="cross">输出 角点</param>
        /// <param name="line1">输出 水平线</param>
        /// <param name="line2">输出 垂直线</param>
        /// <returns></returns>
        public static bool FindCorss(int lineNum, IniFile cpkIni, ref PointContour cross, ref LineContour line1, ref LineContour line2)
        {
            string header = string.Format("vision{0}", lineNum);
            int selectSearchDir = 0;
            int selectMode = 0;
            VisionImage image = Form_Main.Instance.imageSet.Image;


            List<LineContour> lines = new List<LineContour>();
            for (int i = 0; i < 2; i++)
            {
                selectSearchDir = int.Parse(cpkIni.IniReadValue(header, string.Format("SearchDirection{0}", i)));
                selectMode = int.Parse(cpkIni.IniReadValue(header, string.Format("EdgePolaritySearchMode{0}", i)));
                string strRoi = cpkIni.IniReadValue(header, string.Format("LineROI{0}", i));
                string[] array = strRoi.Split(',');

                RectangleContour rect = new RectangleContour(int.Parse(array[0]), int.Parse(array[1]), int.Parse(array[2]), int.Parse(array[3]));
                PointContour start = new PointContour();
                PointContour end = new PointContour();
                int rtn = CPKTools.FitLine(image, rect, 40, selectSearchDir, selectMode, ref start, ref end);
                if (rtn == 0)
                {
                    lines.Add(new LineContour(start, end));
                }
                else
                {
                    return false;
                }
            }

            cross = Algorithms.FindIntersectionPoint(lines[0], lines[1]);
            line1 = lines[0];
            line2 = lines[1];

            // show
            Form_Main.Instance.imageSet.Image.Overlays.Default.AddLine(line1, Rgb32Value.RedColor);
            Form_Main.Instance.imageSet.Image.Overlays.Default.AddLine(line2, Rgb32Value.RedColor);
            return true;
        }

        /// <summary>
        /// 获得一个位置的CPK数据
        /// </summary>
        /// <param name="point">位置</param>
        /// <param name="cpkIni">配置信息</param>
        /// <param name="variable">速度</param>
        /// <param name="result">CPK 数据</param>
        /// <returns></returns>
        public static bool GetCPK(IniFile cpkIni, Variable.VelMode variable, double gain, double offset, int cycle, ref CPK_ResultItem result)
        {
            if (result == null) return false;

            // 移动到目标位
            Form_Main.Instance.XYGoPosTillStop(20 * 1000, result.Pos, variable);

            Thread.Sleep(100);
            // 获得上相机图像
            VisionImage image = Form_Main.Instance.GrabImage2View(Camera.CAM.Top);

            if (image == null)
            {
                return false;
            }

            for (int i = 0; i < cycle; ++i)
            {
                image = Form_Main.Instance.GainOffset(image, gain, offset);
            }

            // 初定位 寻找模板

            try
            {
                // NI 视觉检测方法
                List<PointContour> crossList = new List<PointContour>();
                List<LineContour> lineList = new List<LineContour>();
                for (int i = 0; i < 4; ++i) // 找4个角
                {
                    PointContour cross = new PointContour();
                    LineContour line1 = new LineContour(); // 水平线
                    LineContour line2 = new LineContour(); // 垂直线

                    bool rtn = false;
                    for (int retry = 0; retry < 3; retry++)
                    {
                        rtn = FindCorss(i, cpkIni, ref cross, ref line1, ref line2);
                        if (rtn)
                        {
                            break;
                        }
                    }

                    if (!rtn) { return false; }

                    //crossList.Add(cross);

                    lineList.Add(line1);
                    lineList.Add(line2);

                    PointContour center1 = new PointContour((line1.Start.X + line1.End.X) / 2.0, (line1.Start.Y + line1.End.Y) / 2.0);
                    PointContour center2 = new PointContour((line2.Start.X + line2.End.X) / 2.0, (line2.Start.Y + line2.End.Y) / 2.0);
                    crossList.Add(center1);
                    crossList.Add(center2);
                }

                if (lineList.Count != 8) return false;

                LineContour orgHLine = lineList[0]; // 基准水平线
                LineContour orgVLine = lineList[1]; // 基准垂直线

                //PointContour top =  crossList[1]; // 顶点
                //PointContour leftBottom = crossList[2]; // 左下角
                //PointContour rightTop = crossList[3]; // 右上角
                PointContour topV = crossList[3];
                PointContour topH = crossList[2];
                PointContour leftBottom = crossList[5];
                PointContour rightTop = crossList[6];

                PointContour cross1 = Algorithms.FindIntersectionPoint(orgVLine, new LineContour(topV, new PointContour(topV.X + 10, topV.Y)));
                PointContour cross2 = Algorithms.FindIntersectionPoint(orgHLine, new LineContour(topH, new PointContour(topH.X, topH.Y + 10)));
                PointContour cross3 = Algorithms.FindIntersectionPoint(orgVLine, new LineContour(leftBottom, new PointContour(leftBottom.X + 10, leftBottom.Y)));
                PointContour cross4 = Algorithms.FindIntersectionPoint(orgHLine, new LineContour(rightTop, new PointContour(rightTop.X, rightTop.Y + 10)));

                PointF xy = new PointF();
                xy.X = (float)Form_Main.Instance.X.Pos;
                xy.Y = (float)Form_Main.Instance.Y.Pos;

                PointF tv = CameraDefine.Instance[CAM.Top].ImagePt2WorldPt(xy, topV);
                PointF th = CameraDefine.Instance[CAM.Top].ImagePt2WorldPt(xy, topH);
                PointF l = CameraDefine.Instance[CAM.Top].ImagePt2WorldPt(xy, leftBottom);
                PointF r = CameraDefine.Instance[CAM.Top].ImagePt2WorldPt(xy, rightTop);
                PointF c1 = CameraDefine.Instance[CAM.Top].ImagePt2WorldPt(xy, cross1);
                PointF c2 = CameraDefine.Instance[CAM.Top].ImagePt2WorldPt(xy, cross2);
                PointF c3 = CameraDefine.Instance[CAM.Top].ImagePt2WorldPt(xy, cross3);
                PointF c4 = CameraDefine.Instance[CAM.Top].ImagePt2WorldPt(xy, cross4);

                result.X1 = Math.Abs(tv.X - c1.X);
                result.Y1 = Math.Abs(th.Y - c2.Y);
                result.X2 = Math.Abs(l.X - c3.X);
                result.Y2 = Math.Abs(r.Y - c4.Y);
                Form_Main.Instance.imageSet.Image.Overlays.Default.AddLine(new LineContour(cross1, topV));
                Form_Main.Instance.imageSet.Image.Overlays.Default.AddLine(new LineContour(cross2, topH));
                Form_Main.Instance.imageSet.Image.Overlays.Default.AddLine(new LineContour(cross3, leftBottom));
                Form_Main.Instance.imageSet.Image.Overlays.Default.AddLine(new LineContour(cross4, rightTop));

                Form_Main.Instance.imageSet.Image.Overlays.Default.AddText("X1: " + result.X1.ToString(), topV, Rgb32Value.BlueColor, new OverlayTextOptions("Consolas", 24));
                Form_Main.Instance.imageSet.Image.Overlays.Default.AddText("Y1: " + result.Y1.ToString(), topH, Rgb32Value.BlueColor, new OverlayTextOptions("Consolas", 24));
                Form_Main.Instance.imageSet.Image.Overlays.Default.AddText("X2: " + result.X2.ToString(), leftBottom, Rgb32Value.BlueColor, new OverlayTextOptions("Consolas", 24));
                Form_Main.Instance.imageSet.Image.Overlays.Default.AddText("Y2: " + result.Y2.ToString(), rightTop, Rgb32Value.BlueColor, new OverlayTextOptions("Consolas", 24));
            }
            catch { }

            return false;
        }

        /// <summary>
        /// 找到一个圆
        /// </summary>
        /// <param name="image">图片</param>
        /// <param name="rect">ROI</param>
        /// <param name="minr">最小圆半径</param>
        /// <param name="maxr">最大圆半径</param>
        /// <param name="center">圆心</param>
        /// <param name="radius">半径</param>
        /// <param name="gain">预处理参数</param>
        /// <param name="offset">预处理参数</param>
        /// <param name="cycle">预处理参数</param>
        /// <returns>找到/没找到</returns>
        public static bool FindCircle(VisionImage image, RectangleContour rect, short minr, short maxr, ref PointContour center, ref double radius, double gain, double offset, int cycle)
        {
            if (image == null)
            {
                return false;
            }

            for (int i = 0; i < cycle; i++)
            {
                image = Form_Main.Instance.GainOffset(image, gain, offset);
            }

            Roi roi = rect.ConvertToRoi();
            short rtn = 0;

            try
            {
                rtn = Form_Main.Instance.CamDetect_Circle(image, roi, minr, maxr, ref center, ref radius);

                if (rtn != 0) return false;
            }
            catch
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 计算两个点之间的间距
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static double GetDist(ref PointF a, ref PointF b)
        {
            return Math.Sqrt(Math.Pow((b.X - a.X), 2) + Math.Pow((b.Y - a.Y), 2));
        }

        public static bool GetCailbResult(string filePath, ref Jig_ResultItem[,] items, int jig_row, int jig_col)
        {
            ExcelHelper helper = new ExcelHelper();
            return helper.GetCailbResult(filePath, ref items, jig_row, jig_col);
        }


        /// <summary>
        /// 获得真实的机台坐标
        /// </summary>
        /// <param name="curPos">现在的坐标</param>
        /// <param name="cailb">标定参数</param>
        /// <returns>真实坐标</returns>
        public static PointF GetRealMachinePos(PointF curPos)
        {

            if (CurMachineCailb != null)
            {
                try
                {
                    int jig_col = 97;
                    int jig_row = 77;
                    PointF real = new PointF();
                    int col = (int)(Math.Abs(curPos.X - CurMachineCailb[0, 0].MachinePos.X) / 5);
                    double dx = Math.Abs(curPos.X - CurMachineCailb[0, 0].MachinePos.X) - col * 5;
                    if (dx >= 3 && col < jig_col - 1)
                    {
                        col++;
                    }

                    int row = (int)(Math.Abs(curPos.Y - CurMachineCailb[0, 0].MachinePos.Y) / 5);
                    double dy = Math.Abs(curPos.Y - CurMachineCailb[0, 0].MachinePos.Y) - row * 5;
                    if (dy >= 3 && row < jig_row - 1)
                    {
                        row++;
                    }


                    if (row >= jig_row || col > jig_col)
                    {
                        return curPos;
                    }
                    else
                    {
                        real.X = curPos.X + (float)CurMachineCailb[row, col].RightDist;
                        real.Y = curPos.Y - (float)CurMachineCailb[row, col].DownDist;
                    }


                    return real;
                }
                catch { }
            }
            return curPos;
        }

        public static Jig_ResultItem[,] CurMachineCailb = null;
    }
}
