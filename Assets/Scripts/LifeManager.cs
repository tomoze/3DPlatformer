using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour
{
    public int startingLives;
    private int lifeCounter;

    private Text theText;

    public GameObject gameOverScreen;

    public PlayerController player;

    public float waitAfterGameOver;

    public GameObject levelMusic;

    public GameObject[] icon;


    // Start is called before the first frame update
    void Start()
    {
        int mat = PlayerPrefs.GetInt("CharacterSelected");
        theText = GetComponent<Text>();

        lifeCounter = startingLives;

        player = FindObjectOfType<PlayerController>();

        if (mat == 0)
            icon[0].SetActive(true);
        else icon[1].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (lifeCounter == 0)
        {
            gameOverScreen.SetActive(true);
            player.gameObject.SetActive(false);
            levelMusic.SetActive(false);
        }

        theText.text = "x" + lifeCounter;

        if(gameOverScreen.activeSelf)
        {
            waitAfterGameOver -= Time.deltaTime;
        }
        if(waitAfterGameOver < 0)
        {
            SceneManager.LoadScene(0);
        }
    }

    public void GiveLife()
    {
        lifeCounter++;
    }

    public void TakeLife()
    {
        lifeCounter--;
    }
}
