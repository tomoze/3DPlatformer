﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float rotateSpeed;
    public Transform pivot;
    public float maxViewAngle;
    public float minViewAngle;
    bool pause;

    // Start is called before the first frame update
    void Start()
    {
        offset = target.position - transform.position;

        pivot.transform.position = target.transform.position;
        pivot.transform.parent = target.transform;

        Cursor.lockState = CursorLockMode.Locked;
    }



    // Update is called once per frame
    void LateUpdate()
    {
            float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
            target.Rotate(0, horizontal, 0);

            float vertical = Input.GetAxis("Mouse Y") * rotateSpeed;
            pivot.Rotate(-vertical, 0, 0);

            //Limit up/down camera rotation
            if (pivot.rotation.eulerAngles.x > maxViewAngle && pivot.rotation.eulerAngles.x < 180f)
            {
                pivot.rotation = Quaternion.Euler(maxViewAngle, 0, 0);
            }

            if (pivot.rotation.eulerAngles.x > 180 && pivot.rotation.eulerAngles.x < minViewAngle)
            {
                pivot.rotation = Quaternion.Euler(306f + minViewAngle, 0, 0);
            }

            float desiredYAngle = target.eulerAngles.y;
            float desiredXAngle = pivot.eulerAngles.x;

            Quaternion rotation = Quaternion.Euler(desiredXAngle, desiredYAngle, 0);
            transform.position = target.position - (rotation * offset);

            //transform.position = target.position - offset;
            transform.LookAt(target);

            if (transform.position.y < target.position.y)
            {
                transform.position = new Vector3(transform.position.x, target.position.y, transform.position.z);
            }
    }
}
