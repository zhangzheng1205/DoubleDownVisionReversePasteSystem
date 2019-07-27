using Advantech.Motion;
using System;
using System.Collections;
using System.Drawing;
using System.Runtime.InteropServices; //For Marshal
using static GeneralLabelerStation.Variable;

namespace GeneralLabelerStation.Param
{
    public class Axis_Advantech
    {
        /// <summary>
        /// 比例
        /// </summary>
        public double AxisRatio = 0;

        /// <summary>
        /// 实际世界数值
        /// </summary>
        public double ActAxisValue = 0;

        public double Vel_Low_Ratio = 1;

        public double Vel_High_Ratio = 1;

        public double Vel_Acc_Ratio = 1;

        public double Vel_Dec_Ratio = 1;

        public int axisDefine = -1;

        public virtual void SetSpeedRatio(double low, double high, double acc, double dec)
        {
            this.Vel_Low_Ratio = low;
            this.Vel_High_Ratio = high;
            this.Vel_Acc_Ratio = acc;
            this.Vel_Dec_Ratio = dec;
        }

        #region 研华板卡数据结构定义
        /// <summary>
        /// 马达状态-左右限位 原点 到位 急停
        /// </summary>
        public enum Ax_Motion_IO
        {
            AX_MOTION_IO_RDY = 1,
            AX_MOTION_IO_ALM = 2,
            AX_MOTION_IO_LMTP = 4,
            AX_MOTION_IO_LMTN = 8,
            AX_MOTION_IO_ORG = 16,
            AX_MOTION_IO_DIR = 32,
            AX_MOTION_IO_EMG = 64,
            AX_MOTION_IO_PCS = 128,
            AX_MOTION_IO_ERC = 256,
            AX_MOTION_IO_EZ = 512,
            AX_MOTION_IO_CLR = 1024,
            AX_MOTION_IO_LTC = 2048,
            AX_MOTION_IO_SD = 4096,
            AX_MOTION_IO_INP = 8192,
            AX_MOTION_IO_SVON = 16384,
            AX_MOTION_IO_ALRM = 32768,
            AX_MOTION_IO_SLMTP = 65536,
            AX_MOTION_IO_SLMTN = 131072,
            AX_MOTION_IO_CMP = 262144,
            AX_MOTION_IO_CAMDO = 524288,
        }

        /// <summary>
        /// 轴状态
        /// </summary>
        public enum AxisState
        {
            STA_AX_DISABLE = 0,
            STA_AX_READY = 1,
            STA_AX_STOPPING = 2,
            STA_AX_ERROR_STOP = 3,
            STA_AX_HOMING = 4,
            STA_AX_PTP_MOT = 5,
            STA_AX_CONTI_MOT = 6,
            STA_AX_SYNC_MOT = 7,
            STA_AX_EXT_JOG = 8,
            STA_AX_EXT_MPG = 9,
            STA_AX_PAUSE = 10,
            STA_AX_BUSY = 11,
        }

        /// <summary>
        /// 回零模式
        /// </summary>
        public enum HomeMode
        {
            MODE1_Abs = 0,
            MODE2_Lmt = 1,
            MODE3_Ref = 2,
            MODE4_Abs_Ref = 3,
            MODE5_Abs_NegRef = 4,
            MODE6_Lmt_Ref = 5,
            MODE7_AbsSearch = 6,
            MODE8_LmtSearch = 7,
            MODE9_AbsSearch_Ref = 8,
            MODE10_AbsSearch_NegRef = 9,
            MODE11_LmtSearch_Ref = 10,
            MODE12_AbsSearchReFind = 11,
            MODE13_LmtSearchReFind = 12,
            MODE14_AbsSearchReFind_Ref = 13,
            MODE15_AbsSearchReFind_NegRef = 14,
            MODE16_LmtSearchReFind_Ref = 15,
        }

        public enum CFG_AX_Property
        {
            CFG_Ax_ID = 501,
            CFG_AxCamDOEnable = CFG_Ax_ID + 121,
        }


        /// <summary>
        /// 回零方向
        /// </summary>
        public enum HomeDirection
        {
            Positive = 0,
            Negative = 1,
        }
        #endregion

        /// <summary>
        /// 设备列表
        /// </summary>
        private static DEV_LIST[] DeviceList = new DEV_LIST[Motion.MAX_DEVICES];//

        /// <summary>
        /// 设备个数
        /// </summary>
        private static uint uDeviceCount = 0;

        /// <summary>
        /// 设备1-句柄(8轴卡)
        /// </summary>
        private static IntPtr ipDeviceHandle = IntPtr.Zero;

        /// <summary>
        /// XY插补-句柄
        /// </summary>
        private static IntPtr ipXYHandle = IntPtr.Zero;

