using TMPro;
using UnityEngine;

public class Vento : MonoBehaviour
{
    public TextMeshProUGUI velocidadeVento; // Refer�ncia ao TextMeshProUGUI na cena para exibir a velocidade do vento
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
        // Acessando ventoSalvo a partir da inst�ncia de dados dentro de program
        double ventoSalvo = program.dados.ventoSalvo;
        AtualizarVento(ventoSalvo);
    }

    public void AtualizarVento(double vento)
    {
        Debug.Log($"Velocidade do Vento Calculada: {vento}");
        velocidadeVento.text = vento.ToString("F1"); // Formata com uma casa decimal
    }
}
