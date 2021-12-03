using UnityEngine;
using UnityEngine.UI;


public class SettingsState : GameBaseState
{
    public override void EnterState(GameManager state)
    {
        Debug.Log("Settings State");
        
        state.settingsPanel.SetActive(true);
        state.mainPanel.SetActive(false);
        state.slider.value = state.sensitivity;
        state.slider.onValueChanged.AddListener(delegate { state.HandleSliderChange(); });  // Listen for any changes on sensitivity slider

        // Set correct toggle on according to difficulty previously set
        switch (state.difficulty)
        {
            case "Novice": state.easyToggle.isOn = true; break;
            case "Amateur": state.amateurToggle.isOn = true; break;
            case "Pro": state.proToggle.isOn = true; break;
        }

        // Set listeners on all toggles to detect which is switched on and set difficulty accordingly
        state.easyToggle.onValueChanged.AddListener((bool on) =>
        {
            if (on)
            {
                state.difficulty = "Novice";
                Debug.Log(state.difficulty);
            }
        });

        state.amateurToggle.onValueChanged.AddListener((bool on) =>
        {
            if (on)
            {
                state.difficulty = "Amateur";
                Debug.Log(state.difficulty);
            }
        });

        state.proToggle.onValueChanged.AddListener((bool on) =>
        {
            if (on)
            {
                state.difficulty = "Pro";
                Debug.Log(state.difficulty);
            }
        });
        
        
    }

    public override void UpdateState(GameManager state)
    {
        
    }

    
}
