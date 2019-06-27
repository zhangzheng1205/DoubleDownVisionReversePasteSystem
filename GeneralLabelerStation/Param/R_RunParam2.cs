using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneralLabelerStation;
using System.Threading;

namespace GeneralLabelerStation.Param
{
    /// <summary>
    /// R 轴 运行参数
    /// </summary>
    public class R_RunParam
    {
        /// <summary>
        /// 创建一个R 轴运行参数
        /// </summary>
        /// <param name="ptrInit"></param>
        /// <param name="ptrRRatio"></param>
        /// <param name="ptrAxisRatio"></param>
        /// <param name="ptrPos"></param>
        public R_RunParam(Axis axis, double init_pos, double r_ratio)
        {
            this.init_pos = init_pos;
            this.r_ratio = r_ratio;
            this.rAxis = axis;
        }

        #region 运动控制相关
        public void SetSpeed(double low, double high, double acc, double dec)
        {
            this.low_ratio = low;
            this.high_ratio = high;
            this.acc_ratio = acc;
            this.dec_ratio = dec;
        }

        /// <summary>
        /// 初始位置角度
        /// </summary>
        private double init_pos = 1;

        /// <summary>
        /// R 轴 脉冲比
        /// </summary>
        private double r_ratio = 1;

        /// <summary>
        /// 速度放大比例
        /// </summary>
        private double low_ratio = 1;
        /// <summary>
        /// 速度放大比例
        /// </summary>
        private double high_ratio = 1;
        /// <summary>
        /// 速度放大比例
        /// </summary>
        private double acc_ratio = 1;
        /// <summary>
        /// 速度放大比例
        /// </summary>
        private double dec_ratio = 1;

        /// <summary>
        /// 反馈脉冲方式
        /// </summary>
        public int iAxisSource { get; set; } = 0;

        /// <summary>
        /// R轴 实例的引用
        /// </summary>
        public Axis rAxis = null;

        /// <summary>
        /// R 到 指定角度
        /// </summary>
        /// <param name="angle"></param>
        public short RGoPos(double angle, Variable.VelMode velMode)
        {
            Variable.VelMode newVel = this.ConvertReal2Pulse(velMode);
            return rAxis.AxisMoveTrap_Abs(angle * (this.r_ratio), newVel.LowVel, newVel.HighVel, newVel.Acc, newVel.Dec);
        }

        /// <summary>
        /// R 到指定角度 附带初始值
        /// </summary>
        /// <param name="angle"></param>
        /// <param name="velMode"></param>
        /// <returns></returns>
        public short RGoPosWithInit(double angle, Variable.VelMode velMode)
        {
            //angle = this.DegreeNormal(angle);
            Variable.VelMode newVel = this.ConvertReal2Pulse(velMode);
            return rAxis.AxisMoveTrap_Abs(angle * (this.r_ratio), newVel.LowVel, newVel.HighVel, newVel.Acc, newVel.Dec);
        }


        /// <summary>
        /// R轴 JOG 运动
        /// </summary>
        /// <param name="velMode"></param>
        /// <param name="Dir_Pos"></param>
        /// <returns></returns>
        public short RJog(Variable.VelMode velMode, bool Dir_Pos)
        {
            Variable.VelMode newVel = this.ConvertReal2Pulse(velMode);
            return rAxis.AxisMoveJog(newVel.LowVel, newVel.HighVel, newVel.Acc, newVel.Dec, Dir_Pos);
        }

        /// <summary>
        /// R 轴 停止运动
        /// </summary>
        /// <returns></returns>
        public short RStop(){ return rAxis.StopAxis(); }

        public short GetAxisSts()
        {
            return this.rAxis.GetAxisSts();
        }

        /// <summary>
        /// R轴运动到一个位置直到停止
        /// </summary>
        /// <param name="Timeout_Millsecond"></param>
        /// <param name="deg"></param>
        /// <param name="velMode"></param>
        /// <returns></returns>
        public short RGoPosTillStop(double Timeout_Millsecond, double deg, Variable.VelMode velMode)
        {
            Stopwatch a = new Stopwatch();
            double mm = deg * (this.r_ratio);
            short rtn = 0;

            Variable.VelMode newVel = this.ConvertReal2Pulse(velMode);
            rAxis.AxisMoveTrap_Abs(mm, newVel.LowVel, newVel.HighVel, newVel.Acc,newVel.Dec);
            a.Start();

            while (Math.Abs(deg - this.RPos) > 0.02)
            {
                rtn += rAxis.GetAxisSts();

                if (a.ElapsedMilliseconds > Timeout_Millsecond)
                {
                    rAxis.StopAxis();
                    rtn = 1;
                    break;
                }
                Thread.Sleep(100);
            }
            return rtn;
        }

