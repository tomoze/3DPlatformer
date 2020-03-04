using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashToMenu : MonoBehaviour
{

    public GameObject Logo;
    public GameObject Text;

    void Start()
    {
        StartCoroutine(RunSplash());
    }

    IEnumerator RunSplash()
    {
        yield return new WaitForSeconds(0.5f);
        Logo.SetActive(true);
        Text.SetActive(true);
        yield return new WaitForSeconds(3.75f);
        SceneManager.LoadScene(1);
    }
}
