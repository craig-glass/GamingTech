using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Sets the devilbulldog to eat the ham and ignore the player
public class DevilBulldogEatState : DevilBulldogBaseState
{
    public override void EnterState(DevilBulldogStateManager state)
    {
        
        state.hamStateManager = state.hamCloseBy.GetComponent<HamStateManager>();
        state.anim.SetTrigger("eat");
        GameManager.Instance.snarl.Play();
        state.r.velocity = Vector3.zero;
        state.hamStateManager.eating = true;
    }

    public override void UpdateState(DevilBulldogStateManager state)
    {
        if (state.hamStateManager.allGone)
        {
            Debug.Log("all gone");
            state.agent.ResetPath();
            state.SwitchState(state.PatrolState);
        }
              
    }

    public override void OnCollisionEnter(DevilBulldogStateManager state, Collision collision)
    {
     
    }
}
