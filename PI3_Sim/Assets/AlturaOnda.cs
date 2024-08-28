//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using static UnityEditor.Experimental.GraphView.GraphView;

////public class AlturaOnda : MonoBehaviour
//{
//    public GameObject oceanObject; // Referência ao objeto de oceano
//    private WaterSurface oceanComponent;  // Referência ao componente específico de oceano
//    public float waveHeight = 1.0f; // Altura da onda ajustável

//    void Start()
//    {
//        // Obtendo o componente de oceano do objeto especificado
//        oceanComponent = oceanObject.GetComponent<Ocean>();

//        if (oceanComponent == null)
//        {
//            Debug.LogError("Componente Ocean não encontrado no objeto especificado.");
//        }
//    }

//    void Update()
//    {
//        // Atualiza a altura da onda continuamente
//        UpdateWaveHeight();
//    }

//    void UpdateWaveHeight()
//    {
//        if (oceanComponent != null)
//        {
//            // Exemplo de como você pode atualizar a altura da onda
//            // As propriedades reais que você precisa ajustar podem variar dependendo do pacote de oceano que você está usando
//            oceanComponent.SetWaveHeight(waveHeight); // Este é um exemplo genérico; ajuste conforme a API do asset de oceano que você está usando.
//        }
//    }
//}