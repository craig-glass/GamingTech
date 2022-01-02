using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    [SerializeField]
    float speed = 50f;
    [SerializeField]
    Rigidbody r;

    // Start is called before the first frame update
    void Start()
    {
        r = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        r.AddForce(transform.forward * speed * Time.deltaTime, ForceMode.Impulse);
        StartCoroutine(DestroyBullet());
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
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
       
    }


}
