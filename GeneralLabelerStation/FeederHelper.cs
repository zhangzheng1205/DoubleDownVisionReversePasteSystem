using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;

namespace GeneralLabelerStation
{
    public class FeederHelper
    {
        #region 单例模式
        private FeederHelper()
        {
            this.FeederInfo = new List<FeederBean>();
            this.FeederInfo.Add(new FeederBean());
            this.FeederInfo.Add(new FeederBean());
        }

        private static FeederHelper instance = new FeederHelper();

        public static FeederHelper Instance
        {
            get
            {
                return instance;
            }
        } 
        #endregion

        public void SaveConfig()
        {
            using (TextWriter tw = new StreamWriter(Variable.sPath_FeederInfoConfig, false))
            {
                XmlSerializer xmlHelper = new XmlSerializer(typeof(List<FeederBean>));
                xmlHelper.Serialize(tw, this.FeederInfo);
            }
        }

        public void LoadConfig()
        {
            if (File.Exists(Variable.sPath_FeederInfoConfig))
            {
                using (TextReader tw = new StreamReader(Variable.sPath_FeederInfoConfig))
                {
                    XmlSerializer xmlHelper = new XmlSerializer(typeof(List<FeederBean>));
                    this.FeederInfo = xmlHelper.Deserialize(tw) as List<FeederBean>;
                }
            }
            else
            {
                this.FeederInfo = new List<FeederBean>();
                this.FeederInfo.Add(new FeederBean());
                this.FeederInfo.Add(new FeederBean());
            }
        }

        public List<FeederBean> FeederInfo
        {
            get;
            set;
        }
    }

    public class FeederBean
    {
        public bool IfAlarm
        {
            get;
            set;
        }
        public int TotalCount
        {
            get;
            set;
        }

        public int RemainCount
        {
            get;
            set;
        }

        public DateTime BeginUserTime
        {
            get;
            set;
        }
    }
}
