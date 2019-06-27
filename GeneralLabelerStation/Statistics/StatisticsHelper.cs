#define SHOW_PANEL
using GeneralLabelerStation.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using ZedGraph;


namespace GeneralLabelerStation.Statistics
{
    /// <summary>
    /// 时间记录项
    /// </summary>
    public class TimeRecorder
    {
        public TimeRecorder() { }

        public TimeRecorder(string title)
        {
            this.Title = title;
        }

        /// <summary>
        /// 操作
        /// </summary>
        public string Remark = "时间";

        /// <summary>
        /// 步骤名称
        /// </summary>
        public string Title = "生产";

        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime StartTime = new DateTime();

        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime EndTime = new DateTime();

        public bool IsRunning = false;

        /// <summary>
        /// 花费时间
        /// </summary>
        [JsonIgnore]
        public string Elapsed
        {
            get
            {
                return Time.ToString(@"hh\:mm\:ss");
            }
        }

        [JsonIgnore]
        public TimeSpan Time
        {
            get
            {
                if (this.IsRunning)
                    return (DateTime.Now - StartTime);
                else
                    return (EndTime - StartTime);
            }
        }

        /// <summary>
        /// 停止计时
        /// </summary>
        public void Stop(DateTime end)
        {
            if (this.IsRunning)
            {
                EndTime = end;
                this.IsRunning = false;
                this.Remark = $"【{Title}】耗时:【{Elapsed}】 开始时间:【{StartTime.ToString("HH:mm:ss")}】 停止时间:【{EndTime.ToString("HH:mm:ss")}】";
            }
        }

        /// <summary>
        /// 开始计时
        /// </summary>
        public void Start(DateTime start)
        {
            if (!this.IsRunning)
            {
                StartTime = start;
                this.IsRunning = true;
                this.Remark = $"【{Title}】开始时间:【{StartTime.ToString("HH:mm:ss")}】";
            }
        }
    }

    /// <summary>
    /// 时间分类
    /// </summary>
    public class TimeClassification
    {
        public TimeClassification(){}

        public TimeClassification(string name)
        {
            this.Name = name;
        }

        public string Name = string.Empty;

        public List<TimeRecorder> Items = new List<TimeRecorder>();

        /// <summary>
        /// 花费总时长
        /// </summary>
        [JsonIgnore]
        public string Total
        {
            get
            {
                return Time.ToString(@"hh\:mm\:ss");
            }
        }

        /// <summary>
        /// 花费时间-分钟长度
        /// </summary>
        [JsonIgnore]
        public double TotalMin
        {
            get
            {
                return Time.TotalMilliseconds;
            }
        }

        [JsonIgnore]
        public TimeSpan Time
        {
            get
            {
                TimeSpan time = new TimeSpan();
                foreach (var item in Items)
                {
                    time += item.Time;
                }

                return time;
            }
        }

        /// <summary>
        ///  开始计时
        /// </summary>
        public void Start(string tip, DateTime start)
        {
            Items.Add(new TimeRecorder($"{Name}:{tip}"));
            Items.Last().Start(start);
        }

        /// <summary>
        /// 停止计时
        /// </summary>
        public void Stop(DateTime end)
        {
            if(Items.Count > 0)
            {
                Items.Last().Stop(end);
            }
        }
    }

    /// <summary>
    /// 统计分类
    /// </summary>
    public class CountClassification
    {
        /// <summary>
        /// 生产大板总数
        /// </summary>
        public int TotalPCB = 0;

        /// <summary>
        /// 生产小板总数
        /// </summary>
        public int TotalPCS = 0;

        /// <summary>
        /// 抛料总数
        /// </summary>
        public int TotalDrop = 0;

        /// <summary>
        /// 吸标总次数
        /// </summary>
        public int TotalPick = 0;

        /// <summary>
        /// 总报警数
        /// </summary>
        public int AlarmPcsCount = 0;

        /// <summary>
        /// panel报警数
        /// </summary>
        public int AlaramPanelCount = 0;

        /// <summary>
        /// 生产大板数
        /// </summary>
        public Dictionary<string, int> PCBCount = new Dictionary<string, int>();

