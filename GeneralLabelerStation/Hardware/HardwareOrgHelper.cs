using GeneralLabelerStation.Common;
using HalconDotNet;
using MathNet.Numerics;
using NationalInstruments.Vision;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralLabelerStation
{
    /// <summary>
    /// 硬件机械原点
    /// 可以确定X,Y轴的 夹角
    /// 
    ///                  LeftTop                    RightTop     
    ///                    __________________________
    ///                   |                          |
    ///                   |                          |
    ///                   |                          |
    ///                   |                          |
    ///                   |                          |
    ///                   |                          |
    ///                   |                          |   
    ///                   |__________________________|
    ///                 Org(LeftBottom)              RightBottom
    ///                   
    /// 
    /// 
    /// 
    /// 
    /// </summary>
    public class HardwareItem
    {
        #region 机械原点 和 XY水平度
        /// <summary>
        /// 左上角机械原点
        /// </summary>
        public PointF LeftTop
        {
            get;
            set;
        } = new PointF();

        /// <summary>
        /// 右上角机械原点
        /// </summary>
        public PointF RightTop
        {
            get;
            set;
        } = new PointF();

        /// <summary>
        /// 右下角机械原点
        /// </summary>
        public PointF RightBottom
        {
            get;
            set;
        } = new PointF();

        /// <summary>
        /// 左下角机械原点
        /// </summary>
        public PointF LeftBottom
        {
            get;
            set;
        } = new PointF();

        /// <summary>
        /// 机械偏移
        /// </summary>
        public PointF HardwareOffset
        {
            get;
            set;
        } = new PointF();

        /// <summary>
        /// XY夹角度数
        /// </summary>
        public double XYCroodAngle
        {
            get;
            set;
        } = 90;

        /// <summary>
        /// X轴倾斜率
        /// </summary>
        public double XRate
        {
            get;
            set;
        } = 1;

        /// <summary>
        /// Y轴倾斜率
        /// </summary>
        public double YRate
        {
            get;
            set;
        } = 0;

        public Polynomial XPoly = new Polynomial();

        public Polynomial YPoly = new Polynomial();

        public double[] X = null;
        public double[] RX = null;

        public double[] Y = null;
        public double[] RY = null;

        public PointContour ToReal(PointContour xy)
        {
            try
            {
                PointContour temp = new PointContour(xy.X, xy.Y);

                if (XPoly.Coefficients.Length > 0
                    && (xy.X >= X[0] - 20)
                    && (xy.X <= (X.Last() + 20)))
                {
                    temp.X -= XPoly.Evaluate(xy.X);
                }

                if (YPoly.Coefficients.Length > 0
                    && (xy.Y >= Y[0] - 20)
                    && (xy.Y <= Y.Last()+20))
                {
                    temp.Y -= YPoly.Evaluate(xy.Y);
                }

                return temp;
            }
            catch { }
            return xy;
        }

        public PointContour ToMachine(PointContour xy)
        {
            try
            {
                PointContour temp = new PointContour(xy.X, xy.Y);

                if (XPoly.Coefficients.Length > 0
                    && (xy.X >= X[0] - 20)
                   && (xy.X <= (X.Last() + 20)))
                {
                    temp.X += XPoly.Evaluate(xy.X);
                }

                if (YPoly.Coefficients.Length > 0
                    && (xy.Y >= Y[0] - 20)
                    && (xy.Y <= Y.Last() + 20))
                {
                    temp.Y += YPoly.Evaluate(xy.Y);
                }
                return temp;
            }
            catch { }
            return xy;
        }
        #endregion
    }
    public class HardwareOrgHelper:SingletionProvider<HardwareOrgHelper>
    {
        public HardwareItem HardWare = new  HardwareItem();

        #region 保存和存储
        public static bool Load()
        {
            if (!File.Exists(Variable.sPath_Configure + "//机械校验.json"))
            {
                return true;
            }

            SerializableHelper<HardwareOrgHelper> helper = new SerializableHelper<HardwareOrgHelper>();
            var temp = helper.DeJsonSerialize(Variable.sPath_Configure + "//机械校验.json");
            if (temp != null)
                HardwareOrgHelper.Instance = temp;
            else
                return false;
            return true;
        }

        public static void Save()
        {
            SerializableHelper<HardwareOrgHelper> helper = new SerializableHelper<HardwareOrgHelper>(HardwareOrgHelper.Instance);
            helper.JsonSerialize(Variable.sPath_Configure + "//机械校验.json"
);
        }
        #endregion


        public static double GetAngle(PointF line1S, PointF line1E, PointF line2S, PointF line2E)
        {
            HTuple rad = new HTuple();
            HTuple deg = new HTuple();
            HOperatorSet.AngleLl(line1S.Y, line1S.X, line1E.Y, line1E.X
                , line2S.Y, line2S.X, line2E.Y, line2E.X, out rad);
            HOperatorSet.TupleDeg(rad, out deg);
            double angle = deg.D;
            return angle;
        }

        public static double GetDist(PointF start, PointF end)
        {
            return Math.Sqrt(Math.Pow(end.X - start.X, 2) + Math.Pow(end.Y - start.Y, 2));
        }

        /// <summary>
        /// 三点扩展法扩展点位数组-返回所有的点位
        /// </summary>
        /// <param name="Points2Expand">待扩展的点阵</param>
        /// <param name="Origin">原点</param>
        /// <param name="XCoord">X终点坐标</param>
        /// <param name="YCoord">Y终点坐标</param>
        /// <param name="XCountIncluded">X方向个数</param>
        /// <param name="YCountIncluded">Y方向个数</param>
        /// <returns>返回所有的点位</returns>
        public static PointF[] Expand2AllPoints(PointF Points2Expand, PointF Origin, PointF XCoord, PointF YCoord, short XCountIncluded, short YCountIncluded)
        {
            List<PointF> Expand2AllPoints = new List<PointF>();
            PointF[,] ExpandedPoints = new PointF[XCountIncluded, YCountIncluded];
            PointF TempX = new PointF();
            PointF TempY = new PointF();
            for (int j = 0; j < YCountIncluded; j++)
            {
                for (int i = 0; i < XCountIncluded; i++)
                {

                    ExpandedPoints[i, j] = new PointF();
                    if (XCountIncluded == 1)
                    {
                        TempX.X = Origin.X;
                        TempX.Y = Origin.Y;
                    }
                    else
                    {
                        TempX.X = (XCoord.X - Origin.X) * i / (XCountIncluded - 1) + Origin.X;
                        TempX.Y = (XCoord.Y - Origin.Y) * i / (XCountIncluded - 1) + Origin.Y;
                    }

                    if (YCountIncluded == 1)
                    {
                        TempY.X = Origin.X;
                        TempY.Y = Origin.Y;
                    }
                    else
                    {
                        TempY.X = (YCoord.X - Origin.X) * j / (YCountIncluded - 1) + Origin.X;
                        TempY.Y = (YCoord.Y - Origin.Y) * j / (YCountIncluded - 1) + Origin.Y;
                    }
                    ExpandedPoints[i, j].X = TempX.X + TempY.X - Origin.X;
                    ExpandedPoints[i, j].Y = TempX.Y + TempY.Y - Origin.Y;

                    Expand2AllPoints.Add(new PointF(Points2Expand.X + ExpandedPoints[i, j].X - Origin.X, Points2Expand.Y + ExpandedPoints[i, j].Y - Origin.Y));
                }
            }
            return Expand2AllPoints.ToArray();
        }
    }
}
