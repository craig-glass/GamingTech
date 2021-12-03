using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    //Vector3 offset;
    //Vector3 newTransform;

    // Start is called before the first frame update
    void Start()
    {
        //offset.x = transform.position.x - player.transform.position.x;
        //offset.z = transform.position.z - player.transform.position.z;
        //newTransform = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //newTransform.x = player.transform.position.x + offset.x;
        //newTransform.z = player.transform.position.z + offset.z;
        //transform.position = newTransform;
    }

    private void LateUpdate()
    {
        transform.LookAt(player.transform);
    }
}
