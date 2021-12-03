using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalkState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager state)
    {
        Debug.Log("Entered Walk");
    }

    public override void FixedUpdateState(PlayerStateManager state)
    {

    }

    public override void UpdateState(PlayerStateManager state)
    {
        
    }

    public override void OnCollisionEnter(PlayerStateManager state, Collision collision)
    {
        
    }
}
