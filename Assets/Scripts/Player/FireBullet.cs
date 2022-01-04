using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    [SerializeField]
    float speed = 300f;
    [SerializeField]
    public GameObject bulletPrefab;
    public ParticleSystem muzzleFlash;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            Instantiate(bulletPrefab, transform.position, transform.rotation, transform);
            muzzleFlash.Play();
        }
    }




}
