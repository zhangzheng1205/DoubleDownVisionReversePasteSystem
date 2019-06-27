using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GeneralLabelerStation.Tool
{

    public class FeederBean
    {
        [JsonIgnore]
        public bool IfAlarm
        {
            get;
            set;
        } = false;
        public int TotalCount
        {
            get;
            set;
        } = 0;

        public int RemainCount
        {
            get;
            set;
        } = 0;

        public DateTime BeginUserTime
        {
            get;
            set;
        } = DateTime.Now;
    }

    public class FeederHelper:Common.SingletionProvider<FeederHelper>
    {
        public Dictionary<string, string[]> MaterialList = new Dictionary<string, string[]>();

        public List<FeederBean> FeederInfo = new List<FeederBean>();

        public static void Load()
        {
            Common.SerializableHelper<FeederHelper> helper = new Common.SerializableHelper<FeederHelper>();
            FeederHelper.Instance = helper.DeJsonSerialize(Variable.sPath_Configure + "Feeder.json");

            if (FeederHelper.Instance == null)
            {
                FeederHelper.Instance = new FeederHelper();
                FeederHelper.Instance.FeederInfo.Add(new FeederBean());
                FeederHelper.Instance.FeederInfo.Add(new FeederBean());
            }
        }

        public static void Save()
        {
            Common.SerializableHelper<FeederHelper> helper = new Common.SerializableHelper<FeederHelper>(FeederHelper.Instance);
            helper.JsonSerialize(Variable.sPath_Configure + "Feeder.json");
        }


        /// <summary>
        /// 获得两个 Feeder 的贴附信息
        /// </summary>
        /// <returns></returns>
        public List<string> GetFeederPasteInfo()
        {
            List<string> feederPasteInfo = new List<string>();
            string left = string.Empty;
            string right = string.Empty;
            for(int k = 0; k < Form_Main.Instance.JOB.PASTEInfo.Length; ++k)
            {
                for(int i = 0; i < Form_Main.Instance.JOB.PASTEInfo[k].iPasteED.Length; ++i)
                {
                    if (Form_Main.Instance.JOB.PASTEInfo[k].iPasteED != null
                        && Form_Main.Instance.JOB.PASTEInfo[k].iPasteED[i] == 1)
                    {
                        if(Form_Main.Instance.RUN_PASTEInfo[k].FeederIndex[i] == 1)
                            left += $"{i+1},";
                        else
                            right += $"{i+1},";
                    }
                }
            }

            if (!string.IsNullOrEmpty(left))
            {
                left = left.Remove(left.Length - 1, 1);
            }
            else
                left = "NULL";

            if (!string.IsNullOrEmpty(right))
            {
                right = right.Remove(right.Length - 1, 1);
            }
            else
                right = "NULL";

            feederPasteInfo.Add(left);
            feederPasteInfo.Add(right);
            return feederPasteInfo;
        }

        private string GetString(string[] feederData)
        {
            string result = string.Empty;
            for (int i = 0; i < feederData.Count(); ++i)
            {

                result += feederData[i] + "|";
            }

            result = result.Remove(result.Length - 1, 1);

            return result;
        }

        public string UploadMesInfo()
        {
            string result = string.Empty;
            try
            {
                List<string> feederInfo = this.GetFeederPasteInfo();

                for (int i = 0; i < 2;++i)
                {
                    string[] feederData = ZDTHelper.Instance.GetMesData();
                    feederData[6] = string.IsNullOrEmpty(ZDTHelper.Instance.FpcNo) ? "NULL" :  ZDTHelper.Instance.FpcNo;
                    feederData[7] = Form_Main.Instance.RUN_BadmarkCode;
                    feederData[8] = ZDTHelper.Instance.BJZS_Config.FeederNo[i];
                    if (this.MaterialList.ContainsKey(ZDTHelper.Instance.BJZS_Config.FeederID[i]))
                    {
                        feederData[9] = this.MaterialList[ZDTHelper.Instance.BJZS_Config.FeederID[i]][1];
                    }

                    feederData[10] = ZDTHelper.Instance.BJZS_Config.FeederID[i];
                    feederData[11] = Form_Main.Instance.RUN_TrayCode;
                    feederData[12] = ZDTHelper.Instance.BJZS_Config.FeederOrder[i];
                    feederData[13] = feederInfo[i];

                    result = ZDTHelper.Instance.UploadData(this.GetString(feederData));
                    if(result != string.Empty)
                    {
                        Form_Main.Instance.PutInLog(Variable.sPath_ZDTMESLog, "背胶管控", "数据拼装不正确，无法进行上传！");
                    }
                    Thread.Sleep(500);
                }
            }
            catch(Exception ex)
            {
                Form_Main.Instance.PutInLog(Variable.sPath_ZDTMESLog, "背胶管控", ex.Message);
            }
            return result;
        }
    }
}
