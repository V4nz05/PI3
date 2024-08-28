# PROJETO PI3 (Versão alfa 1.0.0)

![Badge de Versão](https://img.shields.io/badge/version-1.0.0-green.svg)

Este projeto é um simulador básico desenvolvido em Unity 3D que utiliza dados meteorológicos de APIs para simular a navegação de um barco. O comportamento do barco no ambiente 3D é influenciado por dados reais, como direção e intensidade do vento, condições das ondas, e outros fatores climáticos.

## Índice

- [Wiki](https://github.com/V4nz05/PI3/wiki)
- [Cronograma](https://github.com/users/V4nz05/projects/1)
- [Proposta do tema](https://github.com/V4nz05/PI3/blob/main/Proposta_de_tema%20PI3.md)
- [Instalação](#instalação)

## Integração de Dados Meteorológicos em Ambiente Visual Unity Utilizando API.

![Descrição da Imagem](https://github.com/V4nz05/PI3/blob/main/imagem.png)

## Sistema de dia e noite.
<p align="center">
  <img src="https://github.com/V4nz05/PI3/blob/main/GIFs/V%C3%ADdeo%20sem%20t%C3%ADtulo%20%E2%80%90%20Feito%20com%20o%20Clipchamp.gif" alt="Animação de exemplo" />
</p>

## Sistema de chuva.
<p align="center">
  <img src="https://github.com/V4nz05/PI3/blob/main/GIFs/V%C3%ADdeo%20sem%20t%C3%ADtulo%20%E2%80%90%20Feito%20com%20o%20Clipchamp%20(1).gif" alt="Animação de exemplo" />
</p>

## Sugestões de melhorias

- Melhor fluabilidade, e conceitos na navegação;
- Corrigir bugs de iluminação;
- Aprimorar sistemas de dia/noite e sol/chuva, com maiores detalhes e realismo;
- Acrescentar uma noite viva, com lua e estrelas;

## Projeto inspirado

[![Descrição do Vídeo](https://i.ytimg.com/vi/wvUQrL8ywbE/hqdefault.jpg?sqp=-oaymwEcCNACELwBSFXyq4qpAw4IARUAAIhCGAFwAcABBg==&rs=AOn4CLAm2hITWrJji5vOZRgKRLaxht1iew)](https://www.youtube.com/watch?v=wvUQrL8ywbE)

## Código Program.cs
As classes estão na pasta do PI3_sim

```bash
using Projeto_PI3.Classes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        var apiService = new ApiService();

        // Obtém dados de clima e ondas de forma assíncrona
        var climaData = await apiService.GetClimaDataAsync("2535");
        var ondaData = await apiService.GetOndaDataAsync("2535");

        // Exibe dados de clima
        Console.WriteLine($"Dados de clima para {climaData.Cidade}, {climaData.Estado}");
        foreach (var clima in climaData.Clima)
        {
            Console.WriteLine($"Data: {clima.Data}, Condição: {clima.Condicao}, Mínima: {clima.Min}, Máxima: {clima.Max}");
        }

        Console.WriteLine();

        // Exibe dados de ondas
        Console.WriteLine($"Dados de ondas para {ondaData.Cidade}, {ondaData.Estado}");
        foreach (var onda in ondaData.Ondas)
        {
            Console.WriteLine($"Data: {onda.Data}");
            foreach (var dadosOnda in onda.DadosOndas)
            {
                Console.WriteLine($"Hora: {dadosOnda.Hora}, Vento: {dadosOnda.Vento}, Direção do Vento: {dadosOnda.DirecaoVento}, Altura da Onda: {dadosOnda.AlturaOnda}");
                definicao.definiCoisa(dadosOnda); // Processa e exibe informações adicionais
            }
        }

        Console.WriteLine();

        // Exibe novamente dados de clima com temperatura média
        Console.WriteLine($"Dados de clima para {climaData.Cidade}, {climaData.Estado}");
        foreach (var clima in climaData.Clima)
        {
            Console.WriteLine($"Data: {clima.Data}, Condição: {clima.Condicao}, Mínima: {clima.Min}, Máxima: {clima.Max}");
            Utilidades.MostrarTemperatura(clima); // Exibe temperatura média
            horario.horinha(); // Exibe a hora atual em Brasília
        }

        // Obtém a hora atual em formato decimal
        double horaAtualDecimal = horario.ObterHoraatual();

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
                    Console.WriteLine($"Erro ao converter hora '{dadosOnda.Hora}': {ex.Message}");
                    continue; // Pula para a próxima iteração
                }

                double diferencaHoras = Math.Abs((horaDado - TimeSpan.Parse(horaAtual)).TotalHours);

                if (diferencaHoras <= intervaloHoras)
                {
                    ventoSalvo = dadosOnda.Vento;
                    alturaOndaSalva = dadosOnda.AlturaOnda;
                    direcaoVentoSalva = dadosOnda.DirecaoVento;

                    Console.WriteLine($"Hora: {dadosOnda.Hora}, Vento: {dadosOnda.Vento}, Altura da Onda: {dadosOnda.AlturaOnda}, Direção da Onda: {dadosOnda.DirecaoOnda}");
                }
            }
        }

        // Exibe os valores salvos
        Console.WriteLine("\nValores salvos dentro do intervalo de tempo:");
        Console.WriteLine($"Vento: {ventoSalvo}, Altura da Onda: {alturaOndaSalva}, Direção do Vento: {direcaoVentoSalva}");
    }

    static DateTime HoraToDateTime(string value)
    {
        string horas = value.Substring(0, 2);
        string minutos = value.Substring(3, 2);
        DateTime agora = DateTime.Now;
        return new DateTime(agora.Year, agora.Month, agora.Day, int.Parse(horas), int.Parse(minutos), 0);
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
                Console.WriteLine($"Erro ao converter hora '{dadosOnda.Hora}': {ex.Message}");
                return; // Sai da função caso haja um erro na conversão
            }

            // Converte o TimeSpan para um valor double representando a fração do dia
            double hrDecimal = timeSpan.Hours + (timeSpan.Minutes / 60.0) + (timeSpan.Seconds / 3600.0);

            Console.WriteLine($"Vento: {vent}, Altura da Onda: {altu}, Direção do vento: {direcao}");
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

        public static double ObterHoraatual()
        {
            TimeZoneInfo tzBrasilia = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");
            DateTime horaBrasilia = TimeZoneInfo.ConvertTime(DateTime.UtcNow, tzBrasilia);
            int horas = horaBrasilia.Hour;
            int minutos = horaBrasilia.Minute;
            return horas + (minutos / 60.0);
        }
    }
}


```

## Instalação
Siga os passos abaixo para instalar o projeto:

```bash
git clone (https://github.com/V4nz05/PI3)
cd PI3
npm install


