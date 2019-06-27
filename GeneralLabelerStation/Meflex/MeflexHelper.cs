using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MFlexEquipmentProject;
using Model;

namespace GeneralLabelerStation.Meflex
{
    public class MeflexHelper
    {
        public string LineNo
        {
            get;
            set;
        } = "SMT-MIC-001";

        public string MachineName
        {
            get;
            set;
        } = "SMT-MIC-001";

        /// <summary>
        /// 区域
        /// </summary>
        public string WorkArea
        {
            get; set;
        } = "PSAA/PSAB";

        public string OperName
        {
            get;
            set;
        } = "3300780";

        /// <summary>
        /// 厂区类型
        /// </summary>
        public string Site
        {
            get;
            set;
        } = "SMT";

        /// <summary>
        /// 程式名
        /// </summary>
        public string ProgramName
        {
            get;
            set;
        } = string.Empty;

        /// <summary>
        /// 设备物理地址
        /// </summary>
        public string Mac
        {
            get;
            set;
        } = string.Empty;


        public string CheckBaseInfo(string code,out int[] badmarkNo)
        {
            badmarkNo = null;
            MainInfo mainInfo = new MainInfo();
            mainInfo.Panel = code;
            mainInfo.Resource = this.LineNo;
            mainInfo.Machine = this.MachineName;
            mainInfo.WorkArea = this.WorkArea;
            mainInfo.TestType = "TEST";
            mainInfo.OperatorName = this.OperName;
            mainInfo.OperatorType = "Panel";
            mainInfo.TrackType = "S";
            mainInfo.Site = this.Site;
            mainInfo.Mac = this.Mac;

            string[] result = EquipmentInterActive.CheckBaseInfo(mainInfo);
            if(result.Length > 0)
            {
                if(result[0] == "0")
                {
                    for(int i= 1; i< result.Length;++i)
                    {

                    }
                }
                return result[0];
            }
            else
            {
                return "获取信息失败,请检查网络连接是否正常!!!";
            }
        }
    }
}
