using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevilBulldogPatrolState : DevilBulldogBaseState
{
    Vector3 targetPos;

    public override void EnterState(DevilBulldogStateManager state)
    {
        Debug.Log("Entered Patrol State");
        state.anim.SetBool("walk", true);
        state.timeInState = Random.Range(3.0f, 15.0f);
        targetPos = state.firstWaypoint.transform.position;
    }

    public override void UpdateState(DevilBulldogStateManager state)
    {       

        if (Vector3.Distance(state.transform.position, targetPos) < 3.0f)
        {
            targetPos = state.waypoints[state.currentWP].transform.position;
            state.currentWP = Random.Range(0, 6);
        }

        if (state.currentWP >= state.waypoints.Length)
        {
            state.currentWP = 0;
        }

        //state.transform.LookAt(state.waypoints[state.currentWP].transform.position);
        Quaternion lookatWP = Quaternion.LookRotation(targetPos - state.transform.position);
        state.transform.rotation = Quaternion.Slerp(state.transform.rotation, lookatWP, 8.0f * Time.deltaTime);
        state.transform.Translate(0f, 0f, 4.0f * Time.deltaTime);

        state.timeInState -= Time.deltaTime;

        if (state.timeInState <= 0)
            state.SwitchState(state.IdleState);

        if (state.chase && !GameManager.Instance.gameOver)
        {
            if (state.CanSeePlayer())
            {
                Debug.Log("can see player");
                state.SwitchState(state.HuntState);

            }
        }

    }

    public override void OnCollisionEnter(DevilBulldogStateManager state, Collision collision)
    {

    }
}
