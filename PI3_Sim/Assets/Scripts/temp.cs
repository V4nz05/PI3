using TMPro;
using UnityEngine;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using PI3_Sim.Classes;


public class Temp : MonoBehaviour
{
    public TextMeshProUGUI temperatura; // Referência ao TextMeshProUGUI na cena

    private Clima climaobj;
    async void Start()
    {
        var apiService = new ApiService();

        // Obtém dados de clima e ondas de forma assíncrona
        var climaData = await apiService.GetClimaDataAsync("2535");
        var ondaData = await apiService.GetOndaDataAsync("2535");

        // Exibe dados de clima
        Debug.Log($"Dados de clima para {climaData.Cidade}, {climaData.Estado}");
        foreach (var clima in climaData.Clima)
        {
            Debug.Log($"Data: {clima.Data}, Condição: {clima.Condicao}, Mínima: {clima.Min}, Máxima: {clima.Max}");
        }

    }

    // Método para atualizar os dados de clima
    public void AtualizarTemperatura(Clima clima)
    {
        climaobj = clima;

        // Verifique se Max e Min estão sendo inicializados corretamente
        int max = climaobj.Max;
        int min = climaobj.Min;

        // Adicione logs para verificar os valores de Max e Min
        Debug.Log($"Max: {max}, Min: {min}");

        // Usar o método da classe Utilidades para calcular a temperatura
        double tempera = Utilidades.CalcularTemperatura(max, min);

        // Converter para string e exibir na UI
        temperatura.text = tempera.ToString("F1"); // Formata com uma casa decimal
    }

    void Update()
    {
        // Lógica do Update se necessário
    }
}

// Definição das classes de dados
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