        /// <summary>
        /// 生产小板数
        /// </summary>
        public Dictionary<string, int> PCSCount = new Dictionary<string, int>();

        /// <summary>
        /// 各吸嘴抛料数
        public Dictionary<uint, int> ZDrop = new Dictionary<uint, int>
        {
            { 0, 0},
            { 1, 0},
            { 2, 0},
            { 3, 0},
        };

        /// <summary>
        /// 各吸嘴抛料数
        public Dictionary<uint, int> ZPickFial = new Dictionary<uint, int>
        {
            { 0, 0},
            { 1, 0},
            { 2, 0},
            { 3, 0},
        };

        public static CountClassification operator +(CountClassification c1, CountClassification c2)
        {
            CountClassification count = new CountClassification();
            count.TotalPCS = c1.TotalPCS + c2.TotalPCS;
            count.TotalPCB = c1.TotalPCB + c2.TotalPCB;
            count.TotalDrop = c1.TotalDrop + c2.TotalDrop;
            count.AlarmPcsCount = c1.AlarmPcsCount + c2.AlarmPcsCount;
            count.AlaramPanelCount = c1.AlaramPanelCount + c2.AlaramPanelCount;
            for(uint i = 0; i <Variable.NOZZLE_NUM;++i)
            {
                count.ZDrop[i] = c1.ZDrop[i] + c2.ZDrop[i];
            }

            foreach(var name in c1.PCBCount.Keys)
            {
                if(!count.PCBCount.ContainsKey(name))
                    count.PCBCount.Add(name, 0);
                count.PCBCount[name] += c1.PCBCount[name];
            }

            foreach (var name in c2.PCBCount.Keys)
            {
                if (!count.PCBCount.ContainsKey(name))
                    count.PCBCount.Add(name, 0);
                count.PCBCount[name] += c2.PCBCount[name];
            }

            foreach (var name in c1.PCSCount.Keys)
            {
                if (!count.PCSCount.ContainsKey(name))
                    count.PCSCount.Add(name, 0);
                count.PCBCount[name] += c1.PCSCount[name];
            }

            foreach (var name in c2.PCSCount.Keys)
            {
                if (!count.PCSCount.ContainsKey(name))
                    count.PCSCount.Add(name, 0);
                count.PCSCount[name] += c2.PCSCount[name];
            }

            return count;
        }

        public static CountClassification operator -(CountClassification c1, CountClassification c2)
        {
            CountClassification count = new CountClassification();
            count.TotalPCS = c1.TotalPCS - c2.TotalPCS;
            count.TotalPCB = c1.TotalPCB - c2.TotalPCB;
            count.TotalDrop = c1.TotalDrop - c2.TotalDrop;
            count.AlarmPcsCount = c1.AlarmPcsCount - c2.AlarmPcsCount;
            count.AlaramPanelCount = c1.AlaramPanelCount - c2.AlaramPanelCount;

            for (uint i = 0; i < Variable.NOZZLE_NUM; ++i)
            {
                count.ZDrop[i] = c1.ZDrop[i] - c2.ZDrop[i];
            }

            foreach (var name in c1.PCBCount.Keys)
            {
                if (!count.PCBCount.ContainsKey(name))
                    count.PCBCount.Add(name, c1.PCBCount[name]);
                else
                    count.PCBCount[name] = c1.PCBCount[name];
            }

            foreach (var name in c2.PCBCount.Keys)
            {
                if (!count.PCBCount.ContainsKey(name))
                    count.PCBCount.Add(name, c2.PCBCount[name]);
                else
                    count.PCBCount[name] -= c2.PCBCount[name];
            }

            foreach (var name in c1.PCSCount.Keys)
            {
                if (!count.PCSCount.ContainsKey(name))
                    count.PCSCount.Add(name, c1.PCSCount[name]);
                else
                    count.PCSCount[name] = c1.PCSCount[name];
            }

            foreach (var name in c2.PCSCount.Keys)
            {
                if (!count.PCSCount.ContainsKey(name))
                    count.PCSCount.Add(name, c2.PCSCount[name]);
                else
                    count.PCSCount[name] -= c2.PCSCount[name];
            }

            return count;
        }
    }

