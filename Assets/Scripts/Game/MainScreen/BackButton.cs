using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour
{
    Button buttonObject;
    GameObject settingsPanel;
    GameObject mainPanel;
    Scene activeScene;
   
    // Start is called before the first frame update
    void Start()
    {
        activeScene = SceneManager.GetActiveScene();
        settingsPanel = GameObject.Find("SettingsPanel");
        mainPanel = GameObject.Find("MainPanel");
        buttonObject = GetComponent<Button>();
        buttonObject.onClick.AddListener(GoBack);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GoBack()
    {
        if (activeScene.name == "MainScreen")
        {
            GameManager.Instance.SwitchState(GameManager.Instance.MainScreenState);
        }
        else
        {
            settingsPanel.SetActive(false);
            mainPanel.SetActive(true);
            GameManager.Instance.SwitchState(GameManager.Instance.GamePausedState);
        }
    }
}
