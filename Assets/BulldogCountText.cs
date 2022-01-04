using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BulldogCountText : MonoBehaviour
{
    public TMP_Text bulldogcountText;

    // Start is called before the first frame update
    void Start()
    {
        bulldogcountText = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        bulldogcountText.text = "Bulldog Count: " + World1State.devilBulldogsChasing.Count;
    }
}
