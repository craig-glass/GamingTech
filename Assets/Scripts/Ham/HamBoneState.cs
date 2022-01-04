using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HamBoneState : HamBaseState
{
    public override void Enter(HamStateManager state)
    {
        state.transform.GetChild(3).gameObject.SetActive(false);
        state.timeLeft = 0;
        state.allGone = true;
    }

    public override void UpdateState(HamStateManager state)
    {
       
    }
}