        /// <summary>
        /// 轴数组-句柄（默认32组）
        /// </summary>
        public static IntPtr[] ipAxisHandle = new IntPtr[32];

        /// <summary>
        /// 设备2-句柄(8轴卡)
        /// </summary>
        private static IntPtr ipDeviceHandle2 = IntPtr.Zero;

        /// <summary>
        /// XY插补-句柄
        /// </summary>
        private static IntPtr ipXYHandle2 = IntPtr.Zero;

        #region 成员变量
        /// <summary>
        /// 卡号
        /// </summary>
        public short CardNo = 0;
        /// <summary>
        /// 实际轴号，该轴号最大为8
        /// </summary>
        public short ActualAxisNo = 1;
        /// <summary>
        /// 轴号,轴号可以为1,2,3,4,5,6,7,8,9,10...其中9轴为第二块卡的第一轴
        /// </summary>
        public short AxisNo = 1;
        //[轴状态]
        /// <summary>
        /// 轴状态
        /// </summary>
        public uint AxisSts = 0;
        /// <summary>
        /// 正极限状态
        /// </summary>
        public bool bPosLimit = false;
        /// <summary>
        /// 负极限状态
        /// </summary>
        public bool bNegLimit = false;
        /// <summary>
        /// 原点状态
        /// </summary>
        public bool bHome = false;
        /// <summary>
        /// 轴是否伺服报警
        /// </summary>
        public bool bAxisServoWarning = false;
        /// <summary>
        /// 轴是否伺服报警
        /// </summary>
        public bool bAxisServoOn = false;
        /// <summary>
        /// 轴是在运动
        /// </summary>
        public bool bAxisIsRunning = false;
        /// <summary>
        /// 轴目前是否在回原点动作中
        /// </summary>
        public bool bAxisIsHoming = false;
        /// <summary>
        /// 轴急停
        /// </summary>
        public bool bAxisEmgOn = false;
        /// <summary>
        /// 轴准备好
        /// </summary>
        public bool bAxisReady = true;
        //[每一轴的 IO]
        /// <summary>
        /// 轴输入
        /// </summary>
        public bool[] bArrIO_In = new bool[4];
        /// <summary>
        /// 轴输出
        /// </summary>
        public bool[] bArrIO_Out = new bool[4];
        /// <summary>
        /// 轴规划器位置
        /// </summary>
        public double AxisPrfPos = 0;
        /// <summary>
        /// 轴编码器位置
        /// </summary>
        public double AxisEncPos = 0;
        #endregion

        /// <summary>
        /// 以轴号初始化轴,轴号可以为1,2,3,4,5,6,7,8,9,10...其中9轴为第二块卡的第一轴
        /// </summary>
        /// <param name="axisno"></param>
        public Axis_Advantech(short axisno)
        {
            AxisNo = axisno;
        }

        public static void DisableCamDO()
        {
            foreach (var item in ipAxisHandle)
            {
                Motion.mAcm_SetI32Property(item, (uint)CFG_AX_Property.CFG_AxCamDOEnable, 0);
            }
        }

        /// <summary>
        /// 轴卡初始化，搜索使用后再加载配置文件 默认两张轴卡
        /// </summary>
        /// <param name="ConfigPath1">卡1配置文件路径</param>
        /// <param name="ConfigPath2">卡2配置文件路径</param>
        /// <returns></returns>
        public static short CardInit(string ConfigPath1, string ConfigPath2)
        {
            short rtn0;
            IntPtr[] ipAxisHandle2 = new IntPtr[32];
            try
            {
                rtn0 = (short)Motion.mAcm_GetAvailableDevs(DeviceList, Motion.MAX_DEVICES, ref uDeviceCount);
            }
            catch
            {
                return 1;
            }
            if (uDeviceCount == 0)
            {
                return 1;
            }
            for (int ii = 0; ii < uDeviceCount; ii++)
            {
                if (DeviceList[ii].DeviceName.Contains("PCI-1285"))
                {
                    rtn0 += (short)Motion.mAcm_DevOpen(DeviceList[ii].DeviceNum, ref ipDeviceHandle);
                    for (ushort i = 0; i < 8; i++) // 確認PCI1285是否可以控制
                    {
                        rtn0 += (short)Motion.mAcm_AxOpen(ipDeviceHandle, i, ref ipAxisHandle[i]);
                    }
                    rtn0 += (short)Motion.mAcm_DevLoadConfig(ipDeviceHandle, ConfigPath1);
                }
                else if (DeviceList[ii].DeviceName.Contains("PCI-1245"))
                {
                    rtn0 += (short)Motion.mAcm_DevOpen(DeviceList[ii].DeviceNum, ref ipDeviceHandle2);
                    for (ushort i = 0; i < 4; i++) // 確認PCI1285是否可以控制
                    {
                        rtn0 += (short)Motion.mAcm_AxOpen(ipDeviceHandle2, i, ref ipAxisHandle2[i]);
                        ipAxisHandle[8 + i] = ipAxisHandle2[i];
                    }
                    rtn0 += (short)Motion.mAcm_DevLoadConfig(ipDeviceHandle2, ConfigPath2);
                }
            }
            return rtn0;
        }     //初始化轴卡-DONE

