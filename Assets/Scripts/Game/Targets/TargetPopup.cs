using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPopup : MonoBehaviour
{
    Rigidbody r;
    HingeJoint hinge;
    public AudioSource hit;
    public float forceStrength = 0.5f;
    bool popup = false;
    bool isDown = true;

    // Start is called before the first frame update
    void Start()
    {
        r = GetComponent<Rigidbody>();
        hinge = GetComponent<HingeJoint>();
        float rand = Random.Range(2f, 10f);
        Invoke("Popup", rand);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (popup && isDown)
        {
            JointMotor motor = hinge.motor;
            motor.force = 10;
            motor.targetVelocity = 30;
            motor.freeSpin = false;
            hinge.motor = motor;
        }
        else
        {
            JointMotor motor = hinge.motor;
            motor.force = 0;
            motor.targetVelocity = 0;
            motor.freeSpin = false;
            hinge.motor = motor;
        }
        
    }

    private void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            Debug.Log(isDown);
            GameManager.Instance.hitSquareTarget.Play();
            float rand = Random.Range(2f, 10f);
            isDown = true;
            popup = false;
            Invoke("Popup", rand);
        }
    }

    void Popup()
    {
        
         popup = true;
     


    }
}
