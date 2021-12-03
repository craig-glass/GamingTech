using UnityEngine;


public class World1State : GameBaseState
{
    public override void EnterState(GameManager state)
    {
        Debug.Log("World1 State");
        if (!state.paused)
        {
            state.SceneLoad("World1");
        }
        else if (state.paused)
        {
            state.paused = false;
        }
    }

    public override void UpdateState(GameManager state)
    {
      if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("entered pause return");
            state.SwitchState(state.GamePausedState);       // Enter paused state
        }
    }
}
