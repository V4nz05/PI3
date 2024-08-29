using TMPro;
using UnityEngine;

public class AlturaOnda : MonoBehaviour
{
    public TextMeshProUGUI alturaOndaText; // Refer�ncia ao TextMeshProUGUI na cena para exibir a altura da onda
    public Program program; // Refer�ncia ao objeto Program que cont�m os dados de onda

    void Start()
    {
        if (program != null)
        {
            // Inscreve-se no evento OnDataAvailable
            program.OnDataAvailable += Program_OnDataAvailable;
        }
        else
        {
            Debug.LogError("Refer�ncia ao 'program' n�o est� atribu�da!");
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
        // Acessando alturaOndaSalva a partir da inst�ncia de dados dentro de program
        double alturaOndaSalva = program.dados.alturaOndaSalva;
        AtualizarAlturaOnda(alturaOndaSalva);
    }

    public void AtualizarAlturaOnda(double alturaOnda)
    {
        // Verifica se o componente TextMeshProUGUI est� atribu�do
        if (alturaOndaText != null)
        {
            // Exibe a altura da onda formatada com uma casa decimal
            alturaOndaText.text = alturaOnda.ToString("F1");
            Debug.Log($"Altura da Onda Atualizada: {alturaOnda}");
        }
        else
        {
            Debug.LogError("O componente TextMeshProUGUI 'alturaOndaText' n�o est� atribu�do.");
        }
    }
}
