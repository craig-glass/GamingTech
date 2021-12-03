using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakJoint : MonoBehaviour
{
    Rigidbody r;
    TargetMovement balloonScript;

    // Start is called before the first frame update
    void Start()
    {
        balloonScript = transform.parent.gameObject.GetComponent<TargetMovement>();
        r = GetComponent<Rigidbody>();
    }

   

    private void OnJointBreak(float breakForce)
    {
        balloonScript.balloonfloat = true;
        r.freezeRotation = false;
        r.velocity = Vector3.zero;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            gameObject.transform.SetParent(null, true);
            transform.DetachChildren();
        }
        
    }

}
