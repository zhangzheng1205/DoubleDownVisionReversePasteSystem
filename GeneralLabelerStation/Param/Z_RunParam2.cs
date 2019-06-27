using GeneralLabelerStation.Tool;
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

namespace GeneralLabelerStation.Param
{
    /// <summary>
    /// Z轴 运行参数
    /// </summary>
    public class Z_RunParam
    {
        public Z_RunParam(Tuple<ushort, ushort> cylinderOrg, Tuple<ushort, ushort> cylinderDone, Tuple<ushort, ushort> xi, Tuple<ushort, ushort> po)
        {
            this.z_cylinderOrg = cylinderOrg;
            this.z_cylinderDone = cylinderDone;
            this.xi_vaccum = xi;
            this.po_vaccum = po;
        }

        #region 运动控制相关
        /// <summary>
        /// Z 轴气缸IO
        /// </summary>
        private Tuple<ushort,ushort> z_cylinderOrg = new Tuple<ushort, ushort>(0,0);

        /// <summary>
        /// Z 轴气缸IO
        /// </summary>
        private Tuple<ushort, ushort> z_cylinderDone = new Tuple<ushort, ushort>(0, 0);

        /// <summary>
        /// Z 轴开吸真空IO
        /// </summary>
        private Tuple<ushort, ushort> xi_vaccum = new Tuple<ushort, ushort>(0, 0);

        /// <summary>
        /// Z 轴开破真空IO
        /// </summary>
        private Tuple<ushort, ushort> po_vaccum = new Tuple<ushort, ushort>(0, 0);

        /// <summary>
        /// 是否达到真空
        /// </summary>
        private bool bReachVaccum = false;

        /// <summary>
        /// 是否到达动点
        /// </summary>
        private bool bReachDone = false;

        /// <summary>
        /// 是否达到原点
        /// </summary>
        private bool bReachOrg = false;

        /// <summary>
        /// 开真空
        /// </summary>
        public short XI()
        {
            return ExCardHelper.SetIO((short)this.xi_vaccum.Item2);
        }

        /// <summary>
        /// 关真空
        /// </summary>
        public short ResetXI()
        {
            return ExCardHelper.ResetIO((short)this.xi_vaccum.Item2);
        }

        /// <summary>
        /// 开破真空
        /// </summary>
        public short PO()
        {
            return Axis.SetIO(this.po_vaccum.Item1, this.po_vaccum.Item2);
        }

        /// <summary>
        /// 关破真空
        /// </summary>
        public short ResetPO()
        {
            return Axis.ResetIO(this.po_vaccum.Item1, this.po_vaccum.Item2);
        }

        /// <summary>
        /// 延迟吸取
        /// </summary>
        /// <param name="ms"></param>
        /// <returns></returns>
        public short DelayXI(int ms){ Thread.Sleep(ms); return this.XI(); }

        /// <summary>
        /// 延迟破真空
        /// </summary>
        /// <param name="ms"></param>
        /// <returns></returns>
        public short DelayPO(int ms){ Thread.Sleep(ms); return this.PO(); }

        /// <summary>
        /// 是否到达原点
        /// </summary>
        /// <returns>true:到达</returns>
        public bool ReachOrg
        {
            get { return this.bReachOrg; }
            set { this.bReachOrg = value; }
        }

        ///// <summary>
        ///// 是否到达动点
        ///// </summary>
        ///// <returns>true:到达</returns>
        //public bool ReachDone
        //{
        //    get { return this.bReachDone; }
        //    set { this.bReachDone = value; }
        //}

        /// <summary>
        /// 是否达到真空值
        /// </summary>
        /// <returns></returns>
        public bool ReachVaccum
        {
            get { return this.bReachVaccum; }
            set { this.bReachVaccum = value; }
        }

        /// <summary>
        /// Z轴 放下
        /// </summary>
        public short PutDown()
        {
            short rtn = Axis.ResetIO(this.z_cylinderOrg.Item1, this.z_cylinderOrg.Item2);
            rtn += Axis.SetIO(this.z_cylinderDone.Item1, this.z_cylinderDone.Item2);
            return rtn;
        }

