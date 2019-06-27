using NationalInstruments.Vision;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NationalInstruments.Vision.WindowsForms;
using NationalInstruments.Vision.Analysis;
using NationalInstruments.Vision.Acquisition.Imaqdx;
//using HalconDotNet;
using System.Diagnostics;
using HalconDotNet;
using System.Drawing;

namespace GeneralLabelerStation.Tool
{
    /// <summary>
    /// 将 标准机中的算法封装到该目的
    /// </summary>
    public class VisionHelper
    {
        /// <summary>
        /// 获得图像清晰度
        /// </summary>
        /// <param name="image">图像</param>
        /// <param name="value">清晰度</param>
        public static void GetImageDefinitionValue(string filename, out double value)
        {
            value = 0;
            HTuple width, height;
            HObject part1 = null;
            HObject part2 = null;
            HObject subImage = null;
            HObject image = null;

            HTuple Mean, Deviation;

            try
            {

                HOperatorSet.ReadImage(out image, filename);
                //公式 D（f）= ΣxΣy(f(x + 2, y) - f(x, y)) ^ 2
                HOperatorSet.GetImageSize(image, out width, out height);
                HOperatorSet.CropPart(image, out part1, 0, 0, width, height); // f(x+2,y)
                HOperatorSet.ConvertImageType(part1, out part1, "real");

                HOperatorSet.CropPart(image, out part2, 2, 0, width, height); // f(x,y)
                HOperatorSet.ConvertImageType(part2, out part2, "real");

                HOperatorSet.SubImage(part1, part2, out subImage, 1, 0); // f(x+2,y)-f(x,y)

                HOperatorSet.MultImage(subImage, subImage, out subImage, 1, 0);// ^2

                HOperatorSet.Intensity(subImage, subImage, out Mean, out Deviation);

                value = Mean.D;

                image?.Dispose();
                part1?.Dispose();
                part2?.Dispose();
                subImage?.Dispose();
            }
            catch (HalconException ex)
            {
                Debug.WriteLine(ex.Message);
                part1?.Dispose();
                part2?.Dispose();
                subImage?.Dispose();
                image?.Dispose();
            }
        }

        /// <summary>
        /// 创建NCC模板
        /// </summary>
        /// <param name="img">图像</param>
        /// <param name="Roi">ROI</param>
        /// <param name="ModeID">NCC模板</param>
        /// <returns></returns>
        public static bool CreatNCCTemplate(VisionImage img, Roi Roi, out HTuple ModeID)
        {
            img.Type = ImageType.U8;
            ModeID = null;
            HObject Himage = null, HRoi = null;
            HObject imgreduced = null;
            try
            {
                HOperatorSet.GenImage1(out Himage, "byte", img.Width, img.Height, img.StartPtr);
                HOperatorSet.GenRectangle1(out HRoi, ((RectangleContour)Roi[0].Shape).Top, ((RectangleContour)Roi[0].Shape).Left, ((RectangleContour)Roi[0].Shape).Top + ((RectangleContour)Roi[0].Shape).Height, ((RectangleContour)Roi[0].Shape).Left + ((RectangleContour)Roi[0].Shape).Width);
                HOperatorSet.ReduceDomain(Himage, HRoi, out imgreduced);
                HOperatorSet.CreateNccModel(imgreduced, "auto", 0, 0, "auto", "use_polarity", out ModeID);
                Himage.Dispose();
                HRoi.Dispose();
                imgreduced.Dispose();
                return true;
            }
            catch (Exception)
            {
                Himage?.Dispose();
                imgreduced?.Dispose();
                return false;
            }
        }

