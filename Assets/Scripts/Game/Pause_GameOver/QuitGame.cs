using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitGame : MonoBehaviour
{
    Button quitGameButton;

    // Start is called before the first frame update
    void Start()
    {
        quitGameButton = GetComponent<Button>();
        quitGameButton.onClick.AddListener(GameManager.Instance.QuitGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
