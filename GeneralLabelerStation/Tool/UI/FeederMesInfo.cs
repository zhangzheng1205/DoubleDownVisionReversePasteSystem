using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GeneralLabelerStation.Tool
{
    public partial class FeederMesInfo : UserControl
    {
        public FeederMesInfo()
        {
            InitializeComponent();
        }

        public void RefreshData()
        {
            DataTable dt = ZDTHelper.Instance.GetFeederInfo();
            dataGridView.Rows.Clear();
            if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    FeederBean bean = new FeederBean();

                    for(int i = 0; i<2;++i)
                    {
                        if (ZDTHelper.Instance.BJZS_Config.FeederID[i] == item[1].ToString())
                        {
                            FeederHelper.Instance.FeederInfo[i].TotalCount = int.Parse(item[3].ToString());
                            bean = FeederHelper.Instance.FeederInfo[i];
                            ZDTHelper.Instance.BJZS_Config.FeederNo[i] = item[2].ToString();
                        }
                    }
                    
                    string lineID = ZDTHelper.Instance.LineID;

                    TimeSpan span = bean.BeginUserTime.AddHours(ZDTHelper.Instance.BJZS_Config.AlarmHour) - DateTime.Now;
                    string time = string.Format("{0:D2}:{1:D2}:{2:D2}", span.Hours, span.Minutes, span.Seconds);
                    dataGridView.Rows.Add(lineID, item[0], item[1], item[3], bean.RemainCount, time);
                    Form_Main.Instance.PutInLog(Variable.sPath_ZDTMESLog, "背胶管控", string.Format("GetData:{0},{1},{2}", item[0], item[1], item[3]));

                    if (FeederHelper.Instance.MaterialList.ContainsKey(item[1].ToString()))
                    {
                        FeederHelper.Instance.MaterialList[item[1].ToString()] = new string[] { ZDTHelper.Instance.LineID, item[0].ToString(), item[1].ToString(), item[2].ToString(), item[3].ToString() };
                    }
                    else
                    {
                        FeederHelper.Instance.MaterialList.Add(item[1].ToString(), new string[] { ZDTHelper.Instance.LineID, item[0].ToString(), item[1].ToString(), item[2].ToString(), item[3].ToString() });
                    }

                    FeederHelper.Save();
                }
            }
            else
            {
                FeederHelper.Instance.MaterialList.Clear();
                Form_Main.Instance.PutInLog(Variable.sPath_ZDTMESLog, "背胶管控", "GetData error");
            }
        }

        private void FeederRefresh_Click(object sender, EventArgs e)
        {
           this. RefreshData();
           FeederHelper.Instance.FeederInfo[0].BeginUserTime = DateTime.Now;
           FeederHelper.Instance.FeederInfo[0].RemainCount = FeederHelper.Instance.FeederInfo[0].TotalCount;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.RefreshData();
            FeederHelper.Instance.FeederInfo[1].BeginUserTime = DateTime.Now;
            FeederHelper.Instance.FeederInfo[1].RemainCount = FeederHelper.Instance.FeederInfo[1].TotalCount;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.RefreshData();
            this.RefreshUIData();
            //FeederHelper.Instance.UploadMesInfo();
        }

        public void RefreshUIData()
        {
            if (dataGridView.Rows != null)
            {
                for (int i = 0; i < dataGridView.Rows.Count; i++)
                {
                    dataGridView.Rows[i].Cells[4].Value = FeederHelper.Instance.FeederInfo[i].RemainCount;
                    TimeSpan timeSpan = FeederHelper.Instance.FeederInfo[i].BeginUserTime.AddHours(ZDTHelper.Instance.BJZS_Config.AlarmHour) - DateTime.Now;
                    dataGridView.Rows[i].Cells[5].Value = $"{timeSpan.Hours:D2},{timeSpan.Minutes:D2},{timeSpan.Seconds:D2}";
                }
            }
        }

        private void FeederMesInfo_Load(object sender, EventArgs e)
        {
        }
    }
}
