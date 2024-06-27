using Newtonsoft.Json;


namespace Projeto_PI3.Classes
{
    public class DadosOnda
    {
        [JsonProperty("vento")]
        public double Vento { get; set; }

        [JsonProperty("direcao_vento")]
        public string DirecaoVento { get; set; }

        [JsonProperty("direcao_vento_desc")]
        public string DirecaoVentoDesc { get; set; }

        [JsonProperty("altura_onda")]
        public double AlturaOnda { get; set; }

        [JsonProperty("direcao_onda")]
        public string DirecaoOnda { get; set; }

        [JsonProperty("direcao_onda_desc")]
        public string DirecaoOndaDesc { get; set; }

        [JsonProperty("agitacao")]
        public string Agitacao { get; set; }

        [JsonProperty("hora")]
        public string Hora { get; set; }
    }
}
