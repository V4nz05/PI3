using Newtonsoft.Json;
using System.Collections.Generic;


namespace PI3_Sim.Classes
{
    public class Onda
    {
        [JsonProperty("data")]
        public string Data { get; set; }

        [JsonProperty("dados_ondas")]
        public List<DadosOnda> DadosOndas { get; set; }
    }
}
