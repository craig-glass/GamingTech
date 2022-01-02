using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Sets the devilbulldog to eat the ham and ignore the player
public class DevilBulldogEatState : DevilBulldogBaseState
{
    public override void EnterState(DevilBulldogStateManager state)
    {
        Debug.Log("Entered eat state");
        float timeStart = Time.time; 
        state.hamStateManager = state.ham.GetComponent<HamStateManager>();
        state.anim.SetTrigger("eat");
        GameManager.Instance.snarl.Play();
        state.r.velocity = Vector3.zero;
    }

    public override void UpdateState(DevilBulldogStateManager state)
    {
       if (!state.hamStateManager.ateSome)
        {
            if (state.timeLeft > 0)
            {
                state.timeLeft -= Time.deltaTime;
            }
            else
            {
                state.timeLeft = 0;
                Debug.Log("ate some!!");
                state.hamStateManager.ateSome = true;
            }
            
            
        }
       
    }

    public override void OnCollisionEnter(DevilBulldogStateManager state, Collision collision)
    {
     
    }
}
