using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverworldState : GameBaseState
{
    public override void EnterState(GameManager state)
    {
        Debug.Log("Overworld state");
        state.SceneLoad("Overworld");
    }

    public override void UpdateState(GameManager state)
    {

    }
}
