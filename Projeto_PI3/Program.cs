using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Projeto_PI3;
using Projeto_PI3.Classes;

class Program
{
    static async Task Main(string[] args)
    {
        var apiService = new ApiService();

        var climaData = await apiService.GetClimaDataAsync("2535");
        var ondaData = await apiService.GetOndaDataAsync("2535");

        Console.WriteLine($"Dados de clima para {climaData.Cidade}, {climaData.Estado}");
        foreach (var clima in climaData.Clima)
        {
            Console.WriteLine($"Data: {clima.Data}, Condição: {clima.Condicao}, Mínima: {clima.Min}, Máxima: {clima.Max}");

        }

        Console.WriteLine();

        Console.WriteLine($"Dados de ondas para {ondaData.Cidade}, {ondaData.Estado}");
        foreach (var onda in ondaData.Ondas)
        {
            Console.WriteLine($"Data: {onda.Data}");
            foreach (var dadosOnda in onda.DadosOndas)
            {
                Console.WriteLine($"Hora: {dadosOnda.Hora}, Vento: {dadosOnda.Vento}, Direção do Vento: {dadosOnda.DirecaoVento}, Altura da Onda: {dadosOnda.AlturaOnda}");
                definicao.definiCoisa(dadosOnda);
            }
        }
        Console.WriteLine($"Dados de clima para {climaData.Cidade}, {climaData.Estado}");
        foreach (var clima in climaData.Clima)
        {
            Console.WriteLine($"Data: {clima.Data}, Condição: {clima.Condicao}, Mínima: {clima.Min}, Máxima: {clima.Max}");
            Utilidades.MostrarTemperatura(clima); // Chamando a função para mostrar a temperatura média
            horario.horinha();
            

        }
        //CancellationTokenSource source = new CancellationTokenSource();
        //CancellationToken token = source.Token;
        //using (var ws = new ClientWebSocket())
        //{
        //    await ws.ConnectAsync(new Uri("wss://stream.aisstream.io/v0/stream"), token);
        //    await ws.SendAsync(new ArraySegment<byte>(Encoding.UTF8.GetBytes("{ \"APIKey\": \"6691253d1ba69089038f23006f9253414ec50f2e\", \"BoundingBoxes\": [[[-26.797845, -48.715272], [-27.058025, -48.180999]]]}")), WebSocketMessageType.Text, true, token);
        //    byte[] buffer = new byte[4096];
        //    while (ws.State == WebSocketState.Open)
        //    {
        //        var result = await ws.ReceiveAsync(new ArraySegment<byte>(buffer), token);
        //        if (result.MessageType == WebSocketMessageType.Close)
        //        {
        //            await ws.CloseAsync(WebSocketCloseStatus.NormalClosure, string.Empty, token);
        //        }
        //        else
        //        {
        //            Console.WriteLine($"Received {Encoding.Default.GetString(buffer, 0, result.Count)}");
        //        }
        //    }
        //}
        double horaAtualDecimal = horario.ObterHoraBrasiliaDecimal();
        foreach (var onda in ondaData.Ondas)
        {
            foreach (var dadosOnda in onda.DadosOndas)
            {
                double horaOndaDecimal = definicao.ObterHoraDecimal(dadosOnda.Hora);
                Comparador.CompararHora(dadosOnda, horaOndaDecimal, horaAtualDecimal);
            }
        }

    }


    static class Utilidades
    {
        public static void MostrarTemperatura(Clima clima)
        {
            int max = clima.Max;
            int min = clima.Min;

            double tempera = ((double)max + min) / 2; // Convertendo para double antes da divisão

            string temperatura = tempera.ToString();

            Console.WriteLine($"Temperatura média: {temperatura}");
        }
    }

    static class definicao
    {
        public static void definiCoisa(DadosOnda dadosOnda)
        {
            double vent = dadosOnda.Vento;
            double altu = dadosOnda.AlturaOnda;
            string direcao = dadosOnda.DirecaoOnda;

            string hr = dadosOnda.Hora;
            // Tira o z da string porque o TimeSpan não reconhece o formato com Z
            if (hr.EndsWith("Z"))
            {
                hr = hr.Substring(0, hr.Length - 1);
            }

            // Converte a string de hora para TimeSpan
            TimeSpan timeSpan = TimeSpan.Parse(hr);

            // Converte o TimeSpan para um valor double representando a fração do dia
            double hrDecimal = timeSpan.Hours + (timeSpan.Minutes / 60.0) + (timeSpan.Seconds / 3600.0);

            Console.WriteLine($"Vento:{vent}, Altura da Onda:{altu}, Direção do vento:{direcao}");
        }

        public static double ObterHoraDecimal(string hr)
        {
            if (hr.EndsWith("Z"))
            {
                hr = hr.Substring(0, hr.Length - 1);
            }
            TimeSpan timeSpan = TimeSpan.Parse(hr);
            return timeSpan.Hours + (timeSpan.Minutes / 60.0) + (timeSpan.Seconds / 3600.0);
        }
    }

    static class horario
    {
        public static void horinha()
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
            Console.WriteLine("Horário atual em Brasília: " + horaBrasilia.ToString("HH:mm:ss"));
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
    }

    static class Comparador
    {
        public static void CompararHora(DadosOnda dadosOnda, double horaDecimal, double hrdecimal)
        {
            // Compara horaDecimal com horaAtualDecimal
            if (horaDecimal == hrdecimal)
            {
                Console.WriteLine("As horas são iguais.");
            }
            else
            {
                Console.WriteLine($"As horas são diferentes. hr (decimal): {horaDecimal}, hora atual (decimal): {hrdecimal}");
            }
        }
    }
}