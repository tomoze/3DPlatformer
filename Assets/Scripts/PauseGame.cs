using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PauseGame : MonoBehaviour
{
    public bool gamePaused = false;
    public AudioSource levelMusic;
    public GameObject pauseMenu;
    public GameObject CameraStop;
    //bool leavestate;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if(gamePaused == false)
            {

                Cursor.visible = true;
                CameraStop.GetComponent<CameraController>().enabled = false;
                Cursor.lockState = CursorLockMode.Confined;
                pauseMenu.SetActive(true);
                Time.timeScale = 0;
                gamePaused = true;
                levelMusic.Pause();
            }
            else
            {

                CameraStop.GetComponent<CameraController>().enabled = true;
                Cursor.lockState = CursorLockMode.Confined;
                pauseMenu.SetActive(false);
                levelMusic.UnPause();
                Cursor.visible = false;
                gamePaused = false;
                Time.timeScale = 1;
            }
        }
    }


    public void ResumeGame()
    {
        CameraStop.GetComponent<CameraController>().enabled = true;
        Cursor.lockState = CursorLockMode.Confined;
        pauseMenu.SetActive(false);
        levelMusic.UnPause();
        Cursor.visible = false;
        gamePaused = false;
        Time.timeScale = 1;
    }

    public void RestartLevel()
    {
        CameraStop.GetComponent<CameraController>().enabled = true;
        Cursor.lockState = CursorLockMode.Confined;
        pauseMenu.SetActive(false);
        levelMusic.UnPause();
        Cursor.visible = false;
        gamePaused = false;
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitToMenu()
    {
        pauseMenu.SetActive(false);
        levelMusic.UnPause();
        Cursor.visible = false;
        gamePaused = false;
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
        Cursor.visible = true;
    }
}