        /// <summary>
        /// R轴回原点
        /// </summary>
        /// <param name="homemode"></param>
        /// <param name="velMode"></param>
        /// <param name="IsDirP"></param>
        /// <returns></returns>
        public short RGoHome(Axis.HomeMode homemode, Variable.VelMode velMode, bool IsDirP)
        {
            Variable.VelMode newVel = this.ConvertReal2Pulse(velMode);
            return rAxis.AxisGoHome(homemode, IsDirP, newVel.LowVel, newVel.HighVel, newVel.Acc, newVel.Dec);
        }

        /// <summary>
        /// 移动到初始位置
        /// </summary>
        /// <param name="velMode"></param>
        /// <returns></returns>
        public short RGoInitPos(Variable.VelMode velMode)
        {
            return this.RGoPos(this.init_pos, velMode);
        }

        /// <summary>
        /// 脉冲比较 判断是否到位
        /// </summary>
        /// <param name="Command"></param>
        /// <param name="CommandBack"></param>
        /// <returns></returns>
        public bool AxisReach(double angle)
        {
            //angle = this.DegreeNormal(angle);
            if (Math.Abs(angle - this.RPos) <= 0.05)
                return true;
            else
                return false;
        }

        /// <summary>
        /// R轴运行速度 乘以比例
        /// </summary>
        /// <param name="velMode"></param>
        /// <returns></returns>
        private Variable.VelMode ConvertReal2Pulse(Variable.VelMode velMode)
        {
            Variable.VelMode a = new Variable.VelMode();
            a.LowVel = velMode.LowVel * (this.r_ratio) * (this.low_ratio);
            a.HighVel = velMode.HighVel * (this.r_ratio) * (this.high_ratio);
            a.Acc = velMode.Acc * (this.r_ratio) * (this.acc_ratio);
            a.Dec = velMode.Dec * (this.r_ratio) * (this.dec_ratio);
            return a;
        }

        /// <summary>
        /// 当前位置
        /// </summary>
        public double RPos
        {
            get
            {
                return rAxis.AxisPrfPos / this.r_ratio;
            }
        }

        public double RPosEnc
        {
            get
            {
                return this.rAxis.AxisPrfPos / this.r_ratio;
            }
        }

        /// <summary>
        /// 轴 正在回原点
        /// </summary>
        public bool AxisHoming
        {
            get { return rAxis.bAxisIsHoming; }
        }

        /// <summary>
        /// 轴 到达负极限
        /// </summary>
        public bool NegLimit
        {
            get { return rAxis.bNegLimit; }
        }

        /// <summary>
        /// 轴 到达正极限
        /// </summary>
        public bool PosLimit
        {
            get { return rAxis.bPosLimit; }
        }

        /// <summary>
        /// 轴 正在运行
        /// </summary>
        public bool IsRunning
        {
            get { return rAxis.bAxisIsRunning; }
        }

        /// <summary>
        /// 是否在回原点
        /// </summary>
        public bool IsHoming
        {
            get { return rAxis.bAxisIsHoming; }
        }
        /// <summary>
        /// 是否在原点
        /// </summary>
        public bool IsAtHome
        {
            get { return rAxis.bHome; }
        }

        /// <summary>
        /// 是否 打开伺服驱动
        /// </summary>
        public bool IsServoOn
        {
            get { return rAxis.bAxisServoOn; }
        }

        /// <summary>
        /// 是否 伺服报警
        /// </summary>
        public bool IsServoWarning
        {
            get { return rAxis.bAxisServoWarning; }
        }

        /// <summary>
        /// 急停是否打开
        /// </summary>
        public bool IsEmgOn
        {
            get { return rAxis.bAxisEmgOn; }
        }

        /// <summary>
        /// 准备信息是否亮起
        /// </summary>
        public bool IsReady
        {
            get { return rAxis.bAxisReady; }
        }

        /// <summary>
        /// R轴初始化角度
        /// </summary>
        public double InitPos
        {
            get { return init_pos; }
            set { init_pos = value; }
        }

        #endregion

        #region 自动运行相关

        /// <summary>
        /// 处理旋转角度
        /// </summary>
        /// <param name="Angle">角度</param>
        /// <returns></returns>
        private double DegreeNormal(double Angle)
        {
            if (Angle < -360)
            {
                Angle = Angle + (int)(Angle / 360) * 360;
            }
            if (Angle > 360)
            {
                Angle = Angle - (int)(Angle / 360) * 360;
            }

            if (Angle - this.RPos > 180)
            {
                Angle = Angle - 360;
            }
            if (Angle - this.RPos < -180)
            {
                Angle = Angle + 360;
            }

            return Angle;
        }
        #endregion
    }
}