        /// <summary>
        /// 关闭轴卡
        /// </summary>
        /// <returns></returns>
        public static short CardClose()
        {
            short rtn0 = 0;
            UInt16[] usAxisState = new UInt16[32];
            uint AxisNum;
            #region Stop Every Axes-1Card
            for (AxisNum = 0; AxisNum < 8; AxisNum++)
            {
                //Get the axis's current state
                rtn0 += (short)Motion.mAcm_AxGetState(ipAxisHandle[AxisNum], ref usAxisState[AxisNum]);
                if (usAxisState[AxisNum] == (uint)AxisState.STA_AX_ERROR_STOP)
                {
                    // Reset the axis' state. If the axis is in ErrorStop state, the state will be changed to Ready after calling this function
                    rtn0 += (short)Motion.mAcm_AxResetError(ipAxisHandle[AxisNum]);
                }
                //To command axis to decelerate to stop.
                rtn0 += (short)Motion.mAcm_AxStopDec(ipAxisHandle[AxisNum]);
            }
            #endregion
            #region Stop Every Axes-2Card
            if (uDeviceCount == 2)
            {
                for (AxisNum = 8; AxisNum < 16; AxisNum++)
                {
                    //Get the axis's current state
                    rtn0 += (short)Motion.mAcm_AxGetState(ipAxisHandle[AxisNum], ref usAxisState[AxisNum]);
                    if (usAxisState[AxisNum] == (uint)AxisState.STA_AX_ERROR_STOP)
                    {
                        // Reset the axis' state. If the axis is in ErrorStop state, the state will be changed to Ready after calling this function
                        rtn0 += (short)Motion.mAcm_AxResetError(ipAxisHandle[AxisNum]);
                    }
                    //To command axis to decelerate to stop.
                    rtn0 += (short)Motion.mAcm_AxStopDec(ipAxisHandle[AxisNum]);
                }
            }
            #endregion
            #region Close Axes-1Card
            for (AxisNum = 0; AxisNum < 8; AxisNum++)
            {
                //Close Axes
                rtn0 += (short)Motion.mAcm_AxClose(ref ipAxisHandle[AxisNum]);
            }
            #endregion
            #region Close Axes-2Card
            if (uDeviceCount == 2)
            {
                for (AxisNum = 8; AxisNum < 16; AxisNum++)
                {
                    //Close Axes
                    rtn0 += (short)Motion.mAcm_AxClose(ref ipAxisHandle[AxisNum]);
                }
            }
            #endregion
            #region Close XY-1Card
            rtn0 += (short)Motion.mAcm_GpClose(ref ipXYHandle);
            #endregion
            #region Close XY-2Card
            if (uDeviceCount == 2)
            {
                rtn0 += (short)Motion.mAcm_GpClose(ref ipXYHandle2);
            }
            #endregion
            #region Close Device-1Card
            rtn0 += (short)Motion.mAcm_DevClose(ref ipDeviceHandle);
            #endregion
            #region Close Device-2Card
            if (uDeviceCount == 2)
            {
                rtn0 += (short)Motion.mAcm_DevClose(ref ipDeviceHandle2);
            }
            #endregion
            return rtn0;
        }


        /// <summary>
        /// 得到轴状态
        /// </summary>
        /// <returns></returns>
        public short GetAxisSts()
        {
            ushort uCode = 0;
            short rtn = 0;
            rtn += (short)Motion.mAcm_AxGetMotionIO(ipAxisHandle[AxisNo - 1], ref AxisSts);
            #region 状态：伺服报警、原点、极限、急停、到位、回原点
            if ((AxisSts & (uint)Ax_Motion_IO.AX_MOTION_IO_ALM) > 0)//ALM
            {
                bAxisServoWarning = true;
            }
            else
            {
                bAxisServoWarning = false;
            }

            if ((AxisSts & (uint)Ax_Motion_IO.AX_MOTION_IO_ORG) > 0)//ORG
            {
                bHome = true;
            }
            else
            {
                bHome = false;
            }

            if ((AxisSts & (uint)Ax_Motion_IO.AX_MOTION_IO_LMTP) > 0)//+EL
            {
                bPosLimit = true;
            }
            else
            {
                bPosLimit = false;
            }

            if ((AxisSts & (uint)Ax_Motion_IO.AX_MOTION_IO_LMTN) > 0)//-EL
            {
                bNegLimit = true;
            }
            else
            {
                bNegLimit = false;
            }

            if ((AxisSts & (uint)Ax_Motion_IO.AX_MOTION_IO_EMG) > 0)//EMG
            {
                bAxisEmgOn = true;
            }
            else
            {
                bAxisEmgOn = false;
            }
            if ((AxisSts & (uint)Ax_Motion_IO.AX_MOTION_IO_INP) > 0)//INP
            {
                bAxisIsRunning = false;
            }
            else
            {
                bAxisIsRunning = true;
            }
            #endregion
            rtn += (short)Motion.mAcm_AxGetState(ipAxisHandle[AxisNo - 1], ref uCode);
            if (uCode == (ushort)AxisState.STA_AX_HOMING)
            {
                bAxisIsHoming = true;
            }
            else
            {
                bAxisIsHoming = false;
            }

            if (uCode == (ushort)AxisState.STA_AX_ERROR_STOP)
            {
                rtn += CleSts(true);
            }

            return rtn;
            //每次读取完轴状态，或者轴到达某个新状态后都需清除一次轴状态
        }

