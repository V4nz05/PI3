using PI3_Sim.Classes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class RainControle : MonoBehaviour
{
    // Referência ao sistema de partículas da chuva ou ao objeto que representa a chuva na cena
    public GameObject chuvaParticleSystem;
    private Clima climaobj;

    void Start()
    {
        // Inicializa o objeto Clima
        climaobj = new Clima();
    }

    void Update()
    {
        // Verifica se a condição é igual a "c" (chuva, por exemplo)
        if (climaobj.Condicao == "c")
        {
            // Ativa o sistema de partículas de chuva
            chuvaParticleSystem.SetActive(true);
            Debug.Log("Chuva ativada");
        }
        else
        {
            // Desativa o sistema de partículas de chuva
            chuvaParticleSystem.SetActive(false);
            Debug.Log("Chuva desativada");
        }
    }
}
