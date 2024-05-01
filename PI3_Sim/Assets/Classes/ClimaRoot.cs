using Newtonsoft.Json;
using System.Collections.Generic;


namespace PI3_Sim.Classes
{
    public class ClimaRoot
    {
        [JsonProperty("cidade")]
        public string Cidade { get; set; }

        [JsonProperty("estado")]
        public string Estado { get; set; }

        [JsonProperty("atualizado_em")]
        public string AtualizadoEm { get; set; }

        [JsonProperty("clima")]
        public List<Clima> Clima { get; set; }
    }
}