using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevilBulldogFightState : DevilBulldogBaseState
{
    public override void EnterState(DevilBulldogStateManager state)
    {
        Debug.Log("Entered devilbulldog fightstate");
        
    }
    public override void UpdateState(DevilBulldogStateManager state)
    {
        
    }
    public override void OnCollisionEnter(DevilBulldogStateManager state, Collision collision)
    {

    }
}
