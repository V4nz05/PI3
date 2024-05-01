using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Rendering;
using System.Runtime.CompilerServices;
using System;

public class CicloDN : MonoBehaviour
{
    [SerializeField] private Transform luzDirecional;
    [SerializeField][Tooltip("Duração do dia em segundos")] private int duracaoDoDia;
    [SerializeField] private TextMeshProUGUI horarioText;

    private float segundos;
    private float multiplicador;
    // Start is called before the first frame update
    void Start()
    {
        multiplicador = 86400 / duracaoDoDia;

    }

    // Update is called once per frame
    void Update()
    {
        segundos += Time.deltaTime * multiplicador;

        if (segundos >= 86400)
        {
            segundos = 0;
        }
        ProcessarCeu();
        CalcularHorario();

    }

    private void ProcessarCeu()
    {
        float rotacaoX = Mathf.Lerp(-90, 270, segundos / 86400);
        luzDirecional.rotation = Quaternion.Euler(rotacaoX, 0, 0);
    }

    private void CalcularHorario()
    {
        horarioText.text = TimeSpan.FromSeconds(segundos).ToString(@"hh\:mm");

    }
}
