using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    float speed = 50f;
    public Rigidbody r;

    private void Start()
    {
        StartCoroutine("DestroyBullet");
    }
    private void FixedUpdate()
    {
        r.AddForce(transform.forward * speed, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {        
        if (collision.gameObject.CompareTag("devilbulldog"))
        {
            Debug.Log("................................");
        }
        Destroy(gameObject);        
    }

    IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }

}
