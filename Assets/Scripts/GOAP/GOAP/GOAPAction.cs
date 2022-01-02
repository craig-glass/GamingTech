using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class GOAPAction : MonoBehaviour
{
    public string actionName = "Action";
    public float cost = 1.0f;
    public GameObject target;
    public string targetTag;
    public float duration = 0f;
    public WorldState[] preConditions;
    public WorldState[] afterEffects;
    public NavMeshAgent agent;

    public Dictionary<string, int> preconditions;
    public Dictionary<string, int> aftereffects;

    public GOAPWorldStates agentStates;

    public GOAPInventory inventory;
    public GOAPWorldStates beliefs;

    public bool inProcess = false;

    public GOAPAction()
    {
        preconditions = new Dictionary<string, int>();
        aftereffects = new Dictionary<string, int>();
    }

    private void Awake()
    {
        agent = this.gameObject.GetComponent<NavMeshAgent>();
        if (preConditions != null)
        {
            foreach(WorldState wState in preConditions)
            {
                preconditions.Add(wState.key, wState.value);
            }
        }
        
        if (afterEffects != null)
        {
            foreach(WorldState wState in afterEffects)
            {
                aftereffects.Add(wState.key, wState.value);
            }
        }

        inventory = this.GetComponent<GOAPAgent>().inventory;
        beliefs = this.GetComponent<GOAPAgent>().beliefs;
    }

    public bool IsAchievable()
    {
        return true;
    }

    public bool IsAchievableGiven(Dictionary<string, int> conditions)
    {
        foreach(KeyValuePair<string, int> precondition in preconditions)
        {
            if (!conditions.ContainsKey(precondition.Key))
                return false;
        }
        return true;
    }

    public abstract bool PrePerform();
    public abstract bool PostPerform();
}
