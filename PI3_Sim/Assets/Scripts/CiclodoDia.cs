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
    [SerializeField][Tooltip("Dura��o do dia em segundos")] private int duracaoDoDia = 86400; // Default to 24 hours
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
        // Progresso do dia em rela��o ao ciclo de 24 horas
        float progressoDoDia = segundos / 86400f;

        // Calcula o �ngulo de rota��o para o sol com base no progresso do dia
        float rotacaoX = Mathf.Lerp(-90f, 270f, progressoDoDia);

        // Define a rota��o da luz direcional
        luzDirecional.rotation = Quaternion.Euler(rotacaoX, 179, 0); // Ajuste do eixo Y para criar movimento mais natural

        // Ajuste do �ngulo de inclina��o do sol ao longo do dia para corresponder melhor ao ciclo diurno
        // Um ajuste poss�vel: luzDirecional.rotation = Quaternion.Euler(rotacaoX, luzDirecional.rotation.eulerAngles.y, luzDirecional.rotation.eulerAngles.z);
    }

    private void ExibirHorarioBrasilia()
    {
        // Obt�m o hor�rio atual em Bras�lia
        DateTime horarioBrasilia = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, tzBrasilia);

        // Exibe o hor�rio atual em Bras�lia
        horarioText.text = horarioBrasilia.ToString("HH:mm");
    }

    private void AtualizarMultiplicador()
    {
        multiplicador = 86400f / duracaoDoDia;
    }

    // Esta fun��o pode ser chamada para alterar a dura��o do dia dinamicamente
    public void SetDuracaoDoDia(int novaDuracaoDoDia)
    {
        duracaoDoDia = novaDuracaoDoDia;
        AtualizarMultiplicador();
    }
}
