using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using GeneralLabelerStation.Statistics;

namespace GeneralLabelerStation
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool loaded = false;
            Mutex mutex = new Mutex(false, "AutoLabeler", out loaded);

            //! 保证程序只有一个实例
            if (loaded)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
                Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
                Application.Run(new Form_Main());
            }
            else
            {
                Application.Exit();
            }

        }

        #region 2017年12月13日09:57:09 by lichen 添加 异常捕获 记录 系统出现的异常
        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception msg = (Exception)e.ExceptionObject;
            WriteLog(string.Format("UnHandledError: message:{0} \r\n stackTrace:{1} \r\n source:{2} \r\n", msg.Message, msg.StackTrace, msg.Source));
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            Exception msg = e.Exception;
            WriteLog(string.Format("ThreadExceptionError: message:{0} \r\n stackTrace:{1} \r\n source{2} \r\n", msg.Message, msg.StackTrace, msg.Source));
        }

        static void WriteLog(string li)
        {
            string str = DateTime.Now.Year.ToString("0000") + "/"
    + DateTime.Now.Month.ToString("00") + "/"
    + DateTime.Now.Day.ToString("00") + " "
    + DateTime.Now.Hour.ToString("00") + ":"
    + DateTime.Now.Minute.ToString("00") + ":"
    + DateTime.Now.Second.ToString("00");
            string logname = DateTime.Now.Year.ToString("0000")
                + DateTime.Now.Month.ToString("00")
                + DateTime.Now.Day.ToString("00");
            try
            {
                if (!Directory.Exists("D:\\Carsh"))
                {
                    Directory.CreateDirectory("D:\\Carsh");
                }
                StreamWriter sw = File.AppendText("D:\\Carsh\\" + logname + ".txt");
                sw.Write(str + " " + li + "\r\n");
                sw.Close();
            }
            catch { }
        }
        #endregion
    }
}