﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalTimer : MonoBehaviour
{
    public GameObject timeDisplay;
    public bool eina = false;
    public int sekundes = 10;
    public static int extendScore;


    void Update()
    {
        extendScore = sekundes;

        if (eina == false)
        {
            StartCoroutine(atimtiSekunde());
        }

    }

    IEnumerator atimtiSekunde()
    {
        eina = true;
        sekundes -= 1;
        timeDisplay.GetComponent<Text>().text = "" + sekundes;
        yield return new WaitForSeconds(1);
        eina = false;
    }
}
