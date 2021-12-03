using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMovement : MonoBehaviour
{
    Vector3 here;
    Vector3 there;
    Rigidbody r;
    float phase = 0;
    public float speed = 1;
    float phaseDir = 1;
    public float direction = -12f;
    public bool balloonfloat = false;

    private void Start()
    {
        r = GetComponent<Rigidbody>();
        here = transform.position;
        there = transform.position + new Vector3(direction, 0f, 0f);
    }

    private void FixedUpdate()
    {
        if (balloonfloat)
        {
            
            r.AddForce(Vector3.up * 10f);

        }    
    }

    // Update is called once per frame
    void Update()
    {
        if (!balloonfloat)
        {
            transform.position = Vector3.Lerp(here, there, phase);

            phase += Time.deltaTime * speed * phaseDir;

            if (phase >= 1 || phase <= 0)
            {
                phaseDir *= -1;
            }
        }
        
    }

    private void OnTransformChildrenChanged()
    {
        r.constraints = RigidbodyConstraints.None;
        r.velocity = Vector3.zero;
    }
}
