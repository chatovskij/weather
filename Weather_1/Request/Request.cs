using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Weather_1.Request
{
    class Request
    {
        private const string APIKEY = "58dacd2ee9cd984812a7e08253f09227";
        public static async Task<string> UrlRequestAsync(string location, string str)
        {
            return await Task.Run(() => UrlRequest(location, str));
        }

        static string UrlRequest(string location, string str)
        {
            WebRequest req = WebRequest.Create(@"http://api.openweathermap.org/data/2.5/weather?q=" + location + "&APPID=" + APIKEY);
            req.Method = "POST";

            req.ContentType = "application/x-www-urlencoded";

            WebResponse response = req.GetResponse();

            using (Stream s = response.GetResponseStream())
            {
                using (StreamReader r = new StreamReader(s))
                {
                    str = r.ReadToEnd();
                    Console.WriteLine(str); //for debug
                }
            }
            response.Close();

            return str;
        }
    }
}
