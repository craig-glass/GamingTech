using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice : MonoBehaviour
{
    [SerializeField]
    float speed = 400f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Physics.gravity = new Vector3(0f, -speed, 0f);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        Physics.gravity = new Vector3(0f, -9.8f, 0f);
    }
}