        /// <summary>
        /// 复位所有输出-共4个
        /// </summary>
        /// <returns></returns>
        public short ResetAllIO_Out()
        {
            short rtn = 0;
            for (int i = 0; i < 4; i++)
            {
                rtn = (short)Motion.mAcm_AxDoSetBit(ipAxisHandle[AxisNo - 1], (ushort)i, 0);
                rtn += (short)Motion.mAcm_AxDoSetBit(ipAxisHandle[AxisNo - 1], (ushort)i, 0);
                rtn += (short)Motion.mAcm_AxDoSetBit(ipAxisHandle[AxisNo - 1], (ushort)i, 0);
                rtn += (short)Motion.mAcm_AxDoSetBit(ipAxisHandle[AxisNo - 1], (ushort)i, 0);
            }
            return rtn;
        }

        /// <summary>
        /// 得到所有IO点的输出状态-共4个
        /// </summary>
        /// <returns></returns>
        public short GetIO_Out()
        {
            short rtn = 0;
            byte IO_Out = 0;
            for (ushort i = 0; i < 4; i++)
            {
                rtn += (short)Motion.mAcm_AxDoGetBit(ipAxisHandle[AxisNo - 1], (ushort)(4 + i), ref IO_Out);
                if (IO_Out == 1)
                {
                    bArrIO_Out[i] = true;
                }
                else
                {
                    bArrIO_Out[i] = false;
                }
            }
            return rtn;
        }

        /// <summary>
        /// 得到所有IO点的输入状态-共4个
        /// </summary>
        /// <returns></returns>
        public short GetIO_IN()
        {
            short rtn = 0;
            byte IO_IN = 0;
            for (ushort i = 0; i < 4; i++)
            {
                rtn += (short)Motion.mAcm_AxDiGetBit(ipAxisHandle[AxisNo - 1], i, ref IO_IN);
                if (IO_IN == 1)
                {
                    bArrIO_In[i] = true;
                }
                else
                {
                    bArrIO_In[i] = false;
                }
            }
            return rtn;
        }

        /// <summary>
        /// 复位输出点
        /// </summary>
        /// <param name="bit4_7">复位输出点4到7</param>
        /// <returns></returns>
        public short ResetIO_OUT(ushort bit4_7)
        {
            short rtn = (short)Motion.mAcm_AxDoSetBit(ipAxisHandle[AxisNo - 1], (ushort)(bit4_7), 0);
            return rtn;
        }

        /// <summary>
        /// 设置输出点
        /// </summary>
        /// <param name="bit4_7">设置输出点4到7</param>
        /// <returns></returns>
        public short SetIO_OUT(ushort bit4_7)
        {
            short rtn = (short)Motion.mAcm_AxDoSetBit(ipAxisHandle[AxisNo - 1], (ushort)(bit4_7), 1);
            return rtn;
        }

        /// <summary>
        /// 得到轴规划位
        /// </summary>
        /// <returns></returns>
        public short GetAxisPos()
        {
            short rtn = (short)Motion.mAcm_AxGetCmdPosition(ipAxisHandle[AxisNo - 1], ref AxisPrfPos);
            rtn += (short)Motion.mAcm_AxGetActualPosition(ipAxisHandle[AxisNo - 1], ref AxisEncPos);
            return rtn;
        }

        /// <summary>
        /// 轴Jog运动
        /// </summary>
        /// <param name="LowVel">最低速度</param>
        /// <param name="HighVel">最高速度</param>
        /// <param name="acc">加速度</param>
        /// <param name="dec">减速度</param>
        /// <param name="isDirPositive">正负方向</param>
        /// <returns></returns>
        public short AxisMoveJog(double LowVel, double HighVel, double acc, double dec, bool isDirPositive)
        {
            short rtn = AxisSetValue(LowVel, HighVel, acc, dec);
            if (isDirPositive)
            {
                rtn += (short)Motion.mAcm_AxMoveVel(ipAxisHandle[AxisNo - 1], 0);
            }
            else
            {
                rtn += (short)Motion.mAcm_AxMoveVel(ipAxisHandle[AxisNo - 1], 1);
            }
            return rtn;
        }

