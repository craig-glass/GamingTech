using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetsState : GameBaseState
{
    public override void EnterState(GameManager state)
    {
        Debug.Log("Targets State");
        if (!state.paused)
        {
            state.SceneLoad("Targets");
        }
        else if (state.paused)
        {
            state.paused = false;
        }
    }

    public override void UpdateState(GameManager state)
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            state.SwitchState(state.GamePausedState);       // Enter paused state
        }
    }
}
