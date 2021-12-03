using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverState : GameBaseState
{
    public override void EnterState(GameManager state)
    {
        Debug.Log("Game Over State");
        state.gameOver = true;
        
    }

    public override void UpdateState(GameManager state)
    {

    }
}
