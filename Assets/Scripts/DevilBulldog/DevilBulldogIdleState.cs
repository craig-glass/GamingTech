using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevilBulldogIdleState : DevilBulldogBaseState
{
    public override void EnterState(DevilBulldogStateManager state)
    {
        Debug.Log("Entered DevilBulldogIdleState");
        state.anim.SetBool("walk", false);
    }
    public override void UpdateState(DevilBulldogStateManager state)
    {

        if (state.chase && !GameManager.Instance.gameOver)
        {
            if (state.CanSeePlayer())
            {
                Debug.Log("can see player");
                state.SwitchState(state.HuntState);

            }
        }
        
        if (state.eat && state.CanSeeHam())
        {
            Debug.Log("can see ham");
            state.SwitchState(state.GotoHamState);
        }
        
        
        
    }
    public override void OnCollisionEnter(DevilBulldogStateManager state, Collision collision)
    {

    }
}
