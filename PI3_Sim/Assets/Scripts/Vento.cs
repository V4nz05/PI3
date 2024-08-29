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

        // Atualiza o TextMeshProUGUI com a velocidade do vento
        AtualizarVento(ventoSalvo);
    }

    public void AtualizarVento(double vento)
    {
        // Verifica se o componente TextMeshProUGUI est� atribu�do
        if (velocidadeVento != null)
        {
            // Exibe a velocidade do vento formatada com uma casa decimal
            velocidadeVento.text = vento.ToString("F1");
            Debug.Log($"Velocidade do Vento Atualizada: {vento}");
        }
        else
        {
            Debug.LogError("O componente TextMeshProUGUI 'velocidadeVento' n�o est� atribu�do.");
        }
    }
}