    public enum TimeDefine
    {
        NULL,
        ProductTime,
        DTTime,
        PauseTime,
        WaitInputTime,
        WaitOuputTime,
        ChangeLineTime,
    }

    /// <summary>
    /// 一天的报告
    /// </summary>
    public class DayReprot
    {
        /// <summary>
        /// 日期
        /// </summary>
        public DateTime Date = DateTime.Today;

        #region 操作记录
        /// <summary>
        /// 当前机器正在纪录的时间项目
        /// </summary>
        public TimeDefine CurRecordTime = TimeDefine.NULL;

        /// <summary>
        /// 今日各个统计项
        /// </summary>
        public Dictionary<TimeDefine, TimeClassification> Times = new Dictionary<TimeDefine, TimeClassification>()
        {
            { TimeDefine.ProductTime, new TimeClassification("机器生产时间")},
            { TimeDefine.PauseTime, new TimeClassification("机器暂停时间")},
            { TimeDefine.DTTime, new TimeClassification("机器DownTime时间")},
            { TimeDefine.WaitInputTime, new TimeClassification("等待进板时间")},
            { TimeDefine.WaitOuputTime, new TimeClassification("等待出板时间")},
            { TimeDefine.ChangeLineTime, new TimeClassification("换线时间")},
        };
        #endregion

        #region 统计
        /// <summary>
        /// 今日总统计
        /// </summary>
        public CountClassification Total = new CountClassification();

        private TimeClassification GetRecord(string name,TimeDefine define, int startTime, int endTime)
        {
            TimeClassification classification = new TimeClassification(name);

            classification.Items = this.Times[define].Items.FindAll(delegate (TimeRecorder t)
            {
                return t.StartTime.Hour >= startTime && t.StartTime.Hour < endTime && t.EndTime.Hour < endTime;
            });

            return classification;
        }

        public DayReprot GetTimeTotal(int startTime, int endTime)
        {
            DayReprot reprot = new DayReprot();
            // 各个时间段的时间报告
            reprot.Times = new Dictionary<TimeDefine, TimeClassification>
            {
                 { TimeDefine.ProductTime, GetRecord("机器生产时间",TimeDefine.ProductTime, startTime, endTime)},
                { TimeDefine.PauseTime, GetRecord("机器暂停时间",TimeDefine.PauseTime, startTime, endTime)},
                { TimeDefine.DTTime, GetRecord("机器DownTime时间",TimeDefine.DTTime, startTime, endTime)},
                { TimeDefine.WaitInputTime, GetRecord("等待进板时间",TimeDefine.WaitInputTime, startTime, endTime)},
                { TimeDefine.WaitOuputTime, GetRecord("等待出板时间",TimeDefine.WaitOuputTime, startTime, endTime)},
                { TimeDefine.ChangeLineTime, GetRecord("换线时间",TimeDefine.ChangeLineTime, startTime, endTime)},
            };


            return reprot;
        }
        #endregion

        /// <summary>
        /// 换线完成
        /// </summary>
        private bool ChangeLineFinished = true;

        /// <summary>
        /// 连续生产板数
        /// </summary>
        private int ControusPCBCount = 0;

        /// <summary>
        /// 开始计时
        /// </summary>
        /// <param name="define">计时类别</param>
        /// <param name="opterName">附加名称</param>
        public void Start(TimeDefine define, string opterName)
        {
            if(define != this.CurRecordTime
                || define == TimeDefine.ChangeLineTime)
            {
                // 如果 上一次为换线，且这一次不是换线，且换线没有完成
                if(CurRecordTime == TimeDefine.ChangeLineTime && define != TimeDefine.ChangeLineTime
                    && !ChangeLineFinished)
                {
                    return;
                }

                if (define == TimeDefine.ChangeLineTime)
                    {
                        ControusPCBCount = 0;
                        ChangeLineFinished = false;
                    }

                if (CurRecordTime != TimeDefine.NULL)
                    Times[CurRecordTime].Stop(DateTime.Now);
                CurRecordTime = define;
                Times[CurRecordTime].Start(opterName, DateTime.Now);
            }
        }

