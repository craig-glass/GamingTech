using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestrianSpawn : MonoBehaviour
{
    public GameObject[] pedestrianPrefab;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnPedestrian", Random.Range(10, 30));
    }

    void SpawnPedestrian()
    {
        Instantiate(pedestrianPrefab[Random.Range(0, 8)], transform.position, Quaternion.identity, this.gameObject.transform);
        Invoke("SpawnPedestrian", Random.Range(15, 30));
    }
}
