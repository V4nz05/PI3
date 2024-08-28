using TMPro;
using UnityEngine;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using PI3_Sim.Classes;


public class Temp : MonoBehaviour
{
    public TextMeshProUGUI temperatura; // Refer�ncia ao TextMeshProUGUI na cena

    private Clima climaobj;
    async void Start()
    {
        var apiService = new ApiService();

        // Obt�m dados de clima e ondas de forma ass�ncrona
        var climaData = await apiService.GetClimaDataAsync("2535");
        var ondaData = await apiService.GetOndaDataAsync("2535");

        // Exibe dados de clima
        Debug.Log($"Dados de clima para {climaData.Cidade}, {climaData.Estado}");
        foreach (var clima in climaData.Clima)
        {
            Debug.Log($"Data: {clima.Data}, Condi��o: {clima.Condicao}, M�nima: {clima.Min}, M�xima: {clima.Max}");
        }

    }

    // M�todo para atualizar os dados de clima
    public void AtualizarTemperatura(Clima clima)
    {
        climaobj = clima;

        // Verifique se Max e Min est�o sendo inicializados corretamente
        int max = climaobj.Max;
        int min = climaobj.Min;

        // Adicione logs para verificar os valores de Max e Min
        Debug.Log($"Max: {max}, Min: {min}");

        // Usar o m�todo da classe Utilidades para calcular a temperatura
        double tempera = Utilidades.CalcularTemperatura(max, min);

        // Converter para string e exibir na UI
        temperatura.text = tempera.ToString("F1"); // Formata com uma casa decimal
    }

    void Update()
    {
        // L�gica do Update se necess�rio
    }
}

// Defini��o das classes de dados
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

// Classe Utilidades para calcular a temperatura
static class Utilidades
{
    public static double CalcularTemperatura(int max, int min)
    {
        return (double)(max + min) / 2;
    }
}
