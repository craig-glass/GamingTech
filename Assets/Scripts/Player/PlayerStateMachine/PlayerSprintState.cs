using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSprintState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager state)
    {
        Debug.Log("Sprint");
    }

    public override void FixedUpdateState(PlayerStateManager state)
    {

    }

    public override void UpdateState(PlayerStateManager state)
    {
        if (!Input.GetKey(KeyCode.LeftShift))
        {
            state.SwitchState(state.RunState);
        }
        if (Input.GetAxis("Vertical") < 0.1f)
        {
            state.SwitchState(state.IdleState);
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
