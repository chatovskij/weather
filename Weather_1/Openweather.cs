using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
//
namespace Weather_1
{
    class Openweather
    {
        public Coord coord { get; set; }
        public Weather[] weather { get; set; }

        [JsonProperty("base")] //word "base" is a keyword for C# need to chose the parameter, it replace the name.
        public string base1 { get; set; }
        public MainList main { get; set; }
        public int visibility { get; set; }
        public Wind wind { get; set; }
        public Clouds clouds { get; set; }
        public long dt { get; set; }
        public Sys sys { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public int cod { get; set; }
    }
}
