using NationalInstruments.Vision;
using NationalInstruments.Vision.Acquisition.Imaqdx;
using NationalInstruments.Vision.Analysis;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralLabelerStation.Camera
{
    public class CameraEntiy
    {
        public CameraEntiy(CameraConfig config)
        {
            this.Config = config;
            shutter = this.Config.Expouse;
        }

        public CameraConfig Config = null;

        [JsonIgnore]
        private int shutter = 0;

        /// <summary>
        /// 曝光
        /// </summary>
        public int Shutter
        {
            get
            {
                return shutter;
            }
            set
            {
                try
                {
                    shutter = value;
                    this._Session.Attributes["CameraAttributes::AcquisitionControl::ExposureTime"].SetValue(value);
                }
                catch { }
            }
        }

        /// <summary>
        /// 外触发
        /// </summary>
        public int Trigger
        {
            set
            {
                try
                {
                    this._Session.Attributes["CameraAttributes::AcquisitionControl::TriggerMode"].SetValue(value);
                    this._Session.Attributes["CameraAttributes::AcquisitionControl::TriggerSource"].SetValue(value);
                }
                catch { }
           }
        }

        /// <summary>
        /// 相机中心位置
        /// </summary>
        public PointContour[] CenterPt = null;

        /// <summary>
        /// 标定文件
        /// </summary>
        public VisionImage[] CalibImage = null;

        /// <summary>
        /// 该相机是否进行过标定
        /// </summary>
        public bool IsCailb
        {
            get;
            set;
        } = false;

        /// <summary>
        /// 相机实例
        /// </summary>
        public ImaqdxSession _Session = null;

        public string InitCamera()
        {
            string rtn = string.Empty;
            try
            {
                _Session = new ImaqdxSession(this.Config.DevName);
                using (VisionImage A = new VisionImage())
                {
                    this._Session.Acquisition.Unconfigure();
                    this._Session.Snap(A);
                }

                //this._session.Attributes["CameraAttributes::UserSetControl::UserSetSelector"].SetValue(1);//68
                //this._session.Attributes["CameraAttributes::UserSetControl::UserSetLoad"].SetValue(1);//69

                this._Session.Attributes["AcquisitionAttributes::Timeout"].SetValue(1000);

                this._Session.Attributes["CameraAttributes::ImageFormatControl::Width"].SetValue(this.Config.FOV.Width);
                this._Session.Attributes["CameraAttributes::ImageFormatControl::Height"].SetValue(this.Config.FOV.Height);
                this._Session.Attributes["CameraAttributes::ImageFormatControl::OffsetX"].SetValue(this.Config.FOV.Left);
                this._Session.Attributes["CameraAttributes::ImageFormatControl::OffsetY"].SetValue(this.Config.FOV.Top);
                this.Shutter = this.Config.Expouse;
            }
            catch (Exception ex) { rtn = ex.Message; }
            return rtn;
        }

        public bool LoadCalibImage(CAM camera)
        {
            try
            {
                int len = 1;
                if (camera == CAM.Bottom1 || camera == CAM.Bottom2)
                    len = 2;
                // 读取标定文件
                this.CalibImage = new VisionImage[len];
                this.CenterPt = new PointContour[len];
                this.IsCailb = true;

                for (int i = 0; i < len; ++i)
                {
                    this.CalibImage[i] = new VisionImage();
                    this.CenterPt[i] = new PointContour();
                    string direct = string.Format(Variable.sPath_CaliPath, (int)camera,i);
                    this.CalibImage[i].ReadVisionFile(direct + Variable.sPath_CaliImage);
                    // 中心点像素坐标 
                    this.CenterPt[i].X = this.Config.FOV.Width / 2;
                    this.CenterPt[i].Y = this.Config.FOV.Height / 2;

                    var coordreport = Algorithms.ConvertPixelToRealWorldCoordinates(this.CalibImage[i], this.CenterPt[i]);
                    if (coordreport.Points.Count > 0)
                        this.CenterPt[i] = coordreport.Points[0];
                    else
                        this.IsCailb = false;
                }
            }
            catch { this.IsCailb = false; }
            return this.IsCailb;
        }

        #region 校验相关
        /// <summary>
        /// 图像上坐标转位机器坐标
        /// </summary>
        /// <param name="capturePt"></param>
        /// <param name="pixelPt"></param>
        /// <returns></returns>
        public PointF ImagePt2WorldPt(PointF capturePt, PointContour pixelPt, int calib)
        {
            PointF pos = new PointF();
            var coordreport = Algorithms.ConvertPixelToRealWorldCoordinates(this.CalibImage[calib], pixelPt);
            if (coordreport.Points.Count == 0)
            {
                return pos;
            }

            pos.X = (float)(capturePt.X - (coordreport.Points[0].X - this.CenterPt[calib].X));
            pos.Y = (float)(capturePt.Y - (coordreport.Points[0].Y - this.CenterPt[calib].Y));
            return pos;
        }

        #endregion
    }

}
