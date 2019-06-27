using GeneralLabelerStation.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeneralLabelerStation.Tool
{
    public class NozzleOffsetItem
    {
        /// <summary>
        /// 贴附角度
        /// </summary>
        [Category("角度范围")]
        [DisplayName("贴附角度")]
        public double PasteAngle
        {
            get;
            set;
        } = 0;
        /// <summary>
        /// 公差
        /// </summary>
        [Category("角度范围")]
        [DisplayName("公差")]
        public double Offset
        {
            get;
            set;
        } = 0;

        /// <summary>
        /// 需要补偿的X
        /// </summary>
        [Category("补偿值")]
        [DisplayName("X方向")]
        public double OffsetX
        {
            get;
            set;
        } = 0;

        /// <summary>
        /// 需要补偿的Y
        /// </summary>
        [Category("补偿值")]
        [DisplayName("Y方向")]
        public double OffsetY
        {
            get;
            set;
        } = 0;

        /// <summary>
        /// 从列表中找到对应角度 需要补偿的XY值
        /// </summary>
        /// <param name="angle"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        public static PointF GetOffset(uint zindex,double angle)
        {
            NozzleOffsetItem result = new NozzleOffsetItem();
            try
            {
                foreach (NozzleOffsetItem item in Items[zindex].Items)
                {
                    if (Math.Abs(angle - item.PasteAngle) <= item.Offset)
                    {
                        result = item;
                        break;
                    }
                }
            }
            catch { }

            return new PointF((float)result.OffsetX, (float)result.OffsetY);
        }

        public static void Load()
        {
            SerializableHelper<Dictionary<uint, NozzleOffsetShceme>> helper = new SerializableHelper<Dictionary<uint, NozzleOffsetShceme>>();
            Items = helper.DeJsonSerialize("./Configure/NozzleOffsetItem.json");
        }

        public static void Save()
        {
            SerializableHelper<Dictionary<uint, NozzleOffsetShceme>> helper = new SerializableHelper<Dictionary<uint, NozzleOffsetShceme>>(Items);
            helper.JsonSerialize("./Configure/NozzleOffsetItem.json");
        }

        public static Dictionary<uint, NozzleOffsetShceme> Items = new Dictionary<uint, NozzleOffsetShceme>();

        public static void ShowDataGrid(DataGridView view, uint zIndex)
        {
            view.Rows.Clear();
            for (int i = 0; i < Items[zIndex].Items.Count; ++i)
            {
                view.Rows.Add();
                view.Rows[i].Cells[0].Value = Items[zIndex].Items[i].PasteAngle.ToString("f3");
                view.Rows[i].Cells[1].Value = Items[zIndex].Items[i].Offset.ToString("f3");
                view.Rows[i].Cells[2].Value = Items[zIndex].Items[i].OffsetX.ToString("f3");
                view.Rows[i].Cells[3].Value = Items[zIndex].Items[i].OffsetY.ToString("f3");
            }
        }

        public static void SaveToList(DataGridView view, uint zIndex)
        {
            if (Items == null)
                Items = new Dictionary<uint, NozzleOffsetShceme>();
            if(!Items.ContainsKey(zIndex))
                Items.Add(zIndex, new NozzleOffsetShceme());

            Items[zIndex].Items.Clear();
            for (int i = 0; i < view.Rows.Count; ++i)
            {
                Items[zIndex].Items.Add(new NozzleOffsetItem());
                Items[zIndex].Items[i].PasteAngle = double.Parse(view.Rows[i].Cells[0].Value.ToString());
                Items[zIndex].Items[i].Offset = double.Parse(view.Rows[i].Cells[1].Value.ToString());
                Items[zIndex].Items[i].OffsetX = double.Parse(view.Rows[i].Cells[2].Value.ToString());
                Items[zIndex].Items[i].OffsetY = double.Parse(view.Rows[i].Cells[3].Value.ToString());
            }

            Save();
        }
    }

    public class NozzleOffsetShceme
    {
        [Category("补偿方案")]
        [DisplayName("补偿方案")]
        public List<NozzleOffsetItem> Items
        {
            get;
            set;
        } = new List<NozzleOffsetItem>();
    }
}
