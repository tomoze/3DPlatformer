using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;

    public PlayerController thePlayer;

    public float invincibilityLength;
    private float invincibilityCounter;

    public Renderer playerRend;
    private float flashCounter;
    public float flashLength = 0.1f;

    private bool isRespawning;
    private Vector3 respawnPoint;
    public float respawnLength;

    public GameObject fadeOut;
    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;

        //thePlayer = FindObjectOfType<PlayerController>();

        respawnPoint = thePlayer.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(invincibilityCounter > 0)
        {
            invincibilityCounter -= Time.deltaTime;

            flashCounter -= Time.deltaTime;
            if(flashCounter <= 0)
            {
                playerRend.enabled = !playerRend.enabled;
                flashCounter = flashLength;
            }

            if(invincibilityCounter <= 0)
            {
                playerRend.enabled = true;
            }
        }
    }

    public void HurtPlayer(int damage, Vector3 direct)
    {
        if (invincibilityCounter <= 0)
        {
            currentHealth -= damage;
            //if (currentHealth < 0)
            //    currentHealth = 0;

            if(currentHealth <= 0)
            {
                Respawn();
            }

            else
            {
                thePlayer.KnockBack(direct);

                invincibilityCounter = invincibilityLength;

                playerRend.enabled = false;

                flashCounter = flashLength;
            }     
        }        
    }

    public void Respawn()
    {
        //GameObject player = GameObject.Find("Player");
        //CharacterController charController = player.GetComponent<CharacterController>();
        //charController.enabled = false;
        //thePlayer.transform.position = respawnPoint;
        //currentHealth = maxHealth;
        //charController.enabled = true;

        if(!isRespawning)
        StartCoroutine("RespawnCo");
    }

    public IEnumerator RespawnCo()
    {
        isRespawning = true;
        thePlayer.gameObject.SetActive(false);

        yield return new WaitForSeconds(respawnLength);
        isRespawning = false;

        fadeOut.SetActive(true);
        yield return new WaitForSeconds(1f);
        thePlayer.gameObject.SetActive(true);
        GameObject player = GameObject.Find("Player");
        CharacterController charController = player.GetComponent<CharacterController>();
        charController.enabled = false;
        thePlayer.transform.position = respawnPoint;
        currentHealth = maxHealth;
        charController.enabled = true;
        fadeOut.SetActive(false);

        invincibilityCounter = invincibilityLength;
        playerRend.enabled = false;
        flashCounter = flashLength;
    }

    public void HealPlayer(int healAmount)
    {
        currentHealth += healAmount;

        if (currentHealth > maxHealth)
            currentHealth = maxHealth;
    }

    public void SetSpawnPoint(Vector3 newPosition)
    {
        respawnPoint = newPosition;
    }
}
