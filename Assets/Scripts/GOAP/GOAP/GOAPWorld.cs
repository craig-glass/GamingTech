using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class GOAPWorld
{
    private static readonly GOAPWorld instance = new GOAPWorld();
    private static GOAPWorldStates world;
    private static Queue<GameObject> benches;

    static GOAPWorld()
    {
        world = new GOAPWorldStates();
        benches = new Queue<GameObject>();

        GameObject[] benchesInScene = GameObject.FindGameObjectsWithTag("Bench");
        foreach (GameObject c in benchesInScene)
        {
            benches.Enqueue(c);
        }

        if (benchesInScene.Length > 0)
        {
            world.ModifyState("FreeBench", benchesInScene.Length);
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


    public static GOAPWorld Instance
    {
        get { return instance; }
    }

    public GOAPWorldStates GetWorld()
    {
        return world;
    }
}
