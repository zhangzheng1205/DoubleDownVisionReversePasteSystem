using System;
using System.Collections.Generic;
using System.Text;
using Advantech.Motion;
using System.Windows.Forms;
using System.Runtime.InteropServices; //For Marshal
using System.Threading;

namespace Lib_PCI1285L_Card1
{

    class PCI1285LCtrl_Card1
    {
        #region 定義變數
        private static bool bDeviceFlag_NoError = false; // 廣域變數, 定義Device狀態
        private static int iError = 0;
        private static uint uError = 0;
        private static DEV_LIST[] DeviceList = new DEV_LIST[Motion.MAX_DEVICES];
        private static IntPtr ipDeviceHandle = IntPtr.Zero;
        public static IntPtr[] ipAxisHandle = new IntPtr[32];
        private static uint uDeviceCount = 0;
        private const int iLowActive = 0;
        private const int iHighActive = 1;
        private const int iDisable = 0;
        private const int iEnable = 1;
        private const int iORG_IMMED_STOP = 0;
        private const int iORG_DEC_TO_STOP = 1;
        private const int iXAxis = 0;
        private const int iYAxis = 1;
        private const int iZAxis = 2;
        private const int iUAxis = 3;
        public static string sDeviceName = "";
        #endregion
        #region Define Motion IO Signal (Card1)
        // X Axis
        public static bool X_ALARM = false;
        public static bool X_LMTP = false;
        public static bool X_LMTM = false;
        public static bool X_ORG = false;
        public static bool X_INP = false;
        public static bool X_EMG = false;
        // Y Axis
        public static bool Y_ALARM = false;
        public static bool Y_LMTP = false;
        public static bool Y_LMTM = false;
        public static bool Y_ORG = false;
        public static bool Y_INP = false;
        public static bool Y_EMG = false;
        // Z Axis
        public static bool Z_ALARM = false;
        public static bool Z_LMTP = false;
        public static bool Z_LMTM = false;
        public static bool Z_ORG = false;
        public static bool Z_INP = false;
        public static bool Z_EMG = false;
        // U Axis
        public static bool U_ALARM = false;
        public static bool U_LMTP = false;
        public static bool U_LMTM = false;
        public static bool U_ORG = false;
        public static bool U_INP = false;
        public static bool U_EMG = false;
        #endregion
        #region General Motion IO Signal (Card1)
        // X Axis
        public static bool X_IN0 = false;
        public static bool X_IN1 = false;
        public static bool X_IN2 = false;
        public static bool X_IN3 = false;
        // Y Axis
        public static bool Y_IN0 = false;
        public static bool Y_IN1 = false;
        public static bool Y_IN2 = false;
        public static bool Y_IN3 = false;
        // Z Axis
        public static bool Z_IN0 = false;
        public static bool Z_IN1 = false;
        public static bool Z_IN2 = false;
        public static bool Z_IN3 = false;
        // U Axis
        public static bool U_IN0 = false;
        public static bool U_IN1 = false;
        public static bool U_IN2 = false;
        public static bool U_IN3 = false;

        // X Axis
        public static bool X_Sensor_DO4 = false;
        public static bool X_Sensor_DO5 = false;
        public static bool X_Sensor_DO6 = false;
        public static bool X_Sensor_DO7 = false;
        // Y Axis
        public static bool Y_Sensor_DO4 = false;
        public static bool Y_Sensor_DO5 = false;
        public static bool Y_Sensor_DO6 = false;
        public static bool Y_Sensor_DO7 = false;
        // Z Axis
        public static bool Z_Sensor_DO4 = false;
        public static bool Z_Sensor_DO5 = false;
        public static bool Z_Sensor_DO6 = false;
        public static bool Z_Sensor_DO7 = false;
        // U Axis
        public static bool U_Sensor_DO4 = false;
        public static bool U_Sensor_DO5 = false;
        public static bool U_Sensor_DO6 = false;
        public static bool U_Sensor_DO7 = false;