        /// <summary>
        /// Z轴抬起
        /// </summary>
        public short PutUp()
        {
            short rtn = Axis.SetIO(this.z_cylinderOrg.Item1, this.z_cylinderOrg.Item2);
            rtn += Axis.ResetIO(this.z_cylinderDone.Item1, this.z_cylinderDone.Item2);
            return rtn;
        }
        #endregion

        #region 视觉操作相关
        /// <summary>
        /// Z轴
        /// </summary>
        /// <param name="camPoint"></param>
        /// <param name="pixelPoint"></param>
        /// <returns></returns>
        public PointF Point_To_DownCCDCenter(PointF camPoint, PointContour pixelPoint)
        {
            return default(PointF);
        }

        public PointF Nozzle_To_CamPoint(PointF CamPoint)
        {
            return default(PointF);
        }

        /// <summary>
        /// 获得
        /// </summary>
        /// <param name="CamPoint"></param>
        /// <returns></returns>
        public PointF CamPoint_To_NozzlePoint(PointF CamPoint)
        {
            return default(PointF);
        }

        /// <summary>
        /// 获得 
        /// </summary>
        /// <param name="CamPoint"></param>
        /// <returns></returns>
        public PointF Nozzle_To_CamLabelPoint(PointF CamPoint)
        {
            return default(PointF);
        }

        /// <summary>
        /// 获得 当前 吸嘴到相机点
        /// </summary>
        /// <param name="CamPoint"></param>
        /// <returns></returns>
        public PointF CamLabel_To_NozzlePoint(PointF CamPoint)
        {
            return default(PointF);
        }
        #endregion

        #region JOB 相关

        /// <summary>
        /// 下视觉拍照点1
        /// </summary>
        public PointF[] Cam_Point = new PointF[2];
    
        /// <summary>
        /// 吸嘴拍摄次数
        /// </summary>
        public int SnapCount { get; set; } = 1;

        /// <summary>
        /// 吸嘴下视觉计算次数
        /// </summary>
        public int CalCount { get; set; } = 0;

        /// <summary>
        /// 吸嘴 拍照点基准（MARK1）次序-基准点在哪个拍照点
        /// </summary>
        public short CamAlignOrigin { get; set; } = 1;

        /// <summary>
        /// 下视觉扑抓到的图片1
        /// </summary>
        public VisionImage[] CaptureImage { get; set; } = new VisionImage[2];

        #endregion

        #region 自动流程相关
        /// <summary>
        /// 吸嘴可以贴附的点数
        /// </summary>
        //public short RUN_MarkCount { get; set; } = 0;

        /// <summary>
        /// 当次吸嘴在贴第几块板子-----------------多板模式下
        /// </summary>
        public short RUN_PasteInfoIndex { get; set; } = -1;

        /// <summary>
        /// 吸嘴在小板模式【扩展前】下的序列号; 当次吸嘴在[小板模式LIST]下的序列号
        /// </summary>
        public short RUN_PasteInfoIndex_List { get; set; } = 0;

        /// <summary>
        /// 吸嘴是否可用
        /// </summary>
        public bool RUN_bNozzleUse { get; set; } = false;

        /// <summary>
        /// 当前吸嘴 上的Label 是否  0-不使用 1-未使用过 2-使用已过下视觉OK 4-使用已过下视觉NG 3-已贴完 5-有标但需要抛料
        /// </summary>
        public short RUN_dNozzleDownVisionED { get; set; } = 0;

        /// <summary>
        /// 当前吸嘴 吸取Feeder 号码 1-左 2-右
        /// </summary>
        public short RUN_Nozzle_FeederIndex { get; set; } = 0;

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
        public PointF Nozzle_DownXY_Pos = new PointF();
        
        /// <summary>
        /// 吸嘴 上Label  MARK的角度
        /// </summary>
        public double Nozzle_Down_Angle { get; set; } = 0;

        /// <summary>
        /// 下视觉结果  拍照点1  拍照点2
        /// </summary>
        public Variable.CamReturn[] CamResult { get; set; } = new Variable.CamReturn[2] { new Variable.CamReturn(), new Variable.CamReturn()};

