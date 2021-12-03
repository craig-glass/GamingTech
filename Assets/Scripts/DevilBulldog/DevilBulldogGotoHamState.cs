using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevilBulldogGotoHamState : DevilBulldogBaseState
{
    public override void EnterState(DevilBulldogStateManager state)
    {
        Debug.Log("Entered got ham state");
        state.anim.SetBool("walk", true);
        state.agent.isStopped = false;
    }

    public override void UpdateState(DevilBulldogStateManager state)
    {
        if (!GameManager.Instance.gameOver)
        {
            if (state.ham)
            {
                state.agent.SetDestination(state.ham.transform.position);
                if (Vector3.Distance(state.gameObject.transform.position, state.ham.transform.position) < 2.5f)
                {
                    Debug.Log("close to ham");
                    state.agent.isStopped = true;
                    state.anim.SetBool("walk", false);
                    state.eat = false;
                    state.SwitchState(state.EatState);
                }
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
