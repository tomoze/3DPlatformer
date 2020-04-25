using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemRotate : MonoBehaviour
{
    public int RotateSpeed = 2;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, RotateSpeed * Time.timeScale, 0, Space.World);
    }
}