        public void Stop()
        {
            if(CurRecordTime != TimeDefine.NULL)
                Times[CurRecordTime].Stop(DateTime.Now);
        }

        public void ProductPCB(string pcbName)
        {
            if (!Total.PCBCount.ContainsKey(pcbName))
                Total.PCBCount.Add(pcbName, 0);
            Total.PCBCount[pcbName] += 1;
            Total.TotalPCB += 1;
            if (CurRecordTime == TimeDefine.ChangeLineTime)
            {
                ControusPCBCount++;
                if (ControusPCBCount > 2)
                {
                    ChangeLineFinished = true;
                    ControusPCBCount = 0;
                    this.Start(TimeDefine.ProductTime, $"换线【{pcbName}】完成");
                }
            }
        }

        public void ProductPCS(string pcbName)
        {
            if (!Total.PCSCount.ContainsKey(pcbName))
                Total.PCSCount.Add(pcbName, 0);
            Total.PCSCount[pcbName] += 1;
            Total.TotalPCS += 1;
        }

        public void DropPCS(uint zindex)
        {
            this.Total.ZDrop[zindex] += 1;
            this.Total.TotalDrop++;
        }

        public void Pick(uint zindex, bool failed =false)
        {
            this.Total.TotalPick++;
            if (failed)
                this.Total.ZPickFial[zindex] += 1;
        }

