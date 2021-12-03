using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager state)
    {
        Debug.Log("Jump");
    }

    public override void FixedUpdateState(PlayerStateManager state)
    {

    }

    public override void UpdateState(PlayerStateManager state)
    {
     
        if (state.anim.GetFloat("speed") == state.speed
            && !state.hasJumped)
        {
            state.SwitchState(state.RunState);
        }
        else if (state.anim.GetFloat("vertical") < 0.1 && !state.hasJumped)
        {
            state.SwitchState(state.IdleState);
        }
        else if (state.anim.GetFloat("speed") > state.speed
            && !state.hasJumped)
        {
            state.SwitchState(state.SprintState);
        }
                  
    }

    public override void OnCollisionEnter(PlayerStateManager state, Collision collision)
    {
        
    }
}

