
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using NationalInstruments.Vision;
using GeneralLabelerStation.Param;
using GeneralLabelerStation.ViewModle;
using HalconDotNet;

namespace GeneralLabelerStation
{
    public class Variable
    {
        /// <summary>
        /// 吸嘴数
        /// </summary>
        public static int NOZZLE_NUM = 4;

        /// <summary>
        /// 标定相机数
        /// </summary>
        public static int CAIL_NUM = 3; //! up- down1-down2

        /// <summary>
        /// 视觉状态
        /// </summary>
        public enum VisionState
        {
            /// <summary>
            /// 成功
            /// </summary>
            OK,
            /// <summary>
            /// 失败
            /// </summary>
            Fail,
            /// <summary>
            /// 无料
            /// </summary>
            NoLabel,
            /// <summary>
            /// 多料
            /// </summary>
            MoreLabel,
            /// <summary>
            /// 角度过大
            /// </summary>
            AngleFail,
            /// <summary>
            /// 初定位失败
            /// </summary>
            InitFail,
            /// <summary>
            /// 抓圆失败
            /// </summary>
            FindCircleFail,
            /// <summary>
            /// 抓边失败
            /// </summary>
            FindLineFial,
            /// <summary>
            /// 吸标超管控
            /// </summary>
            OutoffRange,
        }

        public struct CamReturn
        {
            public bool IsOK;//计算成功-true 失败-false
            public double X;//计算出来的X坐标数值
            public double Y;//计算出来的Y坐标数值
            public double Angle;//计算出来的角度数值
            public double XScale;
            public double YScale;
            public bool bHaveLabel; // 计算出来的面积是否有料
            public VisionState State; // 视觉状态
        }//相机侦测结果返回结构体
        public struct PASTAE:IDisposable
        {
            public string PasteName;//贴附信息名称

            #region Mark1侦测方式
            //预处理
            public double GainInit1;
            public double OffsetInit1;
            public double GainCircle1;
            public double OffsetCircle1;
            public double GainH1_1;
            public double OffsetH1_1;
            public double GainH2_1;
            public double OffsetH2_1;
            public double GainV1_1;
            public double OffsetV1_1;
            public double GainV2_1;
            public double OffsetV2_1;

            public PointF CamPoint1;
            public double Shutter1;
            public short AlinIndex1;//算法种类
            public PointF Mark1;
            public short Init_ROI_Top1;//初定位***************
            public short Init_ROI_Left1;
            public short Init_ROI_Width1;
            public short Init_ROI_Height1;
            public short Init_OffsetX1;
            public short Init_OffsetY1;
            public PointF Init_Point1;
            public double Init_Angle1;
            public short Score1;
            public double MinAngle1;
            public double MaxAngle1;
            //面积管控
            public bool bAreaEN1;//是否启用面积侦测方法
            public int iAreaMin1;//面积标最小值
            public int iAreaMax1;//面积最大值
            public short iAreaOKStyle1;//OK板方式 1-白色大于 2-白色小于 3- 黑色大于 4-黑色小于

            public short S_ROI_Top1;//圆侦测*******************
            public short S_ROI_Left1;
            public short S_ROI_Width1;
            public short S_ROI_Height1;
            public short S_MinR1;
            public short S_MaxR1;
            public PointF S_Center1;
            //****************************[角参数]*****************************
            public PointF Corner_H1_Point1;//H1
            public short Corner_H1_Top1;
            public short Corner_H1_Left1;
            public short Corner_H1_Width1;
            public short Corner_H1_Height1;
            public double Corner_H1_EdgeStrength1;
            public string Corner_H1_PicDir1;
            public string Corner_H1_GrayValueDir1;

            public PointF Corner_H2_Point1;//H2
            public short Corner_H2_Top1;
            public short Corner_H2_Left1;
            public short Corner_H2_Width1;
            public short Corner_H2_Height1;
            public double Corner_H2_EdgeStrength1;
            public string Corner_H2_PicDir1;
            public string Corner_H2_GrayValueDir1;

            public PointF Corner_V1_Point1;//V1
            public short Corner_V1_Top1;
            public short Corner_V1_Left1;
            public short Corner_V1_Width1;
            public short Corner_V1_Height1;
            public double Corner_V1_EdgeStrength1;
            public string Corner_V1_PicDir1;
            public string Corner_V1_GrayValueDir1;

            public PointF Corner_V2_Point1;//V2
            public short Corner_V2_Top1;
            public short Corner_V2_Left1;
            public short Corner_V2_Width1;
            public short Corner_V2_Height1;
            public double Corner_V2_EdgeStrength1;
            public string Corner_V2_PicDir1;
            public string Corner_V2_GrayValueDir1;

            public PointF Corner_Point1;//
            public short CornerAngleIndex1;//角辅助计算角度1
            //角落分开计算拍照点 & 角落光源打光方式
            //*****************************[H1]*****************************
            public PointF Corner_H1_CamPoint1;//H1初定位拍照点
            public double Corner_H1_Shutter1;
            public short Corner_H1_Init_Top1;//初定位ROI
            public short Corner_H1_Init_Left1;
            public short Corner_H1_Init_Width1;
            public short Corner_H1_Init_Height1;

            public PointF Corner_H1_Init_Point1;//H1初定位 点
            public double Corner_H1_Init_Angle1;//H1初定位 角度
            public short Corner_H1_Init_Score1;//H1初定位 分数
            public double Corner_H1_Init_MinAngle1;//H1初定位 最小角度
            public double Corner_H1_Init_MaxAngle1;//H1初定位 最大角度

