using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevilBulldogHuntState : DevilBulldogBaseState
{
    public override void EnterState(DevilBulldogStateManager state)
    {
        Debug.Log("---------------------------------------------------------------------");
        World1State.devilBulldogsChasing.Add(state.gameObject);
        if (World1State.devilBulldogsChasing.Count > World1State.biggestChase)
        {
            World1State.biggestChase++;
        }
        state.StartCoroutine("PointScoreChase");
        state.anim.SetBool("walk", true);
        state.agent.isStopped = false;
    }
    public override void UpdateState(DevilBulldogStateManager state)
    {
        foreach (GameObject h in state.ham)
        {
            if (Vector3.Distance(state.transform.position, h.transform.position) < 10f)
            {
                if (state.CanSeeHam(h))
                    state.hamCloseBy = h;
            }

        }
        if (state.hamCloseBy && state.CanSeeHam(state.hamCloseBy) &&     
            !state.playerStateManager.hamIsPickedUp && !state.hamCloseBy.GetComponent<HamStateManager>().allGone)
        {
            World1State.devilBulldogsChasing.Remove(state.gameObject);
            state.SwitchState(state.GotoHamState);
        }
           

        if (state.player.GetComponent<CapsuleCollider>().enabled == false)
        {
            World1State.devilBulldogsChasing.Remove(state.gameObject);
            state.SwitchState(state.PatrolState);
        }
        state.agent.SetDestination(state.player.transform.position);

    }
    public override void OnCollisionEnter(DevilBulldogStateManager state, Collision collision)
    {
        
    }
}
