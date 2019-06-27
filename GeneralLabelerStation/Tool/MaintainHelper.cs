using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralLabelerStation.Tool
{
    public class MaintainHelper:Common.SingletionProvider<MaintainHelper>
    {
        public List<DateTime> MaintainCount = new List<DateTime>();

        public DateTime LastMaintainTime = DateTime.Now;

        public TimeSpan MaintainSapn = new TimeSpan(1000, 0, 0);
    }
}