            public bool bCorner_H1_Red1;//打光方式
            public bool bCorner_H1_Green1;
            public bool bCorner_H1_Blue1;
            public double dCorner_H1_RedValue1;
            public double dCorner_H1_GreenValue1;
            public double dCorner_H1_BlueValue1;
            //*****************************[H2]*****************************
            public PointF Corner_H2_CamPoint1;//H2初定位拍照点
            public double Corner_H2_Shutter1;
            public short Corner_H2_Init_Top1;//初定位ROI
            public short Corner_H2_Init_Left1;
            public short Corner_H2_Init_Width1;
            public short Corner_H2_Init_Height1;

            public PointF Corner_H2_Init_Point1;//H2初定位 点
            public double Corner_H2_Init_Angle1;//H2初定位 角度
            public short Corner_H2_Init_Score1;//H2初定位 分数
            public double Corner_H2_Init_MinAngle1;//H2初定位 最小角度
            public double Corner_H2_Init_MaxAngle1;//H2初定位 最大角度

            public bool bCorner_H2_Red1;//打光方式
            public bool bCorner_H2_Green1;
            public bool bCorner_H2_Blue1;
            public double dCorner_H2_RedValue1;
            public double dCorner_H2_GreenValue1;
            public double dCorner_H2_BlueValue1;
            //*****************************[V1]*****************************
            public PointF Corner_V1_CamPoint1;//V1初定位拍照点
            public double Corner_V1_Shutter1;
            public short Corner_V1_Init_Top1;//初定位ROI
            public short Corner_V1_Init_Left1;
            public short Corner_V1_Init_Width1;
            public short Corner_V1_Init_Height1;

            public PointF Corner_V1_Init_Point1;//V1初定位 点
            public double Corner_V1_Init_Angle1;//V1初定位 角度
            public short Corner_V1_Init_Score1;//V1初定位 分数
            public double Corner_V1_Init_MinAngle1;//V1初定位 最小角度
            public double Corner_V1_Init_MaxAngle1;//V1初定位 最大角度

            public bool bCorner_V1_Red1;//打光方式
            public bool bCorner_V1_Green1;
            public bool bCorner_V1_Blue1;
            public double dCorner_V1_RedValue1;
            public double dCorner_V1_GreenValue1;
            public double dCorner_V1_BlueValue1;
            //*****************************[V2]*****************************
            public PointF Corner_V2_CamPoint1;//V2初定位拍照点
            public double Corner_V2_Shutter1;
            public short Corner_V2_Init_Top1;//初定位ROI
            public short Corner_V2_Init_Left1;
            public short Corner_V2_Init_Width1;
            public short Corner_V2_Init_Height1;

            public PointF Corner_V2_Init_Point1;//V2初定位 点
            public double Corner_V2_Init_Angle1;//V2初定位 角度
            public short Corner_V2_Init_Score1;//V2初定位 分数
            public double Corner_V2_Init_MinAngle1;//V2初定位 最小角度
            public double Corner_V2_Init_MaxAngle1;//V2初定位 最大角度

            public bool bCorner_V2_Red1;//打光方式
            public bool bCorner_V2_Green1;
            public bool bCorner_V2_Blue1;
            public double dCorner_V2_RedValue1;
            public double dCorner_V2_GreenValue1;
            public double dCorner_V2_BlueValue1;
            //**************************************************************
            public bool bRed1;
            public bool bGreen1;
            public bool bBlue1;
            public double dRedValue1;
            public double dGreenValue1;
            public double dBlueValue1;

            public VisionImage Align1;
            public VisionImage Corner_H1_Align1;
            public VisionImage Corner_H2_Align1;
            public VisionImage Corner_V1_Align1;
            public VisionImage Corner_V2_Align1;

            // 抓边定角度方式
            public double GrabLine_EdgeStrength1;
            public string GrabLine_PicDir1;
            public string GrabLine_GrayValueDir1;
            public string GrabLine_ROI1;
            public bool GrabLine_Enable1;

            public HTuple Model1ID;
            #endregion

            #region Mark2 侦测方式
            //预处理
            public double GainInit2;
            public double OffsetInit2;
            public double GainCircle2;
            public double OffsetCircle2;
            public double GainH1_2;
            public double OffsetH1_2;
            public double GainH2_2;
            public double OffsetH2_2;
            public double GainV1_2;
            public double OffsetV1_2;
            public double GainV2_2;
            public double OffsetV2_2;

            public PointF CamPoint2;
            public double Shutter2;
            public short AlinIndex2;
            public PointF Mark2;
            public short Init_ROI_Top2;
            public short Init_ROI_Left2;
            public short Init_ROI_Width2;
            public short Init_ROI_Height2;
            public short Init_OffsetX2;
            public short Init_OffsetY2;
            public PointF Init_Point2;
            public double Init_Angle2;
            public short Score2;
            public double MinAngle2;
            public double MaxAngle2;
            //面积管控
            public bool bAreaEN2;//是否启用面积侦测方法
            public int iAreaMin2;//面积标准值
            public int iAreaMax2;//二值化数值
            public short iAreaOKStyle2;//OK板方式 1-白色 2-黑色
            //Circle
            public short S_ROI_Top2;
            public short S_ROI_Left2;
            public short S_ROI_Width2;
            public short S_ROI_Height2;
            public short S_MinR2;
            public short S_MaxR2;
            public PointF S_Center2;

