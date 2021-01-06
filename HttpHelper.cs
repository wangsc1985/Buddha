using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Buddha.helper
{
    class HttpHelper
    {
        public static CookieContainer cookie = new CookieContainer();
        //body是要传递的参数,格式"roleId=1&uid=2"
        //post的cotentType填写:
        //"application/x-www-form-urlencoded;text/xml; charset=utf-8"
        public static string PostHttpByUrl(string url, string body)
        {
            try
            {
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);

                httpWebRequest.ContentType = "application/x-www-form-urlencoded;text/xml;charset=utf-8";
                httpWebRequest.CookieContainer = cookie;
                httpWebRequest.Method = "POST";
                httpWebRequest.Timeout = 200000000;

                byte[] btBodys = Encoding.UTF8.GetBytes(body);
                httpWebRequest.ContentLength = btBodys.Length;
                httpWebRequest.GetRequestStream().Write(btBodys, 0, btBodys.Length);

                HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream());
                string responseContent = streamReader.ReadToEnd();

                httpWebResponse.Close();
                streamReader.Close();
                httpWebRequest.Abort();
                httpWebResponse.Close();

                return responseContent;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        /// <summary>
        /// GET方式发送得结果
        /// </summary>
        /// <param name="url">请求的url</param>
        public static string GetHttp(string url)
        {
            try
            {
                HttpWebRequest hwRequest = (HttpWebRequest)WebRequest.Create(url);
                hwRequest.CookieContainer = cookie;
                //hwRequest.Timeout = 30000;
                hwRequest.Method = "GET";
                hwRequest.ContentType = "application/x-www-form-urlencoded;charset=UTF-8";
                HttpWebResponse hwResponse = (HttpWebResponse)hwRequest.GetResponse();
                StreamReader srReader = new StreamReader(hwResponse.GetResponseStream(), Encoding.ASCII);
                string strResult = srReader.ReadToEnd();
                srReader.Close();
                hwResponse.Close();
                return strResult;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static string PostHttpByJson(string uri, string json)
        {
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(uri);
                httpWebRequest.CookieContainer = cookie;
                httpWebRequest.ContentType = "application/json;charset=UTF-8";
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    streamWriter.Write(json);
                    streamWriter.Flush();
                    streamWriter.Close();
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    return result;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

    }
}
