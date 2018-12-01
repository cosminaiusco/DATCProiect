using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ConsoleApp2.Model
{
    class T1
    {
        [JsonProperty("ID")]
        public int ID { get; set; }

        [JsonProperty("LATITUDINE")]
        public float LATITUDINE { get; set; }

        [JsonProperty("LONGITUDINE")]
        public float LONGITUDINE { get; set; }
    }
}