            //****************************[角参数]*****************************
            public PointF Corner_H1_Point2;//H1
            public short Corner_H1_Top2;
            public short Corner_H1_Left2;
            public short Corner_H1_Width2;
            public short Corner_H1_Height2;
            public double Corner_H1_EdgeStrength2;
            public string Corner_H1_PicDir2;
            public string Corner_H1_GrayValueDir2;

            public PointF Corner_H2_Point2;//H2
            public short Corner_H2_Top2;
            public short Corner_H2_Left2;
            public short Corner_H2_Width2;
            public short Corner_H2_Height2;
            public double Corner_H2_EdgeStrength2;
            public string Corner_H2_PicDir2;
            public string Corner_H2_GrayValueDir2;

            public PointF Corner_V1_Point2;//V1
            public short Corner_V1_Top2;
            public short Corner_V1_Left2;
            public short Corner_V1_Width2;
            public short Corner_V1_Height2;
            public double Corner_V1_EdgeStrength2;
            public string Corner_V1_PicDir2;
            public string Corner_V1_GrayValueDir2;

            public PointF Corner_V2_Point2;//V2
            public short Corner_V2_Top2;
            public short Corner_V2_Left2;
            public short Corner_V2_Width2;
            public short Corner_V2_Height2;
            public double Corner_V2_EdgeStrength2;
            public string Corner_V2_PicDir2;
            public string Corner_V2_GrayValueDir2;

            public PointF Corner_Point2;//
            public short CornerAngleIndex2;//角辅助计算角度2
            //*************************************************************
            //角落拍照点 & 角落光源打光方式
            //*****************************[H1]*****************************
            public PointF Corner_H1_CamPoint2;//H1初定位拍照点
            public double Corner_H1_Shutter2;
            public short Corner_H1_Init_Top2;//初定位ROI
            public short Corner_H1_Init_Left2;
            public short Corner_H1_Init_Width2;
            public short Corner_H1_Init_Height2;

            public PointF Corner_H1_Init_Point2;//H1初定位 点
            public double Corner_H1_Init_Angle2;//H1初定位 角度
            public short Corner_H1_Init_Score2;//H1初定位 分数
            public double Corner_H1_Init_MinAngle2;//H1初定位 最小角度
            public double Corner_H1_Init_MaxAngle2;//H1初定位 最大角度

            public bool bCorner_H1_Red2;//打光方式
            public bool bCorner_H1_Green2;
            public bool bCorner_H1_Blue2;
            public double dCorner_H1_RedValue2;
            public double dCorner_H1_GreenValue2;
            public double dCorner_H1_BlueValue2;
            //*****************************[H2]*****************************
            public PointF Corner_H2_CamPoint2;//H2初定位拍照点
            public double Corner_H2_Shutter2;
            public short Corner_H2_Init_Top2;//初定位ROI
            public short Corner_H2_Init_Left2;
            public short Corner_H2_Init_Width2;
            public short Corner_H2_Init_Height2;

            public PointF Corner_H2_Init_Point2;//H2初定位 点
            public double Corner_H2_Init_Angle2;//H2初定位 角度
            public short Corner_H2_Init_Score2;//H2初定位 分数
            public double Corner_H2_Init_MinAngle2;//H2初定位 最小角度
            public double Corner_H2_Init_MaxAngle2;//H2初定位 最大角度

            public bool bCorner_H2_Red2;//打光方式
            public bool bCorner_H2_Green2;
            public bool bCorner_H2_Blue2;
            public double dCorner_H2_RedValue2;
            public double dCorner_H2_GreenValue2;
            public double dCorner_H2_BlueValue2;
            //*****************************[V1]*****************************
            public PointF Corner_V1_CamPoint2;//V1初定位拍照点
            public double Corner_V1_Shutter2;
            public short Corner_V1_Init_Top2;//初定位ROI
            public short Corner_V1_Init_Left2;
            public short Corner_V1_Init_Width2;
            public short Corner_V1_Init_Height2;

            public PointF Corner_V1_Init_Point2;//V1初定位 点
            public double Corner_V1_Init_Angle2;//V1初定位 角度
            public short Corner_V1_Init_Score2;//V1初定位 分数
            public double Corner_V1_Init_MinAngle2;//V1初定位 最小角度
            public double Corner_V1_Init_MaxAngle2;//V1初定位 最大角度

            public bool bCorner_V1_Red2;//打光方式
            public bool bCorner_V1_Green2;
            public bool bCorner_V1_Blue2;
            public double dCorner_V1_RedValue2;
            public double dCorner_V1_GreenValue2;
            public double dCorner_V1_BlueValue2;
            //*****************************[V2]*****************************
            public PointF Corner_V2_CamPoint2;//V2初定位拍照点
            public double Corner_V2_Shutter2;
            public short Corner_V2_Init_Top2;//初定位ROI
            public short Corner_V2_Init_Left2;
            public short Corner_V2_Init_Width2;
            public short Corner_V2_Init_Height2;

            public PointF Corner_V2_Init_Point2;//V2初定位 点
            public double Corner_V2_Init_Angle2;//V2初定位 角度
            public short Corner_V2_Init_Score2;//V2初定位 分数
            public double Corner_V2_Init_MinAngle2;//V2初定位 最小角度
            public double Corner_V2_Init_MaxAngle2;//V2初定位 最大角度

