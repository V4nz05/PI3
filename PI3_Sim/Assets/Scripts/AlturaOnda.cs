using TMPro;
using UnityEngine;

public class AlturaOnda : MonoBehaviour
{
    public TextMeshProUGUI alturaOndaText; // Referência ao TextMeshProUGUI na cena para exibir a altura da onda
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
        // Verifica se o componente TextMeshProUGUI está atribuído
        if (alturaOndaText != null)
        {
            // Exibe a altura da onda formatada com uma casa decimal
            alturaOndaText.text = alturaOnda.ToString("F1");
            Debug.Log($"Altura da Onda Atualizada: {alturaOnda}");
        }
        else
        {
            Debug.LogError("O componente TextMeshProUGUI 'alturaOndaText' não está atribuído.");
        }
    }
}
