using NationalInstruments.Vision;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GeneralLabelerStation.Form_Main;

namespace GeneralLabelerStation.Tool
{
    public class JY_Config
    {
        public bool bUseRemote
        {
            get;
            set;
        } = false;

        public bool bAlarm
        {
            get;
            set;
        } = false;

        public bool bPaste
        {
            get;
            set;
        } = true;

        public int BadmarkLen
        {
            get;
            set;
        } = 0;
        /// <summary>
        /// 本机IP
        /// </summary>
        public string LocalIp
        {
            get;
            set;
        } = "";

        public int LocalPort
        {
            get;
            set;
        } = 4004;

        /// <summary>
        /// X板机IP
        /// </summary>
        public string RemoteIp
        {
            get;
            set;
        } = "";

        /// <summary>
        /// X板机串口
        /// </summary>
        public int RemotePort
        {
            get;
            set;
        } = 4004;

        /// <summary>
        /// 贴附面 A/B
        /// </summary>
        public SIDE MES_Side = SIDE.A;

        public string ReadCodeBean
        {
            get;
            set;
        } = string.Empty;
    }
}