            public bool bCorner_V2_Red2;//打光方式
            public bool bCorner_V2_Green2;
            public bool bCorner_V2_Blue2;
            public double dCorner_V2_RedValue2;
            public double dCorner_V2_GreenValue2;
            public double dCorner_V2_BlueValue2;

            //*************************************************************
            public bool bRed2;
            public bool bGreen2;
            public bool bBlue2;
            public double dRedValue2;
            public double dGreenValue2;
            public double dBlueValue2;

            public VisionImage Align2;
            public VisionImage Corner_H1_Align2;
            public VisionImage Corner_H2_Align2;
            public VisionImage Corner_V1_Align2;
            public VisionImage Corner_V2_Align2;

            // 抓边定角度方式
            public double GrabLine_EdgeStrength2;
            public string GrabLine_PicDir2;
            public string GrabLine_GrayValueDir2;
            public string GrabLine_ROI2;
            public bool GrabLine_Enable2;
            #endregion

            #region 贴附点信息
            public bool bMark1ED;//0-没有拍过 1-拍过
            public bool bMark2ED;//0-没有拍过 1-拍过
            public bool bMark1Caled;//0-没有计算过 1-计算过
            public bool bMark2Caled;//0-没有计算过 1-计算过

            public int[] iPasteED;//0-没有贴过 1-贴过 || 0-好的 1-坏的（SFCS）
            public string[] PastePN;//同一组的号码 即 BadMark编号（同一组只有一个BadMark）
            public bool[] PasteEN;//贴附使能
            public PointF[] PastePoints;//贴附点XY坐标
            public double[] PasteAngle;//贴附点角度
            /// <summary>
            /// 基准角度
            /// </summary>
            public double BaseAngle;
            /// <summary>
            /// 吸嘴贴附高度 PasteHeight[Row][Nozzle]
            /// </summary>
            public List<List<double>> PasteHeight;

            public short[] FeederIndex;//Feeder 序号
            public short[] NozzleIndex;//Nozzle 序号
            public bool[] IsPastePointsAbs;//贴附点是否为绝对点位置（CPK-使用相对距离位置）
            public short[] Delay;//保压延时
            public double[] dPressureValue;//贴附压力值

            public double Rotation;//纠正过的角度
            public PointF[] TransformedPoints;//纠正过的点位信息
            #endregion

            #region 单个偏移
            public double[] OffsetX_Single;
            public double[] OffsetY_Single;
            #endregion

            #region 整板偏移
            public double OffsetX;//整板的偏移X
            public double OffsetY;//整板的偏移Y
            public double OffsetR;//整板的偏移R
            #endregion

            #region BadMark
            public bool[] BadMarkEN;//BadMark启用与否
            public int[] iBadMarkED;//BadMark结果 0-没有拍 1-拍过需要贴 2-拍过NG不需要贴
            public PointF[] BadMarkPoints;//BadMark点
            public PointF[] TransformedBadMarkPoints;//纠正过的BadMark点位信息
            
            //BadMark侦测的算法
            public short BadMark_ROI_Top;//ROI
            public short BadMark_ROI_Left;//ROI
            public short BadMark_ROI_Width;//ROI
            public short BadMark_ROI_Height;//ROI
            public short BadMark_AlgthrimIndex;//BadMark算法 0-面积 1-匹配
            public double BadMark_Shutter;//BadMark相机曝光
            public bool BadMark_bRed;//BadMark打光方式---红光使用与否
            public bool BadMark_bGreen;//BadMark打光方式---绿光使用与否
            public bool BadMark_bBlue;//BadMark打光方式---蓝光使用与否
            public double BadMark_dRedValue;//BadMark打光方式---红光亮度
            public double BadMark_dGreenValue;//BadMark打光方式---绿光亮度
            public double BadMark_dBlueValue;//BadMark打光方式---蓝光亮度
            //0-面积
            public short BadMark_Threshold;//面积二值化值
            public int BadMark_LimtArea;//面积阈值
            public short ISBadMarkWhite;//正常是否为白色区域 0-白色大于阈值 1-黑色大于阈值 2-白色小于阈值 3-黑色小于阈值
            //1-匹配
            public VisionImage BadMark_Image;//模板
            public short BadMark_Score;//模板设定分数
            public double BadMark_MinAngle;//模板找寻最小角度
            public double BadMark_MaxAngle;//模板找寻最大角度

            public void Dispose()
            {
                if (this.Model1ID != null)
                    HOperatorSet.ClearShapeModel(this.Model1ID);
            }
            #endregion
        }//贴附信息结构体
        public class JOB
        {
            public short PasteCount;//贴附的小板数目(小板-即为PASTE)
            /// <summary>
            /// 小板结果 0-未计算 1-计算OK 2-计算NG
            /// </summary>
            public short[] iUpCCDResult;
            public CamReturn[] UpCCDResult1;//默认拍摄两次 第一次的结果
            public CamReturn[] UpCCDResult2;//默认拍摄两次 第二次的结果
            /// <summary>
            /// 是否整板照过 MarK点
            /// </summary>
            public bool bCalMark;
            public String[] PasteName;//贴附信息 名称
            public PointF[] Cam_Mark1Point;//贴附 Mark1拍照点
            public PointF[] Cam_Mark2Point;//贴附 Mark2拍照点（若只拍一次 则可以不设置）
            public double[] OffsetX;//贴附 强制X偏移（整块小板的强制补偿）
            public double[] OffsetY;//贴附 强制Y偏移（整块小板的强制补偿）
            public double[] OffsetR;//贴附 强制R偏移（整块小板的强制补偿）
            public int[] UsedFeeder; // 贴服 强制使用 Feeder
            public int[] UsedNz; // 贴附 强制使用吸嘴
            public double[] FlyDelay;

