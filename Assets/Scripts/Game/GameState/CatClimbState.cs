using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatClimbState : GameBaseState
{
    public override void EnterState(GameManager state)
    {
        state.mainScreenMusic.Stop();
        state.dontFallMusic.Play();

        Debug.Log("CatClimb State");
        if (!state.paused)
        {
            state.SceneLoad("CatClimb");
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
            state.SwitchState(state.GamePausedState);   // Enter paused state 
        }
    }

    public override void ExitState(GameManager state)
    {
        state.dontFallMusic.Stop();
    }
}