        /// <summary>
        /// 重置自动运行参数
        /// </summary>
        public void ResetAutoRunParam()
        {
            CamResult[0].IsOK = false;
            CamResult[1].IsOK = false;

            Nozzle_Down_Angle = 0;
            Nozzle_DownXY_Pos = new PointF();
            RUN_PasteRealAngle = 0;
            RUN_PasteRealPoint = new PointF();
            RUN_PastePointIndex = 0;
            RUN_Nozzle_FeederIndex = 0;
            RUN_dNozzleDownVisionED = 0;
            RUN_bNozzleUse = false;
            RUN_PasteInfoIndex_List = 0;
            RUN_PasteInfoIndex = 0;
            //RUN_MarkCount = 0;
        }

        #endregion

        #region 显示相关
        /// <summary>
        /// 显示是完成
        /// </summary>
        public Label PassLabel = null;

        /// <summary>
        /// 显示图片
        /// </summary>
        public ImageViewer Viewr1 = null;

        /// <summary>
        /// 显示图片
        /// </summary>
        public ImageViewer Viewr2 = null;

        /// <summary>
        /// 是否需要更新 UpdateImage
        /// </summary>
        public bool UpdateImage { get; set; } = false;

        public void ShowStatus()
        {
            try
            {
                if (this.UpdateImage)
                {
                    if (this.SnapCount == 1)
                    {
                        this.PassLabel.Text = this.CamResult[0].IsOK == true ? "PASS" : "FAIL";
                        Form_Main.Instance.SaveImage(this.CamResult[0].IsOK, this.CaptureImage[0]);
                        this.PassLabel.BackColor = this.CamResult[0].IsOK == true ? Color.Green : Color.Red;
                        Algorithms.Copy(this.CaptureImage[0], Viewr1.Image);
                    }
                    else
                    {
                        this.PassLabel.Text = this.CamResult[0].IsOK && this.CamResult[1].IsOK == true ? "PASS" : "FAIL";
                        this.PassLabel.BackColor = this.CamResult[0].IsOK && this.CamResult[1].IsOK == true ? Color.Green : Color.Red;
                        Form_Main.Instance.SaveImage(this.CamResult[0].IsOK, this.CaptureImage[0]);
                        Form_Main.Instance.SaveImage(this.CamResult[1].IsOK, this.CaptureImage[1]);
                        Algorithms.Copy(this.CaptureImage[0], Viewr1.Image);
                        Algorithms.Copy(this.CaptureImage[1], Viewr2.Image);
                    }
                    

                    Viewr1.Image.Overlays.Default.AddText(this.Nozzle_Down_Angle.ToString("F2"), new PointContour(500, 600), Rgb32Value.BlueColor, new OverlayTextOptions("Consolas", 125));
                    this.UpdateImage = false;
                }
            }
            catch { }
        }
        #endregion

        #region 飞拍滞后参数
        public PointF pFLYP_Offset_1 = new PointF();//正拍-吸嘴1拍照点1-像数偏移
        public PointF pFLYP_Offset_2 = new PointF();//正拍-吸嘴1拍照点2-像数偏移

        public PointF pFLYN_Offset_1 = new PointF();//反拍-吸嘴1拍照点1-像数偏移
        public PointF pFLYN_Offset_2 = new PointF();//反拍-吸嘴1拍照点2-像数偏移

        /// <summary>
        /// 正拍-吸嘴 拍照点1-提前拍照X坐标偏移
        /// </summary>
        public double dFLYP_DownCam_1 { get; set; } = 0;
        /// <summary>
        /// 正拍-吸嘴 拍照点2-提前拍照X坐标偏移
        /// </summary>
        public double dFLYP_DownCam_2 { get; set; } = 0;

        /// <summary>
        /// 反拍-吸嘴 拍照点1-提前拍照X坐标偏移
        /// </summary>
        public double dFLYN_DownCam_1 { get; set; } = 0;
        /// <summary>
        /// 反拍-吸嘴 拍照点2-提前拍照X坐标偏移
        /// </summary>
        public double dFLYN_DownCam_2 { get; set; } = 0;

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
        /// 抛料点1
        /// </summary>
        public PointF ThrowPoint1 = new PointF();

        /// <summary>
        /// 抛料点2
        /// </summary>
        public PointF ThrowPoint2 = new PointF();

        /// <summary>
        /// 抛料点3
        /// </summary>
        public PointF ThrowPoint3 = new PointF();

        /// <summary>
        /// 是否启用抛料下压
        /// </summary>
        public bool bThrowPut { get; set; } = false;

        #endregion
    }
}
