using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PI3_Sim.Classes
{
    public class 
    {
        [JsonProperty("data")]
        public string Data { get; set; }

        [JsonProperty("condicao")]
        public string Condicao { get; set; }

        [JsonProperty("min")]
        public int Min { get; set; }

        [JsonProperty("max")]
        public int Max { get; set; }

        [JsonProperty("indice_uv")]
        public int IndiceUv { get; set; }

        [JsonProperty("condicao_desc")]
        public string CondicaoDesc { get; set; }
    }
}