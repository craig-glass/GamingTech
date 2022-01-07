using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetFood : GOAPAction
{
    
    public override bool PrePerform()
    {
        target = GOAPWorld.Instance.RemoveStand();
        if (target == null)
            return false;

        GOAPWorld.Instance.GetWorld().ModifyState("FreeStand", -1);
        return true;
    }

    public override bool PostPerform()
    {
        GOAPWorld.Instance.AddStand(target);
        GOAPWorld.Instance.GetWorld().ModifyState("FreeStand", 1);
        return true;
    }
}
