using NationalInstruments.Vision;
using NationalInstruments.Vision.Acquisition.Imaqdx;
using NationalInstruments.Vision.Analysis;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GeneralLabelerStation.Tool
{
    public class FlyTool
    {
        public FlyTool(ImaqdxSession _session)
        {
            this._session = _session;
        }

        public List<VisionImage> GrabList = new List<VisionImage>();
        public ImaqdxSession _session = null;

        public void ClearImage()
        {
            foreach (var image in GrabList)
            {
                image?.Dispose();
            }

            GrabList.Clear();
        }

        /// <summary>
        /// 开始飞拍
        /// </summary>
        public void StartFly()
        {
            bFly = true;
            try
            {
                // 设置外触发
                _session.Acquisition.Unconfigure();
                _session.Attributes["CameraAttributes::AcquisitionControl::TriggerMode"].SetValue(1);
                _session.Attributes["CameraAttributes::AcquisitionControl::TriggerSource"].SetValue(1);
                _session.ConfigureGrab();
                Thread thd = new Thread(GrabThread);
                thd.Start();
            }
            catch { }
        }

        /// <summary>
        /// 停止飞拍
        /// </summary>
        public void StopFly()
        {
            _session.Acquisition.Unconfigure();
            _session.Attributes["CameraAttributes::AcquisitionControl::TriggerMode"].SetValue(0);
            _session.Attributes["CameraAttributes::AcquisitionControl::TriggerSource"].SetValue(0);
            bFly = false;
        }

        /// <summary>
        /// 暂停拍照
        /// </summary>
        /// <param name="pause"></param>
        public void PauseFly(bool pause)
        {
            bPause = pause;
        }

        private bool bFly = false;
        private bool bPause = false;
        public void GrabThread()
        {
            while(bFly)
            {
                if(bPause)
                {
                    Thread.Sleep(1);
                    continue;
                }

                try
                {
                    VisionImage image = new VisionImage();
                    _session.Grab(Form_Main.Instance.imageSet.Image, true);
                    Algorithms.Copy(Form_Main.Instance.imageSet.Image, image);
                    this.GrabList.Add(image);
                    //Form_Main.Instance.X.GetAxisPos();
                    //Debug.WriteLine($"X:{Form_Main.Instance.X.Pos}\r\n");
                }
                catch { }
            }
        }
    }
}
