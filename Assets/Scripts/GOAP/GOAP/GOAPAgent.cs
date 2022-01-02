using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SubGoal
{
    public Dictionary<string, int> subgoals;
    public bool remove;

    public SubGoal(string s, int i, bool r)
    {
        subgoals = new Dictionary<string, int>();
        subgoals.Add(s, i);
        remove = r;
    }
}

public class GOAPAgent : MonoBehaviour
{
    public List<GOAPAction> actions = new List<GOAPAction>();
    public Dictionary<SubGoal, int> goals = new Dictionary<SubGoal, int>();
    public GOAPInventory inventory = new GOAPInventory();
    public GOAPWorldStates beliefs = new GOAPWorldStates();

    GOAPPlanner planner;
    Queue<GOAPAction> actionQueue;
    public GOAPAction currentAction;
    SubGoal currentSubgoal;

    // Start is called before the first frame update
    public void Start()
    {
        GOAPAction[] acts = this.GetComponents<GOAPAction>();
        foreach(GOAPAction act in acts)
        {
            actions.Add(act);
        }
    }

    bool invoked = false;
    void CompleteAction()
    {
        currentAction.inProcess = false;
        currentAction.PostPerform();
        invoked = false;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (currentAction != null && currentAction.inProcess)
        {
            if (currentAction.agent.hasPath && currentAction.agent.remainingDistance < 2.0f)
            {
                if (!invoked)
                {
                    Invoke("CompleteAction", currentAction.duration);
                    invoked = true;
                }
            }
            return;
        }

        if (planner == null || actionQueue == null)
        {
            planner = new GOAPPlanner();

            var sortedGoals = from entry in goals orderby entry.Value descending select entry;

            foreach(KeyValuePair<SubGoal, int> subgoal in sortedGoals)
            {
                actionQueue = planner.plan(actions, subgoal.Key.subgoals, beliefs);
                if (actionQueue != null)
                {
                    currentSubgoal = subgoal.Key;
                    break;
                }
            }
        }

        if (actionQueue != null && actionQueue.Count == 0)
        {
            if (currentSubgoal.remove)
            {
                goals.Remove(currentSubgoal);
            }
            planner = null;
        }

        if (actionQueue != null && actionQueue.Count > 0)
        {
            currentAction = actionQueue.Dequeue();
            if (currentAction.PrePerform())
            {
                if (currentAction.target == null && currentAction.targetTag != "")
                {
                    currentAction.target = GameObject.FindWithTag(currentAction.targetTag);
                }

                if (currentAction.target != null)
                {
                    currentAction.inProcess = true;
                    currentAction.agent.SetDestination(currentAction.target.transform.position);
                }
            }
            else
            {
                actionQueue = null;
            }
        }
    }
}
