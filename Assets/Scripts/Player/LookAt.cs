using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    [SerializeField]
    GameObject target;

    private void LateUpdate()
    {
        transform.LookAt(target.transform);
    }
}
