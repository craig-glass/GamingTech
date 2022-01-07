using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BiggestChase : MonoBehaviour
{
    public TMP_Text biggestChaseText;

    // Start is called before the first frame update
    void Start()
    {
        biggestChaseText = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        biggestChaseText.text = "Biggest Chase\n" + World1State.biggestChase;
    }
}