            public bool bUpFly; // 是否为上视觉飞拍模式
            public bool bLocalMode; // 是否是Local 方式
            public int iLocalAlign; // 1:GlobalMark+BadMark 2:LocalMark
            public double GainFly;//飞拍模式下 增益
            public double OffsetFly;//飞拍模式下 灰度偏移

            public GlobalMarkModule GlobalConfig;
            public  PASTAE[] PASTEInfo;//详细贴附信息
            public List<PASTAE> PASTEInfo_List;//详细贴附信息_list
        }//正常工作 多板（多个PASTE联合成（扩展、镜像、旋转 等等））

        public class FEEDER
        {
            public short Delay;//出标延时
            public string PN;//FEEDER 上的什么料(标签? 蓝膜? 背胶?)
            public PASTAE Label;//料下视觉侦测方式
            public double Cam_Degree;//料下视觉侦测角度

            /// <summary>
            /// 标准取料位置
            /// </summary>
            public PointF StandardSuckPos = new PointF();

            //是否提前开真空 true-提前开 false-Z到位再开
            public bool bReachXI;
            public double[] XI_Degree;//吸取时候的角度
            public short PointCount;//一共出多少个标签
            public PointF[] CamPoints;//Up相机 相机对位时的拍照点
            public short[] ReachSensorIndex;//到位Sensor序列号
            /// <summary>
            /// 是否需要等待到位
            /// </summary>
            public bool NeedWaitReach = false;
            /// <summary>
            /// 吸标高度 
            /// </summary>
            public List<List<double>> XIHeight;
        }//Feeder出标 取标 下视觉

        public struct VelMode
        {
            public double LowVel;
            public double HighVel;
            public double Acc;
            public double Dec;

            public VelMode(double low_vel, double high_vel,double acc,double dec)
            {
                this.LowVel = low_vel;
                this.HighVel = high_vel;
                this.Acc = acc;
                this.Dec = dec;
            }
        }//速度结构体

        /// <summary>
        /// 贴服小板信息
        /// </summary>
        public struct PasteItem
        {
            public string PasteName;

            public PointF Cam1;

            public PointF Cam2;

            public double OffsetX;

            public double OffsetY;

            public double OffsetR;

            public int UsedFeeder;

            public int UsedNz;

            public double FlyDelay;
        }

        public class CCDReCheck
        {
            public bool CheckEN;//启用复检与否
            public int iReCheckEveryCount;//复检频率  数目
            //单点信息
            public short iPointCount;//表格一共多少个点
            public short[] iGroupIndex;//组别
            public bool[] bFidicial;//是否为基准 true-基准 false-测量点
            public short[] iROIIndex;//0-H1 1-H2 2-V1 3-V2
            public PointF[] pCamPoints;//相机拍照点
            public double[] dShutter;//相机拍照曝光
            public bool[] bRed;//红光使用与否
            public bool[] bGreen;//绿光使用与否
            public bool[] bBlue;//蓝光使用与否
            public double[] dRedValue;//红光亮度
            public double[] dGreenValue;//绿光亮度
            public double[] dBlueValue;//蓝光亮度

            public bool[] bInitON;//初定位开启与否
            public VisionImage[] InitImage;//初定位模板
            public short[] InitScore;
            public double[] InitMinAngle;
            public double[] InitMaxAngle;
            public short[] Init_ROI_Top;
            public short[] Init_ROI_Left;
            public short[] Init_ROI_Width;
            public short[] Init_ROI_Height;

            public short[] Edge_Strength;
            public string[] Edge_PicDir;
            public string[] Edge_GrayDir;
            public short[] Edge_ROI_Top;
            public short[] Edge_ROI_Left;
            public short[] Edge_ROI_Width;
            public short[] Edge_ROI_Height;
            public double[] SpecMin;//最小公差数值
            public double[] SpecMax;//最大公差数值
        }//复检功能
        //*******************************************************[轴 pulse/mm 比例 或者 pulse/deg 比例]*******************************************************
        public double dRatio_Axis_X = 100;
        public double dRatio_Axis_Y = 100;
        public double dRatio_Axis_Turn = 250;
        public double dRatio_Axis_R = 13.888889;
        public double dRatio_Axis_Z = 50;
        public double dRatio_Axis_Wide = 400;
        public double dRatio_Axis_Conveyor = 40;
        public double dRatio_Axis_ConveyorLeft = 40;
        public double dRatio_Axis_ConveyorRight = 40;
        //*******************************************************[光源目前数值]*******************************************************
        public bool bRedU, bGreenU, bBlueU, bRedD, bGreenD, bBlueD;
        public double dRedValue_U;//
        public double dGreenValue_U;
        public double dBlueValue_U;
        public double dRedValue_D;
        public double dGreenValue_D;
        public double dBlueValue_D;

        //*******************************************************[IO表]*******************************************************
        #region IO表
        public bool[] bIO_Card_0to3, bIO_Card_4to7;//输入
        public bool[] bIO_Out_Card_0to3, bIO_Out_Card_4to7;//输出
        //public bool[] bIO_IN_ExCard, bIO_Out_ExCard; // 扩展输入输出

