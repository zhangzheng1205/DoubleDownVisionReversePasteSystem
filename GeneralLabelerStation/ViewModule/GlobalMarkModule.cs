using GeneralLabelerStation.Common;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralLabelerStation.ViewModle
{
    public class MarkEntiy
    {
        /// <summary>
        /// 拍照点
        /// </summary>
        public PointF CamPos = new PointF();

        /// <summary>
        /// 找到Mark点的坐标
        /// </summary>
        public PointF MarkXY = new PointF();

        /// <summary>
        /// Gain
        /// </summary>
        public int Gain { get; set; } = 1;

        /// <summary>
        /// Offset
        /// </summary>
        public int Offset { get; set; } = 0;

        /// <summary>
        /// 曝光
        /// </summary>
        public int Exp { get; set; } = 0;

        /// <summary>
        /// 打光
        /// </summary>
        public string Light { get; set; } = string.Empty;

        public string ROI { get; set; } = string.Empty;

        public short MinR { get; set; } = 3;

        public short MaxR { get; set; } = 500;
    }

    public class GlobalMarkModule
    {
        public MarkEntiy[] Mark = new MarkEntiy[2];
        public double BaseAngle { get; set; } = 0;
    }
}
