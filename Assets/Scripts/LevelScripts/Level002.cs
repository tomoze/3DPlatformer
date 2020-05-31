using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level002 : MonoBehaviour
{

    public GameObject fadeIn;

    void Start()
    {
        RedirectToLevel.redirectToLevel = 6;
        PlayerPrefs.SetInt("LevelIndex", RedirectToLevel.redirectToLevel);
        StartCoroutine(FadeInOff());
    }

    IEnumerator FadeInOff()
    {
        yield return new WaitForSeconds(1);
        fadeIn.SetActive(false);
    }

}
