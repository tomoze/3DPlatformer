using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RedirectToLevel : MonoBehaviour
{

    public static int redirectToLevel;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if(redirectToLevel == 3)
        SceneManager.LoadScene(redirectToLevel);
        if (redirectToLevel == 4)
        SceneManager.LoadScene(redirectToLevel);
    }
}
