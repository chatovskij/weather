using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Weather_1;
using Weather_1.Request;
//
namespace Weather_1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Weather_console_application_v1.1");
            Console.WriteLine("Please enter the location(default: Lviv):");
            string location = Console.ReadLine();

            if (String.IsNullOrEmpty(location))
            {
                location = "Lviv";
            }

            try
            {
                string str1 = "";
                string str = await Request.Request.UrlRequestAsync(location, str1);

                Openweather openweather;

                openweather = JsonConvert.DeserializeObject<Openweather>(str);

                ConsoleOutput.ConsoleOutput.ConOutput(openweather);
            }

            catch (Exception e)
            {
                Console.WriteLine("The connection failed: {0}", e.ToString());
            }
        }
    }
}
