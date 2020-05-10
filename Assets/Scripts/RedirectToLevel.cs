using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RedirectToLevel : MonoBehaviour
{

    public static int redirectToLevel;

    // Update is called once per frame
    void Update()
    {
        if(redirectToLevel == 4)
        SceneManager.LoadScene(redirectToLevel);
        if (redirectToLevel == 5)
        SceneManager.LoadScene(redirectToLevel);
    }
}
