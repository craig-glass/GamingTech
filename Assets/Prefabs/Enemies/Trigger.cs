using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    GameObject devilBulldog;
    DevilBulldogStateManager devilBulldogStateManager;

    private void Start()
    {
        
        devilBulldogStateManager = transform.parent.GetComponent<DevilBulldogStateManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!devilBulldogStateManager.eat)
        {
            if (other.gameObject.CompareTag("ham"))
            {
                Debug.Log("eat the ham");
                devilBulldogStateManager.eat = true;
                devilBulldogStateManager.ham = other.gameObject;
            }
        }
        if (other.gameObject.CompareTag("Player"))
        {
            devilBulldogStateManager.chase = true;
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("ham"))
        {
            Debug.Log("leave ham");
            devilBulldogStateManager.eat = false;
            devilBulldogStateManager.ham = null;
        }
        if (other.gameObject.CompareTag("Player"))
        {
            devilBulldogStateManager.chase = false;
        }
    }

}
