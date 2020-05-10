using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public int bestScore;
    public GameObject bestScoreDisplay;
    int stageIndex = 0;

    void Start()
    {
        bestScore = PlayerPrefs.GetInt("LevelScore");
        bestScoreDisplay.GetComponent<Text>().text = "High Score: " + bestScore;
    }

    public void Continue()
    {
        stageIndex = PlayerPrefs.GetInt("LevelIndex");
        SceneManager.LoadScene(stageIndex);
    }

    public void PlayGame()
    {
        RedirectToLevel.redirectToLevel = 4;
        SceneManager.LoadScene(2);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Reset()
    {
        PlayerPrefs.SetInt("LevelScore", 0);
        bestScoreDisplay.GetComponent<Text>().text = "High Score: " + 0;
    }
}
