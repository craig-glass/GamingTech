using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestartGame : MonoBehaviour
{
    Button restartButton;

    // Start is called before the first frame update
    void Awake()
    {
        Debug.Log("entered restartbutton");
        restartButton = GetComponent<Button>();
        restartButton.onClick.AddListener(GameManager.Instance.ResetGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
