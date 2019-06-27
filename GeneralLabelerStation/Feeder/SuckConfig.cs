using GeneralLabelerStation.Common;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralLabelerStation
{
    /// <summary>
    /// 吸料配置
    /// </summary>
    public class SuckConfig
    {
        /// <summary>
        /// 各个吸嘴的吸标标准位置
        /// </summary>
        public PointF SuckPos = new PointF();

        /// <summary>
        /// 每个吸嘴吸标的自动补偿值
        /// </summary>
        public Dictionary<int,PointF[]> XI_Offset = new Dictionary<int,PointF[]>();

        public static SuckConfig Load(string path)
        {
            SerializableHelper<SuckConfig> helper = new SerializableHelper<SuckConfig>();
            return helper.DeJsonSerialize(path);
        }

        public static void Save(string path, SuckConfig config)
        {
            SerializableHelper<SuckConfig> helper = new SerializableHelper<SuckConfig>(config);
            helper.JsonSerialize(path);
        }
    }
}
