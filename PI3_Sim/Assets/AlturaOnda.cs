//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using static UnityEditor.Experimental.GraphView.GraphView;

////public class AlturaOnda : MonoBehaviour
//{
//    public GameObject oceanObject; // Refer�ncia ao objeto de oceano
//    private WaterSurface oceanComponent;  // Refer�ncia ao componente espec�fico de oceano
//    public float waveHeight = 1.0f; // Altura da onda ajust�vel

//    void Start()
//    {
//        // Obtendo o componente de oceano do objeto especificado
//        oceanComponent = oceanObject.GetComponent<Ocean>();

//        if (oceanComponent == null)
//        {
//            Debug.LogError("Componente Ocean n�o encontrado no objeto especificado.");
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
//            // Exemplo de como voc� pode atualizar a altura da onda
//            // As propriedades reais que voc� precisa ajustar podem variar dependendo do pacote de oceano que voc� est� usando
//            oceanComponent.SetWaveHeight(waveHeight); // Este � um exemplo gen�rico; ajuste conforme a API do asset de oceano que voc� est� usando.
//        }
//    }
//}