using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager state)
    {
        Debug.Log("Death");
        state.StartCoroutine("Death");
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
