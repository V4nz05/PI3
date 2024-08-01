using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using PI3_Sim.Classes;

public class DadosAPI : MonoBehaviour
{
    private async void Start()
    {
        // Chama o método assíncrono usando await
        await FetchDataAsync();
    }

    private async Task FetchDataAsync()
    {
        var apiService = new ApiService();

        // Executa chamadas assíncronas
        var climaData = await apiService.GetClimaDataAsync("2535");
        var ondaData = await apiService.GetOndaDataAsync("2535");

        // Log dos dados
        Debug.Log($"Dados de clima para {climaData.Cidade}, {climaData.Estado}");
        foreach (var clima in climaData.Clima)
        {
            Debug.Log($"Data: {clima.Data}, Condição: {clima.Condicao}, Mínima: {clima.Min}, Máxima: {clima.Max}");
        }

        Debug.Log($"Dados de ondas para {ondaData.Cidade}, {ondaData.Estado}");
        foreach (var onda in ondaData.Ondas)
        {
            Debug.Log($"Data: {onda.Data}");
            foreach (var dadosOnda in onda.DadosOndas)
            {
                Debug.Log($"Hora: {dadosOnda.Hora}, Vento: {dadosOnda.Vento}, Direção do Vento: {dadosOnda.DirecaoVento}, Altura da Onda: {dadosOnda.AlturaOnda}");
            }
        }
    }
}