        /// <summary>
        /// 轴Jog运动
        /// </summary>
        /// <param name="LowVel">最低速度</param>
        /// <param name="HighVel">最高速度</param>
        /// <param name="acc">加速度</param>
        /// <param name="dec">减速度</param>
        /// <param name="isDirPositive">正负方向</param>
        /// <returns></returns>
        public short AxisMoveJog(Variable.VelMode velmode, bool isDirPositive)
        {
            short rtn = AxisSetValue(velmode);
            if (isDirPositive)
            {
                rtn += (short)Motion.mAcm_AxMoveVel(ipAxisHandle[AxisNo - 1], 0);
            }
            else
            {
                rtn += (short)Motion.mAcm_AxMoveVel(ipAxisHandle[AxisNo - 1], 1);
            }
            return rtn;
        }

        private double velLow = -1;
        private double velHeigh = -1;
        private double acc = -1;
        private double dec = -1;
        /// <summary>
        /// 设置轴速度
        /// </summary>
        /// <param name="dVelLow">最低速度</param>
        /// <param name="dVelHigh">最高速度</param>
        /// <param name="dAcc">加速度</param>
        /// <param name="dDec">减速度</param>
        /// <returns></returns>
        public short AxisSetValue(double dVelLow, double dVelHigh, double dAcc, double dDec) // 設定速度,加速度範圍
        {
            short rtn = 0;
            if(velLow != dVelLow)
            {
                rtn += (short)Motion.mAcm_SetProperty(ipAxisHandle[AxisNo - 1], (uint)PropertyID.PAR_AxVelLow, ref dVelLow, (uint)Marshal.SizeOf(typeof(double)));
                velLow = dVelLow;
            }

            if (velHeigh != dVelHigh)
            {
                rtn += (short)Motion.mAcm_SetProperty(ipAxisHandle[AxisNo - 1], (uint)PropertyID.PAR_AxVelHigh, ref dVelHigh, (uint)Marshal.SizeOf(typeof(double)));
                velHeigh = dVelHigh;
            }

            if(acc != dAcc)
            {
                rtn += (short)Motion.mAcm_SetProperty(ipAxisHandle[AxisNo - 1], (uint)PropertyID.PAR_AxAcc, ref dAcc, (uint)Marshal.SizeOf(typeof(double)));
                acc = dAcc;
            }

            if(dec != dDec)
            {
                rtn += (short)Motion.mAcm_SetProperty(ipAxisHandle[AxisNo - 1], (uint)PropertyID.PAR_AxDec, ref dDec, (uint)Marshal.SizeOf(typeof(double)));
                dec = dDec;
            }

            return rtn;
        }

        /// <summary>
        /// 设置轴速度
        /// </summary>
        /// <param name="velmode">速度模式</param>
        /// <returns></returns>
        public short AxisSetValue(Variable.VelMode velmode) // 設定速度,加速度範圍
        {
            short rtn = (short)Motion.mAcm_SetProperty(ipAxisHandle[AxisNo - 1], (uint)PropertyID.PAR_AxVelLow, ref velmode.LowVel, (uint)Marshal.SizeOf(typeof(double)));
            rtn += (short)Motion.mAcm_SetProperty(ipAxisHandle[AxisNo - 1], (uint)PropertyID.PAR_AxVelHigh, ref velmode.HighVel, (uint)Marshal.SizeOf(typeof(double)));
            rtn += (short)Motion.mAcm_SetProperty(ipAxisHandle[AxisNo - 1], (uint)PropertyID.PAR_AxAcc, ref velmode.Acc, (uint)Marshal.SizeOf(typeof(double)));
            rtn += (short)Motion.mAcm_SetProperty(ipAxisHandle[AxisNo - 1], (uint)PropertyID.PAR_AxDec, ref velmode.Dec, (uint)Marshal.SizeOf(typeof(double)));
            return rtn;
        }

        /// <summary>
        /// 在运动中改变轴速度
        /// </summary>
        /// <param name="NewVel">新的速度</param>
        /// <param name="NewAcc">新的加速度</param>
        /// <param name="NewDec">新的减速度</param>
        /// <returns></returns>
        public short AxisChangeValue(double NewVel, double NewAcc, double NewDec) // 設定速度,加速度範圍
        {
            short rtn = (short)Motion.mAcm_AxChangeVel(ipAxisHandle[AxisNo - 1], NewVel);
            //return (short)Motion.mAcm_AxChangeVelEx(ipAxisHandle[AxisNo - 1], NewVel, NewAcc, NewDec);
            return rtn;
        }

