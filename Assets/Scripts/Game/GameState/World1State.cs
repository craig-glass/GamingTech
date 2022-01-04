using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class World1State : GameBaseState
{
    // Devil Bulldogs
    public static List<GameObject> devilBulldogs = new List<GameObject>();
    public static List<GameObject> devilBulldogsChasing = new List<GameObject>();

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
        state.player.GetComponent<PlayerStateManager>().startPos = state.player.transform.position;
    }

    public override void UpdateState(GameManager state)
    {
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
