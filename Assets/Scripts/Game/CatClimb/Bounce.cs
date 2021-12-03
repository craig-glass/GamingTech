using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    Rigidbody r;


    private void Start()
    {
        r = player.GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("entered collision");
            r.AddForce(0f, 100f, 0f, ForceMode.Impulse);
        }
    }
}
