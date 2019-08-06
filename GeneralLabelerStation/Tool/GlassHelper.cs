using Calibration;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralLabelerStation.Tool
{
    /// <summary>
    /// 玻璃板相关
    /// </summary>
    public class GlassHelper
    {
        /// <summary>
        /// 玻璃板矫正参数
        /// </summary>
        public static GalCali galcali = new GalCali();

        public static bool IsLoaded = false;

        /// <summary>
        /// 获得一个点 相对于 Mark点 的 机械偏移 X：[0] Y：[1]
        /// </summary>
        /// <param name="curPos_Machine_Lilun">理论坐标 即轴卡坐标</param>
        /// <param name="markPos_Machine">mark点坐标 相机中心点
        /// </param>
        /// <returns> X：[0] Y：[1]</returns>
        public static PointF GetDisCmpMarkPointF(PointF curPos_Machine_Lilun, PointF markPos_Machine)
        {
            if (Form_Main.VariableSys.bEnableGlassOffset && IsLoaded)
                return galcali.GetActPaste(curPos_Machine_Lilun, markPos_Machine);
            else
                return curPos_Machine_Lilun;
        }

        public static PointF GetDisCmpMarkOffset(PointF curPos_Machine_Lilun, PointF markPos_Machine)
        {
            if (Form_Main.VariableSys.bEnableGlassOffset && IsLoaded)
            {
                PointF newPt = GetDisCmpMarkPointF(curPos_Machine_Lilun, markPos_Machine);
                return new PointF(newPt.X - curPos_Machine_Lilun.X, newPt.Y - curPos_Machine_Lilun.Y);
            }
            else
                return new PointF();
        }

        /// <summary>
        /// 机器马达坐标 转 玻璃板坐标
        /// </summary>
        /// <param name="machinePos">机器马达坐标</param>
        /// <returns></returns>
        public static PointF MachinePoint2ActPoint(PointF machinePos)
        {
            return machinePos;
            //if (Form_Main.VariableSys.bEnableGlassOffset)
            //{
            //    bool IsOk = false;
            //    machinePos.X = (int)(machinePos.X * 100) / 100.0f;
            //    machinePos.Y = (int)(machinePos.Y * 100) / 100.0f;

            //    PointF temp = galcali.MachinePoint2ActPoint(machinePos, out IsOk);
            //    if (IsOk)
            //    {
            //        temp.X = (float)(temp.X * galcali.Jig_XDist);
            //        temp.Y = (float)(temp.Y * galcali.Jig_YDist);
            //        return temp;
            //    }
            //    else
            //    {
            //        return machinePos;
            //    }
            //}
            //else
            //{
            //    return machinePos;
            //}
        }

        /// <summary>
        /// 玻璃板坐标 转 机器马达坐标
        /// </summary>
        /// <param name="actPos">玻璃板坐标</param>
        /// <returns></returns>
        public static PointF ActPoint2MachinePoint(PointF actPos)
        {
            return actPos;
            //if (Form_Main.VariableSys.bEnableGlassOffset && IsLoaded)
            //{
            //    bool IsOk = false;
            //    actPos.X = (float)(actPos.X / galcali.Jig_XDist); // 获得在那一行那一列
            //    actPos.Y = (float)(actPos.Y / galcali.Jig_YDist);
            //    PointF temp = galcali.ActPoint2MachinePoint(actPos, out IsOk);

            //    if (IsOk)
            //    {
            //        return temp;
            //    }
            //    else
            //    {
            //        return actPos;
            //    }
            //}
            //else
            //{
            //    return actPos;
            //}
        }

        public static void LoadJigData()
        {
            if (Form_Main.VariableSys.bEnableGlassOffset)
            {
                Task.Factory.StartNew(() =>
                {
                    IsLoaded = GlassHelper.galcali.LoadJigData(Variable.sPath_SYS_Jig);
                });
            }
        }
    }
}