        /// <summary>
        /// 在运动中改变位置（必须同向）
        /// </summary>
        /// <param name="Vel"></param>
        /// <param name="NewPt"></param>
        /// <returns></returns>
        public short AxisChangePos(double NewPt, VelMode Vel)
        {
            short rtn = 0;
            rtn = AxisSetValue(Vel);
            rtn = (short)Motion.mAcm_AxChangePos(ipAxisHandle[AxisNo - 1], NewPt);
            return rtn;
        }

        /// <summary>
        /// 轴回零
        /// </summary>
        /// <param name="uHomeMode">回零模式</param>
        /// <param name="IsDirP">是否正向</param>
        /// <param name="LowVel">最低速度</param>
        /// <param name="HighVel">最高速度</param>
        /// <param name="acc">加速度</param>
        /// <param name="dec">减速度</param>
        /// <returns></returns>
        public short AxisGoHome(HomeMode uHomeMode, bool IsDirP, double LowVel, double HighVel, double acc, double dec)
        {
            ushort uDirMode = 0;
            if (IsDirP)
            {
                uDirMode = 0;
            }
            else
            {
                uDirMode = 1;
            }
            short rtn = AxisSetValue(LowVel, HighVel, acc, dec);
            rtn += (short)Motion.mAcm_AxHome(ipAxisHandle[AxisNo - 1], (ushort)uHomeMode, uDirMode);
            return rtn;
        }

        /// <summary>
        /// 轴回零
        /// </summary>
        /// <param name="uHomeMode">回零模式</param>
        /// <param name="IsDirP">是否正向</param>
        /// <param name="velmode">速度模式</param>
        /// <returns></returns>
        public short AxisGoHome(HomeMode uHomeMode, bool IsDirP, VelMode velmode)
        {
            this.CleSts(true);
            ushort uDirMode = 0;
            if (IsDirP)
            {
                uDirMode = 0;
            }
            else
            {
                uDirMode = 1;
            }
            short rtn = AxisSetValue(velmode);
            rtn += (short)Motion.mAcm_AxHome(ipAxisHandle[AxisNo - 1], (ushort)uHomeMode, uDirMode);
            return rtn;
        }

        /// <summary>
        /// 轴使能
        /// </summary>
        /// <returns></returns>
        public short SetAxisServoOn()
        {
            return (short)Motion.mAcm_AxSetSvOn(ipAxisHandle[AxisNo - 1], 1);
        }

        /// <summary>
        /// 轴去使能
        /// </summary>
        /// <returns></returns>
        public short SetAxisServoOff()
        {
            return (short)Motion.mAcm_AxSetSvOn(ipAxisHandle[AxisNo - 1], 0);
        }

        /// <summary>
        /// 设置最大速度、加速度、减速度
        /// </summary>
        /// <param name="dMaxVel">最大速度</param>
        /// <param name="dMaxAcc">加速度</param>
        /// <param name="dMaxDec">减速度</param>
        /// <returns></returns>
        public short SetAxisMaxRange(double dMaxVel, double dMaxAcc, double dMaxDec) // 設定最大速度,加速度範圍
        {
            // Max Vel
            short rtn = (short)Motion.mAcm_SetProperty(ipAxisHandle[AxisNo - 1], (uint)PropertyID.CFG_AxMaxVel, ref dMaxVel, (uint)Marshal.SizeOf(typeof(double)));
            // Max Acc
            rtn += (short)Motion.mAcm_SetProperty(ipAxisHandle[AxisNo - 1], (uint)PropertyID.CFG_AxMaxAcc, ref dMaxAcc, (uint)Marshal.SizeOf(typeof(double)));
            // Max Dec
            rtn += (short)Motion.mAcm_SetProperty(ipAxisHandle[AxisNo - 1], (uint)PropertyID.CFG_AxMaxDec, ref dMaxDec, (uint)Marshal.SizeOf(typeof(double)));
            return rtn;
        }

        /// <summary>
        /// 点到点运动-相对
        /// </summary>
        /// <param name="dist">相对目前位置的距离</param>
        /// <param name="LowVel">最低速度</param>
        /// <param name="HighVel">最高速度</param>
        /// <param name="acc">加速度</param>
        /// <param name="dec">减速度</param>
        /// <returns></returns>
        public short AxisMoveTrap_Rel(double dist, double LowVel, double HighVel, double acc, double dec)
        {
            short rtn = AxisSetValue(LowVel, HighVel, acc, dec);
            rtn = (short)Motion.mAcm_AxMoveRel(ipAxisHandle[AxisNo - 1], dist);
            return rtn;
        }

