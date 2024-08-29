using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using UnityEngine;

public class Dados
{
    public ClimaRoot ClimaRoot { get; set; }
    public OndaRoot OndaRoot { get; set; }

    public double alturaOndaSalva { get; private set; }

    public double ventoSalvo { get; private set; }

    public string direcaoVentoSalva { get; private set; }
}

public delegate void APIReady(object sender, Dados d);

public class Program : MonoBehaviour
{

    public Dados dados = new Dados();
    ApiService apiService = new ApiService();
    public event APIReady OnDataAvailable;

    async void Awake()
        {
        //var apiService = new ApiService();

        // Obtém dados de clima e ondas de forma assíncrona
            var climaData = await apiService.GetClimaDataAsync("2535");
            var ondaData = await apiService.GetOndaDataAsync("2535");

            dados.ClimaRoot = climaData;

            // Exibe dados de clima
            Debug.Log($"Dados de clima para {climaData.Cidade}, {climaData.Estado}");
            foreach (var clima in climaData.Clima)
            {
                Debug.Log($"Data: {clima.Data}, Condição: {clima.Condicao}, Mínima: {clima.Min}, Máxima: {clima.Max}");
            }


            Debug.Log("");

            // Exibe dados de ondas
            Debug.Log($"Dados de ondas para {ondaData.Cidade}, {ondaData.Estado}");
            foreach (var onda in ondaData.Ondas)
            {
                Debug.Log($"Data: {onda.Data}");
                foreach (var dadosOnda in onda.DadosOndas)
                {
                    Debug.Log($"Hora: {dadosOnda.Hora}, Vento: {dadosOnda.Vento}, Direção do Vento: {dadosOnda.DirecaoVento}, Altura da Onda: {dadosOnda.AlturaOnda}");
                    Definicao.DefiniCoisa(dadosOnda); // Processa e exibe informações adicionais
                }
            }

            Debug.Log("");

            // Exibe novamente dados de clima com temperatura média
            Debug.Log($"Dados de clima para {climaData.Cidade}, {climaData.Estado}");
            foreach (var clima in climaData.Clima)
            {
                Debug.Log($"Data: {clima.Data}, Condição: {clima.Condicao}, Mínima: {clima.Min}, Máxima: {clima.Max}");
                // Utilidades.MostrarTemperatura(clima); // Exibe temperatura média
                Horario.Horinha(); // Exibe a hora atual em Brasília
            }

            // Obtém a hora atual em formato decimal
            double horaAtualDecimal = Horario.ObterHoraAtual();

            // Converte para string no formato HH:mm
            string horaAtual = TimeSpan.FromHours(horaAtualDecimal).ToString(@"hh\:mm");

            double intervaloHoras = 2;

            // Variáveis para armazenar os valores dentro do intervalo de tempo
            double ventoSalvo = 0;
            double alturaOndaSalva = 0;
            string direcaoVentoSalva = string.Empty;

            // Compara e exibe dados de ondas dentro de um intervalo de tempo
            foreach (var onda in ondaData.Ondas)
            {
                foreach (var dadosOnda in onda.DadosOndas)
                {
                    // Remove "Z" antes de parsear
                    string horaDadoStr = dadosOnda.Hora.Replace("Z", "");
                    TimeSpan horaDado;

                    // Tenta analisar a hora do dado, lidando com possíveis exceções
                    try
                    {
                        horaDado = TimeSpan.Parse(horaDadoStr);
                    }
                    catch (FormatException ex)
                    {
                        Debug.Log($"Erro ao converter hora '{dadosOnda.Hora}': {ex.Message}");
                        continue; // Pula para a próxima iteração
                    }

                    double diferencaHoras = Math.Abs((horaDado - TimeSpan.Parse(horaAtual)).TotalHours);

                    if (diferencaHoras <= intervaloHoras)
                    {
                        ventoSalvo = dadosOnda.Vento;
                        alturaOndaSalva = dadosOnda.AlturaOnda;
                        direcaoVentoSalva = dadosOnda.DirecaoVento;

                        Debug.Log($"Hora: {dadosOnda.Hora}, Vento: {dadosOnda.Vento}, Altura da Onda: {dadosOnda.AlturaOnda}, Direção da Onda: {dadosOnda.DirecaoOnda}");
                    }
                }
            }

            // Exibe os valores salvos
            Debug.Log("\nValores salvos dentro do intervalo de tempo:");
            Debug.Log($"Vento: {ventoSalvo}, Altura da Onda: {alturaOndaSalva}, Direção do Vento: {direcaoVentoSalva}");

            if (OnDataAvailable != null)
            {
                OnDataAvailable(this, dados);
            }
        }

    static DateTime HoraToDateTime(string value)
    {
        string horas = value.Substring(0, 2);
        string minutos = value.Substring(3, 2);
        DateTime agora = DateTime.Now;
        return new DateTime(agora.Year, agora.Month, agora.Day, int.Parse(horas), int.Parse(minutos), 0);
    }

