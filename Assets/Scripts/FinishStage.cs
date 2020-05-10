using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinishStage : MonoBehaviour
{
    public GameObject levelMusic;
    public AudioSource levelComplete;
    public GameObject levelTimer;
    public GameObject timeLeft;
    public GameObject theScore;
    public GameObject totalScore;
    public GameObject timeLeftSh;
    public GameObject theScoreSh;
    public GameObject totalScoreSh;
    public GameObject EndScreen;

    public GameObject RankA;
    public GameObject RankB;
    public GameObject RankC;

    public int timeCalc;
    public int scoreCalc;
    public int totalScored;
    public GameObject levelBlocker;

    public GameObject fadeOut;

    private void OnTriggerEnter(Collider other)
    {
        GetComponent<BoxCollider>().enabled = false;
        levelBlocker.SetActive(true);
        levelBlocker.transform.parent = null;
        timeCalc = GlobalTimer.extendScore * 100;
        timeLeft.GetComponent<Text>().text = GlobalTimer.extendScore + " x 100";
        timeLeftSh.GetComponent<Text>().text = GlobalTimer.extendScore + " x 100";
        theScore.GetComponent<Text>().text = "" + GlobalScore.currentScore;
        theScoreSh.GetComponent<Text>().text = "" + GlobalScore.currentScore;
        totalScored = GlobalScore.currentScore + timeCalc;
        totalScore.GetComponent<Text>().text = "" + totalScored;
        totalScoreSh.GetComponent<Text>().text = "" + totalScored;
        PlayerPrefs.SetInt("LevelScore", totalScored);
        levelMusic.SetActive(false);
        levelTimer.SetActive(false);
        levelComplete.Play();
        StartCoroutine(CalculateScore());
        //PlayerPrefs.SetInt("LevelIndex", RedirectToLevel.redirectToLevel + 1);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    IEnumerator CalculateScore()
    {
        EndScreen.SetActive(true);
        yield return new WaitForSeconds(0.25f);
        timeLeft.SetActive(true);
        timeLeftSh.SetActive(true);
        yield return new WaitForSeconds(0.25f);
        theScore.SetActive(true);
        theScoreSh.SetActive(true);
        yield return new WaitForSeconds(0.25f);
        totalScore.SetActive(true);
        totalScoreSh.SetActive(true);
        yield return new WaitForSeconds(0.25f);
        if (totalScored >= 10000)
            RankA.SetActive(true);
        else if (totalScored >= 5000)
            RankB.SetActive(true);
        else RankC.SetActive(true);
        yield return new WaitForSeconds(1);
        fadeOut.SetActive(true);
        yield return new WaitForSeconds(0.25f);
        GlobalScore.currentScore = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
