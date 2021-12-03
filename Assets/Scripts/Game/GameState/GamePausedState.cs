using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePausedState : GameBaseState
{
    Scene activeScene;

    public override void EnterState(GameManager state)
    {
        activeScene = SceneManager.GetActiveScene();
        state.paused = true;

        Time.timeScale = 0;                         // Stop all movement in scene
        Pause.pauseMenu.SetActive(true);            // Display pause menu
        Debug.Log("Entered Game Paused State");
    }

    public override void UpdateState(GameManager state)
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Time.timeScale = 1;                     // Re-enable movement in scene
            Pause.pauseMenu.SetActive(false);

            switch (activeScene.name)
            {
                case "World1": state.SwitchState(state.World1state); break;
                case "CatClimb": state.SwitchState(state.CatClimbState); break;
                case "Targets": state.SwitchState(state.TargetsState); break;
            }
            
        }
    }
}
