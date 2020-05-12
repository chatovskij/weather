using System;
using System.Collections.Generic;
using System.Text;

namespace Weather_1.ConsoleOutput
{
    class ConsoleOutput
    {
        public static void ConOutput(Openweather openweather)
        {
            string clouds;
            string preasure;
            string windSpeed;
            string temperature;

            preasure = openweather.main.pressure.ToString();
            Console.WriteLine("Air pressure is: " + preasure + " hPa");

            clouds = openweather.clouds.all.ToString();
            Console.WriteLine("Clouds value is: " + clouds + " %");

            windSpeed = openweather.wind.speed.ToString();
            Console.WriteLine("Wind speed is: " + windSpeed + " m/s");

            temperature = (openweather.main.temp - 273).ToString();
            Console.WriteLine("Temperature is: " + temperature.Substring(0, 4) + "°C");
        }
    }
}
