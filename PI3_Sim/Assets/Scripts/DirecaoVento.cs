using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DirecaoVento : MonoBehaviour
{
    // Refer�ncia ao componente de texto da UI (Text ou TextMeshProUGUI)
    public Text uiText;
    public TextMeshProUGUI uiTextMeshPro;

    // Refer�ncia ao script que cont�m o valor 'direcaoVentoSalva'
    private Program program;

    void Start()
    {
        // Encontra o GameObject que tem o script 'Program' e obt�m o componente
        program = FindObjectOfType<Program>();

        if (program != null)
        {
            // Inscreve-se no evento para ser notificado quando os dados estiverem dispon�veis
            program.OnDataAvailable += OnDataAvailable;
        }
        else
        {
            Debug.LogError("N�o foi poss�vel encontrar o script 'Program' na cena.");
        }
    }

    void OnDataAvailable(object sender, Dados dados)
    {
        // Verifica se os dados necess�rios est�o dispon�veis
        if (program != null && program.dados.OndaRoot != null && program.dados.OndaRoot.Ondas != null && program.dados.OndaRoot.Ondas.Count > 0 && program.dados.OndaRoot.Ondas[0].DadosOndas != null && program.dados.OndaRoot.Ondas[0].DadosOndas.Count > 0)
        {
            string direcaoVento = program.dados.OndaRoot.Ondas[0].DadosOndas[0].DirecaoVento;

            // Atualiza o texto da UI
            if (uiText != null)
            {
                uiText.text = "Dire��o do Vento: " + direcaoVento;
            }
            else if (uiTextMeshPro != null)
            {
                uiTextMeshPro.text = "Dire��o do Vento: " + direcaoVento;
            }
            else
            {
                Debug.LogError("Refer�ncia ao componente de texto da UI n�o foi atribu�da.");
            }
        }
        else
        {
            Debug.LogError("Os dados de ondas n�o est�o dispon�veis ou n�o est�o no formato esperado.");
        }
    }

    void OnDestroy()
    {
        // Desinscreve-se do evento quando o objeto for destru�do para evitar erros de refer�ncia nula
        if (program != null)
        {
            program.OnDataAvailable -= OnDataAvailable;
        }
    }
}
