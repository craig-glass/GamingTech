using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevilBulldogPatrolState : DevilBulldogBaseState
{
    Vector3 targetPos;

    public override void EnterState(DevilBulldogStateManager state)
    {
        Debug.Log("patrolling");
        state.anim.SetBool("walk", true);
        state.timeInState = Random.Range(3.0f, 15.0f);
        targetPos = state.firstWaypoint.transform.position;
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

        if (Vector3.Distance(state.transform.position, targetPos) < 3.0f)
        {
            targetPos = state.waypoints[state.currentWP].transform.position;
            state.currentWP = Random.Range(0, 6);
        }

        if (state.currentWP >= state.waypoints.Length)
        {
            state.currentWP = 0;
        }

        Quaternion lookatWP = Quaternion.LookRotation(targetPos - state.transform.position);
        state.transform.rotation = Quaternion.Slerp(state.transform.rotation, lookatWP, 8.0f * Time.deltaTime);
        state.transform.Translate(0f, 0f, 4.0f * Time.deltaTime);

        state.timeInState -= Time.deltaTime;

        if (state.timeInState <= 0)
            state.SwitchState(state.IdleState);

        
        
        

    }

    public override void OnCollisionEnter(DevilBulldogStateManager state, Collision collision)
    {

    }
}
