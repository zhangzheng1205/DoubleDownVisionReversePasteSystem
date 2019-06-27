using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralLabelerStation.ZDT
{
    /// <summary>
    /// 背胶追溯的配置
    /// </summary>
    public class BJZSConfig:Common.SingletionProvider<BJZSConfig>
    {
        /// <summary>
        /// Webservice 地址
        /// </summary>
        public string WebServiceAddress
        {
            get;
            set;
        } = "http://szecpw013.eavarytech.com:8001/webserviceforsz/service1.asmx";

        /// <summary>
        /// 机器编号
        /// </summary>
        public string MachineID
        {
            get;
            set;
        } = "Hostar";

        /// <summary>
        /// 线体
        /// </summary>
        public string LineID
        {
            get;
            set;
        } = "1";

        /// <summary>
        /// 地区
        /// </summary>
        public string Area
        {
            get;
            set;
        } = "SZ";

        /// <summary>
        /// 厂区
        /// </summary>
        public string FactoryID
        {
            get;
            set;
        } = "01";

        /// <summary>
        /// 工龄
        /// </summary>
        public string EmployeeName
        {
            get;
            set;
        } = string.Empty;

        /// <summary>
        /// 工号
        /// </summary>
        public string EmployeeID
        {
            get;
            set;
        } = string.Empty;

        /// <summary>
        /// 左FeederID
        /// </summary>
        public string LeftFeederID
        {
            get;
            set;
        } = "左Feeder";

        /// <summary>
        /// 右FeederID
        /// </summary>
        public string RightFeederID
        {
            get;
            set;
        } = "右Feeder";

        /// <summary>
        /// 超时时间
        /// </summary>
        public double TimeOut
        {
            get;
            set;
        } = 1000;

        /// <summary>
        /// 背胶报警个数
        /// </summary>
        public int AlarmCount
        {
            get;
            set;
        } = 100;

        /// <summary>
        /// 报警时长
        /// </summary>
        public double AlarmTime
        {
            get;
            set;
        } = 2000;

        /// <summary>
        /// 是否启用生产上传
        /// </summary>
        public bool EnableProductUpload
        {
            get;
            set;
        } = false;
    }
}
