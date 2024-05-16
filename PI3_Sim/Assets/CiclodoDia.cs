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
        float rotacaoX = Mathf.Lerp(-90, 270, segundos / 86400f);
        luzDirecional.rotation = Quaternion.Euler(rotacaoX, 0, 0);
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

    // This function can be called to change the duration of the day dynamically
    public void SetDuracaoDoDia(int novaDuracaoDoDia)
    {
        duracaoDoDia = novaDuracaoDoDia;
        AtualizarMultiplicador();
    }
}