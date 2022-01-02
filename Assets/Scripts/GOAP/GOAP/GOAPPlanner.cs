using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Node
{
    public Node parent;
    public float cost;
    public Dictionary<string, int> state;
    public GOAPAction action;

    public Node(Node parent, float cost, Dictionary<string, int> allStates, GOAPAction action)
    {
        this.parent = parent;
        this.cost = cost;
        this.state = new Dictionary<string, int>(allStates);
        this.action = action;
    }

    public Node(Node parent, float cost, Dictionary<string, int> allStates, Dictionary<string, int> beliefStates, GOAPAction action)
    {
        this.parent = parent;
        this.cost = cost;
        this.state = new Dictionary<string, int>(allStates);
        foreach(KeyValuePair<string, int> b in beliefStates)
        {
            if (!this.state.ContainsKey(b.Key))
            {
                this.state.Add(b.Key, b.Value);
            }
        }
        this.action = action;
    }
}

public class GOAPPlanner
{
    public Queue<GOAPAction> plan(List<GOAPAction> actions, Dictionary<string, int> goal, GOAPWorldStates beliefStates)
    {
        List<GOAPAction> usableActions = new List<GOAPAction>();
        foreach(GOAPAction a in actions)
        {
            if (a.IsAchievable())
            {
                usableActions.Add(a);
            }
        }

        List<Node> leaves = new List<Node>();
        Node start = new Node(null, 0, GOAPWorld.Instance.GetWorld().GetStates(), beliefStates.GetStates(), null);

        bool success = BuildGraph(start, leaves, usableActions, goal);

        if (!success)
        {
            Debug.Log("no plan!!");
            return null;
        }

        Node cheapest = null;
        foreach(Node leaf in leaves)
        {
            if (cheapest == null)
            {
                cheapest = leaf;
            }
            else
            {
                if(leaf.cost < cheapest.cost)
                {
                    cheapest = leaf;
                }
            }
        }

        List<GOAPAction> result = new List<GOAPAction>();
        Node n = cheapest;
        while (n != null)
        {
            if (n.action != null)
            {
                result.Insert(0, n.action);
            }
            n = n.parent;
        }

        Queue<GOAPAction> queue = new Queue<GOAPAction>();
        foreach(GOAPAction a in result)
        {
            queue.Enqueue(a);
        }

        Debug.Log("The plan is: ");
        foreach(GOAPAction a in queue)
        {
            Debug.Log("Q: " + a.actionName);
        }

        return queue;
    }

    private bool BuildGraph(Node parent, List<Node> leaves, List<GOAPAction> usuableActions, Dictionary<string, int> goal)
    {
        bool foundPath = false;
        foreach(GOAPAction action in usuableActions)
        {
            if (action.IsAchievableGiven(parent.state))
            {
                Dictionary<string, int> currentState = new Dictionary<string, int>(parent.state);
                foreach(KeyValuePair<string, int> effect in action.aftereffects)
                {
                    if (!currentState.ContainsKey(effect.Key))
                    {
                        currentState.Add(effect.Key, effect.Value);
                    }
                }

                Node node = new Node(parent, parent.cost + action.cost, currentState, action);
                
                if(GoalAchieved(goal, currentState))
                {
                    leaves.Add(node);
                    foundPath = true;
                }
                else
                {
                    List<GOAPAction> subset = ActionSubset(usuableActions, action);
                    bool found = BuildGraph(node, leaves, subset, goal);
                    if (found)
                        foundPath = true;
                }
            }
        }
        return foundPath;
    }

    private bool GoalAchieved(Dictionary<string, int> goal, Dictionary<string, int> state)
    {
        foreach(KeyValuePair<string, int> g in goal)
        {
            if (!state.ContainsKey(g.Key))
                return false;
        }
        return true;
    }

    private List<GOAPAction> ActionSubset(List<GOAPAction> actions, GOAPAction removeMe)
    {
        List<GOAPAction> subset = new List<GOAPAction>();
        foreach (GOAPAction a in actions)
        {
            if (!a.Equals(removeMe))
            {
                subset.Add(a);
            }
        }

        return subset;
    }
}
