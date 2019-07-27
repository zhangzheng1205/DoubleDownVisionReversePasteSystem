using GeneralLabelerStation.Common;
using GeneralLabelerStation.Param;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeneralLabelerStation.IO
{
    /// <summary>
    /// IO 管理者
    /// </summary>
    public class IOManager: Singleton<IOManager>
    {
        public ConcurrentDictionary<ushort, Axis_RunParam> Card = new ConcurrentDictionary<ushort, Axis_RunParam>();

        public  IOManager()
        {
        }
        
        /// <summary>
        /// 释放所有IO点
        /// </summary>
        public void ResetAllOut()
        {
            foreach(var card in Card.Values)
            {
                card.ResetAllIO_Out();
                Thread.Sleep(100);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void ResetAllAxis()
        {
            foreach (var card in Card.Values)
            {
                card.StopAxis();
                Thread.Sleep(100);
                card.CleSts(true);
            }
        }

        /// <summary>
        /// 刷新IO
        /// </summary>
        public void updateIO()
        {
            while (!Form_Main.Instance.bSystemExit)
            {
                Thread.Sleep(5);

                for (ushort i = 0; i < Card.Count; ++i)
                {
                    Card[i].GetIO_IN();
                    Card[i].GetIO_Out();

                    if(Form_Main.Instance.RunMode != 1)
                    {
                        Card[i].GetAxisPos();
                        Card[i].GetAxisSts();
                    }
                }

                Form_Main.Instance.bArr_IO_IN_Status.bIN_AfterRequest = Card[5].bArrIO_In[0];// R2.bArrIO_In[0];
                Form_Main.Instance.bArr_IO_IN_Status.bIN_Conveyor_BeforeReady = Card[5].bArrIO_In[1];// R2.bArrIO_In[1];
                Form_Main.Instance.bArr_IO_IN_Status.bIN_WorkSpace_IN =  Card[5].bArrIO_In[2]; //R2.bArrIO_In[2];
                Form_Main.Instance.bArr_IO_IN_Status.bIN_WorkSpace_Out = Card[5].bArrIO_In[3]; //R2.bArrIO_In[3];
                Form_Main.Instance.bArr_IO_IN_Status.bIN_WorkSpace_Reach = Card[1].bArrIO_In[2];
                Form_Main.Instance.bArr_IO_IN_Status.bIN_WorkSpace_Reach = Card[1].bArrIO_In[2];

                Form_Main.Instance.bArr_IO_IN_Status.bIN_LabelReach_Left[0] = Card[1].bArrIO_In[0] == true ? 1 : 0;
                Form_Main.Instance.bArr_IO_IN_Status.bIN_LabelReach_Left[1] = Card[6].bArrIO_In[0] == true ? 1 : 0;
                Form_Main.Instance.bArr_IO_IN_Status.bIN_LabelReach_Left[2] = Card[6].bArrIO_In[2] == true ? 1 : 0;
                Form_Main.Instance.bArr_IO_IN_Status.bIN_LabelReach_Left[3] = Card[6].bArrIO_In[3] == true ? 1 : 0;

                Form_Main.Instance.bArr_IO_IN_Status.bIN_LabelReach_Right[0] = Card[2].bArrIO_In[0] == true ? 1 : 0;
                Form_Main.Instance.bArr_IO_IN_Status.bIN_LabelReach_Right[1] = Card[7].bArrIO_In[0] == true ? 1 : 0;
                Form_Main.Instance.bArr_IO_IN_Status.bIN_LabelReach_Right[2] = Card[7].bArrIO_In[2] == true ? 1 : 0;
                Form_Main.Instance.bArr_IO_IN_Status.bIN_LabelReach_Right[3] = Card[7].bArrIO_In[3] == true ? 1 : 0;

                Form_Main.Instance.bArr_IO_IN_Status.bIN_LabelReach_Left[4] = Form_Main.Instance.bArr_IO_IN_Status.bIN_LabelReach_Right[0];
                Form_Main.Instance.bArr_IO_IN_Status.bIN_LabelReach_Left[5] = Form_Main.Instance.bArr_IO_IN_Status.bIN_LabelReach_Right[1];
                Form_Main.Instance.bArr_IO_IN_Status.bIN_LabelReach_Left[6] = Form_Main.Instance.bArr_IO_IN_Status.bIN_LabelReach_Right[2];
                Form_Main.Instance.bArr_IO_IN_Status.bIN_LabelReach_Left[7] = Form_Main.Instance.bArr_IO_IN_Status.bIN_LabelReach_Right[3];

                Form_Main.Instance.bArr_IO_IN_Status.bIN_LabelReach_Right[4] = Form_Main.Instance.bArr_IO_IN_Status.bIN_LabelReach_Left[0];
                Form_Main.Instance.bArr_IO_IN_Status.bIN_LabelReach_Right[5] = Form_Main.Instance.bArr_IO_IN_Status.bIN_LabelReach_Left[1];
                Form_Main.Instance.bArr_IO_IN_Status.bIN_LabelReach_Right[6] = Form_Main.Instance.bArr_IO_IN_Status.bIN_LabelReach_Left[2];
                Form_Main.Instance.bArr_IO_IN_Status.bIN_LabelReach_Right[7] = Form_Main.Instance.bArr_IO_IN_Status.bIN_LabelReach_Left[3];

                //if (Form_Main.Instance.FlowIndex > 10000 && Form_Main.Instance.FlowIndex < 10100)
                //{
                //    if (!Form_Main.Instance.Feeder[0].NeedWaitReach)
                //        Form_Main.Instance.Feeder[0].NeedWaitReach = Form_Main.Instance.bArr_IO_IN_Status.bIN_LabelReach_Left.Sum() == 0;

                //    if (!Form_Main.Instance.Feeder[1].NeedWaitReach)
                //        Form_Main.Instance.Feeder[1].NeedWaitReach = Form_Main.Instance.bArr_IO_IN_Status.bIN_LabelReach_Right.Sum() == 0;
                //}
            }
        }

        /// <summary>
        /// 设置 输出点
        /// </summary>
        /// <param name="axisNo">轴号</param>
        /// <param name="output">输出点</param>
        public short SetIO(ushort axisNo, ushort output)
        {
            return Card[axisNo].SetIO_OUT(output);
        }

        /// <summary>
        /// 设置 输出点
        /// </summary>
        /// <param name="axisNo">轴号</param>
        /// <param name="output">输出点</param>
        public short ResetIO(ushort axisNo, ushort output)
        {
            return Card[axisNo].ResetIO_OUT(output);
        }

        /// <summary>
        /// 获得 输入点状态
        /// </summary>
        /// <param name="axisNo">轴号0-7 8-15</param>
        /// <param name="input">输入点0-3</param>
        /// <returns></returns>
        public bool GetInput(ushort axisNo, ushort input)
        {
            return Card[axisNo].bArrIO_In[input];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="axisNo">轴号0-7 8-15</param>
        /// <param name="output">输出点4-7</param>
        /// <returns></returns>
        public bool GetOutput(ushort axisNo, ushort output)
        {
            output -= 4;
            return Card[axisNo].bArrIO_Out[output];
        }

        /// <summary>
        /// UI 刷新
        /// </summary>
        public event EventHandler UIRefresh;
    }
}
