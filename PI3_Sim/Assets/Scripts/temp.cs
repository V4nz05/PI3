using TMPro;
using UnityEngine;
using PI3_Sim.Classes;

public class temp : MonoBehaviour
{
    public TextMeshProUGUI temperatura;

    private Clima climaobj;

    void Start()
    {
        // Inicializa o objeto Clima
        climaobj = new Clima();

        // Atualiza a temperatura inicial com os valores padrão
        AtualizarTemperatura(climaobj);
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

        // Calcular a temperatura média como double
        double tempera = (double)(max + min) / 2;

        // Converter para string e exibir na UI
        temperatura.text = tempera.ToString("F1"); // Formata com uma casa decimal
    }

    void Update()
    {
        // Lógica do Update se necessário
    }
}
