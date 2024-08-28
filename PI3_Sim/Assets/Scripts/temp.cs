using TMPro;
using UnityEngine;

public class Temp : MonoBehaviour
{
    public TextMeshProUGUI temperatura; // Refer�ncia ao TextMeshProUGUI na cena
    public Program program;
    private Clima climaobj;

    void Start()
    {
        program.OnDataAvailable += Program_OnDataAvailable;
    }

    private void OnDisable()
    {
        program.OnDataAvailable -= Program_OnDataAvailable;
    }

    private void Program_OnDataAvailable(object sender, Dados d)
    {
        Debug.Log(d.ClimaRoot.Clima[0].Data);
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
