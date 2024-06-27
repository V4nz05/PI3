using Projeto_PI3.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_PI3.Temp
{
    internal class Temp
    { 
        
            public void MostrarTemperatura(Clima clima)
            {
                int max = clima.Max;
                int min = clima.Min;

                double tempera = ((double)max + min) / 2;

                string temperatura = tempera.ToString();

                Console.WriteLine($"Temperatura média: {temperatura}");
            }
        }
   
}