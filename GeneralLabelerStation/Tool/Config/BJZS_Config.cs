using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeneralLabelerStation.Tools;
using System.Drawing;
using System.Xml;
using System.Xml.Serialization;
using NationalInstruments.Vision;

namespace GeneralLabelerStation.Tool
{
    public class BJZS_Config
    {
        public BJZS_Config()
        {
            if(parameters.Count == 0)
            {
                parameters.Add("SZ", new string[] { "TJ02", "TJ02", "TJ02", "TJ01" });
                parameters.Add("XFY", new string[] { "TJ02", "TJ02", "TJ02", "TJ01" });
                parameters.Add("QHD", new string[] { "TJ02", "TJ02", "TJ02", "TJ01" });
                parameters.Add("HA", new string[] { "TJ01", "TJ02", "TJ01", "TJ01" });
            }
        }

        private static Dictionary<string, string[]> parameters = new Dictionary<string, string[]>();

        /// <summary>
        /// 连接超时是否报警
        /// </summary>
        public bool ConnectAlarm
        {
            get;
            set;
        } = true;

        /// <summary>
        /// 读码失败是否报警
        /// </summary>
        public bool DataAlarm
        {
            get;
            set;
        } = true;

        /// <summary>
        /// 背胶管控数量
        /// </summary>
        public int AlarmCount
        {
            get;
            set;
        } = 30;

        /// <summary>
        /// 背胶管控时间
        /// </summary>
        public int AlarmHour
        {
            get;
            set;
        } = 5;

        /// <summary>
        /// 是否启用 背胶数量管控
        /// </summary>
        public bool EnableAlarmCount
        {
            get;
            set;
        } = false;

        /// <summary>
        /// 是否启用 背胶时间管控
        /// </summary>
        public bool EnableAlarmHour
        {
            get;
            set;
        } = false;

        /// <summary>
        /// 左Feeder 编号
        /// </summary>
        public string[] FeederID
        {
            get;
            set;
        } = new string[2];
        /// <summary>
        /// Feeder1背料料号
        /// </summary>
        public string[] FeederNo
        {
            get;
            set;
        } = new string[2];
        /// <summary>
        /// Feeder1贴胶工序
        /// </summary>
        public string[] FeederOrder
        {
            get;
            set;
        } = new string[2];

        /// <summary>
        /// 读码配置
        /// </summary>
        public string ReadCodeBean
        {
            get;
            set;
        } = string.Empty;
    }
}
