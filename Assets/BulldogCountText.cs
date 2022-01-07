using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BulldogKillCount : MonoBehaviour
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
        bulldogcountText.text = "Kill Count\n" + World1State.devilBulldogsKillCount;
    }
}
