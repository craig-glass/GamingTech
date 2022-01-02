using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SitAndEat : GOAPAction
{
    public override bool PrePerform()
    {
        target = GOAPWorld.Instance.Removebench();
        if (target == null)
            return false;

        GOAPWorld.Instance.GetWorld().ModifyState("FreeBench", -1);
        return true;
    }

    public override bool PostPerform()
    {
        GOAPWorld.Instance.Addbench(target);
        return true;
    }
}
