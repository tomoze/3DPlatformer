using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelDeath : MonoBehaviour
{
    bool death = true;
    public PlayerController thePlayer;
    public GameObject levelAudio;
    public GameObject fadeOut;

    private LifeManager lifeSystem;
    private Vector3 respawnPoint;
    //public HealthBar healthBar;

    private HealthManager health;

    void Start()
    {
        respawnPoint = thePlayer.transform.position;
    }

    void OnTriggerEnter()
    {
        StartCoroutine(YouFellOff());
    }

    IEnumerator YouFellOff()
    {
        levelAudio.SetActive(false);
        if (death)
        {
            lifeSystem = FindObjectOfType<LifeManager>();
            lifeSystem.TakeLife();
            death = false;
        }
        yield return new WaitForSeconds(0.25f);
        fadeOut.SetActive(true);
        yield return new WaitForSeconds(0.75f);
        fadeOut.SetActive(false);
        levelAudio.SetActive(true);
        GlobalScore.currentScore = 0;
        thePlayer.transform.position = respawnPoint;
        health = FindObjectOfType<HealthManager>();
        health.currentHealth = health.maxHealth;
        health.healthBar.SetHealth(health.maxHealth);
        death = true;
        for (int i = 0; i < health.items.childCount; i++)
            health.items.GetChild(i).gameObject.SetActive(true);
        //SceneManager.LoadScene(RedirectToLevel.redirectToLevel);
    }

    public void SetSpawn(Vector3 newPosition)
    {
        respawnPoint = newPosition;
    }
}
