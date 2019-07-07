using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static GeneralLabelerStation.Variable;

namespace GeneralLabelerStation.Param
{
    public class Axis_RunParam: Axis_Advantech
    {
        /// <summary>
        /// 创建一个轴运行参数
        /// </summary>
        /// <param name="axis"></param>
        public Axis_RunParam(short axis):
            base(axis)
        {
        }

        #region 运动控制相关

        /// <summary>
        /// 反馈脉冲方式 0:编码器 1：规划器
        /// </summary>
        public int iAxisSource { get; set; } = 0;

        public virtual short GoPosManual(double pos, VelMode velMode)
        {
            VelMode newVel = this.ConvertReal2Pulse(velMode);
            velMode = this.ConvertReal2PulseManual(velMode);
            return this.AxisMoveTrap_Abs(pos * (this.AxisRatio), velMode.LowVel, velMode.HighVel, velMode.Acc, velMode.Dec);
        }

        /// 到 指定角度
        /// </summary>
        /// <param name="pos"></param>
        public virtual short GoPos(double pos, VelMode velMode)
        {
            VelMode newVel = this.ConvertReal2Pulse(velMode);
            return this.AxisMoveTrap_Abs(pos * (this.AxisRatio), newVel.LowVel, newVel.HighVel, newVel.Acc, newVel.Dec);
        }

        public virtual short MoveTrim(double TrimDist, VelMode velMode)
        {
            return this.GoPosManual(TrimDist + this.Pos, velMode);
        }

        /// <summary>
        /// 轴 JOG 运动
        /// </summary>
        /// <param name="velMode"></param>
        /// <param name="Dir_Pos"></param>
        /// <returns></returns>
        public virtual short Jog(VelMode velMode, bool Dir_Pos)
        {
            velMode = ConvertReal2PulseManual(velMode);
            return this.AxisMoveJog(velMode.LowVel, velMode.HighVel, velMode.Acc, velMode.Dec, Dir_Pos);
        }

        /// <summary>
        /// 轴 停止运动
        /// </summary>
        /// <returns></returns>
        public virtual short Stop() { return this.StopAxis(); }

        /// <summary>
        /// 轴运动到一个位置直到停止
        /// </summary>
        /// <param name="Timeout_Millsecond"></param>
        /// <param name="deg"></param>
        /// <param name="velMode"></param>
        /// <returns></returns>
        public virtual short GoPosTillStop(double Timeout_Millsecond, double pos, VelMode velMode)
        {
            Stopwatch a = new Stopwatch();
            short rtn = 0;
            velMode = ConvertReal2Pulse(velMode);
            this.AxisMoveTrap_Abs(pos*this.AxisRatio, velMode.LowVel, velMode.HighVel, velMode.Acc, velMode.Dec);
            a.Start();
            rtn += this.GetAxisPos();
            rtn += this.GetAxisSts();

            while (!this.AxisReach(pos) || this.bAxisIsRunning)
            {
                rtn += this.GetAxisPos();

                if (a.ElapsedMilliseconds > Timeout_Millsecond)
                {
                    this.StopAxis();
                    rtn = 1;
                    break;
                }
                Thread.Sleep(100);
            }
            return rtn;
        }

        /// <summary>
        /// 轴回原点
        /// </summary>
        /// <param name="homemode"></param>
        /// <param name="velMode"></param>
        /// <param name="IsDirP"></param>
        /// <returns></returns>
        public virtual short GoHome(Axis_Advantech.HomeMode homemode, VelMode velMode, bool IsDirP)
        {
            velMode = ConvertReal2PulseManual(velMode);
            return this.AxisGoHome(homemode, IsDirP, velMode.LowVel, velMode.HighVel, velMode.Acc, velMode.Dec);
        }

        public virtual short ChangePos(double mm, Variable.VelMode velMode)
        {
            VelMode newVel = this.ConvertReal2Pulse(velMode);
            return this.AxisChangePos(mm, velMode);
        }

        /// <summary>
        /// 到位精度
        /// </summary>
        public virtual double MinDiff { get; set; } = 0.03;

        /// <summary>
        /// 脉冲比较 判断是否到位
        /// </summary>
        /// <param name="Command"></param>
        /// <param name="CommandBack"></param>
        /// <returns></returns>
        public virtual bool AxisReach(double pos)
        {
            if (Form_Main.Instance.RunMode == 1)
                this.GetAxisSts();

            if (Math.Abs(pos - this.Pos) <= MinDiff && !this.bAxisIsRunning)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 轴运行速度 乘以比例
        /// </summary>
        /// <param name="velMode"></param>
        /// <returns></returns>
        private VelMode ConvertReal2Pulse(VelMode velMode)
        {
            VelMode a = new VelMode();
            a.LowVel = velMode.LowVel *(this.AxisRatio) * (this.Vel_Low_Ratio);
            a.HighVel = velMode.HighVel * (this.AxisRatio) * (this.Vel_High_Ratio);
            a.Acc = velMode.Acc * (this.AxisRatio) * (this.Vel_Acc_Ratio);
            a.Dec = velMode.Dec * (this.AxisRatio) * (this.Vel_Dec_Ratio);
            return a;
        }

        private VelMode ConvertReal2PulseManual(VelMode velMode)
        {
            VelMode a = new VelMode();
            a.LowVel = velMode.LowVel * (this.AxisRatio);
            a.HighVel = velMode.HighVel * (this.AxisRatio);
            a.Acc = velMode.Acc * (this.AxisRatio);
            a.Dec = velMode.Dec * (this.AxisRatio);
            return a;
        }

        /// <summary>
        /// 当前位置
        /// </summary>
        public double Pos
        {
            get
            {
                if (Form_Main.Instance.RunMode == 1)
                    this.GetAxisPos();

                double pos = 0;
                if(this.iAxisSource==0)
                    pos = this.AxisEncPos / this.AxisRatio;
                else
                    pos = this.AxisPrfPos / this.AxisRatio;

                return pos;
            }
        }

        #endregion
    }
}
