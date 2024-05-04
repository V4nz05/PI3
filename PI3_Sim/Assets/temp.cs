using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using PI3_Sim.Classes;

public class temp : MonoBehaviour
{
    public TextMeshProUGUI temperatura;

    Clima climaobj;

    int max;
    int min;

    void Start()
    {

        climaobj = new Clima();

        max = climaobj.Max;
        min = climaobj.Min;

        double tempera =(double)(max + min) / 2;

        temperatura.text = tempera.ToString();
    }

    // Update is called once per frame
    void Update()
    {
       
        
    }
}
