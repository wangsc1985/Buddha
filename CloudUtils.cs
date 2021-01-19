using Buddha.helper;
using LitJson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Buddha
{
    class CloudUtils
    {

        private static string env = "yipinshangdu-4wk7z";
        private static string appid = "wxbdf065bdeba96196";
        private static string secret = "d2834f10c0d81728e73a4fe4012c0a5d";
        private delegate void FormControlInvoker();
        public delegate void CloudResponseFinished(int code, string msg);

        public static void loadRecords(DateTime startTime, CloudResponseFinished callBack)
        {
            new Thread(new ThreadStart(() =>
            {
                try
                {
                    DataContext dc = new DataContext();
                    dc.Connect();
                    List<Record> result = new List<Record>();
                    string access_token = getToken();

                    string url = $"https://api.weixin.qq.com/tcb/invokecloudfunction?access_token={access_token}&env={env}&name=loadBuddha";
                    string body = "{\"phone\":\"18509513143\",\"startTime\":\"" + Utils.ConvertDateTimeToLong(startTime) + "\"}";
                    string html = HttpHelper.PostHttpByJson(url, body);
                    JsonData jsonData = JsonMapper.ToObject(html);
                    if (jsonData["errcode"].ToString().Equals("0"))
                    {
                        string resp_data = jsonData["resp_data"].ToString();
                        jsonData = JsonMapper.ToObject(resp_data);

                        foreach (JsonData position in jsonData)
                        {
                            DateTime time = Utils.ConvertLongToDateTime(Convert.ToInt64(position["startTime"].ToString()));
                            long duration = Convert.ToInt64(position["duration"].ToString());
                            int count = Convert.ToInt32(position["count"].ToString());
                            string summary = position["summary"].ToString();
                            int type = Convert.ToInt32(position["type"].ToString());

                            result.Add(new Record(time, duration, count, summary, type));
                        }

                        dc.AddRecords(result);
                    }
                    dc.EditSetting("loadTime", Utils.ConvertDateTimeToLong(DateTime.Now) + "");
                    dc.Close();


                    callBack(0, "云端下载完毕！");
                }
                catch (Exception ex)
                {
                    callBack(-1, ex.Message);
                }
            })).Start();
        }


        private static string getToken()
        {
            DataContext dc = new DataContext();
            dc.Connect();
            string set = dc.getSettingValue("expires");
            if (set != null)
            {
                DateTime now = DateTime.Now;
                DateTime expires = Utils.ConvertLongToDateTime(Convert.ToInt64(set.Substring(0, set.IndexOf("."))));
                if (expires.Subtract(now).TotalMilliseconds > 0)
                {
                    return dc.getSettingValue("token");
                }
            }

            string html = HttpHelper.GetHttp($"https://sahacloudmanager.azurewebsites.net/home/token/{appid}/{secret}");

            var data = html.Split(':');
            string access_token = data[0];
            dc.EditSetting("token", access_token);
            dc.EditSetting("expires", data[1]);
            dc.Close();
            return access_token;
        }


        public static void uploadRecords(List<Record> records, CloudResponseFinished callBack)
        {
            new Thread(new ThreadStart(() =>
            {
                try
                {
                    string access_token = getToken();
                    string url = $"https://api.weixin.qq.com/tcb/invokecloudfunction?access_token={access_token}&env={env}&name=addBuddhaRange";
                    StringBuilder sb = new StringBuilder();
                    sb.Append("{\"phone\":\"18509513143\",\"data\":");
                    sb.Append("[");

                    for (int i = 0; i < records.Count; i++)
                    {
                        sb.Append("{");
                        sb.Append($"\"startTime\":\"{ Utils.ConvertDateTimeToLong(records[i].startDateTime)}\"");
                        sb.Append($",\"duration\":\"{records[i].duration}\"");
                        sb.Append($",\"count\":\"{records[i].count}\"");
                        sb.Append($",\"summary\":\"{records[i].summury}\"");
                        sb.Append($",\"type\":\"{records[i].type}\"");
                        sb.Append($",\"tt\":\"{records[i].startDateTime.ToLongDateString()}\"");
                        sb.Append("}");
                        if (i < records.Count - 1)
                            sb.Append(",");
                    }

                    sb.Append("]");
                    sb.Append("}");
                    string html = HttpHelper.PostHttpByJson(url, sb.ToString());
                    JsonData jsonData = JsonMapper.ToObject(html);
                    if (jsonData["errcode"].ToString().Equals("0"))
                    {
                        callBack(0, "上传云端完毕！");
                    }
                }
                catch (Exception ex)
                {
                    callBack(-1, ex.Message);
                }
            })).Start();
        }

        public static void uploadRecord(Record record, CloudResponseFinished callBack)
        {
            //new Thread(new ThreadStart(() =>
            //{
                try
                {
                    string access_token = getToken();
                    string url = $"https://api.weixin.qq.com/tcb/invokecloudfunction?access_token={access_token}&env={env}&name=addBuddha";
                    string body = "{\"phone\":\"18509513143\"" +
                        ",\"startTime\":\"" + Utils.ConvertDateTimeToLong(record.startDateTime) + "\"" +
                        ",\"duration\":\"" + record.duration + "\"" +
                        ",\"count\":\"" + record.count + "\"" +
                        ",\"summary\":\"" + record.summury + "\"" +
                        ",\"type\":\"" + record.type + "\"}";
                    string html = HttpHelper.PostHttpByJson(url, body);
                    JsonData jsonData = JsonMapper.ToObject(html);
                    if (jsonData["errcode"].ToString().Equals("0"))
                    {
                        callBack(0, "上传云端完毕！");
                    }
                }
                catch (Exception ex)
                {
                    callBack(-1, ex.Message);
                }
            //})).Start();
        }
    }
}
