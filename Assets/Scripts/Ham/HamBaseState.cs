using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HamBaseState 
{
    public abstract void Enter(HamStateManager state);

    public abstract void UpdateState(HamStateManager state);
}
