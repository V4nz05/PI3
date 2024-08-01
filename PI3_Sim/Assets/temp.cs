using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using PI3_Sim.Classes;

public class temp : MonoBehaviour
{
    public TextMeshProUGUI temperatura;

    private Clima climaobj;

    private int max;
    private int min;

    void Start()
    {
        // Inicializa o objeto Clima
        climaobj = new Clima();

        // Verifique se Max e Min est�o sendo inicializados corretamente
        max = climaobj.Max;
        min = climaobj.Min;

        // Adicione logs para verificar os valores de Max e Min
        Debug.Log($"Max: {max}, Min: {min}");

        // Calcular a temperatura m�dia como double
        double tempera = (double)(max + min) / 2;

        // Converter para string e exibir na UI
        temperatura.text = tempera.ToString("F1"); // Formata com uma casa decimal
    }

    void Update()
    {
        // L�gica do Update se necess�rio
    }
}
