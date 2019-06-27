using GeneralLabelerStation.Camera;
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
    public class DownVisionCaler
    {
        public DownVisionCaler()
        {
        }

        /// <summary>
        /// 开始循环
        /// </summary>
        public void StartLoop()
        {
            if (this.Exit)
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
            public ResultItem(uint nz)
            {
                this.Nozzle = nz;
            }

            /// <summary>
            /// 属于哪个吸嘴
            /// </summary>
            public uint Nozzle = 0;

            /// <summary>
            /// 结果
            /// </summary>
            public Variable.CamReturn Result = new Variable.CamReturn();
        }

        /// <summary>
        /// 下视觉计算
        /// </summary>
        /// <param name="nz">吸嘴号</param>
        /// <param name="camIndex">吸嘴中的拍照点</param>
        /// <param name="image">图片</param>
        public void Cal(uint nz)
        {
            this.calQueue.Enqueue(new ResultItem(nz));
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
                if (!this.calQueue.IsEmpty)
                {
                    ResultItem item = null;
                    try
                    {
                        #region 计算
                        if (this.calQueue.TryDequeue(out item))
                        {
                            Stopwatch watch = new Stopwatch();
                            watch.Restart();

                            // 如果已有该吸嘴得计算结果顶替掉
                            Z_RunParam zParam = Form_Main.Instance.Z_RunParamMap[item.Nozzle];

                            CAM camera = Form_Main.Nozzle2Cam((int)item.Nozzle);

                            // 算法
                            zParam.CamResult = Form_Main.Instance.Auto_Detect1(ref Form_Main.Instance.Feeder[zParam.RUN_Nozzle_FeederIndex - 1].Label, zParam.CaptureImage, camera, (int)item.Nozzle);

                            Form_Main.Instance.CalNozzle(item.Nozzle, camera);
                            zParam.CalFinished = true;

                            Form_Main.Instance.ShowVisionStatus((int)(item.Nozzle + 1), zParam.CamResult, zParam.CaptureImage);

                            Debug.WriteLine($"下视觉计算时间:{watch.ElapsedMilliseconds} ms");
                        }
                        #endregion
                    }
                    catch (Exception ex)
                    {
                        if (item != null)
                        {
                            // 如果已有该吸嘴得计算结果顶替掉
                            Z_RunParam zParam = Form_Main.Instance.Z_RunParamMap[item.Nozzle];
                            zParam.CalFinished = true;
                            zParam.RUN_dNozzleDownVisionED = 4;
                            Form_Main.Instance.PutInLog("D://下视觉//", "Log", $"下视觉计算错误 {ex.Message} \n 错误所在:{ex.StackTrace} 吸嘴{item.Nozzle + 1},贴附信息{zParam.RUN_PasteInfoIndex},{zParam.RUN_PastePointIndex}");//
                        }
                    }
                }
                else
                    Thread.Sleep(1);
            }
        }
    }
}
