using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DirecaoVento : MonoBehaviour
{
    // Referência ao componente de texto da UI (Text ou TextMeshProUGUI)
    public Text uiText;
    public TextMeshProUGUI uiTextMeshPro;

    // Referência ao script que contém o valor 'direcaoVentoSalva'
    private Program program;

    void Start()
    {
        // Encontra o GameObject que tem o script 'Program' e obtém o componente
        program = FindObjectOfType<Program>();

        if (program != null)
        {
            // Inscreve-se no evento para ser notificado quando os dados estiverem disponíveis
            program.OnDataAvailable += OnDataAvailable;
        }
        else
        {
            Debug.LogError("Não foi possível encontrar o script 'Program' na cena.");
        }
    }

    void OnDataAvailable(object sender, Dados dados)
    {
        // Verifica se os dados necessários estão disponíveis
        if (program != null && program.dados.OndaRoot != null && program.dados.OndaRoot.Ondas != null && program.dados.OndaRoot.Ondas.Count > 0 && program.dados.OndaRoot.Ondas[0].DadosOndas != null && program.dados.OndaRoot.Ondas[0].DadosOndas.Count > 0)
        {
            string direcaoVento = program.dados.OndaRoot.Ondas[0].DadosOndas[0].DirecaoVento;

            // Atualiza o texto da UI
            if (uiText != null)
            {
                uiText.text = "Direção do Vento: " + direcaoVento;
            }
            else if (uiTextMeshPro != null)
            {
                uiTextMeshPro.text = "Direção do Vento: " + direcaoVento;
            }
            else
            {
                Debug.LogError("Referência ao componente de texto da UI não foi atribuída.");
            }
        }
        else
        {
            Debug.LogError("Os dados de ondas não estão disponíveis ou não estão no formato esperado.");
        }
    }

    void OnDestroy()
    {
        // Desinscreve-se do evento quando o objeto for destruído para evitar erros de referência nula
        if (program != null)
        {
            program.OnDataAvailable -= OnDataAvailable;
        }
    }
}
