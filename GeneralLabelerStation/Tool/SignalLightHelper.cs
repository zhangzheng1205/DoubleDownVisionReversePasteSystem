using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GeneralLabelerStation.Tool
{
    /// <summary>
    ///  信号灯管理
    /// </summary>
    public class SignalLightHelper:Common.SingletionProvider<SignalLightHelper>
    {
        public enum State
        {
            Pause,
            Running,
            Alarm,
        }

        /// <summary>
        /// 上一次信号等状态
        /// </summary>
        private State LastState = State.Pause;

        /// <summary>
        /// 当前信号等状态
        /// </summary>
        private State CurState = State.Pause;


        /// <summary>
        /// 中间变量 是否报警过
        /// </summary>
        private bool isAlarmed = false;

        /// <summary>
        /// 中间变量 报警多少次了
        /// </summary>
        private int alarmCount = 1;

        /// <summary>
        /// 报警间隔
        /// </summary>
        public int AlarmSpace = 500;

        /// <summary>
        /// 报警次数
        /// </summary>
        public int AlarmCount = 10;

        /// <summary>
        /// 是否连续报警
        /// </summary>
        public bool AlarmContinue = true;

        /// <summary>
        /// 报警消音
        /// </summary>
        public bool IsAlarmIgnore = false;
 
        public void thread_Singal()
        {
            while(!Form_Main.Instance.bSystemExit)
            {
                Thread.Sleep(this.AlarmSpace);

                switch(CurState)
                {
                    case State.Pause:
                        Form_Main.Instance.Three_Yellow_ON();
                        Thread.Sleep(100);
                        break;
                    case State.Running:
                        Form_Main.Instance.Three_Green_ON();
                        Thread.Sleep(100);
                        break;
                    case State.Alarm:
                        if(IsAlarmIgnore)
                        {
                            if (isAlarmed)
                            {
                                if (this.alarmCount < this.AlarmCount)
                                {
                                    Form_Main.Instance.Three_Red_ON();
                                    if (!this.AlarmContinue)
                                        this.alarmCount++;
                                }
                                else
                                    this.CurState = State.Pause;
                            }
                            else
                                Form_Main.Instance.Three_Red_OFF();
                        }
                        else
                        {
                            if(isAlarmed)
                                Form_Main.Instance.Three_Yellow_ON();
                            else
                                Form_Main.Instance.Three_Yellow_OFF();
                        }
                        isAlarmed = !isAlarmed;
                        break;
                }
            }
        }
    }
}
