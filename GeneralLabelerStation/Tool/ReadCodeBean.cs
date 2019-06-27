using NationalInstruments.Vision;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralLabelerStation.Tool
{
    public class ReadCodeBean
    {
        public string BeanName
        {
            get;
            set;
        } = string.Empty;

        public PointF BarcodePos
        {
            get;
            set;
        } = new PointF();

        public double Shutter
        {
            get;
            set;
        } = 100;

        public string Light
        {
            get;
            set;
        } = "1,1,1,80,80,80";

        public CodeType CodeType
        {
            get;
            set;
        } = CodeType.Code_2D_Mat;

        public double Gain
        {
            get;
            set;
        } = 1;

        public double Offset
        {
            get;
            set;
        } = 0;

        public double Cycle
        {
            get;
            set;
        } = 1;

        public RectangleContour ROI
        {
            get;
            set;
        }

        public string BarcodeFormate
        {
            get;
            set;
        }

        public bool BarcodeFormateEN
        {
            get;
            set;
        }

        public static ReadCodeBean Load(string name)
        {
            Common.SerializableHelper<ReadCodeBean> helper = new Common.SerializableHelper<ReadCodeBean>();
            return helper.DeJsonSerialize(Variable.sPath_ReadCodeBean+ name + ".json");
        }

        public static void Save(ReadCodeBean bean)
        {
            Common.SerializableHelper<ReadCodeBean> helper = new Common.SerializableHelper<ReadCodeBean>(bean);
            helper.JsonSerialize(Variable.sPath_ReadCodeBean + bean.BeanName + ".json");
        }

        public static List<string> GetList()
        {
            List<string> list = new List<string>();
            string fullPath = Variable.sPath_ReadCodeBean;
            var files = Directory.GetFiles(fullPath, "*.json");
            foreach(string file in files)
            {
                list.Add(file.Replace(".json", "").Replace(Variable.sPath_ReadCodeBean, ""));
            }

            return list;
        }
        /// <summary>
        /// 打光
        /// </summary>
        public void OpenLight()
        {
            try
            {
                var arr = this.Light.Split(',');
                if (arr.Length == 6)
                {
                    bool a1 = arr[0] == "1";
                    bool a2 = arr[1] == "1";
                    bool a3 = arr[2] == "1";
                    double a4 = double.Parse(arr[3]);
                    double a5 = double.Parse(arr[4]);
                    double a6 = double.Parse(arr[5]);
                    Form_Main.Instance.LightON_Up(a1, a2, a3, a4, a5, a6);
                }
            }
            catch { }
        }

        /// <summary>
        /// 比较格式
        /// </summary>
        /// <param name="barcode"></param>
        /// <returns></returns>
        public bool CompareBarcode(string barcode)
        {
            if (barcode == string.Empty)
                return false;

            if (!this.BarcodeFormateEN)
            {
                return true;
            }
            if (barcode.Length != this.BarcodeFormate.Length)
            {
                return false;
            }
            for (int i = 0; i < barcode.Length; i++)
            {
                if (this.BarcodeFormate.Substring(i, 1) != "*")
                {
                    if (this.BarcodeFormate.Substring(i, 1) != barcode.Substring(i, 1))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
