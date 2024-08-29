using TMPro;
using UnityEngine;

public class AlturaOnda : MonoBehaviour
{
    public TextMeshProUGUI temperatura; // Referência ao TextMeshProUGUI na cena
    public Program program; // Referência ao objeto Program que contém os dados de onda

    void Start()
    {
        if (program != null)
        {
            // Inscreve-se no evento OnDataAvailable
            program.OnDataAvailable += Program_OnDataAvailable;
        }
        else
        {
            Debug.LogError("Referência ao 'program' não está atribuída!");
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
        // Acessando alturaOndaSalva a partir da instância de dados dentro de program
        double alturaOndaSalva = program.dados.alturaOndaSalva;
        AtualizarAlturaOnda(alturaOndaSalva);
    }

    public void AtualizarAlturaOnda(double alturaOnda)
    {
        Debug.Log($"Altura da Onda Calculada: {alturaOnda}");
        temperatura.text = alturaOnda.ToString("F1"); // Formata com uma casa decimal
    }
}
