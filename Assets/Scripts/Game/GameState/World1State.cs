using UnityEngine;


public class World1State : GameBaseState
{
    public override void EnterState(GameManager state)
    {
        state.mainScreenMusic.Stop();
        state.beatTheDogsMusic.Play();
        Debug.Log("World1 State");
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
            Debug.Log("entered pause return");
            state.SwitchState(state.GamePausedState);       // Enter paused state
        }
    }

    public override void ExitState(GameManager state)
    {
        Debug.Log("exit state");
        state.beatTheDogsMusic.Stop();
    }
}
