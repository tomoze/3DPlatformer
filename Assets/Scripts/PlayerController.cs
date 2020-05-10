using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Material[] material;
    Renderer rend;
    

    public float moveSpeed;
    public CharacterController controller;
    public float jumpForce;

    private Vector3 moveDirection;
    public float gravityScale;

    public float knockBackForce;
    public float knockBackTime;
    private float knockBackCounter;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        Scene scene = SceneManager.GetActiveScene();
        int mat = PlayerPrefs.GetInt("CharacterSelected");
        if (scene.name != "CharacterSelection")
        {
            rend = GetComponent<Renderer>();
            rend.sharedMaterial = material[mat];
        }

    }

    // Update is called once per frame
    void Update()
    {

        if(knockBackCounter <= 0)
        {
            float yStore = moveDirection.y;
            moveDirection = (transform.forward * Input.GetAxisRaw("Vertical")) + (transform.right * Input.GetAxisRaw("Horizontal"));
            moveDirection = moveDirection.normalized * moveSpeed;
            moveDirection.y = yStore;

            if (controller.isGrounded)
            {
                moveDirection.y = 0f;
                if (Input.GetButtonDown("Jump"))
                {
                    moveDirection.y = jumpForce;
                }
            }

            
        }
        else
        {
            knockBackCounter -= Time.deltaTime;
        }

        //moveDirection = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, moveDirection.y, Input.GetAxis("Vertical") * moveSpeed);


        moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale * Time.deltaTime);
        controller.Move(moveDirection * Time.deltaTime);
    }

    public void KnockBack(Vector3 direction)
    {
        knockBackCounter = knockBackTime;
        //direction = new Vector3(1f, 1f, 1f);
        moveDirection = direction * knockBackForce;
        moveDirection.y = knockBackForce;
    }
}
