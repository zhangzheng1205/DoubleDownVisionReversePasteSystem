
using GeneralLabelerStation;
using GeneralLabelerStation.IO;
using NationalInstruments.Vision;
using NationalInstruments.Vision.Analysis;
using NationalInstruments.Vision.WindowsForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static GeneralLabelerStation.Variable;

namespace GeneralLabelerStation.Param
{
    /// <summary>
    /// Z轴 运行参数
    /// </summary>
    public class Z_RunParam:Axis_RunParam
    {
        public Z_RunParam(short zAxis):base(zAxis)
        {
        }

        #region 固有属性

        /// <summary>
        /// Z 轴开吸真空IO
        /// </summary>
        public IOOutput XI_vaccum = null;

        /// <summary>
        /// Z 轴开破真空IO
        /// </summary>
        public IOOutput PO_vaccum = null;

        /// <summary>
        /// Z轴 真空检测
        /// </summary>
        public IOInput Check_vaccum = null;

        public IOInput HomeLimit = null;

        /// <summary>
        /// 刹车打开
        /// </summary>
        public IOOutput Svon = null;

        /// <summary>
        /// 运动方向 1：正向 -1:fu
        /// </summary>
        public int MoveDir = 1;
        /// <summary>
        /// 安全高度
        /// </summary>
        public double SafeHeigh { get; set; } = 0;

        /// <summary>
        /// 轴拍照高度
        /// </summary>
        public double CamHeigh { get; set; } = 0;

        /// <summary>
        /// 贴标高度
        /// </summary>
        public double PasteHeight { get; set; } = 0;

        /// <summary>
        /// 是否在安全高度
        /// </summary>
        public bool IsSafePos { get { return this.AxisReach(this.SafeHeigh); } }

        public override double MinDiff
        {
            get;
            set;
        } = 1;
        #endregion

        #region 运动控制相关

        /// <summary>
        /// 延迟吸取
        /// </summary>
        /// <param name="ms"></param>
        /// <returns></returns>
        public short DelayXI(int ms){ Thread.Sleep(ms); return XI_vaccum.SetIO(); }

        /// <summary>
        /// 延迟破真空
        /// </summary>
        /// <param name="ms"></param>
        /// <returns></returns>
        public short DelayPO(int ms){ Thread.Sleep(ms); return PO_vaccum.SetIO(); }

        /// <summary>
        /// 去安全高度
        /// </summary>
        /// <param name="velMode"></param>
        /// <returns></returns>
        public short GoSafePos(VelMode velMode)
        {
            return base.GoPos(this.SafeHeigh, velMode);
        }

        #endregion

        #region JOB 相关
        /// <summary>
        /// 是否计算完成
        /// </summary>
        public bool CalFinished
        {
            get;
            set;
        }

        /// <summary>
        /// 下视觉扑抓到的图片1
        /// </summary>
        public VisionImage CaptureImage { get; set; } = new VisionImage();
        #endregion

        #region 自动流程相关
        /// <summary>
        /// 自动运行时需要走到的高度
        /// </summary>
        public double RUN_ZPos = 0;

        /// <summary>
        /// 吸起来的Feeder上 第几个标签
        /// </summary>
        public int RUN_SuckIndex = 0;

        public double RUN_ZHeight { get; set; } = 0;

        /// <summary>
        /// 吸嘴可以贴附的点数
        /// </summary>
        public int RUN_MarkCount { get; set; } = 0;

        /// <summary>
        /// 当次吸嘴在贴第几块板子-----------------多板模式下
        /// </summary>
        public int RUN_PasteInfoIndex { get; set; } = -1;

        /// <summary>
        /// 吸嘴在小板模式【扩展前】下的序列号; 当次吸嘴在[小板模式LIST]下的序列号
        /// </summary>
        public int RUN_PasteInfoIndex_List { get; set; } = 0;

        /// <summary>
        /// 吸嘴是否可用
        /// </summary>
        public bool RUN_bNozzleUse { get; set; } = false;

        /// <summary>
        /// 当前吸嘴 上的Label 是否  0-不使用 1-未使用过 2-使用已过下视觉OK 4-使用已过下视觉NG 3-已贴完 5-有标但需要抛料
        /// </summary>
        public short RUN_dNozzleDownVisionED { get; set; } = 0;

        public short RUN_LasteDownVisionED { get; set; } = 0;

        /// <summary>
        /// 当前吸嘴 吸取Feeder 号码 1-左 2-右
        /// </summary>
        public short RUN_Nozzle_FeederIndex { get; set; } = 0;

        /// <summary>
        /// 当前吸嘴 吸取Feeder 号码 1-左 2-右
        /// </summary>
        public short RUN_LastFeederIndex { get; set; } = 0;

        /// <summary>
        /// 吸得第几个标
        /// </summary>
        public short XI_Index { get; set; } = 0;

        /// <summary>
        /// 当前吸嘴 在贴板子的第几个点
        /// </summary>
        public short RUN_PastePointIndex { get; set; } = 0;

        /// <summary>
        /// 吸嘴大概贴附位置（提前走）
        /// </summary>
        public PointF RUN_PasteRealPoint = new PointF();
       

        /// <summary>
        /// 吸嘴真正贴附角度
        /// </summary>
        public double RUN_PasteRealAngle { get; set; } = 0;

        /// <summary>
        /// 吸嘴 上Label  MARK的位置
        /// </summary>
        public PointContour Nozzle_DownXY_Pos = new PointContour();
        
        /// <summary>
        /// 吸嘴 上Label  MARK的角度
        /// </summary>
        public double Nozzle_Down_Angle { get; set; } = 0;

        /// <summary>
        /// 上一次点序号
        /// </summary>
        public short RUN_LastPastePoint = -1;

        /// <summary>
        /// 上一次点板号
        /// </summary>
        public int RUN_LastPasteIndex = -1;

        /// <summary>
        /// 下视觉结果  拍照点1  拍照点2
        /// </summary>
        public CamReturn CamResult = new CamReturn();

        /// <summary>
        /// 重置自动运行参数
        /// </summary>
        public void ResetAutoRunParam()
        {
            Nozzle_Down_Angle = 0;
            Nozzle_DownXY_Pos = new PointContour();
            RUN_PasteRealAngle = 0;
            RUN_PasteRealPoint = new PointF();
            RUN_PastePointIndex = 0;
            RUN_Nozzle_FeederIndex = 0;
            RUN_dNozzleDownVisionED = 1;
            RUN_bNozzleUse = false;
            RUN_PasteInfoIndex_List = 0;
            RUN_PasteInfoIndex = 0;
            RUN_MarkCount = 0;
            this.RUN_ZHeight = 0;
        }

        #endregion

        #region 抛料相关
        /// <summary>
        /// 抛料次数
        /// </summary>
        public int ThrowLabelCount { get; set; } = 0;

        /// <summary>
        /// 吸嘴连续抛料报警
        /// </summary>
        public int ThrowWarningCount { get; set; } = 0;

        /// <summary>
        /// 吸标失败次数
        /// </summary>
        public int SuckFailCount { get; set; } = 0;

        /// <summary>
        /// 抛料点1
        /// </summary>
        public PointF ThrowPoint1 = new PointF();

        /// <summary>
        /// 抛料高度
        /// </summary>
        public double ThrowHeight { get; set; } = 0;

        #endregion
    }
}
