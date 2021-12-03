using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager state)
    {
        Debug.Log("Entered Idle");
    }

    public override void FixedUpdateState(PlayerStateManager state)
    {
       
    }

    public override void UpdateState(PlayerStateManager state)
    {
        if (Input.GetAxis("Vertical") > 0.1f && !GameManager.Instance.gameOver)
        {
            state.SwitchState(state.RunState);
        }
        if (state.hasJumped)
        {
            state.SwitchState(state.JumpState);
        }

    }

    public override void OnCollisionEnter(PlayerStateManager state, Collision collision)
    {
        
    }
}
