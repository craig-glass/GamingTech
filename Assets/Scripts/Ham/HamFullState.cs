using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HamFullState : HamBaseState
{
    public override void Enter(HamStateManager state)
    {
        
    }

    public override void UpdateState(HamStateManager state)
    {
       if (state.eating)
        {
            if (state.timeLeft > 0)
            {
                state.timeLeft -= Time.deltaTime;
            }
            else
            { 
                state.SwitchState(state.Ham3State);
            }
            
        }
    }
}
