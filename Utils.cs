using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Buddha
{
    class Utils
    {
        // DateTime --> long
        public static long ConvertDateTimeToLong(DateTime dt)
        {
            DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            TimeSpan toNow = dt.Subtract(dtStart);
            long timeStamp = toNow.Ticks;
            timeStamp = long.Parse(timeStamp.ToString().Substring(0, timeStamp.ToString().Length - 4));
            return timeStamp;
        }


        // long --> DateTime
        public static DateTime ConvertLongToDateTime(long d)
        {
            DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            long lTime = long.Parse(d + "0000");
            TimeSpan toNow = new TimeSpan(lTime);
            DateTime dtResult = dtStart.Add(toNow);
            return dtResult;
        }

        public delegate void BuildBuddhaListCallback(int code, string result);
        public static void buildBuddhaListAndSave(int count, DateTime stoptime, long avgDuration, BuildBuddhaListCallback callback)
        {
            try
            {
                if (count < 1)
                {
                    callback(-1, "count<1,不会计入数据库");
                    return;
                }
                var buddhaList = new List<Record>();
                DateTime tmpTime = new DateTime(1970, 1, 1);
                Record buddha = null;
                for (int index = count; index > 1; index--)
                {
                    if (tmpTime.Year == 1970 || buddha == null)
                    {
                        tmpTime = stoptime;
                        tmpTime = tmpTime.AddMilliseconds(-1 * avgDuration * index);
                        buddha = new Record(tmpTime, avgDuration, 1, "计时计数念佛", 11);
                    }
                    else
                    {
                        var startTime = stoptime;
                        startTime = startTime.AddMilliseconds(-1 * avgDuration * index);
                        if (startTime.DayOfYear == tmpTime.DayOfYear && startTime.Hour == tmpTime.Hour)
                        {
                            buddha.duration += avgDuration;
                            buddha.count += 1;
                        }
                        else
                        {
                            buddhaList.Add(buddha);
                            buddha = new Record(startTime, avgDuration, 1, "计时计数念佛", 11);
                            tmpTime = startTime;
                        }
                    }
                }
                if (buddha != null)
                {
                    buddhaList.Add(buddha);
                }


                CloudUtils.uploadRecords(buddhaList, (code, result) =>
                {
                    switch (code)
                    {
                        case 0:
                            //var dc = new DataContext();
                            MainForm.dc.AddRecords(buddhaList);
                            callback(code, result);
                            break;

                        default:
                            callback(code, result);
                            break;

                    }
                });
            }
            catch (Exception ex)
            {
                callback(-1, ex.Message);
            }
        }

        public static List<Record> IntegrateBuddhaList(DateTime startTime)
        {
            //var dc = new DataContext();
            //dc.Connect();


            var buddhaList = MainForm.dc.GetBuddhaListStartDate(startTime);
            var removeList = new List<Record>();
            Record tmp = null;

            foreach (var buddha in buddhaList)
            {
                if (tmp != null)
                {
                    if (buddha.startDateTime.DayOfYear != tmp.startDateTime.DayOfYear)
                    {
                        MainForm.dc.EditRecord(tmp);
                        tmp = buddha;
                    }
                    else
                    {
                        if (buddha.startDateTime.Hour == tmp.startDateTime.Hour)
                        {
                            tmp.duration += buddha.duration;
                            tmp.count += buddha.count;
                            removeList.Add(buddha);
                        }
                        else
                        {
                            MainForm.dc.EditRecord(tmp);
                            tmp = buddha;
                        }
                    }
                }
                else
                {
                    tmp = buddha;
                }
            }
            if (tmp != null)
            {
                MainForm.dc.EditRecord(tmp);
            }
           
            foreach(var re in removeList)
            {
                buddhaList.Remove(re);
            }
            MainForm.dc.DeleteRecodeList(removeList);

            //dc.Close();
            return buddhaList;
        }
    }
}
