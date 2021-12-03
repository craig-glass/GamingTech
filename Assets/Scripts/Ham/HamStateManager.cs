using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HamStateManager : MonoBehaviour
{
    public HamBaseState currentState;
    public HamFullState HamFullState = new HamFullState();
    public Ham3State Ham3State = new Ham3State();
    public Ham2State Ham2State = new Ham2State();
    public Ham1State Ham1State = new Ham1State();
    public HamBoneState HamBoneState = new HamBoneState();

    public bool ateSome = false;

    // Start is called before the first frame update
    void Start()
    {
        currentState = HamFullState;
        currentState.Enter(this);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(HamBaseState state)
    {
        currentState = state;
        state.Enter(this);
    }
    
}
