using PI3_Sim.Classes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class RainControle : MonoBehaviour
{
    // Referência ao sistema de partículas da chuva ou ao objeto que representa a chuva na cena
    public GameObject chuvaParticleSystem;

    // Variável pública para controle manual, visível no Inspector
    public bool manualControl = false;

    private Clima climaobj;

    void Start()
    {
        // Inicializa o objeto Clima
        climaobj = new Clima();
        // Adiciona uma mensagem de depuração para garantir que o Start() é chamado
        Debug.Log("Script iniciado. Clima e controle manual configurados.");
    }

    void Update()
    {
        // Verifica se o controle manual está ativado ou se a condição é igual a "c" (chuva)
        if (manualControl || climaobj.Condicao == "c")
        {
            // Ativa o sistema de partículas de chuva
            if (!chuvaParticleSystem.activeSelf)  // Verifica se já está ativado
            {
                chuvaParticleSystem.SetActive(true);
                Debug.Log("Chuva ativada");
            }
        }
        else
        {
            // Desativa o sistema de partículas de chuva
            if (chuvaParticleSystem.activeSelf)  // Verifica se já está desativado
            {
                chuvaParticleSystem.SetActive(false);
                Debug.Log("Chuva desativada");
            }
        }
    }
}
