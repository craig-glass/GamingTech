using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnterSettings : MonoBehaviour
{
    Button settingsButton;

    private void Awake()
    {
        GameManager.Instance.settingsPanel = GameObject.Find("SettingsPanel");
        GameManager.Instance.mainPanel = GameObject.Find("MainPanel");
        GameManager.Instance.toggleGroup = GameObject.Find("ToggleGroup");
        GameManager.Instance.easyToggle = GameObject.Find("EasyToggle").GetComponent<Toggle>();
        GameManager.Instance.amateurToggle = GameObject.Find("AmateurToggle").GetComponent<Toggle>();
        GameManager.Instance.proToggle = GameObject.Find("ProToggle").GetComponent<Toggle>();
        GameManager.Instance.toggleGroup = GameObject.Find("ToggleGroup");
        GameManager.Instance.slider = GameObject.Find("Slider").GetComponent<Slider>();
        GameManager.Instance.slider.minValue = 0.2f;
    }

    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.togglesGroup = GameManager.Instance.toggleGroup.GetComponent<ToggleGroup>();
        settingsButton = GetComponent<Button>();
        settingsButton.onClick.AddListener(SettingsEnter);
        GameManager.Instance.settingsPanel.SetActive(false);
    }

    void SettingsEnter()
    {
        GameManager.Instance.SwitchState(GameManager.Instance.SettingsState);
    }
}
