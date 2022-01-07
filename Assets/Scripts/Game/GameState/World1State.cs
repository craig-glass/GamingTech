using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class World1State : GameBaseState
{
    // Devil Bulldogs
    public static List<GameObject> devilBulldogs = new List<GameObject>();
    public static List<GameObject> devilBulldogsChasing = new List<GameObject>();
    public static int devilBulldogsKillCount;
    public static int biggestChase;
    public static bool chaseTimerRun;
    public static float longestChase;
    public static int points;

    public override void EnterState(GameManager state)
    {
        
        state.mainScreenMusic.Stop();
        state.beatTheDogsMusic.Play();
        if (!state.paused)
        {
            state.SceneLoad("World1");
        }
        else if (state.paused)
        {
            state.paused = false;
        }
        state.player = GameObject.FindGameObjectWithTag("Player");
        state.playerStateManager = state.player.GetComponent<PlayerStateManager>();
        state.playerStateManager.startPos = state.player.transform.position;
        devilBulldogsKillCount = 0;
        biggestChase = 0;
        chaseTimerRun = false;
        longestChase = 0;
        points = 0;
    }

    public override void UpdateState(GameManager state)
    {
        if (devilBulldogsChasing.Count > 0)
        {
            chaseTimerRun = true;
           
        }
        else
        {
            chaseTimerRun = false;
        }
        

        if (Input.GetKeyDown(KeyCode.Return))
        {
            state.SwitchState(state.GamePausedState);       // Enter paused state
        }
    }

    public override void ExitState(GameManager state)
    {
        state.beatTheDogsMusic.Stop();
    }
}
