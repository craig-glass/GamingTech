using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveStreetSellerStand : MonoBehaviour
{
    public bool directionForward;
    Vector3 initialPos;
    float maxMovement = 10f;
    bool readyToMove = false;
    public PedestrianSpawn[] pedestrianSpawnpoints;

    // Start is called before the first frame update
    void Start()
    {
        initialPos = transform.position;
        Invoke("GetReady", 10);
    }

    // Update is called once per frame
    void Update()
    {
        if (readyToMove)
        {
            MoveStand();
        }
       
    }

    void MoveStand()
    {

        if (directionForward)
        {
            transform.Translate(Vector3.forward * Time.deltaTime);
            if (Vector3.Distance(transform.position, initialPos) >= maxMovement)
            {
                directionForward = false;
                readyToMove = false;
                Invoke("GetReady", Random.Range(20, 40));
            }
        }
        else
        {
            transform.Translate(Vector3.back * Time.deltaTime);
            if (Vector3.Distance(transform.position, initialPos) <= maxMovement)
            {
                directionForward = true;
                readyToMove = false;
                Invoke("GetReady", Random.Range(20, 40));
            }

        }


    }

   void GetReady()
    {
        readyToMove = !readyToMove;
    }
}
