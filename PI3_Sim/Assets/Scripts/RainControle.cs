using PI3_Sim.Classes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class RainControle : MonoBehaviour
{
    // Refer�ncia ao sistema de part�culas da chuva ou ao objeto que representa a chuva na cena
    public GameObject chuvaParticleSystem;

    // Vari�vel p�blica para controle manual, vis�vel no Inspector
    public bool manualControl = false;

    private Clima climaobj;

    void Start()
    {
        // Inicializa o objeto Clima
        climaobj = new Clima();
        // Adiciona uma mensagem de depura��o para garantir que o Start() � chamado
        Debug.Log("Script iniciado. Clima e controle manual configurados.");
    }

    void Update()
    {
        // Verifica se o controle manual est� ativado ou se a condi��o � igual a "c" (chuva)
        if (manualControl || climaobj.Condicao == "c")
        {
            // Ativa o sistema de part�culas de chuva
            if (!chuvaParticleSystem.activeSelf)  // Verifica se j� est� ativado
            {
                chuvaParticleSystem.SetActive(true);
                Debug.Log("Chuva ativada");
            }
        }
        else
        {
            // Desativa o sistema de part�culas de chuva
            if (chuvaParticleSystem.activeSelf)  // Verifica se j� est� desativado
            {
                chuvaParticleSystem.SetActive(false);
                Debug.Log("Chuva desativada");
            }
        }
    }
}
