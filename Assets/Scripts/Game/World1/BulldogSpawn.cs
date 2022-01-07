using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulldogSpawn : MonoBehaviour
{
    public GameObject bulldogPrefab;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnBulldog", Random.Range(3, 15));
    }

    void SpawnBulldog()
    {
        Instantiate(bulldogPrefab, transform.position, Quaternion.identity, this.gameObject.transform);
        World1State.devilBulldogs.Add(bulldogPrefab);
        Invoke("SpawnBulldog", Random.Range(20, 40));
    }
}
