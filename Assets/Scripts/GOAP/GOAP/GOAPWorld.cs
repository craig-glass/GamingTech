using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class GOAPWorld
{
    private static readonly GOAPWorld instance = new GOAPWorld();
    private static GOAPWorldStates world;
    private static Queue<GameObject> benches;
    private static Queue<GameObject> foodStands;

    static GOAPWorld()
    {
        world = new GOAPWorldStates();
        benches = new Queue<GameObject>();
        foodStands = new Queue<GameObject>();

        GameObject[] benchesInScene = GameObject.FindGameObjectsWithTag("Bench");
        foreach (GameObject c in benchesInScene)
        {
            benches.Enqueue(c);
        }

        if (benchesInScene.Length > 0)
        {
            world.ModifyState("FreeBench", benchesInScene.Length);
        }

        GameObject[] foodStandsInScene = GameObject.FindGameObjectsWithTag("Stand");
        foreach (GameObject stand in foodStandsInScene)
        {
            foodStands.Enqueue(stand);
        }

        if (foodStandsInScene.Length > 0)
        {
            world.ModifyState("FreeStand", foodStandsInScene.Length);
        }
    }

    private GOAPWorld()
    {

    }

    public void Addbench(GameObject bench)
    {
        benches.Enqueue(bench);
    }

    public GameObject Removebench()
    {
        if (benches.Count == 0)
        {
            return null;
        }
        return benches.Dequeue();
    }

    public void AddStand(GameObject stand)
    {
        foodStands.Enqueue(stand);
    }

    public GameObject RemoveStand()
    {
        if (foodStands.Count == 0)
        {
            return null;
        }
        return foodStands.Dequeue();
    }


    public static GOAPWorld Instance
    {
        get { return instance; }
    }

    public GOAPWorldStates GetWorld()
    {
        return world;
    }
}
