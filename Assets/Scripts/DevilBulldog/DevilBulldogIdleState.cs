using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevilBulldogIdleState : DevilBulldogBaseState
{

    public override void EnterState(DevilBulldogStateManager state)
    {
        Debug.Log("idel");
        state.anim.SetBool("walk", false);
        state.timeInState = Random.Range(3.0f, 15.0f);
    }
    public override void UpdateState(DevilBulldogStateManager state)
    {
        if (Vector3.Distance(state.transform.position, state.player.transform.position) < 10f && state.CanSeePlayer())
        {
            state.SwitchState(state.HuntState);
        }

        foreach (GameObject h in state.ham)
        {
            if (Vector3.Distance(state.transform.position, h.transform.position) < 10f)
            {
                if (state.CanSeeHam(h))
                    state.hamCloseBy = h;
            }

        }
        if (state.hamCloseBy && state.CanSeeHam(state.hamCloseBy) && 
            !state.hamCloseBy.GetComponent<HamStateManager>().allGone && 
            !state.playerStateManager.hamIsPickedUp)
            state.SwitchState(state.GotoHamState);

        state.timeInState -= Time.deltaTime;

        if (state.timeInState <= 0)
            state.SwitchState(state.PatrolState);
        
        
        
    }
    public override void OnCollisionEnter(DevilBulldogStateManager state, Collision collision)
    {

    }
}
