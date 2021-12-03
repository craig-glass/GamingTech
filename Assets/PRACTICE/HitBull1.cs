using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBull1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered");
        if (other.gameObject.CompareTag("bullet"))
        {
            Debug.Log("hit bull 1");
        }
    }
}
