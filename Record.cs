using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buddha
{
    public class Record
    {

        public DateTime startDateTime;
        public long duration;
        public int count;
        public string summury;
        public int type;
        public string dateStr;

        public Record()
        {
        }

        public Record(DateTime startDateTime, long duration, int count ,string summury, int type)
        {
            this.startDateTime = startDateTime;
            this.duration = duration;
            this.count = count;
            this.summury = summury;
            this.type = type;
            this.dateStr = startDateTime.ToLongDateString() + "  "+startDateTime.ToLongTimeString();
        }
    }
}
