using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Pedestrian : GOAPAgent
{
    public Animator anim;
    public NavMeshAgent agent;

    new void Start()
    {
        base.Start();
        SubGoal subgoal = new SubGoal("isFedAndHome", 1, true);
        goals.Add(subgoal, 3);
    }

    private void Update()
    {
        if (Vector3.Distance(agent.transform.position, agent.destination) < 2.0f)
        {
            agent.isStopped = true;
            anim.SetBool("isStopped", true);
        }
        else
        {
            agent.isStopped = false;
            anim.SetBool("isStopped", false);
        }


    }

}
