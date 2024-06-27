using Newtonsoft.Json;


namespace Projeto_PI3.Classes
{
    public class Onda
    {
        [JsonProperty("data")]
        public string Data { get; set; }

        [JsonProperty("dados_ondas")]
        public List<DadosOnda> DadosOndas { get; set; }
    }
}
