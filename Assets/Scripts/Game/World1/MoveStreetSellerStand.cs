using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveStreetSellerStand : MonoBehaviour
{
    public bool directionForward;
    Vector3 initialPos;
    float maxMovement = 10f;

    // Start is called before the first frame update
    void Start()
    {
        initialPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void MoveStand()
    {
        if (directionForward)
        {
            transform.Translate(Vector3.forward * Time.deltaTime);
            if (Vector3.Distance(transform.position, initialPos) >= maxMovement)
                directionForward = false;
        }
        else
        {
            transform.Translate(Vector3.back * Time.deltaTime);
            if (Vector3.Distance(transform.position, initialPos) <= 0.0f)
                directionForward = true;
        }


    }
}
