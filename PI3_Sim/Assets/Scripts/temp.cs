using TMPro;
using UnityEngine;

public class Temp : MonoBehaviour
{
    public TextMeshProUGUI temperatura; // Refer�ncia ao TextMeshProUGUI na cena
    public Program program; // Refer�ncia ao script Program
    private Clima climaobj;
    public TMP_Text TextTemperatura;

    void Start()
    {
        // Verifica se 'program' n�o � nulo
        if (program != null)
        {
            program.OnDataAvailable += Program_OnDataAvailable;
        }
        else
        {
            Debug.LogError("A refer�ncia ao script 'Program' n�o est� atribu�da.");
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
        // Verifica se 'ClimaRoot' e 'Clima' n�o s�o nulos
        if (d?.ClimaRoot?.Clima != null && d.ClimaRoot.Clima.Count > 0)
        {
            climaobj = d.ClimaRoot.Clima[0];
            AtualizarTemperatura(climaobj);
        }
        else
        {
            Debug.LogError("Dados de clima n�o est�o dispon�veis ou est�o no formato incorreto.");
        }
    }

    // M�todo para atualizar os dados de clima
    public void AtualizarTemperatura(Clima clima)
    {
        if (clima == null)
        {
            Debug.LogError("O objeto 'Clima' fornecido � nulo.");
            return;
        }

        // Verifique se Max e Min est�o sendo inicializados corretamente
        int max = clima.Max;
        int min = clima.Min;

        // Adicione logs para verificar os valores de Max e Min
        Debug.Log($"Max: {max}, Min: {min}");

        // Usar o m�todo da classe Utilidades para calcular a temperatura
        double tempera = Utilidades.CalcularTemperatura(max, min);

        // Verifica se 'temperatura' n�o � nulo
        if (temperatura != null)
        {
            // Converter para string e exibir na UI
            //temperatura.text = tempera.ToString("F1"); // Formata com uma casa decimal
            TextTemperatura.text = tempera.ToString("F1");
        }
        else
        {
            Debug.LogError("A refer�ncia ao componente TextMeshProUGUI n�o est� atribu�da.");
        }
    }

    void Update()
    {
        // L�gica do Update se necess�rio
    }
}
