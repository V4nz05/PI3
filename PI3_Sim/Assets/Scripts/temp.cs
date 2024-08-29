using TMPro;
using UnityEngine;

public class Temp : MonoBehaviour
{
    public TextMeshProUGUI temperatura; // Referência ao TextMeshProUGUI na cena
    public Program program; // Referência ao script Program
    private Clima climaobj;
    public TMP_Text TextTemperatura;

    void Start()
    {
        // Verifica se 'program' não é nulo
        if (program != null)
        {
            program.OnDataAvailable += Program_OnDataAvailable;
        }
        else
        {
            Debug.LogError("A referência ao script 'Program' não está atribuída.");
        }
    }

    private void OnDisable()
    {
        if (program != null)
        {
            program.OnDataAvailable -= Program_OnDataAvailable;
        }
    }

    private void Program_OnDataAvailable(object sender, Dados d)
    {
        // Verifica se 'ClimaRoot' e 'Clima' não são nulos
        if (d?.ClimaRoot?.Clima != null && d.ClimaRoot.Clima.Count > 0)
        {
            climaobj = d.ClimaRoot.Clima[0];
            AtualizarTemperatura(climaobj);
        }
        else
        {
            Debug.LogError("Dados de clima não estão disponíveis ou estão no formato incorreto.");
        }
    }

    // Método para atualizar os dados de clima
    public void AtualizarTemperatura(Clima clima)
    {
        if (clima == null)
        {
            Debug.LogError("O objeto 'Clima' fornecido é nulo.");
            return;
        }

        // Verifique se Max e Min estão sendo inicializados corretamente
        int max = clima.Max;
        int min = clima.Min;

        // Adicione logs para verificar os valores de Max e Min
        Debug.Log($"Max: {max}, Min: {min}");

        // Usar o método da classe Utilidades para calcular a temperatura
        double tempera = Utilidades.CalcularTemperatura(max, min);

        // Verifica se 'temperatura' não é nulo
        if (temperatura != null)
        {
            // Converter para string e exibir na UI
            //temperatura.text = tempera.ToString("F1"); // Formata com uma casa decimal
            TextTemperatura.text = tempera.ToString("F1");
        }
        else
        {
            Debug.LogError("A referência ao componente TextMeshProUGUI não está atribuída.");
        }
    }

    void Update()
    {
        // Lógica do Update se necessário
    }
}
