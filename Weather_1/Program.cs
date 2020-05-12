using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using Weather_1;
//
namespace Weather_1
{
    class Program
    {
        private const string APIKEY = "58dacd2ee9cd984812a7e08253f09227";

        static void Main(string[] args)
        {
            string str = "";
            string clouds;
            string preasure;
            string windSpeed;
            string temperature;

            Console.WriteLine("Weather_console_application_v1");
            Console.WriteLine("Please enter the location(default: Lviv):");
            string location = Console.ReadLine();

            if (String.IsNullOrEmpty(location))
            {
                location = "Lviv";
            }

            try
            {
                WebRequest req = WebRequest.Create(@"http://api.openweathermap.org/data/2.5/weather?q=" + location + "&APPID=" + APIKEY);
                req.Method = "POST";

                req.ContentType = "application/x-www-urlencoded";

                Openweather openweather;

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

                openweather = JsonConvert.DeserializeObject<Openweather>(str);

                if (args.Length == 0)
                {
                    preasure = openweather.main.pressure.ToString();
                    Console.WriteLine("Air pressure is: " + preasure + " hPa");

                    clouds = openweather.clouds.all.ToString();
                    Console.WriteLine("Clouds value is: " + clouds + " %");

                    windSpeed = openweather.wind.speed.ToString();
                    Console.WriteLine("Wind speed is: " + windSpeed + " m/s");

                    temperature = (openweather.main.temp - 273).ToString();
                    Console.WriteLine("Temperature is: " + temperature.Substring(0, 4) + "°C");
                }

                if (args.Length != 0)
                {
                    for (int i = 0; i < args.Length; i++)
                    {
                        if (args[i] == "-t")
                        {
                            temperature = (openweather.main.temp - 273).ToString();
                            Console.WriteLine("Temperature is: " + temperature.Substring(0, 4) + "°C"); 
                        }
                        if (args[i] == "-p")
                        {
                            preasure = openweather.main.pressure.ToString();
                            Console.WriteLine("Air pressure is: " + preasure + " hPa");
                        }
                        if (args[i] == "-c")
                        {
                            clouds = openweather.clouds.all.ToString();
                            Console.WriteLine("Clouds value is: " + clouds + " %");
                        }
                        if (args[i] == "-w")
                        {
                            windSpeed = openweather.wind.speed.ToString();
                            Console.WriteLine("Wind speed is: " + windSpeed + " m/s");
                        }
                    }
                }

             }

            catch (Exception e)
            {
                Console.WriteLine("The connection failed: {0}", e.ToString());
            }
        }
    }
}
