using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeneralLabelerStation.Camera
{
    /// <summary>
    /// 相机列表
    /// </summary>
    public enum CAM
    {
        Top = 0,
        Bottom1 = 1,
        Bottom2 = 2,
        Label = 3,
    }

    public class CameraDefine:Common.SingletionProvider<CameraDefine>
    {
        /// <summary>
        /// 相机配置
        /// </summary>
        public Dictionary<CAM, CameraConfig> Config = new Dictionary<CAM, CameraConfig>();

        [JsonIgnore]
        public Dictionary<CAM, CameraEntiy> Entiys = new Dictionary<CAM, CameraEntiy>();

        /// <summary>
        /// 相机实例
        /// </summary>
        /// <param name="camera">相机描述符</param>
        /// <returns></returns>
        [JsonIgnore]
        public CameraEntiy this[CAM camera]
        {
            get
            {
                return this.Entiys[camera];
            }
        }

        /// <summary>
        /// 相机连接
        /// </summary>
        /// <returns></returns>
        public bool Connect(bool initLabel)
        {  
            if (this.Config.Count == 0)
            {
                foreach (CAM cam in Enum.GetValues(typeof(CAM)))
                {
                    if(CAM.Label != cam || (CAM.Label == cam && initLabel))
                        this.Config.Add(cam, new CameraConfig());
                }

                CameraDefine.Save();
                MessageBox.Show("没有找到相机配置文件!\r\n已自动生成文件，请配置好后启动!!!");
                return false;
            }
            else
            {
                foreach(CAM cam in Enum.GetValues(typeof(CAM)))
                {
                    if (CAM.Label != cam || (CAM.Label == cam && initLabel))
                    {
                        this.Entiys.Add(cam, new CameraEntiy(this.Config[cam]));
                        string rtn = this.Entiys[cam].InitCamera();
                        this.Entiys[cam].LoadCalibImage(cam);
                        if (!string.IsNullOrEmpty(rtn))
                        {
                            MessageBox.Show($"相机{cam.ToString()} 初始化失败 原因:{rtn}!!");
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// 断开所有相机的连接
        /// </summary>
        public void DisConnect()
        {
            foreach (CAM cam in Enum.GetValues(typeof(CAM)))
            {
                if (this.Config.ContainsKey(cam))
                {
                    this.Entiys[cam]._Session.Acquisition.Unconfigure();
                    this.Entiys[cam]._Session.Dispose();
                }
            }
        }

        public static void Load()
        {
            Common.SerializableHelper<CameraDefine> helper = new Common.SerializableHelper<CameraDefine>();
            var temp = helper.DeJsonSerialize(Variable.sPath_Configure + "Camera.config");
            if(temp != null)
            {
                CameraDefine.Instance = temp;
            }
        }

        public static void Save()
        {
            Common.SerializableHelper<CameraDefine> helper = new Common.SerializableHelper<CameraDefine>(CameraDefine.Instance);
            helper.JsonSerialize(Variable.sPath_Configure + "Camera.config");
        }
    }
}