        #endregion
        #region Functions
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
        public enum HomeDirection
        {
            Positive = 0,
            Negative = 1,
        }
        public static void fcInitDevice(int iDeviceIndex) // 初始化控制卡
        {
            // set flag True
            bDeviceFlag_NoError = true;
            // Check Motion Card Status
            iError = Motion.mAcm_GetAvailableDevs(DeviceList, Motion.MAX_DEVICES, ref uDeviceCount);  // 確認PCI1240是否存在
            uError = Motion.mAcm_DevOpen(DeviceList[iDeviceIndex].DeviceNum, ref ipDeviceHandle); // 確認PCI1240是否可以控制
            sDeviceName = DeviceList[iDeviceIndex].DeviceName;
            if (iError != (uint)ErrorCode.SUCCESS)
            {
                bDeviceFlag_NoError = false;
                PCI1245LMessage_Card1.fcShowMessageForm("PCI-1245L_Card1初始化错误, 找不到控制卡, 請結束程式!!!");
                //MessageBox.Show("PCI-1240初始化错误, 找不到控制卡, 請結束程式!!!", "警告!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (uError != (uint)ErrorCode.SUCCESS)
            {
                bDeviceFlag_NoError = false;
                PCI1245LMessage_Card1.fcShowMessageForm("PCI-1245L_Card1初始化错误, 不能夠開啟控制卡, 請結束程式!!!");
                //MessageBox.Show("PCI-1240初始化错误, 不能夠開啟控制卡, 請結束程式!!!", "警告!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string strConfig_Card = Lib_GlobalPara.Global.sConfig_Folder + "\\PCI-1245L_Card1.cfg";
                if(System.IO.File.Exists( strConfig_Card))
                {
                    Motion.mAcm_DevLoadConfig(ipDeviceHandle, strConfig_Card);
                }

                for (ushort i = 0; i < 4; i++) // 確認PCI1240軸是否可以控制
                {
                    uError = Motion.mAcm_AxOpen(ipDeviceHandle, i, ref ipAxisHandle[i]);
                    if (uError != (uint)ErrorCode.SUCCESS)
                    {
                        bDeviceFlag_NoError = false;
                        PCI1245LMessage_Card1.fcShowMessageForm("PCI-1245L_Card1初始化错误, 不能夠控制軸, 請結束程式!!!");
                        //MessageBox.Show("PCI-1240初始化错误, 不能夠控制軸, 請結束程式!!!", "警告!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
                }
            }
        }
        public static void fcGetCurrPosPulse(byte btAxisSel_X0_Y1_Z2_U3, out double dPositionOut)
        {
            dPositionOut = 0;
            if (bDeviceFlag_NoError)
            {
                Motion.mAcm_AxGetCmdPosition(ipAxisHandle[btAxisSel_X0_Y1_Z2_U3], ref dPositionOut);
                if (uError != (uint)ErrorCode.SUCCESS)
                {
                    bDeviceFlag_NoError = false;
                    PCI1245LMessage_Card1.fcShowMessageForm("PCI-1245L_Card1错误, 讀取當前座標發生错误, 請結束程式!!!" + " Axis-" + btAxisSel_X0_Y1_Z2_U3 + "; Code-" + uError);
                }
            }
        }
        public static void fcGoHome(byte btAxisSel_X0_Y1_Z2_U3, uint uHomeMode, uint uDirMode)
        {
            if (bDeviceFlag_NoError)
            {
                uError = Motion.mAcm_AxHome(ipAxisHandle[btAxisSel_X0_Y1_Z2_U3], uHomeMode, uDirMode);
                if (uError != (uint)ErrorCode.SUCCESS)
                {
                    bDeviceFlag_NoError = false;
                    PCI1245LMessage_Card1.fcShowMessageForm("PCI-1245L_Card1 軸" + btAxisSel_X0_Y1_Z2_U3 + "错误, 回原點發生错误, 請結束程式!!!");
                }
            }
        }
        public static void fcSetAxisJerk(byte btAxisSel_X0_Y1_Z2_U3) // Default for T Curve
        {
            int iIndex = sDeviceName.IndexOf("1245L");
            if (iIndex != -1) // Use 1245L
            {
                int iBuffValue = 0; //0 For T Curve, 1 For S Curve
                if (bDeviceFlag_NoError)
                {
                    uError = Motion.mAcm_SetProperty(ipAxisHandle[btAxisSel_X0_Y1_Z2_U3], (uint)PropertyID.PAR_AxJerk, ref iBuffValue, (uint)Marshal.SizeOf(typeof(double)));
                    if (uError != (uint)ErrorCode.SUCCESS)
                    {
                        bDeviceFlag_NoError = false;
                        PCI1245LMessage_Card1.fcShowMessageForm("PCI-1245L_Card1错误, 不能設定" + btAxisSel_X0_Y1_Z2_U3 + "Axis T型運動曲線, 請結束程式!!!");
                    }
                }
            }
        }
        public static void fcSetAlarmLogic(bool bTrueForHigh, byte btAxisSel_X0_Y1_Z2_U3) // 設定Alarm以及其觸發方式
        {
            int iBuffValue = 0;
            int iEnable = 1;
            if (bDeviceFlag_NoError)
            {
                if (bTrueForHigh)
                {
                    iBuffValue = iHighActive;
                }
                else
                {
                    iBuffValue = iLowActive;
                }
                // Enable Alarm 功能
                uError = Motion.mAcm_SetProperty(ipAxisHandle[btAxisSel_X0_Y1_Z2_U3], (uint)PropertyID.CFG_AxAlmEnable, ref iEnable, (uint)Marshal.SizeOf(typeof(double)));
                if (uError != (uint)ErrorCode.SUCCESS)
                {
                    bDeviceFlag_NoError = false;
                    PCI1245LMessage_Card1.fcShowMessageForm("PCI-1245L_Card1错误, 不能開啟" + btAxisSel_X0_Y1_Z2_U3 + "Axis Alarm功能, 請結束程式!!!");
                }
                // 設定 Alarm 觸發方式
                uError = Motion.mAcm_SetProperty(ipAxisHandle[btAxisSel_X0_Y1_Z2_U3], (uint)PropertyID.CFG_AxAlmLogic, ref iBuffValue, (uint)Marshal.SizeOf(typeof(double)));
                if (uError != (uint)ErrorCode.SUCCESS)
                {
                    bDeviceFlag_NoError = false;
                    PCI1245LMessage_Card1.fcShowMessageForm("PCI-1245L_Card1错误, 不能設定" + btAxisSel_X0_Y1_Z2_U3 + "Axis Alarm觸發方式, 請結束程式!!!");
                }
            }
        }
        public static void fcSetHLMTLogic(bool bTrueForHigh, byte btAxisSel_X0_Y1_Z2_U3) // 設定極限Sensor觸發方式
        {
            int iBuffValue = 0;
            if (bDeviceFlag_NoError)
            {
                if (bTrueForHigh)
                {
                    iBuffValue = iHighActive;
                }
                else
                {
                    iBuffValue = iLowActive;
                }
                uError = Motion.mAcm_SetProperty(ipAxisHandle[btAxisSel_X0_Y1_Z2_U3], (uint)PropertyID.CFG_AxElLogic, ref iBuffValue, (uint)Marshal.SizeOf(typeof(double)));
                if (uError != (uint)ErrorCode.SUCCESS)
                {
                    bDeviceFlag_NoError = false;
                    PCI1245LMessage_Card1.fcShowMessageForm("PCI-1245L_Card1错误, 不能設定" + btAxisSel_X0_Y1_Z2_U3 + "Axis 極限狀態, 請結束程式!!!");
                }
            }
        }
        public static void fcSetORGLogic(bool bTrueForHigh, byte btAxisSel_X0_Y1_Z2_U3) // 設定ORG Sensor觸發方式
        {
            int iBuffValue = 0;
            if (bDeviceFlag_NoError)
            {
                if (bTrueForHigh)
                {
                    iBuffValue = iHighActive;
                }
                else
                {
                    iBuffValue = iLowActive;
                }
                uError = Motion.mAcm_SetProperty(ipAxisHandle[btAxisSel_X0_Y1_Z2_U3], (uint)PropertyID.CFG_AxOrgLogic, ref iBuffValue, (uint)Marshal.SizeOf(typeof(double)));
                if (uError != (uint)ErrorCode.SUCCESS)
                {
                    bDeviceFlag_NoError = false;
                    PCI1245LMessage_Card1.fcShowMessageForm("PCI-1245L_Card1错误, 不能設定" + btAxisSel_X0_Y1_Z2_U3 + "Axis 原點狀態, 請結束程式!!!");
                }
            }
        }
        public static void fcSetINPLogic(bool bTrueForEnable, bool bTrueForHigh, byte btAxisSel_X0_Y1_Z2_U3) // 設定INP觸發方式
        {
            int iBuffValue = 0;
            if (bDeviceFlag_NoError)
            {
                if (bTrueForEnable)
                {
                    iBuffValue = 1;
                }
                else
                {
                    iBuffValue = 0;
                }
                uError = Motion.mAcm_SetProperty(ipAxisHandle[btAxisSel_X0_Y1_Z2_U3], (uint)PropertyID.CFG_AxInpEnable, ref iBuffValue, (uint)Marshal.SizeOf(typeof(double)));
                if (uError != (uint)ErrorCode.SUCCESS)
                {
                    bDeviceFlag_NoError = false;
                    PCI1245LMessage_Card1.fcShowMessageForm("PCI-1245L_Card1错误, 不能設定" + btAxisSel_X0_Y1_Z2_U3 + "INP是否啟動, 請結束程式!!!");
                }
                if (uError == (uint)ErrorCode.SUCCESS && bTrueForEnable)
                {
                    if (bTrueForHigh)
                    {
                        iBuffValue = iHighActive;
                    }
                    else
                    {
                        iBuffValue = iLowActive;
                    }
                    uError = Motion.mAcm_SetProperty(ipAxisHandle[btAxisSel_X0_Y1_Z2_U3], (uint)PropertyID.CFG_AxInpLogic, ref iBuffValue, (uint)Marshal.SizeOf(typeof(double)));
                    if (uError != (uint)ErrorCode.SUCCESS)
                    {
                        bDeviceFlag_NoError = false;
                        PCI1245LMessage_Card1.fcShowMessageForm("PCI-1245L_Card1错误, 不能設定" + btAxisSel_X0_Y1_Z2_U3 + "INP邏輯訊號, 請結束程式!!!");
                    }
                }
            }
        }
        public static void fcSetHomeMomePara(bool bTrueForiORG_IMMED_STOP_FalseForiORG_DEC_TO_STOP, byte btAxisSel_X0_Y1_Z2_U3)
        {
            int iBuffValue = 100;
            int iIndex = sDeviceName.IndexOf("1245L");
            if (bDeviceFlag_NoError && iIndex == -1) // Use 1245
            {
                if (bTrueForiORG_IMMED_STOP_FalseForiORG_DEC_TO_STOP)
                {
                    iBuffValue = iORG_IMMED_STOP;
                }
                else
                {
                    iBuffValue = iORG_DEC_TO_STOP;
                }
                uError = Motion.mAcm_SetProperty(ipAxisHandle[btAxisSel_X0_Y1_Z2_U3], (uint)PropertyID.CFG_AxOrgReact, ref iBuffValue, (uint)Marshal.SizeOf(typeof(double)));
                if (uError != (uint)ErrorCode.SUCCESS)
                {
                    bDeviceFlag_NoError = false;
                    PCI1245LMessage_Card1.fcShowMessageForm("PCI-1245L_Card1错误, 不能設定" + btAxisSel_X0_Y1_Z2_U3 + "Axis 原點參數-停止方式, 請結束程式!!!");
                    return;
                }
                //iBuffValue = 100; // Cross Distance
                //uError = Motion.mAcm_SetProperty(ipAxisHandle[btAxisSel_X0_Y1_Z2_U3], (uint)PropertyID.PAR_AxHomeCrossDistance, ref iBuffValue, (uint)Marshal.SizeOf(typeof(double)));
                //if (uError != (uint)ErrorCode.SUCCESS)
                //{
                //    bDeviceFlag_NoError = false;
                //    PCI1245LMessage_Card1.fcShowMessageForm("PCI-1245L_Card1错误, 不能設定" + btAxisSel_X0_Y1_Z2_U3 + "Axis 原點參數-掃描距離, 請結束程式!!!");
                //    return;
                //}
            }
        }
        public static void fcSetAxisMaxRange(byte btAxisSel_X0_Y1_Z2_U3, double dMaxVel, double dMaxAcc, double dMaxDec) // 設定最大速度,加速度範圍
        {
            if (bDeviceFlag_NoError)
            {
                uint uErr1 = 0;
                uint uErr2 = 0;
                uint uErr3 = 0;
                double defValue = 0;

                // Max Vel
                defValue = dMaxVel;
                uErr1 = Motion.mAcm_SetProperty(ipAxisHandle[btAxisSel_X0_Y1_Z2_U3], (uint)PropertyID.CFG_AxMaxVel, ref defValue, (uint)Marshal.SizeOf(typeof(double)));

                // Max Acc
                defValue = dMaxAcc;
                uErr2 = Motion.mAcm_SetProperty(ipAxisHandle[btAxisSel_X0_Y1_Z2_U3], (uint)PropertyID.CFG_AxMaxAcc, ref defValue, (uint)Marshal.SizeOf(typeof(double)));

                // Max Dec
                defValue = dMaxDec;
                uErr3 = Motion.mAcm_SetProperty(ipAxisHandle[btAxisSel_X0_Y1_Z2_U3], (uint)PropertyID.CFG_AxMaxDec, ref defValue, (uint)Marshal.SizeOf(typeof(double)));

                uError = uErr1 + uErr2 + uErr3;
                if (uError != (uint)ErrorCode.SUCCESS)
                {
                    bDeviceFlag_NoError = false;
                    PCI1245LMessage_Card1.fcShowMessageForm("PCI-1245L_Card1错误, 不能設定最大(速度,加速度,減速度), 請結束程式!!!");
                    //MessageBox.Show("PCI-1240错误, 不能設定最大(速度,加速度,減速度), 請結束程式!!!", "TIS-1000", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }            
        }
        public static void fcSetAxisValue(byte btAxisSel_X0_Y1_Z2_U3, double dVelLow,double dVelHigh, double dAcc, double dDec) // 設定速度,加速度範圍
        {
            if (bDeviceFlag_NoError)
            {
                uint uErr1 = 0;
                uint uErr2 = 0;
                uint uErr3 = 0;
                uint uErr4 = 0;
                double defValue = 0;

                int iIndex = sDeviceName.IndexOf("1245L");
                if (iIndex != -1) // 1240
                {
                    if (dVelLow == 1)
                    {
                        dVelLow = dVelHigh / 8;
                    }
                }

                // Vel Low
                defValue = dVelLow;
                uErr1 = Motion.mAcm_SetProperty(ipAxisHandle[btAxisSel_X0_Y1_Z2_U3], (uint)PropertyID.PAR_AxVelLow, ref defValue, (uint)Marshal.SizeOf(typeof(double)));

                // Vel High
                defValue = dVelHigh;
                uErr2 = Motion.mAcm_SetProperty(ipAxisHandle[btAxisSel_X0_Y1_Z2_U3], (uint)PropertyID.PAR_AxVelHigh, ref defValue, (uint)Marshal.SizeOf(typeof(double)));

                // Acc
                defValue = dAcc;
                uErr3 = Motion.mAcm_SetProperty(ipAxisHandle[btAxisSel_X0_Y1_Z2_U3], (uint)PropertyID.PAR_AxAcc, ref defValue, (uint)Marshal.SizeOf(typeof(double)));

                // Dec
                defValue = dDec;
                uErr4 = Motion.mAcm_SetProperty(ipAxisHandle[btAxisSel_X0_Y1_Z2_U3], (uint)PropertyID.PAR_AxDec, ref defValue, (uint)Marshal.SizeOf(typeof(double)));

                uError = uErr1 + uErr2 + uErr3 + uErr4;
                if (uError != (uint)ErrorCode.SUCCESS)
                {
                    bDeviceFlag_NoError = false;
                    PCI1245LMessage_Card1.fcShowMessageForm("PCI-1245L_Card1错误, 不能設定速度參數(最低, 最高, 加速度, 減速度), 請結束程式!!!");
                    //MessageBox.Show("PCI-1240错误, 不能設定速度參數(最低, 最高, 加速度, 減速度), 請結束程式!!!", "TIS-1000", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }            
        }
        public static void fcChangeAxisValue(byte btAxisSel_X0_Y1_Z2_U3, double dVelSpeed)
        {
            if (bDeviceFlag_NoError)
            {
                uint uError = 0;

                // Change Vel
                uError = Motion.mAcm_AxChangeVel(ipAxisHandle[btAxisSel_X0_Y1_Z2_U3], dVelSpeed);

                if (uError != (uint)ErrorCode.SUCCESS)
                {
                    string sAxisName = "";
                    switch (btAxisSel_X0_Y1_Z2_U3)
                    {
                        case 0:
                            sAxisName = "== 板卡-第0轴异常, 错误码" + uError;
                            break;
                        case 1:
                            sAxisName = "== 板卡-第1轴异常, 错误码" + uError;
                            break;
                        case 2:
                            sAxisName = "== 板卡-第2轴异常, 错误码" + uError;
                            break;
                        case 3:
                            sAxisName = "== 板卡-第3轴异常, 错误码" + uError;
                            break;
                    }
                    bDeviceFlag_NoError = false;
                    PCI1245LMessage_Card1.fcShowMessageForm("PCI-1245L_Card1错误, 不能改變速度參數, 請結束程式!!!" + sAxisName);
                }
            }
        }
        public static void fcOnAxisMoveRel(byte btAxisSel_X0_Y1_Z2_U3, int iPulse) // 馬達以相對座標移動
        {
            if (bDeviceFlag_NoError)
            {
                uError = Motion.mAcm_AxMoveRel(ipAxisHandle[btAxisSel_X0_Y1_Z2_U3], iPulse);
                if (uError != (uint)ErrorCode.SUCCESS)
                {
                    string sAxisName = "";
                    switch (btAxisSel_X0_Y1_Z2_U3)
                    {
                        case 0:
                            sAxisName = "== 板卡-第0轴异常, 错误码" + uError;
                            break;
                        case 1:
                            sAxisName = "== 板卡-第1轴异常, 错误码" + uError;
                            break;
                        case 2:
                            sAxisName = "== 板卡-第2轴异常, 错误码" + uError;
                            break;
                        case 3:
                            sAxisName = "== 板卡-第3轴异常, 错误码" + uError;
                            break;
                    }
                    bDeviceFlag_NoError = false;
                    PCI1245LMessage_Card1.fcShowMessageForm("PCI-1245L_Card1错误, 單軸相對移動發生错误, 請結束程式!!!" + sAxisName);
                    //MessageBox.Show("PCI-1240错误, 單軸相對移動發生错误, 請結束程式!!!", "警告!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public static void fcOnAxisMoveVel(byte btAxisSel_X0_Y1_Z2_U3, bool bTrueForPositive) // 馬達以相對座標移動
        {
            if (bDeviceFlag_NoError)
            {
                ushort uDir = 0;
                if (!bTrueForPositive)
                {
                    uDir = (ushort)1;
                }
                uError = Motion.mAcm_AxMoveVel(ipAxisHandle[btAxisSel_X0_Y1_Z2_U3], uDir);
                if (uError != (uint)ErrorCode.SUCCESS)
                {
                    string sAxisName = "";
                    switch (btAxisSel_X0_Y1_Z2_U3)
                    {
                        case 0:
                            sAxisName = "== 板卡-第0轴异常, 错误码" + uError;
                            break;
                        case 1:
                            sAxisName = "== 板卡-第1轴异常, 错误码" + uError;
                            break;
                        case 2:
                            sAxisName = "== 板卡-第2轴异常, 错误码" + uError;
                            break;
                        case 3:
                            sAxisName = "== 板卡-第3轴异常, 错误码" + uError;
                            break;
                    }
                    bDeviceFlag_NoError = false;
                    PCI1245LMessage_Card1.fcShowMessageForm("PCI-1245L_Card1错误,单轴无终点移动发生错误,请结束程式!!!" + sAxisName);
                    //MessageBox.Show("PCI-1240错误, 單軸相對移動發生错误, 請結束程式!!!", "警告!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public static void fcOnAxisMoveAbs(byte btAxisSel_X0_Y1_Z2_U3, double iPulse) // 馬達以絕對座標移動
        {
            //uint AxesPerDev = new uint();
            //uint buffLen = 4;
            //uError = Motion.mAcm_GetProperty(ipAxisHandle[btAxisSel_X0_Y1_Z2_U3], (uint)PropertyID.PAR_AxJerk, ref AxesPerDev, ref buffLen);
            //if (uError != (uint)ErrorCode.SUCCESS)
            //{
            //    Log.Write(AxesPerDev.ToString());
            //}

            if (bDeviceFlag_NoError)
            {
                uError = Motion.mAcm_AxMoveAbs(ipAxisHandle[btAxisSel_X0_Y1_Z2_U3], iPulse);
                if (uError != (uint)ErrorCode.SUCCESS)
                {
                    string sAxisName = "";
                    switch (btAxisSel_X0_Y1_Z2_U3)
                    {
                        case 0:
                            sAxisName = "== 板卡-第0轴异常, 错误码" + uError;
                            break;
                        case 1:
                            sAxisName = "== 板卡-第1轴异常, 错误码" + uError;
                            break;
                        case 2:
                            sAxisName = "== 板卡-第2轴异常, 错误码" + uError;
                            break;
                        case 3:
                            sAxisName = "== 板卡-第3轴异常, 错误码" + uError;
                            break;
                    }
                    bDeviceFlag_NoError = false;
                    PCI1245LMessage_Card1.fcShowMessageForm("PCI-1245L_Card1错误, 单轴移动发生错误,请结束程式!!!" + sAxisName);
                }
            }
        }
        public static void fcOnAxisMoveStop(byte btAxisSel_X0_Y1_Z2_U3) // 馬達停止移動
        {
            if (bDeviceFlag_NoError)
            {
                fcSetDeviceFlag_NoError();
                uError = Motion.mAcm_AxStopEmg(ipAxisHandle[btAxisSel_X0_Y1_Z2_U3]);
                //uError = Motion.mAcm_AxStopDec(ipAxisHandle[btAxisSel_X0_Y1_Z2_U3]);
                if (uError != (uint)ErrorCode.SUCCESS)
                {
                    string sAxisName = "";
                    switch (btAxisSel_X0_Y1_Z2_U3)
                    {
                        case 0:
                            sAxisName = "== 板卡-第0轴异常, 错误码" + uError;
                            break;
                        case 1:
                            sAxisName = "== 板卡-第1轴异常, 错误码" + uError;
                            break;
                        case 2:
                            sAxisName = "== 板卡-第2轴异常, 错误码" + uError;
                            break;
                        case 3:
                            sAxisName = "== 板卡-第3轴异常, 错误码" + uError;
                            break;
                    }
                    bDeviceFlag_NoError = false;
                    PCI1245LMessage_Card1.fcShowMessageForm("PCI-1245L_Card1错误, 单轴停止发生错误, 請結束程式!!!" + sAxisName);
                    //MessageBox.Show("PCI-1240错误, 单轴停止发生错误, 請結束程式!!!", "警告!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public static void fcOnAxisMoveStop_Emg(byte btAxisSel_X0_Y1_Z2_U3) // 馬達停止移動
        {
            if (bDeviceFlag_NoError)
            {
                uError = Motion.mAcm_AxStopEmg(ipAxisHandle[btAxisSel_X0_Y1_Z2_U3]);
                //uError = Motion.mAcm_AxStopDec(ipAxisHandle[btAxisSel_X0_Y1_Z2_U3]);
                if (uError != (uint)ErrorCode.SUCCESS)
                {
                    string sAxisName = "";
                    switch (btAxisSel_X0_Y1_Z2_U3)
                    {
                        case 0:
                            sAxisName = "== 板卡-第0轴异常, 错误码" + uError;
                            break;
                        case 1:
                            sAxisName = "== 板卡-第1轴异常, 错误码" + uError;
                            break;
                        case 2:
                            sAxisName = "== 板卡-第2轴异常, 错误码" + uError;
                            break;
                        case 3:
                            sAxisName = "== 板卡-第3轴异常, 错误码" + uError;
                            break;
                    }
                    bDeviceFlag_NoError = false;
                    PCI1245LMessage_Card1.fcShowMessageForm("PCI-1245L_Card1错误, 單軸緊急停止發生错误, 請結束程式!!!" + sAxisName);
                    //MessageBox.Show("PCI-1240错误, 单轴停止发生错误, 請結束程式!!!", "警告!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public static void fcGeneralDO(byte btAxisSel_X0_Y1_Z2_U3, ushort uChSel_Bit4To7, bool bTrueForHigh) // 數位輸出控制
        {
            if (bDeviceFlag_NoError)
            {
                byte btDoValue = 0;
                if (bTrueForHigh)
                {
                    btDoValue = 1;
                }
                else
                {
                    btDoValue = 0;
                }
                uError = Motion.mAcm_AxDoSetBit(ipAxisHandle[btAxisSel_X0_Y1_Z2_U3], uChSel_Bit4To7, btDoValue);
                if (uError != (uint)ErrorCode.SUCCESS)
                {
                    string sAxisName = "";
                    switch (btAxisSel_X0_Y1_Z2_U3)
                    {
                        case 0:
                            sAxisName = "== 板卡-第0轴异常, 错误码" + uError;
                            break;
                        case 1:
                            sAxisName = "== 板卡-第1轴异常, 错误码" + uError;
                            break;
                        case 2:
                            sAxisName = "== 板卡-第2轴异常, 错误码" + uError;
                            break;
                        case 3:
                            sAxisName = "== 板卡-第3轴异常, 错误码" + uError;
                            break;
                    }
                    bDeviceFlag_NoError = false;
                    PCI1245LMessage_Card1.fcShowMessageForm("PCI-1245L_Card1错误, DO控制發生错误, 請結束程式!!!" + sAxisName);
                    //MessageBox.Show("PCI-1240错误, DO控制發生错误, 請結束程式!!!", "警告!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public static void fcGeneralDOInit()
        {
            int iXAxis = 0;
            int iYAxis = 1;
            int iZAxis = 2;
            int iUAxis = 3;
            uint uError_X = 0;
            uint uError_Y = 0;
            uint uError_Z = 0;
            uint uError_U = 0;
            if (bDeviceFlag_NoError)
            {
                for (int i = 4; i < 8; i++)
                {
                    uError_X = Motion.mAcm_AxDoSetBit(ipAxisHandle[iXAxis], (ushort)i, 0);
                    uError_Y = Motion.mAcm_AxDoSetBit(ipAxisHandle[iYAxis], (ushort)i, 0);
                    uError_Z = Motion.mAcm_AxDoSetBit(ipAxisHandle[iZAxis], (ushort)i, 0);
                    uError_U = Motion.mAcm_AxDoSetBit(ipAxisHandle[iUAxis], (ushort)i, 0);
                }
                if ((uError_X != (uint)ErrorCode.SUCCESS) ||
                    (uError_Y != (uint)ErrorCode.SUCCESS) ||
                    (uError_Z != (uint)ErrorCode.SUCCESS) ||
                    (uError_U != (uint)ErrorCode.SUCCESS))
                {
                    bDeviceFlag_NoError = false;
                    PCI1245LMessage_Card1.fcShowMessageForm("PCI-1245L_Card1错误, DO初始化發生错误, 請結束程式!!!");
                }
            }
        }
        public static void fcGeneralDI(byte btAxisSel_X0_Y1_Z2_U3) // 數位輸入偵測
        {
            byte btDIValue = 0;
            for (ushort i = 0; i < 4; i++)
            {
                if (bDeviceFlag_NoError)
                {
                    uError = Motion.mAcm_AxDiGetBit(ipAxisHandle[btAxisSel_X0_Y1_Z2_U3], i, ref btDIValue);
                    if (uError != (uint)ErrorCode.SUCCESS)
                    {
                        bDeviceFlag_NoError = false;
                        PCI1245LMessage_Card1.fcShowMessageForm("PCI-1245L_Card1错误, DI偵測發生错误, 請結束程式!!!");
                        //MessageBox.Show("PCI-1240错误, DI偵測發生错误, 請結束程式!!!", "警告!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        switch (btAxisSel_X0_Y1_Z2_U3)
                        {
                            #region X Axis Data
                            case 0: // X Axis Data
                                switch (i)
                                {
                                    case 0: // bit 0
                                        if (btDIValue == 1)
                                            X_IN0 = true;
                                        else
                                            X_IN0 = false;
                                    break;
                                    case 1: // bit 1
                                        if (btDIValue == 1)
                                            X_IN1 = true;
                                        else
                                            X_IN1 = false;
                                    break;
                                    case 2: // bit 2
                                        if (btDIValue == 1)
                                            X_IN2 = true;
                                        else
                                            X_IN2 = false;
                                    break;
                                    case 3: // bit 3
                                        if (btDIValue == 1)
                                            X_IN3 = true;
                                        else
                                            X_IN3 = false;
                                    break;
                                }
                            break;
                            #endregion
                            #region Y Axis Data
                            case 1: // Y Axis Data
                            switch (i)
                            {
                                case 0: // bit 0
                                    if (btDIValue == 1)
                                        Y_IN0 = true;
                                    else
                                        Y_IN0 = false;
                                    break;
                                case 1: // bit 1
                                    if (btDIValue == 1)
                                        Y_IN1 = true;
                                    else
                                        Y_IN1 = false;
                                    break;
                                case 2: // bit 2
                                    if (btDIValue == 1)
                                        Y_IN2 = true;
                                    else
                                        Y_IN2 = false;
                                    break;
                                case 3: // bit 3
                                    if (btDIValue == 1)
                                        Y_IN3 = true;
                                    else
                                        Y_IN3 = false;
                                    break;
                            }
                            break;
                            #endregion
                            #region Z Axis Data
                            case 2: // Z Axis Data
                            switch (i)
                            {
                                case 0: // bit 0
                                    if (btDIValue == 1)
                                        Z_IN0 = true;
                                    else
                                        Z_IN0 = false;
                                    break;
                                case 1: // bit 1
                                    if (btDIValue == 1)
                                        Z_IN1 = true;
                                    else
                                        Z_IN1 = false;
                                    break;
                                case 2: // bit 2
                                    if (btDIValue == 1)
                                        Z_IN2 = true;
                                    else
                                        Z_IN2 = false;
                                    break;
                                case 3: // bit 3
                                    if (btDIValue == 1)
                                        Z_IN3 = true;
                                    else
                                        Z_IN3 = false;
                                    break;
                            }
                            break;
                            #endregion
                            #region U Axis Data
                            case 3: // U Axis Data
                            switch (i)
                            {
                                case 0: // bit 0
                                    if (btDIValue == 1)
                                        U_IN0 = true;
                                    else
                                        U_IN0 = false;
                                    break;
                                case 1: // bit 1
                                    if (btDIValue == 1)
                                        U_IN1 = true;
                                    else
                                        U_IN1 = false;
                                    break;
                                case 2: // bit 2
                                    if (btDIValue == 1)
                                        U_IN2 = true;
                                    else
                                        U_IN2 = false;
                                    break;
                                case 3: // bit 3
                                    if (btDIValue == 1)
                                        U_IN3 = true;
                                    else
                                        U_IN3 = false;
                                    break;
                            }
                            break;
                            #endregion
                        }
                    }
                }
            }
        }
        public static void fcGeneralDO_Sensor(byte btAxisSel_X0_Y1_Z2_U3) // 數位輸出偵測
        {
            byte btDIValue = 0;
            for (ushort i = 4; i < 8; i++)
            {
                if (bDeviceFlag_NoError)
                {
                    uError = Motion.mAcm_AxDoGetBit(ipAxisHandle[btAxisSel_X0_Y1_Z2_U3], i, ref btDIValue);
                    if (uError != (uint)ErrorCode.SUCCESS)
                    {
                        bDeviceFlag_NoError = false;
                        PCI1245LMessage_Card1.fcShowMessageForm("PCI-1245L_Card1错误, DO偵測發生错误, 請結束程式!!!");
                        //MessageBox.Show("PCI-1240错误, DI偵測發生错误, 請結束程式!!!", "警告!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        switch (btAxisSel_X0_Y1_Z2_U3)
                        {
                            #region X Axis Data
                            case 0: // X Axis Data
                                switch (i)
                                {
                                    case 4: // bit 4
                                        if (btDIValue == 1)
                                            X_Sensor_DO4 = true;
                                        else
                                            X_Sensor_DO4 = false;
                                        break;
                                    case 5: // bit 5
                                        if (btDIValue == 1)
                                            X_Sensor_DO5 = true;
                                        else
                                            X_Sensor_DO5 = false;
                                        break;
                                    case 6: // bit 6
                                        if (btDIValue == 1)
                                            X_Sensor_DO6 = true;
                                        else
                                            X_Sensor_DO6 = false;
                                        break;
                                    case 7: // bit 7
                                        if (btDIValue == 1)
                                            X_Sensor_DO7 = true;
                                        else
                                            X_Sensor_DO7 = false;
                                        break;
                                }
                                break;
                            #endregion
                            #region Y Axis Data
                            case 1: // Y Axis Data
                                switch (i)
                                {
                                    case 4: // bit 4
                                        if (btDIValue == 1)
                                            Y_Sensor_DO4 = true;
                                        else
                                            Y_Sensor_DO4 = false;
                                        break;
                                    case 5: // bit 5
                                        if (btDIValue == 1)
                                            Y_Sensor_DO5 = true;
                                        else
                                            Y_Sensor_DO5 = false;
                                        break;
                                    case 6: // bit 6
                                        if (btDIValue == 1)
                                            Y_Sensor_DO6 = true;
                                        else
                                            Y_Sensor_DO6 = false;
                                        break;
                                    case 7: // bit 7
                                        if (btDIValue == 1)
                                            Y_Sensor_DO7 = true;
                                        else
                                            Y_Sensor_DO7 = false;
                                        break;
                                }
                                break;
                            #endregion
                            #region Z Axis Data
                            case 2: // Z Axis Data
                                switch (i)
                                {
                                    case 4: // bit 4
                                        if (btDIValue == 1)
                                            Z_Sensor_DO4 = true;
                                        else
                                            Z_Sensor_DO4 = false;
                                        break;
                                    case 5: // bit 5
                                        if (btDIValue == 1)
                                            Z_Sensor_DO5 = true;
                                        else
                                            Z_Sensor_DO5 = false;
                                        break;
                                    case 6: // bit 6
                                        if (btDIValue == 1)
                                            Z_Sensor_DO6 = true;
                                        else
                                            Z_Sensor_DO6 = false;
                                        break;
                                    case 7: // bit 7
                                        if (btDIValue == 1)
                                            Z_Sensor_DO7 = true;
                                        else
                                            Z_Sensor_DO7 = false;
                                        break;
                                }
                                break;
                            #endregion
                            #region U Axis Data
                            case 3: // U Axis Data
                                switch (i)
                                {
                                    case 4: // bit 4
                                        if (btDIValue == 1)
                                            U_Sensor_DO4 = true;
                                        else
                                            U_Sensor_DO4 = false;
                                        break;
                                    case 5: // bit 5
                                        if (btDIValue == 1)
                                            U_Sensor_DO5 = true;
                                        else
                                            U_Sensor_DO5 = false;
                                        break;
                                    case 6: // bit 6
                                        if (btDIValue == 1)
                                            U_Sensor_DO6 = true;
                                        else
                                            U_Sensor_DO6 = false;
                                        break;
                                    case 7: // bit 7
                                        if (btDIValue == 1)
                                            U_Sensor_DO7 = true;
                                        else
                                            U_Sensor_DO7 = false;
                                        break;
                                }
                                break;
                            #endregion
                        }
                    }
                }
            }
        }
        public static void fcMotionDI(byte btAxisSel_X0_Y1_Z2_U3) // 偵測Motion相關訊號
        {
            uint uIOStatus = 0;
            if (bDeviceFlag_NoError)
            {
                uError = Motion.mAcm_AxGetMotionIO(ipAxisHandle[btAxisSel_X0_Y1_Z2_U3], ref uIOStatus);
                if (uError != (uint)ErrorCode.SUCCESS)
                {
                    bDeviceFlag_NoError = false;
                    PCI1245LMessage_Card1.fcShowMessageForm("PCI-1245L_Card1错误, MotionIO偵測發生错误, 請結束程式!!!");
                }
                else
                {
                    switch (btAxisSel_X0_Y1_Z2_U3)
                    {
                        #region X Axis Data
                        case 0: // X Axis Data
                            if ((uIOStatus & 0x2) > 0) //Alarm, Hex, Ref Manual
                            {
                                X_ALARM = true;
                            }
                            else
                            {
                                X_ALARM = false;
                            }
                            if ((uIOStatus & 0x4) > 0) //+EL, Hex, Ref Manual
                            {
                                X_LMTP = true;
                            }
                            else
                            {
                                X_LMTP = false;
                            }
                            if ((uIOStatus & 0x8) > 0) //-EL, Hex, Ref Manual
                            {
                                X_LMTM = true;
                            }
                            else
                            {
                                X_LMTM = false;
                            }
                            if ((uIOStatus & 0x10) > 0) //Org, Hex, Ref Manual
                            {
                                X_ORG = true;
                            }
                            else
                            {
                                X_ORG = false;
                            }
                            if ((uIOStatus & 0x40) > 0) //EMG, Hex, Ref Manual
                            {
                                X_EMG = true;
                            }
                            else
                            {
                                X_EMG = false;
                            }
                            if ((uIOStatus & 0x2000) > 0) //INP, Hex, Ref Manual
                            {
                                X_INP = true;
                            }
                            else
                            {
                                X_INP = false;
                            }
                            break;
                        #endregion
                        #region Y Axis Data
                        case 1: // Y Axis Data
                            if ((uIOStatus & 0x2) > 0) //Alarm, Hex, Ref Manual
                            {
                                Y_ALARM = true;
                            }
                            else
                            {
                                Y_ALARM = false;
                            }
                            if ((uIOStatus & 0x4) > 0) //+EL, Hex, Ref Manual
                            {
                                Y_LMTP = true;
                            }
                            else
                            {
                                Y_LMTP = false;
                            }
                            if ((uIOStatus & 0x8) > 0) //-EL, Hex, Ref Manual
                            {
                                Y_LMTM = true;
                            }
                            else
                            {
                                Y_LMTM = false;
                            }
                            if ((uIOStatus & 0x10) > 0) //Org, Hex, Ref Manual
                            {
                                Y_ORG = true;
                            }
                            else
                            {
                                Y_ORG = false;
                            }
                            if ((uIOStatus & 0x40) > 0) //EMG, Hex, Ref Manual
                            {
                                Y_EMG = true;
                            }
                            else
                            {
                                Y_EMG = false;
                            }
                            if ((uIOStatus & 0x2000) > 0) //INP, Hex, Ref Manual
                            {
                                Y_INP = true;
                            }
                            else
                            {
                                Y_INP = false;
                            }
                            break;
                        #endregion
                        #region Z Axis Data
                        case 2: // Z Axis Data
                            if ((uIOStatus & 0x2) > 0) //Alarm, Hex, Ref Manual
                            {
                                Z_ALARM = true;
                            }
                            else
                            {
                                Z_ALARM = false;
                            }
                            if ((uIOStatus & 0x4) > 0) //+EL, Hex, Ref Manual
                            {
                                Z_LMTP = true;
                            }
                            else
                            {
                                Z_LMTP = false;
                            }
                            if ((uIOStatus & 0x8) > 0) //-EL, Hex, Ref Manual
                            {
                                Z_LMTM = true;
                            }
                            else
                            {
                                Z_LMTM = false;
                            }
                            if ((uIOStatus & 0x10) > 0) //Org, Hex, Ref Manual
                            {
                                Z_ORG = true;
                            }
                            else
                            {
                                Z_ORG = false;
                            }
                            if ((uIOStatus & 0x40) > 0) //EMG, Hex, Ref Manual
                            {
                                Z_EMG = true;
                            }
                            else
                            {
                                Z_EMG = false;
                            }
                            if ((uIOStatus & 0x2000) > 0) //INP, Hex, Ref Manual
                            {
                                Z_INP = true;
                            }
                            else
                            {
                                Z_INP = false;
                            }
                            break;
                        #endregion
                        #region U Axis Data
                        case 3: // U Axis Data
                            if ((uIOStatus & 0x2) > 0) //Alarm, Hex, Ref Manual
                            {
                                U_ALARM = true;
                            }
                            else
                            {
                                U_ALARM = false;
                            }
                            if ((uIOStatus & 0x4) > 0) //+EL, Hex, Ref Manual
                            {
                                U_LMTP = true;
                            }
                            else
                            {
                                U_LMTP = false;
                            }
                            if ((uIOStatus & 0x8) > 0) //-EL, Hex, Ref Manual
                            {
                                U_LMTM = true;
                            }
                            else
                            {
                                U_LMTM = false;
                            }
                            if ((uIOStatus & 0x10) > 0) //Org, Hex, Ref Manual
                            {
                                U_ORG = true;
                            }
                            else
                            {
                                U_ORG = false;
                            }
                            if ((uIOStatus & 0x40) > 0) //EMG, Hex, Ref Manual
                            {
                                U_EMG = true;
                            }
                            else
                            {
                                U_EMG = false;
                            }
                            if ((uIOStatus & 0x2000) > 0) //INP, Hex, Ref Manual
                            {
                                U_INP = true;
                            }
                            else
                            {
                                U_INP = false;
                            }
                            break;
                        #endregion
                    }
                }
            }
        }
        public static void fcSetCompareModePara(byte btAxisSel_X0_Y1_Z2_U3, 
                                                uint uSource_0CmdPos_1ActualPos, 
                                                uint uMethod_0GreaterPos_1SmallerPos, 
                                                uint uFlag_0Off_1On,
                                                double dStart, double dEnd, double dInterval) // 設定比較模式參數
        {
            if (bDeviceFlag_NoError)
            {
                uint uErr1 = 0;
                uint uErr2 = 0;
                uint uErr3 = 0;
                uint uErr4 = 0;
                uint uValue = 0;

                uValue = uSource_0CmdPos_1ActualPos; // 設定使用Command Pos或是Actual Pos
                uErr1 = Motion.mAcm_SetProperty(ipAxisHandle[btAxisSel_X0_Y1_Z2_U3], (uint)PropertyID.CFG_AxCmpSrc, ref uValue, (uint)Marshal.SizeOf(typeof(UInt32)));

                uValue = uMethod_0GreaterPos_1SmallerPos; // 設定輸出方式
                uErr2 = Motion.mAcm_SetProperty(ipAxisHandle[btAxisSel_X0_Y1_Z2_U3], (uint)PropertyID.CFG_AxCmpMethod, ref uValue, (uint)Marshal.SizeOf(typeof(UInt32)));

                uValue = uFlag_0Off_1On; // 設定是否執行比較模式
                uErr3 = Motion.mAcm_SetProperty(ipAxisHandle[btAxisSel_X0_Y1_Z2_U3], (uint)PropertyID.CFG_AxCmpEnable, ref uValue, (uint)Marshal.SizeOf(typeof(UInt32)));

                // 設定比較模式起始,停止,間距資料
                uErr4 = Motion.mAcm_AxSetCmpAuto(ipAxisHandle[btAxisSel_X0_Y1_Z2_U3], dStart, dEnd, dInterval);

                uError = uErr1 + uErr2 + uErr3 + uErr4;
                if (uError != (uint)ErrorCode.SUCCESS)
                {
                    bDeviceFlag_NoError = false;
                    PCI1245LMessage_Card1.fcShowMessageForm("PCI-1245L_Card1错误, 設定比較模式參數發生错误, 請結束程式!!!");
                    //MessageBox.Show("PCI-1240错误, 設定比較模式參數發生错误, 請結束程式!!!", "警告!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                // In AMONet motion device, need to call Sleep() before call Acm_AxGetCmpData().
                // Because comparison data need time to write into remote AMONet device

                //double CurCmpData = 0;
                //uErr1 = Motion.mAcm_AxGetCmpData(ipAxisHandle[btAxisSel_X0_Y1_Z2_U3], ref CurCmpData);
                //if (uErr1 !=  (uint)ErrorCode.SUCCESS)
                //{
                //    bDeviceFlag_NoError = false;
                //    PCI1245LMessage_Card1.fcShowMessageForm("PCI-1245L_Card1错误, 設定比較模式參數發生错误, 請結束程式!!!");
                //}
                Thread.Sleep(50);
            }
        }

        // Try Add By Allen
        public static void fcSetCompareModeEvent(byte btAxisSel_X0_Y1_Z2_U3)
        {
            uint[] AxEnableEvtArray = new uint[32];
            uint[] GpEnableEvt = new uint[32];
            if (bDeviceFlag_NoError)
            {
                // Step1: Set Axis Event Array Group
                AxEnableEvtArray[btAxisSel_X0_Y1_Z2_U3] |= 0x2;
                // Step2: Set Enable Motion Event
                uError = Motion.mAcm_EnableMotionEvent(ipDeviceHandle, AxEnableEvtArray, GpEnableEvt, 4, 3);
                if (uError != (uint)ErrorCode.SUCCESS)
                {
                    bDeviceFlag_NoError = false;
                    PCI1245LMessage_Card1.fcShowMessageForm("PCI-1245L_Card1错误, 設定比較參數Event發生错误, 請結束程式!!!");
                }
            }
        }
        public static UInt32[] gAxEvtStatusArray = new UInt32[32];
        public static UInt32[] gGpEvtStatusArray = new UInt32[32];
        public static void fcCheckComPareResult(out uint OutuResult)
        {
            OutuResult = Motion.mAcm_CheckMotionEvent(ipDeviceHandle, gAxEvtStatusArray, gGpEvtStatusArray, 4, 3, 10);
        }
        public static void fRetCmpData(byte btAxisSel_X0_Y1_Z2_U3, ref double rCurCmpData)
        {
            Motion.mAcm_AxGetCmpData(ipAxisHandle[btAxisSel_X0_Y1_Z2_U3], ref rCurCmpData);
        }
        #endregion
        public static string fcReturnAxisStatus(byte btAxisSel_X0_Y1_Z2_U3)
        {
            ushort uCode = 0;
            string strTemp = "";
            Motion.mAcm_AxGetState(ipAxisHandle[btAxisSel_X0_Y1_Z2_U3], ref uCode);
            switch (uCode)
            {
                case 0:
                    strTemp = "STA_AX_DISABLE";
                    break;
                case 1:
                    strTemp = "STA_AX_READY";
                    break;
                case 2:
                    strTemp = "STA_AX_STOPPING";
                    break;
                case 3:
                    strTemp = "STA_AX_ERROR_STOP";
                    break;
                case 4:
                    strTemp = "STA_AX_HOMING";
                    break;
                case 5:
                    strTemp = "STA_AX_PTP_MOT";
                    break;
                case 6:
                    strTemp = "STA_AX_CONTI_MOT";
                    break;
                case 7:
                    strTemp = "STA_AX_SYNC_MOT";
                    break;
                default:
                    break;
            }
            return strTemp;
        }
        public static void fcResetCount(byte btAxisSel_X0_Y1_Z2_U3)
        {
            if (bDeviceFlag_NoError)
            {
                double dPosition = 0;
                uError = Motion.mAcm_AxSetCmdPosition(ipAxisHandle[btAxisSel_X0_Y1_Z2_U3], dPosition);
                if (uError != (uint)ErrorCode.SUCCESS)
                {
                    bDeviceFlag_NoError = false;
                    PCI1245LMessage_Card1.fcShowMessageForm("PCI-1245L_Card1错误, 不能歸零, 請結束程式!!!");
                }
            }
        }
        public static bool fcGet_Device_Status() // 初始化控制卡
        {
            return bDeviceFlag_NoError;
        }
        public static void fcSetDeviceFlag_NoError() // 初始化控制卡
        {
            bDeviceFlag_NoError = true;
        }
        public static void fcResetError(byte btAxisSel_X0_Y1_Z2_U3)
        {
            uError = Motion.mAcm_AxResetError(ipAxisHandle[btAxisSel_X0_Y1_Z2_U3]);
            bDeviceFlag_NoError = true;
            // Modify By Allen, 2014/0403
            // Skip It
            //if (uError != (uint)ErrorCode.SUCCESS)
            //{
            //    bDeviceFlag_NoError = false;
            //    PCI1245LMessage_Card1.fcShowMessageForm("PCI-1245L_Card1错误, 不能清除错误, 請結束程式!!!");
            //}
            //else
            //{
            //    bDeviceFlag_NoError = true;
            //}
        }
    }
    class PCI1245LCtrl_Card1_ErrorState
    {
        public static string STA_AX_DISABLE = "STA_AX_DISABLE";
        public static string STA_AX_READY = "STA_AX_READY";
        public static string STA_AX_STOPPING = "STA_AX_STOPPING";
        public static string STA_AX_ERROR_STOP = "STA_AX_ERROR_STOP";
        public static string STA_AX_HOMING = "STA_AX_HOMING";
        public static string STA_AX_PTP_MOT = "STA_AX_PTP_MOT";
        public static string STA_AX_CONTI_MOT = "STA_AX_CONTI_MOT";
        public static string STA_AX_SYNC_MOT = "STA_AX_SYNC_MOT";
    }
}
