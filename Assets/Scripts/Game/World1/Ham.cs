using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ham : MonoBehaviour
{
    Rigidbody r;
    GameObject holdHam, player;
    GameObject hamThrowDirection;
    Vector3 direction;
    Vector3 newPosition = new Vector3(0f, 0f, 0f);
    public bool canPickUp = false;
    PlayerStateManager playerStateManager;
    GameObject devilBulldog;
    public bool pickUpHam = false;
    BoxCollider collider;
    

    private void Start()
    {
        collider = GetComponent<BoxCollider>();
        r = GetComponent<Rigidbody>();
        holdHam = GameObject.Find("HoldHam");
        hamThrowDirection = GameObject.Find("HamThrowDirection");
        direction = hamThrowDirection.transform.position - transform.position;
        player = GameObject.Find("Player");
        playerStateManager = player.GetComponent<PlayerStateManager>();
    }

    private void FixedUpdate()
    {
        if (pickUpHam)
        {
            PickUpHam();
        }
    }

    private void Update()
    {
        CanPickUp();
    }

    public void ThrowHam()
    {
        if (playerStateManager.hamIsPickedUp)
        {
            StartCoroutine("ThrowIt");
        }
            
    }

    public IEnumerator ThrowIt()
    {
        r.isKinematic = false;
        yield return new WaitForSeconds(0.75f);
        r.AddForce(transform.forward * -10f, ForceMode.Impulse);
        r.useGravity = true;
        holdHam.transform.DetachChildren();        
        playerStateManager.hamIsPickedUp = false;

    }

    public void PickUpHam()
    {
        transform.parent = holdHam.transform;
        playerStateManager.hamIsPickedUp = true;
        r.useGravity = false;
        r.isKinematic = true;
        //Vector3()Vector3(0.00325000007,0.00138000003,-0.000429999985)
        //Vector3()Vector3(0.353529423,190.275787,324.838135)
        transform.localPosition = new Vector3(0.00325000007f, 0.00138000003f, -0.000429999985f);
        transform.localRotation = Quaternion.Euler(0.353529423f, 190.275787f, 324.838135f);
        
        r.velocity = Vector3.zero;
        playerStateManager.r.velocity = Vector3.zero;
        canPickUp = false;
        pickUpHam = false;
    }

    void CanPickUp()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < 3f && !playerStateManager.holdingGun)
        {
            playerStateManager.ham = this;
            canPickUp = true;
        }
        else
        {
            canPickUp = false;
        }
    }

}
