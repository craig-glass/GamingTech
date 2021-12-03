using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround : MonoBehaviour
{
    [SerializeField]
    GameObject sphere;
    [SerializeField]
    float speed = 50f;

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(sphere.transform.position, Vector3.up, speed * Time.deltaTime);
    }

   
}
