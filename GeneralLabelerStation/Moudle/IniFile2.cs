using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace GeneralLabelerStation
{
    public class IniFile
    {
        public string Path;

        public IniFile(string path)
        {
            this.Path = path;
        }
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string
            section,
            string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section,
            string key, string def, StringBuilder retVal,
            int size, string filePath);

        /// 写INI文件
        public void IniWriteValue(string section, string key, string iValue)
        {
            WritePrivateProfileString(section, key, iValue, this.Path);
        }

        /// 读取INI文件
        public string IniReadValue(string section, string key)
        {
            StringBuilder temp = new StringBuilder(255);

            int i = GetPrivateProfileString(section, key, "", temp, 255, this.Path);
            return temp.ToString();
        }

        public void IniWriteNumber(string section, string key, int nValue)
        {
            string strtowrt;
            strtowrt = nValue.ToString();
            WritePrivateProfileString(section, key, strtowrt, this.Path);
        }
        public void IniWriteNumber(string section, string key, double dValue)
        {
            string strtowrt;
            strtowrt = dValue.ToString();
            WritePrivateProfileString(section, key, strtowrt, this.Path);
        }

        public double IniReadNum(string section, string key)
        {
            StringBuilder temp = new StringBuilder(255);
            string strres;
            int i = GetPrivateProfileString(section, key, "", temp, 255, this.Path);
            strres = temp.ToString();
            if (strres == "")
            {
                strres = "0";
            }
            return Convert.ToDouble(strres);
        }

    }
}
