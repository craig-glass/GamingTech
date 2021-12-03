using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ham3State : HamBaseState
{
    public override void Enter(HamStateManager state)
    {
        Debug.Log("Entered ham3 state");
        state.transform.GetChild(0).gameObject.SetActive(false);
        state.transform.GetChild(1).gameObject.SetActive(true);
    }

    public override void UpdateState(HamStateManager state)
    {

    }
}
