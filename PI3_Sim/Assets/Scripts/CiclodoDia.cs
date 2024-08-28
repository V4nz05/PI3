using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Rendering;
using System.Runtime.CompilerServices;
using System;
public class CiclodoDia : MonoBehaviour
{
    [SerializeField] private Transform luzDirecional;
    [SerializeField][Tooltip("Duração do dia em segundos")] private int duracaoDoDia = 86400; // Default to 24 hours
    [SerializeField] private TextMeshProUGUI horarioText;

    

    private float segundos = 0f;
    private float multiplicador;
    private TimeZoneInfo tzBrasilia;

    void Start()
    {
        tzBrasilia = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");

        AtualizarMultiplicador();
        ExibirHorarioBrasilia();
    }

    // Update is called once per frame
    void Update()
    {
        segundos += Time.deltaTime * multiplicador;

        if (segundos >= 86400)
        {
            segundos -= 86400;
        }

        ProcessarCeu();
        ExibirHorarioBrasilia();
    }

    private void ProcessarCeu()
    {
        // Progresso do dia em relação ao ciclo de 24 horas
        float progressoDoDia = segundos / 86400f;

        // Calcula o ângulo de rotação para o sol com base no progresso do dia
        float rotacaoX = Mathf.Lerp(-90f, 270f, progressoDoDia);

        // Define a rotação da luz direcional
        luzDirecional.rotation = Quaternion.Euler(rotacaoX, 179, 0); // Ajuste do eixo Y para criar movimento mais natural

        // Ajuste do ângulo de inclinação do sol ao longo do dia para corresponder melhor ao ciclo diurno
        // Um ajuste possível: luzDirecional.rotation = Quaternion.Euler(rotacaoX, luzDirecional.rotation.eulerAngles.y, luzDirecional.rotation.eulerAngles.z);
    }

    private void ExibirHorarioBrasilia()
    {
        // Obtém o horário atual em Brasília
        DateTime horarioBrasilia = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, tzBrasilia);

        // Exibe o horário atual em Brasília
        horarioText.text = horarioBrasilia.ToString("HH:mm");
    }

    private void AtualizarMultiplicador()
    {
        multiplicador = 86400f / duracaoDoDia;
    }

    // Esta função pode ser chamada para alterar a duração do dia dinamicamente
    public void SetDuracaoDoDia(int novaDuracaoDoDia)
    {
        duracaoDoDia = novaDuracaoDoDia;
        AtualizarMultiplicador();
    }
}