        /// <summary>
        /// 点到点运动-相对
        /// </summary>
        /// <param name="dist">相对目前位置的距离</param>
        /// <param name="velmode">速度模式</param>
        /// <returns></returns>
        public short AxisMoveTrap_Rel(double dist, VelMode velmode)
        {
            short rtn = AxisSetValue(velmode);
            rtn = (short)Motion.mAcm_AxMoveRel(ipAxisHandle[AxisNo - 1], dist);
            return rtn;
        }

        /// <summary>
        /// 点到点运动-绝对
        /// </summary>
        /// <param name="dist">绝对的位置点</param>
        /// <param name="LowVel">最低速度</param>
        /// <param name="HighVel">最高速度</param>
        /// <param name="acc">加速度</param>
        /// <param name="dec">减速度</param>
        /// <returns></returns>
        public short AxisMoveTrap_Abs(double dist, double LowVel, double HighVel, double acc, double dec)
        {
            short rtn = AxisSetValue(LowVel, HighVel, acc, dec);
            rtn = (short)Motion.mAcm_AxMoveAbs(ipAxisHandle[AxisNo - 1], dist);
            return rtn;
        }

        /// <summary>
        /// 点到点运动-绝对
        /// </summary>
        /// <param name="dist">绝对的位置点</param>
        /// <param name="velmode">速度模式</param>
        /// <returns></returns>
        public short AxisMoveTrap_Abs(double dist, VelMode velmode)
        {
            short rtn = AxisSetValue(velmode);
            rtn = (short)Motion.mAcm_AxMoveAbs(ipAxisHandle[AxisNo - 1], dist);
            return rtn;
        }

        /// <summary>
        /// 立即停止轴运动
        /// </summary>
        /// <returns></returns>
        public short StopAxis(bool emg = true)
        {
            short rtn = 0;
            if (emg)
                rtn = (short)Motion.mAcm_AxStopEmg(ipAxisHandle[AxisNo - 1]);
            else
                rtn = (short)Motion.mAcm_AxStopDec(ipAxisHandle[AxisNo - 1]);
            return rtn;
        }

        /// <summary>
        /// 清除轴状态
        /// </summary>
        /// <returns></returns>
        public short CleSts(bool emg = false)
        {
            if (emg)
            {
                return (short)Motion.mAcm_AxResetError(ipAxisHandle[AxisNo - 1]);//清除当前轴状态
            }
            else
            {
                if (this.bAxisEmgOn || this.bPosLimit || this.bNegLimit)
                    return (short)Motion.mAcm_AxResetError(ipAxisHandle[AxisNo - 1]);//清除当前轴状态
            }

            return 0;
        }

        /// <summary>
        /// 清除轴位置
        /// </summary>
        /// <returns></returns>
        public short ZeroAxis()
        {
            short rtn = (short)Motion.mAcm_AxSetCmdPosition(ipAxisHandle[AxisNo - 1], 0);
            rtn += (short)Motion.mAcm_AxSetActualPosition(ipAxisHandle[AxisNo - 1], 0);
            return rtn;
        }

        /// <summary>
        /// 获得目前的比较输出的数据
        /// </summary>
        /// <param name="rCurCmpData">比较输出数据</param>
        /// <returns></returns>
        public short GetCompareCurData(ref double rCurCmpData)
        {
            return (short)Motion.mAcm_AxGetCmpData(ipAxisHandle[AxisNo - 1], ref rCurCmpData);
        }

        /// <summary>
        /// 设置比较输出数据
        /// </summary>
        /// <param name="EN">使用与否</param>
        /// <param name="CompareMethodIndex">0-greater 1-smaller</param>
        /// <param name="CompareSourceIndex">0-command 1-encode</param>
        /// <param name="ComparePulseLogicIndex">0-Low 1-High</param>
        /// <param name="ComparePulseWidthIndex">脉冲宽度</param>
        /// <param name="ComparePulseEX">脉冲宽度</param>
        /// <returns></returns>
        public short SetComapreData(uint EN, uint CompareMethodIndex, uint CompareSourceIndex, uint ComparePulseLogicIndex, uint ComparePulseWidthIndex, uint ComparePulseEX)
        {
            short rtn = (short)Motion.mAcm_SetU32Property(ipAxisHandle[AxisNo - 1], (uint)PropertyID.CFG_AxCmpSrc, 1);//0-command 1-encode
            rtn += (short)Motion.mAcm_SetU32Property(ipAxisHandle[AxisNo - 1], (uint)PropertyID.CFG_AxCmpMethod, CompareMethodIndex);//0-greater 1-smaller
            rtn += (short)Motion.mAcm_SetU32Property(ipAxisHandle[AxisNo - 1], (uint)PropertyID.CFG_AxCmpPulseLogic, 0);//0-Low 1-High

            rtn += (short)Motion.mAcm_SetU32Property(ipAxisHandle[AxisNo - 1], (uint)PropertyID.CFG_AxCmpPulseWidth, 10);//0-5 1-10
            rtn += (short)Motion.mAcm_SetU32Property(ipAxisHandle[AxisNo - 1], (uint)PropertyID.CFG_AxCmpPulseWidthEx, 10);//ComparePulseEX);//0-5 1-10
            rtn = (short)Motion.mAcm_SetU32Property(ipAxisHandle[AxisNo - 1], (uint)PropertyID.CFG_AxCmpEnable, EN);//0-disable 1-enable
            return rtn;
        }

