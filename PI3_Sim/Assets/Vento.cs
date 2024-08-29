using TMPro;
using UnityEngine;

public class AlturaOnda : MonoBehaviour
{
    public TextMeshProUGUI temperatura; // Refer�ncia ao TextMeshProUGUI na cena
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
        Debug.Log($"Altura da Onda Calculada: {alturaOnda}");
        temperatura.text = alturaOnda.ToString("F1"); // Formata com uma casa decimal
    }
}
