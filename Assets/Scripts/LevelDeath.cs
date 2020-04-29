using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelDeath : MonoBehaviour
{

    public GameObject levelAudio;
    public GameObject fadeOut;

    void OnTriggerEnter()
    {
        StartCoroutine(YouFellOff());
    }

    IEnumerator YouFellOff()
    {
        levelAudio.SetActive(false);
        yield return new WaitForSeconds(0.25f);
        fadeOut.SetActive(true);
        yield return new WaitForSeconds(0.25f);
        GlobalScore.currentScore = 0;
        SceneManager.LoadScene(RedirectToLevel.redirectToLevel);
    }
}
