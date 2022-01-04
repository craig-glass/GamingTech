using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevilBulldogGotoHamState : DevilBulldogBaseState
{
    public override void EnterState(DevilBulldogStateManager state)
    {
        Debug.Log("=================================================================");
        state.anim.SetBool("walk", true);
        state.agent.isStopped = false;
    }

    public override void UpdateState(DevilBulldogStateManager state)
    {

        state.agent.SetDestination(state.hamCloseBy.transform.position); 
        if (Vector3.Distance(state.gameObject.transform.position, state.hamCloseBy.transform.position) < 2.5f)
        {
            state.agent.isStopped = true;
            state.anim.SetBool("walk", false);
            state.eat = false;
            state.SwitchState(state.EatState);
        }        
            
        
    }

    public override void OnCollisionEnter(DevilBulldogStateManager state, Collision collision)
    {

    }
}
