using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lives : MonoBehaviour
{
    public static Text livesText;

    // Start is called before the first frame update
    void Start()
    {
        livesText = GetComponent<Text>();
        livesText.text = "Lives: " + (GameManager.Instance.lives).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
