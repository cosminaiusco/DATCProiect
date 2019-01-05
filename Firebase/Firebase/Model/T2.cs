using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Firebase.Model
{
    class T2
    {
        [JsonProperty("ID")]
        public int ID { get; set; }

        [JsonProperty("TIPM")]
        public DateTime TIMP { get; set; }

        [JsonProperty("TEMPERATURA")]
        public float TEMPERATURA { get; set; }

        [JsonProperty("UMIDITATE")]
        public float UMIDITATE { get; set; }
    }
}
