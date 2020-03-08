using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SplashToMenu : MonoBehaviour
{

    public GameObject Logo;
    public GameObject Text;
    public GameObject BG;

    void Start()
    {
        StartCoroutine(RunSplash());
    }

    IEnumerator RunSplash()
    {
        yield return new WaitForSeconds(0.75f);
        //FadeIn();
        Logo.SetActive(true);
        Text.SetActive(true);
        BG.SetActive(true);
        yield return new WaitForSeconds(2.25f);
        SceneManager.LoadScene(1);
    }

    //void FadeIn()
    //{
    //    BG.CrossFadeAlpha(1.0f, 1.5f, false);
    //}
}
