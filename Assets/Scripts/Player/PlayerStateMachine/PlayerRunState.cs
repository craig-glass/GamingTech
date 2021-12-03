using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager state)
    {
        Debug.Log("Run");
    }

    public override void FixedUpdateState(PlayerStateManager state)
    {

    }

    public override void UpdateState(PlayerStateManager state)
    {
        if (Input.GetAxis("Vertical") < 0.1 || GameManager.Instance.gameOver)
        {
            state.anim.SetFloat("vertical", 0f);
            state.SwitchState(state.IdleState);
        }
        if (state.hasJumped)
        {
            state.SwitchState(state.JumpState);
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            state.SwitchState(state.SprintState);
        }
    }

    public override void OnCollisionEnter(PlayerStateManager state, Collision collision)
    {
        
    }
}
