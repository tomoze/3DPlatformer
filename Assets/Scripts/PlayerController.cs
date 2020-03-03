using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;
    public CharacterController controller;
    public float jumpForce;

    private Vector3 moveDirection;
    public float gravityScale;

    // Start is called before the first frame update
    void Start()
    {
        //theRB = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //theRB.velocity = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, theRB.velocity.y, Input.GetAxis("Vertical") * moveSpeed);
        
        //if(Input.GetButtonDown("Jump"))
        //{
        //    //theRB.velocity = new Vector3(theRB.velocity.x, jumpForce, theRB.velocity.z);
        //}

        moveDirection = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, 0f, Input.GetAxis("Vertical") * moveSpeed);
        if (Input.GetButtonDown("Jump"))
        {
            moveDirection.y = jumpForce;
            //theRB.velocity = new Vector3(theRB.velocity.x, jumpForce, theRB.velocity.z);
        }

        moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale);
        controller.Move(moveDirection * Time.deltaTime);
    }
}