        public bool bAxis_X_Origin, bAxis_Y_Origin;//, bAxis_R1_Origin, bAxis_R2_Origin, bAxis_Wide_Origin;
        public bool bAxis_X_LimP, bAxis_Y_LimP, bAxis_Wide_LimP;
        public bool bAxis_X_LimN, bAxis_Y_LimN, bAxis_Wide_LimN;

        public class IO_IN_Parameter
        {
            public IO.IOInput bIN_AirPressure;//气压检测
            public IO.IOInput bIN_FeederOK_Left;//左Feeder放好
            public IO.IOInput bIN_FeederOK_Right;//右Feeder放好
            /// <summary>
            /// 启动感应
            /// </summary>
            public IO.IOInput bIN_StartBtn;
            /// <summary>
            /// 停止感应
            /// </summary>
            public IO.IOInput bIN_StopBtn;
            /// <summary>
            /// 复位感应
            /// </summary>
            public IO.IOInput bIN_ResetBtn;
            public IO.IOInput bIN_SafeDoor;//上安全门
            public IO.IOInput bIN_SafeGrant; // 安全光柵
            public IO.IOInput bIN_Stop_Origin;//轨道-档板原点
            public IO.IOInput bIN_Stop_Move;//轨道-档板动点
            public IO.IOInput bIN_Carry_Origin;//轨道上下夹板原点
            public IO.IOInput bIN_Carry_Move;//轨道上下夹板动点
            public int[] bIN_LabelReach_Left;//左Label到位
            public int[] bIN_LabelReach_Right;//右Label到位
            public bool bIN_Conveyor_BeforeReady;//前流水Ready
            public bool bIN_AfterRequest;//后要板
            public bool bIN_WorkSpace_Out;//轨道-出口感应
            public bool bIN_WorkSpace_Reach;//轨道-到位感应
            public bool bIN_WorkSpace_IN;//轨道-进板感应
        }
        #endregion
        //*******************************************************[SystemParameter]*******************************************************
        //Position
        //public List<double> R_DegInitList = new List<double>();//初始旋转轴 初始角度 R1

        public PointF pReadyPoint;//待料点
        public short iThrowTime;//抛料时间
        public short iThrowAlarmTime;//连续抛料报警次数
        public int iThrowAlarmAddTime;//累计抛料报警次数
        public int iSuckAlarmTime;//连续吸标失败报警次数

        public PointF pTest1, pTest2, pTest3, pTest4;//刚性测试点1到点4
        //Feeder
        public string sFeederLeftName = "";//
        public string sFeederRightName = "";//
        //LastJob
        public string sJobName = "";
        //LastProgram
        public string sProgramName = "";
        //ReCheck
        public string sReCheckName = "";
        //public string sProductInfoPath = "";//程式路径
        //Statistics
        public int iTotalCount = 0;//总数
        public int iNGCount = 0;//NG数
        //VisionCalibration
        public short iNozzleCount = 1;
        public PointF[] pNozzle_2_Cam;//吸嘴到相机中心距离
        public PointF pLabelCam2MarkCam;//Label相机到Mark相机中心距离
        public PointF pNozzle_2_CamLabel;//吸嘴1到Label相机中心距离
        public PointF[] pDownMarkCoord;//下相机Mark坐标
        public PointF[] pPasteCoord;//贴附坐标
        public PointF[] pUpMarkCoord;//上相机坐标
        public PointContour[] pDownRotateCenter;//旋转中心坐标
        public PointF[] pDownRotateCam;//选择中心拍照中心
        public RectangleContour[] rDownROI; // 下视觉搜索区域
        //RunOption
        public short ConveyorStyle = 0;//0-一段式 1-三段式
        public short LanguageFlag = 0;//0-chinese 1-english
        public short iAddress_FeederDelay1 = 0;
        public short iAddress_FeederDelay2 = 0;
        public short iAddress_FeederSpeed1 = 10;
        public short iAddress_FeederSpeed2 = 10;
        public short ComIndex_LightUp = 0;//上光源COM口
        public short ComIndex_LightDown = 0;//下光源COM口
        public short ComIndex_FeederPLC = 0;//Feeder PLC COM口
        public short LightUpVendor = 0;//0-huilin 1-OPT
        public short LightDownVendor = 0;//0-huilin 1-OPT
        public bool bRunMode = true;//机台运行模式 false-BYPASS|true-Run
        public int iOutSideBadMark = 0;//读BadMark 0-SFCS 1-自动扫描 2-SFCS失败自动切换到自动扫描 3-屏蔽

        /// <summary>
        /// Z 轴回原点方式 0： 不带限位感应器 1: 带限位感应器
        /// </summary>
        public int iZHomeStyle = 1;
        public bool bLabelOffsetEN = true;//false-不补正 true-启用补正
        public bool bSafeDoorEN = true;//false-屏蔽 true-启用不屏蔽
        public bool bVisionEN = false;//false-屏蔽 true-启用不屏蔽
        public bool bAfterBreakEN = true;//false-屏蔽 true-启用不屏蔽
        public bool bSystemIsOnLine = true;//false-离线模式 true-在线模式
        public short dFlowIN_OUT = 1;//1-左进右出 2-右进左出 3-左进左出 4-右进右出 5-左进右出(三段) 6-右进左出(三段)
        public double dMaxOffsetX = 5;//最大偏移量X
        public double dMaxOffsetY = 5;//最大偏移量Y
        public double dMaxOffsetR = 5;//最大偏移量R
        public short iAxisSource = 0;//0-编码器反馈数值 1-规划器数值