        public void HourChange(DateTime last, DateTime cur)
        {
            Times[CurRecordTime].Stop(last);
            Times[CurRecordTime].Start("时间更替", cur);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class StatisticsHelper
    {
        private static StatisticsHelper instance = null;
        private static string StatisticsPath = "D://Statistics";
        private static string RecordPath = string.Empty;
        
        /// <summary>
        /// 实例
        /// </summary>
        public static StatisticsHelper Instance
        {
            get
            {
                if(instance == null)
                {
                    var now = DateTime.Now;
                    instance = new StatisticsHelper();
                    instance.DayChange(now);

                    if (!File.Exists(RecordPath+"today.json"))
                    {
                        instance.Reoprt = new DayReprot();
                        instance.Reoprt.Date = now;
                    }
                    else
                    {
                        instance.Reoprt = instance.Today;
                    }

                    instance.Reoprt.Start(TimeDefine.PauseTime, "启动软件");
                    instance.Timer.Interval = 30000; // 30s 刷新一次
                    instance.Timer.Tick += instance.Timer_Tick;
                    instance.Timer.Start();
                }
                return instance;
            }
        }

        #region 当日报告操作
        /// <summary>
        /// 当天的报告
        /// </summary>
        public DayReprot Reoprt = null;

        /// <summary>
        /// 获得今日报告
        /// </summary>
        public DayReprot Today
        {
            get
            {
                Common.SerializableHelper<DayReprot> helper = new Common.SerializableHelper<DayReprot>();
                var temp = helper.DeJsonSerialize(RecordPath+"today.json");
                if (temp == null)
                    temp = new DayReprot();
                return temp;
            }
        }

        /// <summary>
        /// 保存今日数据
        /// </summary>
        public void Refresh()
        {
            if (this.Reoprt != null)
            {
                var now = DateTime.Now;
                if (this.Reoprt.Date.Day != now.Day)
                {
                    // 保存上一天的
                    this.Reoprt.Stop();
                    Common.SerializableHelper<DayReprot> helper = new Common.SerializableHelper<DayReprot>(this.Reoprt);
                    helper.JsonSerialize(RecordPath);

                    DayChange(now);
                    TimeDefine temp = this.Reoprt.CurRecordTime;
                    this.Reoprt = new DayReprot();
                    this.Reoprt.Date = now;
                    this.Reoprt.Start(temp, "日期更换");
                }
                else
                {
                    if(this.Reoprt.Date.Hour != now.Hour)
                    {
                        this.Reoprt.HourChange(this.Reoprt.Date, now);
                    }

                    Common.SerializableHelper<DayReprot> helper = new Common.SerializableHelper<DayReprot>(this.Reoprt);
                    helper.JsonSerialize(RecordPath + "today.json");
                    this.SaveTotal(this.Reoprt.Total, RecordPath, this.Reoprt.Date.Hour);
                    this.Reoprt.Date = now;
                }
            }
        }

        public void DayChange(DateTime dateTime)
        {
            Common.CommonHelper.CreatePath(StatisticsPath);
            Common.CommonHelper.CreatePath($"{StatisticsPath}//{dateTime.Year}年//");
            Common.CommonHelper.CreatePath($"{StatisticsPath}//{dateTime.Year}年//{dateTime.Month}月//");
            Common.CommonHelper.CreatePath($"{StatisticsPath}//{dateTime.Year}年//{dateTime.Month}月//{dateTime.Day}号//");
            RecordPath = $"{StatisticsPath}//{dateTime.Year}年//{dateTime.Month}月//{dateTime.Day}号//";
        }
        #endregion

        #region 定时更新
        private void SaveTotal(CountClassification count,string path,int hour)
        {
            SerializableHelper<CountClassification> helper = new SerializableHelper<CountClassification>(count);
            helper.JsonSerialize($"{path}//{hour}.json");
        }

        private CountClassification LoadTotal(string path, int hour)
        {
            SerializableHelper<CountClassification> helper = new SerializableHelper<CountClassification>();
            return helper.DeJsonSerialize($"{path}//{hour}.json");
        }

        private CountClassification GetCount(string path, int startHour, int endHour)
        {
            CountClassification h1 = null;
            CountClassification h2 = null;
            int tStart = startHour == 0? 0: startHour - 1;
            int tEnd = endHour - 1;
            while (tStart <= tEnd)
            {
                if (h1 == null)
                {
                    h1 = this.LoadTotal(path, tStart);
                    if (h1 == null) tStart++;
                }

                if (h2 == null)
                {
                    h2 = this.LoadTotal(path, tEnd);
                    if (h2 == null) tEnd--;
                }

                if (h1 != null && h2 != null)
                    break;
            }

            if (h1 == null || h2 == null)
            {
                return new CountClassification();
            }
            else
            {
                if(tStart > (startHour - 1) || startHour == 0 || tStart == tEnd)
                {
                    return h2;
                }
                else
                {
                    return h2 - h1;
                }
            }
        }

        /// <summary>
        /// 定时保存
        /// </summary>
        private Timer Timer = new Timer();

        /// <summary>
        /// 保存报告
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Tick(object sender, EventArgs e)
        {
            this.Refresh();
        }
        #endregion

        #region 设置到控件上显示
        private void SetTree(TimeClassification classification, TreeView view)
        {
            var treeNode = view.Nodes.Add($"{classification.Name} 总耗时:[{classification.Total}]");
            foreach (var item in classification.Items)
            {
                treeNode.Nodes.Add(item.Remark);
            }
        }

        /// <summary>
        /// 将数据设置到树上显示
        /// </summary>
        /// <param name="view"></param>
        private void SetTree(DayReprot report, TreeView view)
        {
            view.Nodes.Clear();
            foreach (TimeDefine define in Enum.GetValues(typeof(TimeDefine)))
            {
                if(TimeDefine.NULL != define)
                    this.SetTree(report.Times[define], view);
            }

            TreeNode pcbCount = view.Nodes.Add($"生产大板数 [{report.Total.TotalPCB}]");

            foreach(string pcbName in report.Total.PCBCount.Keys)
            {
                pcbCount.Nodes.Add($"生产:[{pcbName}]  [{report.Total.PCBCount[pcbName]}] 大板");
            }

            TreeNode pcsCount = view.Nodes.Add($"生产总小板数 [{report.Total.TotalPCS}]");
            foreach (string pcbName in report.Total.PCSCount.Keys)
            {
                pcsCount.Nodes.Add($"生产:[{pcbName}]  [{report.Total.PCSCount[pcbName]}] 小片");
            }

            TreeNode drop = view.Nodes.Add("");
            double rate = 0;
            int count = 0;
            for(uint nz = 0; nz < Variable.NOZZLE_NUM; ++nz)
            {
                count = report.Total.ZDrop[nz];
                rate = 0;
                if ((report.Total.TotalPCS+count) != 0)
                {
                    rate = (double)count / (report.Total.TotalPCS+ count) * 100;
                }

                drop.Nodes.Add($"吸嘴{nz + 1} 抛料数[{count}] 抛料率[{rate:N2}%]");
            }

            if ((report.Total.TotalPCS +report.Total.TotalDrop) != 0)
            {
                rate = (double)report.Total.TotalDrop / (report.Total.TotalPCS + report.Total.TotalDrop) * 100;
            }
            else
                rate = 0;

            drop.Text = $"总抛料数[{report.Total.TotalDrop}] 总抛料率[{rate:N2}%]";
        }

        private void addPie(string name, double time, ZedGraph.GraphPane pane, Color color)
        {
            float angle = (float)(time / 4);
            pane.AddPieSlice(time, color, Color.White, angle, 0, name);
        }
        /// <summary>
        /// 设置到饼状图上
        /// </summary>
        /// <param name="pane"></param>
        private void SetChart(DayReprot report, ZedGraphControl zgc)
        {
            GraphPane pane = zgc.GraphPane;
            pane.CurveList.Clear();
            pane.GraphObjList.Clear();
            pane.Title.Text = report.Date.ToString($"yyyy-MM-dd 生产情况");
            pane.Title.FontSpec.IsItalic = true;
            pane.Title.FontSpec.Size = 12;
            pane.Title.FontSpec.Family = "微软雅黑";

            //pane.Fill = new Fill(Color.White, Color.Goldenrod, 45.0f);
            //pane.Chart.Fill.Type = FillType.None;

            //pane.Legend.Position = LegendPos.Float;
            //pane.Legend.Location = new Location()
            addPie("生产时间", report.Times[TimeDefine.ProductTime].TotalMin, pane, Color.Navy);
            addPie("暂停时间", report.Times[TimeDefine.PauseTime].TotalMin, pane, Color.Yellow);
            addPie("DT时间", report.Times[TimeDefine.DTTime].TotalMin, pane, Color.Red);
            addPie("换线时间", report.Times[TimeDefine.ChangeLineTime].TotalMin, pane, Color.DarkRed);
            addPie("待板时间", report.Times[TimeDefine.WaitInputTime].TotalMin, pane, Color.Blue);
            addPie("进板时间", report.Times[TimeDefine.WaitOuputTime].TotalMin, pane, Color.Blue);
            pane.AxisChange();
            zgc.Refresh();
            zgc.Invalidate();
        }

        /// <summary>
        /// 设置到表格表上
        /// </summary>
        /// <param name="reprot"></param>
        /// <param name="view"></param>
        public void SetGridView(DayReprot reprot, DataGridView view, bool showCT = false)
        {
            int adjust = 0;
#if !SHOW_PANEL
            adjust = -1;
#endif

            // 初始化
            if (view.Rows.Count <= 1)
            {
                view.Rows.Add();
                view.Rows[0].Cells[0].Value = "生产大板数";
                view.Rows[0].Cells[2].Value = "板";

                view.Rows.Add();
                view.Rows[1].Cells[0].Value = "生产小板数";
                view.Rows[1].Cells[2].Value = "片";

                view.Rows.Add();
                view.Rows[2].Cells[0].Value = "抛料率";
                view.Rows[2].Cells[2].Value = "%";

                view.Rows.Add();
                view.Rows[3].Cells[0].Value = "报警率(Pcs)";
                view.Rows[3].Cells[2].Value = "%";

#if SHOW_PANEL
                view.Rows.Add();
                view.Rows[4].Cells[0].Value = "报警率(Panel)";
                view.Rows[4].Cells[2].Value = "%";
#endif

                view.Rows.Add();
                view.Rows[5+adjust].Cells[0].Value = "生产时间";
                view.Rows[5 + adjust].Cells[2].Value = "时:分";

                view.Rows.Add();
                view.Rows[6 + adjust].Cells[0].Value = "暂停时间";
                view.Rows[6 + adjust].Cells[2].Value = "时:分";

                view.Rows.Add();
                view.Rows[7 + adjust].Cells[0].Value = "待板时间";
                view.Rows[7 + adjust].Cells[2].Value = "时:分";

                view.Rows.Add();
                view.Rows[8 + adjust].Cells[0].Value = "DownTime";
                view.Rows[8 + adjust].Cells[2].Value = "时:分";

                if (showCT)
                {
                    view.Rows.Add();
                    view.Rows[9 + adjust].Cells[0].Value = "CT";
                    view.Rows[9 + adjust].Cells[2].Value = "s/板";
                }
            }

            view.Rows[0].Cells[1].Value = reprot.Total.TotalPCB.ToString();
            view.Rows[1].Cells[1].Value = reprot.Total.TotalPCS.ToString();

            if ((reprot.Total.TotalPCS +reprot.Total.TotalDrop) == 0)
                view.Rows[2].Cells[1].Value = 0.ToString();
            else
                view.Rows[2].Cells[1].Value = ((double)(reprot.Total.TotalDrop) / (reprot.Total.TotalPCS +reprot.Total.TotalDrop) * 100).ToString("F2");

            if ((reprot.Total.AlarmPcsCount + reprot.Total.TotalPCS) == 0)
                view.Rows[3].Cells[1].Value = 0.ToString();
            else
                view.Rows[3].Cells[1].Value = ((double)(reprot.Total.AlarmPcsCount) / (reprot.Total.AlarmPcsCount + reprot.Total.TotalPCS) * 100).ToString("F2");

#if SHOW_PANEL
            if ((reprot.Total.AlaramPanelCount + reprot.Total.TotalPCB) == 0)
                view.Rows[4].Cells[1].Value = 0.ToString();
            else
                view.Rows[4].Cells[1].Value = ((double)(reprot.Total.AlaramPanelCount) / (reprot.Total.AlaramPanelCount + reprot.Total.TotalPCB) * 100).ToString("F2");
#endif

            view.Rows[5+adjust].Cells[1].Value = reprot.Times[TimeDefine.ProductTime].Total;
            view.Rows[6 + adjust].Cells[1].Value = reprot.Times[TimeDefine.PauseTime].Total;
            TimeSpan wait = reprot.Times[TimeDefine.WaitInputTime].Time + reprot.Times[TimeDefine.WaitOuputTime].Time;
            view.Rows[7 + adjust].Cells[1].Value = wait.ToString(@"hh\:mm\:ss");
            view.Rows[8 + adjust].Cells[1].Value = reprot.Times[TimeDefine.DTTime].Total;

            if(showCT)
                view.Rows[9 + adjust].Cells[1].Value = (Form_Main.Instance.Test.ElapsedMilliseconds / 1000.0).ToString("f2");
        }
#endregion

        /// <summary>
        /// 获得 某天 某时的数据
        /// </summary>
        /// <param name="day"></param>
        public DayReprot GetData(DateTime day, int startTime, int endTime, TreeView view = null, ZedGraphControl zgc = null, DataGridView gridView = null)
        {
            try
            {
                string path = $"{StatisticsPath}//{day.Year}年//{day.Month}月//{day.Day}号";
                if (Directory.Exists(path))
                {
                    DayReprot report = new DayReprot();
                    Common.SerializableHelper<DayReprot> helper = new Common.SerializableHelper<DayReprot>();
                    // 拿到当天记录
                    report = helper.DeJsonSerialize(path+"//today.json");
                    // 根据时间进行筛选
                    report = report.GetTimeTotal(startTime, endTime);
                    // 获得对应时间的统计
                    report.Total = this.GetCount(path, startTime, endTime);

                    if (view != null)
                    {
                        this.SetTree(report, view);
                    }

                    if (zgc != null)
                    {
                        this.SetChart(report, zgc);
                    }

                    if(gridView != null)
                    {
                        this.SetGridView(report, gridView);
                    }

                    return report;
                }
                else
                {
                    if (view != null)
                    {
                        view.Nodes.Clear();
                    }

                    return null;
                }
            }
            catch(Exception ex)
            {
                return null;
            }
        }
    }
}