        /// <summary>
        /// NCC模板匹配-Roi-HObject
        /// </summary>
        /// <param name="img"></param>
        /// <param name="Roi"></param>
        /// <param name="ModelID"></param>
        /// <param name="MaxReturns"></param>
        /// <param name="MinScore"></param>
        /// <param name="MinAngle"></param>
        /// <param name="MaxAngle"></param>
        /// <param name="MinScal"></param>
        /// <param name="MaxScal"></param>
        /// <param name="matchresults"></param>
        /// <returns></returns>
        public static bool FindNccTemplate(VisionImage img, Roi Roi, HTuple ModelID, int MaxReturns, double MinScore, double MinAngle, double MaxAngle, double MinScal, double MaxScal, ref Variable.CamReturn camreturn)//, double MaxOverlap, double Greediness)
        {
            img.Type = ImageType.U8;
            HObject Himage = null, HRoi = null;
            HObject imgreduced = null;
            HTuple FindRow, FindColumn, FindAngle, FindScore;
            try
            {
                img.BorderWidth = 0;
                HOperatorSet.GenImage1(out Himage, "byte", img.Width, img.Height, img.StartPtr);
                //HOperatorSet.WriteImage(Himage, "bmp", 0, "D:\\1.bmp");
                HOperatorSet.GenRectangle1(out HRoi, ((RectangleContour)Roi[0].Shape).Top, ((RectangleContour)Roi[0].Shape).Left, ((RectangleContour)Roi[0].Shape).Top + ((RectangleContour)Roi[0].Shape).Height, ((RectangleContour)Roi[0].Shape).Left + ((RectangleContour)Roi[0].Shape).Width);
                HOperatorSet.ReduceDomain(Himage, HRoi, out imgreduced);//image_rectified
                HOperatorSet.FindNccModel(imgreduced, ModelID, (new HTuple(MinAngle)).TupleRad(), (new HTuple(MaxAngle)).TupleRad(), MinScore, MaxReturns, 0.5, "true",
                0, out FindRow, out FindColumn, out FindAngle, out FindScore);
                if (FindRow.Length == 0)
                {
                    camreturn.X = 0;
                    camreturn.Y = 0;
                    camreturn.Angle = 0;
                    camreturn.IsOK = false;

                    Himage.Dispose();
                    HRoi.Dispose();
                    imgreduced.Dispose();
                    return false;
                }
                else
                {
                    camreturn.X = float.Parse(FindColumn[0].D.ToString());
                    camreturn.Y = float.Parse(FindRow[0].D.ToString());
                    camreturn.Angle = FindAngle[0].D;
                    camreturn.IsOK = true;

                    Himage.Dispose();
                    HRoi.Dispose();
                    imgreduced.Dispose();
                    return true;
                }
            }
            catch (Exception a)
            {
                //PutInLog("玻璃板错误：" + a.Message);
                camreturn.X = 0;
                camreturn.Y = 0;
                camreturn.Angle = 0;
                camreturn.IsOK = false;
                //HOperatorSet.ClearObj(Himage);
                //HOperatorSet.ClearObj(HRoi);
                //HOperatorSet.ClearObj(imgreduced);
                if (Himage != null)
                    Himage.Dispose();

                if (HRoi != null)
                    HRoi.Dispose();

                if (imgreduced != null)
                    imgreduced.Dispose();

                return false;
            }

        }

