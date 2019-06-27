using GeneralLabelerStation.Param;
using NationalInstruments.Vision;
using NationalInstruments.Vision.Analysis;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GeneralLabelerStation.Tool
{

    /// <summary>
    /// 下视觉计算者
    /// </summary>
    public class UpVisionCaler
    {
        public UpVisionCaler()
        {
        }

        /// <summary>
        /// 开始循环
        /// </summary>
        public void StartLoop()
        {
            if(this.Exit)
            {
                this.ResetQueue();
                Exit = false;
                var thd = new Thread(CalLoop);
                thd.Start();
                //Task.Factory.StartNew(CalLoop);
            }
        }

        /// <summary>
        /// 停止循环
        /// </summary>
        public void ExitLoop()
        {
            this.Exit = true;
            this.ResetQueue();
        }

        /// <summary>
        /// 需要计算的队列
        /// </summary>
        private ConcurrentQueue<ResultItem> calQueue = new ConcurrentQueue<ResultItem>();

        private class ResultItem
        {
            public ResultItem(int pasteIndex, VisionImage image)
            {
                this.PasteIndex = pasteIndex;
                this.Image = image;
            }


            /// <summary>
            /// 属于吸嘴得哪个拍照点
            /// </summary>
            public int PasteIndex = 0;

            /// <summary>
            /// 图片
            /// </summary>
            public VisionImage Image = null;
        }

        /// <summary>
        /// 下视觉计算
        /// </summary>
        /// <param name="nz">吸嘴号</param>
        /// <param name="camIndex">吸嘴中的拍照点</param>
        /// <param name="image">图片</param>
        public void Cal(int pasteIndex, VisionImage image)
        {
            this.calQueue.Enqueue(new ResultItem(pasteIndex, image));
        }

        /// <summary>
        /// 线程停止
        /// </summary>
        public bool Exit = true;

        /// <summary>
        /// 重置队列
        /// </summary>
        public void ResetQueue()
        {
            ResultItem item = null;

            while (!this.calQueue.IsEmpty)
            {
                this.calQueue.TryDequeue(out item);
                item = null;
            }
        }

        private void CalLoop()
        {
            while (!Exit)
            {
                Thread.Sleep(5);
                if (!this.calQueue.IsEmpty)
                {
                    ResultItem item = null;
                    if(this.calQueue.TryDequeue(out item))
                    {
                        try
                        {
                            // 如果已有该吸嘴得计算结果顶替掉
                            int runPasteIndex = Form_Main.Instance.GetRUNPasteIndex(Form_Main.Instance.JOB.PasteName[item.PasteIndex]);
                            Form_Main.Instance.JOB.UpCCDResult1[item.PasteIndex] = Form_Main.Instance.Auto_Detect1(ref Form_Main.Instance.RUN_PASTEInfo[runPasteIndex],
                                item.Image, 0);

                            Form_Main.Instance.UpCCDResult[0] = Form_Main.Instance.JOB.UpCCDResult1[item.PasteIndex];
                            Form_Main.Instance.ImageCapture_Up1 = item.Image;
                            Form_Main.Instance.JOB.PASTEInfo[item.PasteIndex].bMark1ED = true;

                            if (Form_Main.Instance.JOB.UpCCDResult1[item.PasteIndex].IsOK)
                            {
                                Form_Main.Instance.JOB.iUpCCDResult[item.PasteIndex] = 1;
                            }
                            else
                            {
                                Form_Main.Instance.JOB.iUpCCDResult[item.PasteIndex] = 2;
                                for(int i =0; i < Form_Main.Instance.JOB.PASTEInfo[item.PasteIndex].iPasteED.Length; ++i)
                                {
                                    Form_Main.Instance.JOB.PASTEInfo[item.PasteIndex].iPasteED[i] = 1;
                                }
                            }

                            Form_Main.Instance.ShowVisionStatus(0, Form_Main.Instance.JOB.UpCCDResult1[item.PasteIndex].IsOK, item.Image,
                                Form_Main.Instance.JOB.UpCCDResult1[item.PasteIndex].IsOK);
                        }
                        catch(Exception ex)
                        {
                            Debug.WriteLine(ex.Message);
                        }
                    }
                }
            }
        }
    }
}
