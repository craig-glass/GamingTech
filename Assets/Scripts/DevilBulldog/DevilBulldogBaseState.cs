using UnityEngine;

// Base state of devilbulldog state machine
public abstract class DevilBulldogBaseState
{
    public abstract void EnterState(DevilBulldogStateManager state);

    public abstract void UpdateState(DevilBulldogStateManager state);

    public abstract void OnCollisionEnter(DevilBulldogStateManager state, Collision collision);
}
