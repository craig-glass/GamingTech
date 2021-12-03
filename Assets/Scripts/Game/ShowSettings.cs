using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowSettings : MonoBehaviour
{
    Button settingsButton;
    GameObject settingsWindow;

    private void Awake()
    {

        settingsWindow = GameObject.Find("SettingsPanel");
    }
    // Start is called before the first frame update
    void Start()
    {
        settingsButton = gameObject.GetComponent<Button>();
        settingsButton.onClick.AddListener(SettingsShow);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SettingsShow()
    {
        settingsWindow.SetActive(true);
    }
}
