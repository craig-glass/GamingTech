using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeroGravity : MonoBehaviour
{
    [SerializeField]
    float speed = 10f;
    [SerializeField]
    bool xDirection, zDirection = false;
    [SerializeField]
    bool yDirection = true;

    private void OnTriggerEnter(Collider other)
    {
        if (yDirection)
        {
            Physics.gravity = new Vector3(0f, speed, 0f);
        }
        if (xDirection)
        {
            Physics.gravity = new Vector3(speed, 0f, 0f);
        }
        if (zDirection)
        {
            Physics.gravity = new Vector3(0f, 0f, speed);
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        Physics.gravity = new Vector3(0f, -9.8f, 0f);
    }

}
