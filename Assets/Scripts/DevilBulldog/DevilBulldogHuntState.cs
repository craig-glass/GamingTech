using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevilBulldogHuntState : DevilBulldogBaseState
{
    public override void EnterState(DevilBulldogStateManager state)
    {
        Debug.Log("Entered hunt state");
        state.anim.SetBool("walk", true);
        state.agent.isStopped = false;
    }
    public override void UpdateState(DevilBulldogStateManager state)
    {
        if (state.chase && !GameManager.Instance.gameOver)
        {
            state.agent.SetDestination(state.player.transform.position); 
            if (state.eat)
            {
                state.SwitchState(state.GotoHamState);
            }
          
        }
        else
        {
            state.agent.isStopped = true;
            state.SwitchState(state.IdleState);
        }
        
    }
    public override void OnCollisionEnter(DevilBulldogStateManager state, Collision collision)
    {
       
    }
}