        /// <summary>
        /// 设置比较输出表
        /// </summary>
        /// <param name="TableArray">比较输出队列</param>
        /// <param name="TablePointsCount">比较输出点数</param>
        /// <returns></returns>
        public short SetComapreTable(double[] TableArray, short TablePointsCount)
        {
            return (short)Motion.mAcm_AxSetCmpTable(ipAxisHandle[AxisNo - 1], TableArray, TablePointsCount);
        }

        //插补 未用*********************************************************************************************************************

        /// <summary>
        /// 卡1XY直线插补
        /// </summary>
        /// <param name="positions">点列表</param>
        /// <param name="LowVel">最低速度</param>
        /// <param name="HighVel">最高速度</param>
        /// <param name="dAcc">加速度</param>
        /// <param name="dDec">减速度</param>
        /// <returns></returns>
        public short CrdMoveXYMul(ArrayList positions, double LowVel, double HighVel, double dAcc, double dDec)
        {
            short rtn = (short)Motion.mAcm_SetF64Property(ipXYHandle, (uint)PropertyID.PAR_GpVelLow, LowVel);
            rtn += (short)Motion.mAcm_SetF64Property(ipXYHandle, (uint)PropertyID.PAR_GpVelHigh, HighVel);
            rtn += (short)Motion.mAcm_SetF64Property(ipXYHandle, (uint)PropertyID.PAR_GpAcc, dAcc);
            rtn += (short)Motion.mAcm_SetF64Property(ipXYHandle, (uint)PropertyID.PAR_GpDec, dDec);
            //向缓存区写入数据（坐标系号，X,Y，目标速度，加速度，终点速度，缓存区号FIFO）
            double[] EndArray = new double[2];
            uint AxisNum = 2;
            foreach (PointF xy in positions)
            {
                EndArray[0] = (double)(xy.X);
                EndArray[1] = (double)(xy.Y);
                rtn += (short)Motion.mAcm_GpMoveLinearAbs(ipXYHandle, EndArray, ref AxisNum);
            }
            return rtn;
        }

        /// <summary>
        /// 卡1XY直线插补
        /// </summary>
        /// <param name="positions">点列表</param>
        /// <param name="velmode">速度模式</param>
        /// <returns></returns>
        public short CrdMoveXYMul(ArrayList positions, VelMode velmode)
        {
            short rtn = (short)Motion.mAcm_SetF64Property(ipXYHandle, (uint)PropertyID.PAR_GpVelLow, velmode.LowVel);
            rtn += (short)Motion.mAcm_SetF64Property(ipXYHandle, (uint)PropertyID.PAR_GpVelHigh, velmode.HighVel);
            rtn += (short)Motion.mAcm_SetF64Property(ipXYHandle, (uint)PropertyID.PAR_GpAcc, velmode.Acc);
            rtn += (short)Motion.mAcm_SetF64Property(ipXYHandle, (uint)PropertyID.PAR_GpDec, velmode.Dec);
            //向缓存区写入数据（坐标系号，X,Y，目标速度，加速度，终点速度，缓存区号FIFO）
            double[] EndArray = new double[2];
            uint AxisNum = 2;
            foreach (PointF xy in positions)
            {
                EndArray[0] = (double)(xy.X);
                EndArray[1] = (double)(xy.Y);
                rtn += (short)Motion.mAcm_GpMoveLinearAbs(ipXYHandle, EndArray, ref AxisNum);
            }
            return rtn;
        }

        /// <summary>
        /// 卡1建立坐标系
        /// </summary>
        /// <param name="axis1">轴1</param>
        /// <param name="axis2">轴2</param>
        /// <returns></returns>
        public short CreateCrdXY(short axis1, short axis2)
        {
            short rtn = (short)Motion.mAcm_GpAddAxis(ref ipXYHandle, ipAxisHandle[axis1]);
            rtn += (short)Motion.mAcm_GpAddAxis(ref ipXYHandle, ipAxisHandle[axis2]);
            return rtn;
        }

        /// <summary>
        /// 卡1停止XY轴
        /// </summary>
        /// <returns></returns>
        public short StopXY()
        {
            return (short)Motion.mAcm_AxStopEmg(ipXYHandle);
        }
    }
}
