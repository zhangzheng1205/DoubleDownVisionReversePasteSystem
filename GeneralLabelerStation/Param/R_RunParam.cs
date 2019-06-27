using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using GeneralLabelerStation;
using static GeneralLabelerStation.Variable;

namespace GeneralLabelerStation.Param
{
    /// <summary>
    /// R 轴 运行参数
    /// </summary>
    public class R_RunParam:Axis_RunParam
    {
        /// <summary>
        /// 创建一个R 轴运行参数
        /// </summary>
        /// <param name="ptrInit"></param>
        public R_RunParam(short axis)
            :base(axis)
        {
            this.iAxisSource = 1;
        }


        #region 运动控制相关

        /// <summary>
        /// 角度到位差
        /// </summary>
        public override double MinDiff
        {
            get;
            set;
        } = 0.2;

        /// <summary>
        /// R 到指定角度 附带初始值
        /// </summary>
        /// <param name="angle"></param>
        /// <param name="velMode"></param>
        /// <returns></returns>
        public override short GoPos(double angle, VelMode velMode)
        {
            angle = this.DegreeNormal(angle);
            return base.GoPos(angle, velMode);
        }

        /// <summary>
        /// 移动到初始位置
        /// </summary>
        /// <param name="velMode"></param>
        /// <returns></returns>
        public short RGoInitPos(VelMode velMode)
        {
            return base.GoPos(0, velMode);
        }

        public override void SetSpeedRatio(double low, double high, double acc, double dec)
        {
            low *= 5;
            high *= 5;
            acc *= 5;
            dec *= 5;

            base.SetSpeedRatio(low, high, acc, dec);
        }
        #endregion

        #region 自动运行相关
        /// <summary>
        /// R轴自动运行时的初始角度
        /// </summary>
        public double RUN_RInit = 0;

        /// <summary>
        /// 复位时的 初始角度
        /// </summary>
        public double InitPos = 0;

        /// <summary>
        /// 处理旋转角度
        /// </summary>
        /// <param name="Angle">角度</param>
        /// <returns></returns>
        private double DegreeNormal(double Angle)
        {
            return Angle;
        }
        #endregion
    }
}