        public bool SaveNccTemp(HTuple ModelID, string Path)
        {
            try
            {
                HOperatorSet.WriteNccModel(ModelID, Path);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public static bool ReadNccTemp(out HTuple ModelID, string Path)
        {
            ModelID = null;
            try
            {
                HOperatorSet.ReadNccModel(Path, out ModelID);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        //Circle****************************************************************************************
        /// <summary>
        /// 找圆-使用ROI-RectangleRegion
        /// </summary>
        /// <param name="img">图片</param>
        /// <param name="rectRoi">ROI</param>
        /// <param name="MinRadius">最小半径</param>
        /// <param name="MaxRadius">最大半径</param>
        /// <param name="Center">中心点</param>
        /// <param name="Radius">半径</param>
        /// <param name="ho_Contcircle">圆轮廓</param>
        /// <param name="ho_cross">圆中心</param>
        /// <returns></returns>
        public static bool DetectCircle(HObject img, RectangleContour rectRoi, double MinRadius, double MaxRadius, out PointF Center, out double Radius, out HObject ho_Contcircle, out HObject ho_cross)
        {
            //*************************************************************************************************
            ho_Contcircle = null;
            ho_cross = null;
            Center = new PointF();
            Radius = 0;
            HObject ho_ImageROI, Roi, hCircles, countour;
            HOperatorSet.GenEmptyObj(out ho_ImageROI);
            HOperatorSet.GenEmptyObj(out hCircles);
            HOperatorSet.GenEmptyObj(out countour);
            HOperatorSet.GenRectangle1(out Roi, rectRoi.Left, rectRoi.Top, rectRoi.Left + rectRoi.Height, rectRoi.Width);
            //*************************************************************************************************
            HTuple hv_numbers, CoutourType;//返回拟合圆个数
            try
            {
                HOperatorSet.ReduceDomain(img, Roi, out ho_ImageROI);   //获取图像区域 形态学处理后
                HOperatorSet.EdgesSubPix(ho_ImageROI, out ho_ImageROI, "canny", 1.5, 50, 75);
                HOperatorSet.SegmentContoursXld(ho_ImageROI, out ho_ImageROI, "lines_circles", 5, 4, 2);
                HOperatorSet.SelectShapeXld(ho_ImageROI, out ho_ImageROI, "circularity", "and", 0.5, 1);
                HOperatorSet.SelectShapeXld(ho_ImageROI, out ho_ImageROI, "outer_radius", "and", MinRadius, MaxRadius);
                HOperatorSet.CountObj(ho_ImageROI, out hv_numbers);
                if (hv_numbers.D != 0)
                {
                    for (int i = 0; i < hv_numbers.D; i++)
                    {
                        HOperatorSet.SelectObj(ho_ImageROI, out countour, i);
                        HOperatorSet.GetContourAttribXld(countour, "cont_approx", out CoutourType);
                        if (CoutourType.D != -1)//-1=line 0- 1-circle
                        {
                            HOperatorSet.ConcatObj(hCircles, countour, out hCircles);
                        }
                    }
                    HOperatorSet.CountObj(hCircles, out hv_numbers);
                    if (hv_numbers.D == 0)
                    {
                        Roi.Dispose();
                        ho_ImageROI.Dispose();
                        hCircles.Dispose();
                        countour.Dispose();
                        return false;
                    }
                    HTuple hv_Row, hv_Column, hv_Radius, hv_startPhi, hv_endPhi, hv_PointOrder;
                    HOperatorSet.FitCircleContourXld(hCircles, "geometric", -1, 2, 0, 3, 2, out hv_Row, out hv_Column, out hv_Radius, out hv_startPhi, out hv_endPhi, out hv_PointOrder);
                    hv_numbers = new HTuple(hv_Row.TupleLength());
                    if (hv_numbers.D == 0)
                    {
                        Roi.Dispose();
                        ho_ImageROI.Dispose();
                        hCircles.Dispose();
                        countour.Dispose();
                        return false;
                    }
                    Center.X = (float)(hv_Column[0].D);
                    Center.Y = (float)(hv_Row[0].D);
                    Radius = hv_Radius[0].D;
                    HOperatorSet.GenCircleContourXld(out ho_Contcircle, hv_Row[0], hv_Column[0], hv_Radius[0], 0, 6.28, "positive", 1);
                    HOperatorSet.GenCrossContourXld(out ho_cross, hv_Row[0], hv_Column[0], 10, 0);
                    Roi.Dispose();
                    ho_ImageROI.Dispose();
                    hCircles.Dispose();
                    countour.Dispose();
                    return true;
                }
                else
                {
                    Roi.Dispose();
                    ho_ImageROI.Dispose();
                    hCircles.Dispose();
                    countour.Dispose();
                    return false;
                }

            }
            catch
            {
                Roi.Dispose();
                ho_ImageROI.Dispose();
                hCircles.Dispose();
                countour.Dispose();
                return false;
            }
        }


        public static void ShowResult(ImageViewer View, Variable.CamReturn camreturn)
        {
            PointF Center = new PointF();
            Center.X = (float)camreturn.X;
            Center.Y = (float)camreturn.Y;
            double R = camreturn.Angle;
            //center cross
            View.Image.Overlays.Default.AddLine(new LineContour(new PointContour(Center.X - 30, Center.Y), new PointContour(Center.X + 30, Center.Y)), Rgb32Value.YellowColor);
            View.Image.Overlays.Default.AddLine(new LineContour(new PointContour(Center.X, Center.Y - 30), new PointContour(Center.X, Center.Y + 30)), Rgb32Value.YellowColor);
            PointF a = new PointF();
            PointF A = new PointF();
            a.X = Center.X + 500;
            a.Y = Center.Y;
            Form_Main.Instance.PtRotate(a, Center, R, out A);
            //Line Direction
            View.Image.Overlays.Default.AddLine(new LineContour(new PointContour(Center.X, Center.Y), new PointContour(A.X, A.Y)), Rgb32Value.BlueColor);
        }
        //Circle****************************************************************************************
        /// <summary>
        /// 找圆-使用ROI-RectangleRegion
        /// </summary>
        /// <param name="img">图片</param>
        /// <param name="rectRoi">ROI</param>
        /// <param name="MinRadius">最小半径</param>
        /// <param name="MaxRadius">最大半径</param>
        /// <param name="Center">中心点</param>
        /// <param name="Radius">半径</param>
        /// <returns></returns>
        public static bool DetectCircle(VisionImage img, Roi rectRoi, double MinRadius, double MaxRadius, out PointContour Center, out double Radius)
        {
            //*************************************************************************************************
            Center = new PointContour();
            Radius = 0;
            HObject ho_Image = new HObject();
            HObject ho_ImageROI = new HObject();
            HObject Roi = new HObject();
            HObject hCircles = new HObject();
            HObject countour = new HObject();
            img.BorderWidth = 0;

            try
            {
                HOperatorSet.GenImage1(out ho_Image, "byte", img.Width, img.Height, img.StartPtr);

                RectangleContour rect = (RectangleContour)rectRoi[0].Shape;
                HOperatorSet.GenRectangle1(out Roi, rect.Top,
                    rect.Left,
                    rect.Top + rect.Height, rect.Left + rect.Width);

                HOperatorSet.ReduceDomain(ho_Image, Roi, out ho_ImageROI);   //获取图像区域 形态学处理后

                HOperatorSet.EdgesSubPix(ho_ImageROI, out ho_ImageROI, "canny", 1.5, 50, 75);
                HOperatorSet.SegmentContoursXld(ho_ImageROI, out ho_ImageROI, "lines_circles", 5, 4, 2);
                HOperatorSet.SelectShapeXld(ho_ImageROI, out ho_ImageROI, "outer_radius", "and", MinRadius, MaxRadius);
                HOperatorSet.SelectShapeXld(ho_ImageROI, out ho_ImageROI, "circularity", "and", 0.4, 1);

                HTuple colY, colX, rad, startPhi, endPhi, pointOrder;
                HOperatorSet.FitCircleContourXld(ho_ImageROI, "ahuber", -1, 2, 0, 3, 2,
                    out colY, out colX, out rad, out startPhi, out endPhi, out pointOrder);

                if(colY.Length > 0)
                {
                    Radius = rad[0];
                    int minIndex = 0;
                    for (int i = 1; i < colY.Length; i++)
                    {
                        // 输出在范围之内最小的半径 和 圆心
                        if (rad[i] < Radius)
                        {
                            minIndex = i;
                            Radius = rad[i];
                        }
                    }

                    Center.X = (float)(colX[minIndex].D);
                    Center.Y = (float)(colY[minIndex].D);

                    ho_Image?.Dispose();
                    Roi?.Dispose();
                    ho_ImageROI?.Dispose();
                    hCircles?.Dispose();
                    countour?.Dispose();
                }
                else
                {
                    throw new HalconException("没有扑抓的有效椭圆，请检查半径参数");
                }
            }
            catch(HalconException ex)
            {
                ho_Image?.Dispose();
                Roi?.Dispose();
                ho_ImageROI?.Dispose();
                hCircles?.Dispose();
                countour?.Dispose();
                return false;
            }

            return true;
        }
    }
}
