using System.Threading.Tasks;
using UnityEngine;
using PI3_Sim.Classes;

class Program
{
    static async Task Main(string[] args)
    {
        var apiService = new ApiService();

        var climaData = await apiService.GetClimaDataAsync("2535");
        var ondaData = await apiService.GetOndaDataAsync("2535");

        Debug.Log($"Dados de clima para {climaData.Cidade}, {climaData.Estado}");
        foreach (var clima in climaData.Clima)
        {
            //Console.WriteLine($"Data: {clima.Data}, Condição: {clima.Condicao}, Mínima: {clima.Min}, Máxima: {clima.Max}");
            Debug.Log($"Data: {clima.Data}, Condição: {clima.Condicao}, Mínima: {clima.Min}, Máxima: {clima.Max}");
        }

        //Console.WriteLine();

        //Console.WriteLine($"Dados de ondas para {ondaData.Cidade}, {ondaData.Estado}");
        Debug.Log($"Dados de ondas para {ondaData.Cidade}, {ondaData.Estado}");
        foreach (var onda in ondaData.Ondas)
        {
            Debug.Log($"Data: {onda.Data}");
            foreach (var dadosOnda in onda.DadosOndas)
            {
                //Console.WriteLine($"Hora: {dadosOnda.Hora}, Vento: {dadosOnda.Vento}, Direção do Vento: {dadosOnda.DirecaoVento}, Altura da Onda: {dadosOnda.AlturaOnda}");
                Debug.Log($"Hora: {dadosOnda.Hora}, Vento: {dadosOnda.Vento}, Direção do Vento: {dadosOnda.DirecaoVento}, Altura da Onda: {dadosOnda.AlturaOnda}");
            }
        }
    }

  

}