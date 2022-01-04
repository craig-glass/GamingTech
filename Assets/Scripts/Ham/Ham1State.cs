using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ham1State : HamBaseState
{
    public override void Enter(HamStateManager state)
    {
        state.transform.GetChild(2).gameObject.SetActive(false);
        state.transform.GetChild(3).gameObject.SetActive(true);
        state.timeLeft = 5;
    }

    public override void UpdateState(HamStateManager state)
    {
        if (state.timeLeft > 0)
        {
            state.timeLeft -= Time.deltaTime;
        }
        else
        {
            state.SwitchState(state.HamBoneState);
        }
    }
}