using HalconDotNet;
using NationalInstruments.Vision;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeneralLabelerStation.HalconVision
{
    public static class HalconHelper
    {
        public static HTuple startAngle = -0.39;
        public static HTuple endAngle = 0.79;

        /// <summary>
        /// NI 转 Image
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        public static HObject NI2HImage(VisionImage image)
        {
            HObject rtnImage = new HObject();

            try
            {
                image.BorderWidth = 0;
                HOperatorSet.GenImage1(out rtnImage,"byte", image.Width, image.Height, (HTuple)image.StartPtr);
                return rtnImage;
            }
            catch (HalconException ex)
            {
                return rtnImage;
            }
        }

        public static HTuple LearnShapeModel(HObject edges)
        {
            HTuple modelID = new HTuple();
            HOperatorSet.CreateAnisoShapeModelXld(edges, "auto", startAngle
        , endAngle, "auto", 1, 1, "auto", 1, 1, "auto", "none", "use_polarity", 10, out modelID);
            return modelID;
        }

        public static void FindShapeModel(HObject image, RectangleContour roi, HTuple modeID, ref Variable.CamReturn cam,
            HTuple windowTuple = null, double minScore = 0.7, int matchNum = 1)
        {
            minScore = 0.6;
            HTuple row, column, angle, scaleR, scaleC, score;
            HObject reduceImage = new HObject();
            try
            {
                HRegion region = new HRegion();
                if (roi == null)
                    reduceImage = image;
                else
                {
                    region = new HRegion(roi.Top, roi.Left, roi.Top + roi.Height, roi.Left + roi.Width);
                    HOperatorSet.ReduceDomain(image, region, out reduceImage);
                }

                HOperatorSet.FindAnisoShapeModel(reduceImage, modeID, startAngle, endAngle, 1,1,1,1, minScore, matchNum,
                    0.5, "least_squares", 0, 0.9, out row, out column, out angle, out scaleR, out scaleC, out score);
                image?.Dispose();
                if (score.Length > 0)
                {
                    cam.XScale = scaleC.D;
                    cam.YScale = scaleR.D;

                    cam.Y = row[0].D;
                    cam.X = column[0].D;
                    cam.Angle = new HTuple(angle[0].D).TupleDeg();
                    if (Math.Abs(cam.Angle) > 90)
                    {
                        if (cam.Angle > 0)
                            cam.Angle -= 180;
                        else
                            cam.Angle += 180;
                    }

                    cam.Angle = -cam.Angle;
                    cam.IsOK = true;

                    if (windowTuple != null)
                    {
                        HTuple hv_HomMat2D;
                        HObject ho_Contours, ho_TransContours;
                        HOperatorSet.VectorAngleToRigid(0, 0, 0, row[0], column[0], angle[0], out hv_HomMat2D);
                        HOperatorSet.GetShapeModelContours(out ho_Contours, modeID, 1);
                        HOperatorSet.AffineTransContourXld(ho_Contours, out ho_TransContours, hv_HomMat2D);
                        HOperatorSet.SetColor(windowTuple, "red");
                        HOperatorSet.DispObj(ho_TransContours, windowTuple);
                        ho_Contours?.Dispose();
                        ho_TransContours?.Dispose();
                    }
                }
                else
                    cam.IsOK = false;

                reduceImage?.Dispose();
                image?.Dispose();
            }
            catch
            {
                cam.IsOK = false;
                reduceImage?.Dispose();
                image?.Dispose();
            }
        }

        public static void ClearModel(HTuple modelID)
        {
            if(modelID != null)
            {
                try
                {
                    HOperatorSet.ClearShapeModel(modelID);
                }
                catch { }
            }
        }

        public static HTuple LoadModel(string path)
        {
            HTuple modelID = null;
            try
            {
                HOperatorSet.ReadShapeModel(path + "\\temp.temp", out modelID);
            }
            catch { }

            return modelID;
        }

        public static void SaveModel(string path, HTuple modelID)
        {
            try
            {
                if(modelID != null)
                    HOperatorSet.WriteShapeModel(modelID,path+"//temp.temp");
            }
            catch(HalconException ex)
            {
                MessageBox.Show(ex.GetErrorMessage());
            }
        }
    }
}
