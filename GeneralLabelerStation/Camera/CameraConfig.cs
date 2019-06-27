using NationalInstruments.Vision;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralLabelerStation.Camera
{
    public class CameraConfig
    {
        /// <summary>
        /// 设备名称
        /// </summary>
        public string DevName
        {
            get;
            set;
        } = string.Empty;

        /// <summary>
        /// 相机FOV
        /// </summary>
        public Rectangle FOV
        {
            get;
            set;
        } = new Rectangle(0, 0, 1900, 1200);

        /// <summary>
        /// 曝光
        /// </summary>
        public int Expouse
        {
            get;
            set;
        } = 100;

        /// <summary>
        /// 增益
        /// </summary>
        public int Gain
        {
            get;
            set;
        } = 5;

        /// <summary>
        /// 采图超时时间
        /// </summary>
        public int Timeout
        {
            get;
            set;
        } = 1000;

        /// <summary>
        /// 相机中心位置
        /// </summary>
        public PointContour CenterPt = new PointContour();

    }
}
