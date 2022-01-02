using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScreenState : GameBaseState
{
    public override void EnterState(GameManager state)
    {
        Debug.Log("Main Screen State");
        state.SceneLoad("MainScreen");
        Debug.Log("difficulty = " + state.difficulty);
    }

    public override void UpdateState(GameManager state)
    {

    }

    public override void ExitState(GameManager state)
    {

    }
}
