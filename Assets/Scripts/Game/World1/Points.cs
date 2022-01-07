using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Points : MonoBehaviour
{
    int points;
    public TMP_Text pointsText;
    public static Color textColor;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        pointsText.text = World1State.points.ToString();
        pointsText.color = textColor;
    }
}