        public bool bEnableAsyncXI = true; // 启用吸嘴同吸功能
        public bool bEnableGlassOffset = false; // 启用玻璃杯坐标补偿
        public bool bEnableVacuumCheck = false; // 启用真空检测
        public bool bEnableLineOffset = false; // 启用线性矫正
        public bool bEnableThrowPut = false; // 启用抛料下压功能

        public bool bPressureEN = false;//false-不启用压力反馈 true-启用压力反馈
        
        // Turn Pos
        /// <summary>
        /// 贴标时 翻转气缸的角度
        /// </summary>
        public double dTurnPasteAngle = 0;

        /// <summary>
        /// 吸标时 翻转气缸的角度
        /// </summary>
        public double dTurnXIAngle = 0;

        /// <summary>
        /// X轴 最小安全贴标
        /// </summary>
        public double dXSafeMinX = 0;

        /// <summary>
        /// X轴 最大安全贴标
        /// </summary>
        public double dXSafeMaxX = 0;

        //TimeOut
        public short iDelay_PASTE = 100;//延时 吸之前
        public short iDelay_BeforeXI = 100;//延时 吸之前
        public short iDelay_XIOK = 100;//吸真空达到延时
        public short iDelayReach = 1000;//产品到位延时
        public short iUpCamDelay = 100;//走停模式下的上拍照延时
        public short iDownCamDelay = 100;//走停模式下的上拍照延时
        public int iDelayReached = 1000;//产品顶升到位后延时

        public short iXIRetry = 3;//吸失败重吸次数
        public double iTimeOut_Feeder = 3;//超时 feeder
        public double iTimeOut_Normal = 3;//超时 正常动作
        //SaveFile
        public short iPic_SaveIndex = 0;//图片保存 方式//0-none 1-ok 2-ng 3-all
        public string sPath_PicSave = "D:\\SavePic";//保存图片 路径
        public string sLogPath = "D:\\Log\\";//log 路径
        //VelMode
        public short iVelMode_Current_NO;//目前速度模式 1-run(1) 2-slow(0.5) 3-debug(0.1)
        //速度比例
        public double dRatio_Axis_XY_LowVel = 1;
        public double dRatio_Axis_X_LowVel = 1;
        public double dRatio_Axis_Y_LowVel = 1;
        public double dRatio_Axis_Turn_LowVel = 1;
        public double dRatio_Axis_R_LowVel = 1;

        public double dRatio_Axis_XY_HighVel = 1;
        public double dRatio_Axis_X_HighVel = 1;
        public double dRatio_Axis_Y_HighVel = 1;
        public double dRatio_Axis_Turn_HighVel = 1;
        public double dRatio_Axis_R_HighVel = 1;

        //加速度比例
        public double dRatio_Axis_XY_Dec = 1;
        public double dRatio_Axis_X_Dec = 1;
        public double dRatio_Axis_Y_Dec = 1;
        public double dRatio_Axis_Turn_Dec = 1;
        public double dRatio_Axis_R_Dec = 1;

        public double dRatio_Axis_XY_Acc = 1;
        public double dRatio_Axis_X_Acc = 1;
        public double dRatio_Axis_Y_Acc = 1;
        public double dRatio_Axis_Turn_Acc = 1;
        public double dRatio_Axis_R_Acc = 1;

        public VelMode VelMode_Current, VelMode_Debug, VelMode_Slow, VelMode_Run;//速度模式//正常运行三种速度模式及目前的速度
        public VelMode VelMode_Fly; //正常运行飞拍速度
        public VelMode VelMode_UpFly; //正常运行飞拍速度

        #region 分段加速
        //距离速度比例
        public short DistVelCount;
        public double[] DistVel_MinDist;
        public double[] DistVel_MaxDist;
        public double[] DistVel_Ratio_LowVel;
        public double[] DistVel_Ratio_HighVel;
        public double[] DistVel_Ratio_Acc;
        public double[] DistVel_Ratio_Dec;
        #endregion

        //正常运行 轨道速度-(正常和减速)
        public VelMode VelMode_Conveyor, VelMode_Conveyor_SlowDown;
        //手动运行三种速度调节
        public short iVelMode_Current_NO_Manual;//目前速度模式 1-run(1) 2-slow(0.5) 3-debug(0.1)
        public VelMode VelMode_Current_Manual, VelMode_Debug_Manual, VelMode_Slow_Manual, VelMode_Run_Manual;//速度模式
        //空跑模式速度
        public VelMode VelMode_Test;
        //调宽速度
        public VelMode VelMode_Wide;
        //回零速度配置
        public VelMode VelMode_Home_XY;//回极限速度
        public VelMode VelMode_Home_X;
        public VelMode VelMode_Home_Y;

        public VelMode VelMode_Home_R1;
        public VelMode VelMode_Home_R2;
        public VelMode VelMode_Home_R3;
        public VelMode VelMode_Home_R4;
        public VelMode VelMode_Home_Wide;
        //*******************************************************[系统设定]*******************************************************
        public VisionImage imageCali_Template;
        public VisionImage imageCali_Gemetric;
       
        public static int PassWordOK = 0;//密码确认 1-密码错误 2-管理员密码正确 3-工程师密码正确 4-操作员密码正确
        public static string sPath_BaseProgram = System.AppDomain.CurrentDomain.BaseDirectory;//程式执行路径
        public bool bKeyBoardMoveEnable = false;
        //public bool bKeyboardMove_XP = false;
        //public bool bKeyboardMove_XN = false;
        //public bool bKeyboardMove_YP = false;
        //public bool bKeyboardMove_YN = false;
        //public bool bKeyboardMove_ZP = false;
        //public bool bKeyboardMove_ZN = false;

