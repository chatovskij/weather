using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WeatherJSon
{
    class openweather
    {
        public coord coord { get; set; }
        public weather[] weather { get; set; }

        [JsonProperty("base")] //word "base" is a keyword for C# need to chose the parameter, it replace the name.
        public string base1 { get; set; }
        public main main { get; set; }
        public int visibility { get; set; }
        public wind wind { get; set; }
        public clouds clouds { get; set; }
        public long dt { get; set; }
        public sys sys { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public int cod { get; set; }
    }
}