    //  static class Utilidades
    //   {
    //   public static void MostrarTemperatura(Clima clima)
    //   {
    //    int max = clima.Max;
    //    int min = clima.Min;


    //   double tempera = ((double)max + min) / 2; // Convertendo para double antes da divisão

    //    string temperatura = tempera.ToString();

    //    Debug.Log($"Temperatura média: {temperatura}");
    //   }
    // }

}

public static class Utilidades
{
    public static double CalcularTemperatura(Clima clima)
    {
        int max = clima.Max;
        int min = clima.Min;
        return CalcularTemperatura(max, min);
    }

    public static double CalcularTemperatura(int max, int min)
    {
        return (double)(max + min) / 2;
    }
}

static class Definicao
{
    public static void DefiniCoisa(DadosOnda dadosOnda)
    {
        double vent = dadosOnda.Vento;
        double altu = dadosOnda.AlturaOnda;
        string direcao = dadosOnda.DirecaoOnda;

        string hr = dadosOnda.Hora;
        // Tira o Z da string porque o TimeSpan não reconhece o formato com Z
        if (hr.EndsWith("Z"))
        {
            hr = hr.Substring(0, hr.Length - 1);
        }

        // Converte a string de hora para TimeSpan
        TimeSpan timeSpan;

        // Tenta analisar a hora do dado, lidando com possíveis exceções
        try
        {
            timeSpan = TimeSpan.Parse(hr);
        }
        catch (FormatException ex)
        {
            Debug.Log($"Erro ao converter hora '{dadosOnda.Hora}': {ex.Message}");
            return; // Sai da função caso haja um erro na conversão
        }

        // Converte o TimeSpan para um valor double representando a fração do dia
        double hrDecimal = timeSpan.Hours + (timeSpan.Minutes / 60.0) + (timeSpan.Seconds / 3600.0);

        Debug.Log($"Vento: {vent}, Altura da Onda: {altu}, Direção do vento: {direcao}");
    }
}

static class Horario
{
    public static void Horinha()
    {
        // Obtém o fuso horário de Brasília
        TimeZoneInfo tzBrasilia = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");

        // Obtém a data e hora atual no fuso horário de Brasília
        DateTime horaBrasilia = TimeZoneInfo.ConvertTime(DateTime.UtcNow, tzBrasilia);

        int horas = horaBrasilia.Hour;
        int minutos = horaBrasilia.Minute;
        int segundos = horaBrasilia.Second;

        double horaDecimal = horas + (minutos / 60.0) + (segundos / 3600.0);

        // Exibe a hora de Brasília
        Debug.Log("Horário atual em Brasília: " + horaBrasilia.ToString("HH:mm:ss"));
    }

    public static double ObterHoraBrasiliaDecimal()
    {
        TimeZoneInfo tzBrasilia = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");
        DateTime horaBrasilia = TimeZoneInfo.ConvertTime(DateTime.UtcNow, tzBrasilia);
        int horas = horaBrasilia.Hour;
        int minutos = horaBrasilia.Minute;
        int segundos = horaBrasilia.Second;
        return horas + (minutos / 60.0) + (segundos / 3600.0);
    }

    public static double ObterHoraAtual()
    {
        TimeZoneInfo tzBrasilia = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");
        DateTime horaBrasilia = TimeZoneInfo.ConvertTime(DateTime.UtcNow, tzBrasilia);
        int horas = horaBrasilia.Hour;
        int minutos = horaBrasilia.Minute;
        return horas + (minutos / 60.0);
    }
}

public class Clima
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

public class Onda
{
    [JsonProperty("data")]
    public string Data { get; set; }

    [JsonProperty("dados_ondas")]
    public List<DadosOnda> DadosOndas { get; set; }
}

public class OndaRoot
{
    [JsonProperty("cidade")]
    public string Cidade { get; set; }

    [JsonProperty("estado")]
    public string Estado { get; set; }

    [JsonProperty("atualizado_em")]
    public string AtualizadoEm { get; set; }

    [JsonProperty("ondas")]
    public List<Onda> Ondas { get; set; }
}

public class ApiService
{
    private HttpClient _client;

    public ApiService()
    {
        _client = new HttpClient();
    }

    public async Task<ClimaRoot> GetClimaDataAsync(string cityId)
    {
        var response = await _client.GetAsync($"https://brasilapi.com.br/api/cptec/v1/clima/previsao/{cityId}");
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        var climaData = JsonConvert.DeserializeObject<ClimaRoot>(content);
        return climaData;
    }

    public async Task<OndaRoot> GetOndaDataAsync(string cityId)
    {
        var response = await _client.GetAsync($"https://brasilapi.com.br/api/cptec/v1/ondas/{cityId}");
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        var ondaData = JsonConvert.DeserializeObject<OndaRoot>(content);
        return ondaData;
    }
}
