using UnityEngine;

public abstract class GameBaseState
{
    public abstract void EnterState(GameManager state);

    public abstract void UpdateState(GameManager state);

   
}