        public static string sPath_CaliPath = System.AppDomain.CurrentDomain.BaseDirectory + "Configure\\CalibResult\\Cam{0}";
        public static string sPath_ImageBackGround = "\\background.bmp";
        public static string sPath_CaliImage = "\\cali.png";

        public static string sDir_CaliPlane = System.AppDomain.CurrentDomain.BaseDirectory + "Configure\\PlaneLiner";//
        public static string sPath_CaliPlane = System.AppDomain.CurrentDomain.BaseDirectory + "Configure\\PlaneLiner\\cal_PlaneLiner{0}.ini";//

        //public static string sPath_CaliPlane1 = System.AppDomain.CurrentDomain.BaseDirectory + "Configure\\cal_PlaneLiner1.ini";//
        //public static string sPath_CaliPlane2 = System.AppDomain.CurrentDomain.BaseDirectory + "Configure\\cal_PlaneLiner2.ini";//
        //public static string sPath_CaliPlane3 = System.AppDomain.CurrentDomain.BaseDirectory + "Configure\\cal_PlaneLiner3.ini";//
        //public static string sPath_CaliPlane4 = System.AppDomain.CurrentDomain.BaseDirectory + "Configure\\cal_PlaneLiner4.ini";//

        public static string sPath_CaliPlaneNonliner = System.AppDomain.CurrentDomain.BaseDirectory + "Configure\\PlaneLiner\\cal_PlaneNonLiner{0}.xls";//

        //public static string sPath_CaliPlaneNonliner1 = System.AppDomain.CurrentDomain.BaseDirectory + "Configure\\cal_PlaneNonLiner1.xls";//
        //public static string sPath_CaliPlaneNonliner2 = System.AppDomain.CurrentDomain.BaseDirectory + "Configure\\cal_PlaneNonLiner2.xls";//
        //public static string sPath_CaliPlaneNonliner3 = System.AppDomain.CurrentDomain.BaseDirectory + "Configure\\cal_PlaneNonLiner3.xls";//
        //public static string sPath_CaliPlaneNonliner4 = System.AppDomain.CurrentDomain.BaseDirectory + "Configure\\cal_PlaneNonLiner4.xls";//

        public static string sPath_Configure = System.AppDomain.CurrentDomain.BaseDirectory + "Configure\\";
        public static string sPath_Adt_Configure = System.AppDomain.CurrentDomain.BaseDirectory + "Configure\\Adventech.cfg";//8轴配置文件
        public static string sPath_Adt_Configure2 = System.AppDomain.CurrentDomain.BaseDirectory + "Configure\\Adventech4Axis.cfg";//4轴配置文件
        public static string sPath_XLS_Configure = System.AppDomain.CurrentDomain.BaseDirectory + "Configure\\Init.xls";//表格初始化
        public static string sPath_FeederInfoConfig = System.AppDomain.CurrentDomain.BaseDirectory + "Configure\\CurrentFeederConfig.xml";//
        public static string sPath_MachineConfig = System.AppDomain.CurrentDomain.BaseDirectory + "Configure\\MachineConfig.xml";//
      
        public static string sPath_SYS_MachineNO = "D:\\ALM1000";//
        public static string sPath_SYS_Program = sPath_SYS_MachineNO + "\\ALMProgram";//打包程式
        public static string sPath_SYS_FEEDER = sPath_SYS_MachineNO + "\\FEEDER";//程式模块1-Feeder
        public static string sPath_SYS_JOBFILE = sPath_SYS_MachineNO + "\\JOBFILE";//程式模块2-JOBFILE
        public static string sPath_SYS_LABEL = sPath_SYS_MachineNO + "\\LABEL";//程式模块3-LABEL
        public static string sPath_SYS_LABEL_UP = sPath_SYS_MachineNO + "\\LABEL_UP";//程式模块3-LABEL
        public static string sPath_SYS_PASTE = sPath_SYS_MachineNO + "\\PASTE";//程式模块4-PASTE
        public static string sPath_SYS_FLY = sPath_SYS_MachineNO + "\\FLYCapture";//
        public static string sPath_SYS_BadMark = sPath_SYS_MachineNO + "\\BadMark";//
        public static string sPath_SYS_ReCheck = sPath_SYS_MachineNO + "\\ReCheck";// 
        public static string sPath_SYS_Jig = sPath_SYS_MachineNO + "\\Jig\\";//

        public static string sPath_ReadCodeBean = sPath_SYS_MachineNO + "\\ReadCodeBean\\";//
        public static string sPath_ZDTMESLog = "D:\\MES对接日志\\";//
        public static string sPath_ErrorCodeInfoConfig = sPath_SYS_MachineNO + "\\ErrorCode.xls";//

        //public int iProductCount = 0;//产品总数
        //public int iUpCCD_OK = 0;//上相机OK数目
        //public int iUpCCD_Total = 0;//上相机总数目
        //public int iDownCCD_OK = 0;//下相机OK数目
        //public int iDownCCD_Total = 0;//下相机总数目
        //public uint iThrowedLeftNozzle = 0; // 左吸嘴抛料次数
        //public uint iThrowedRightNozzle = 0; // 右吸嘴抛料次数
    }
}
