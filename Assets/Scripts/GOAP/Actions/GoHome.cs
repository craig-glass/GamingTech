using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoHome : GOAPAction
{
    public override bool PrePerform()
    {
        target = this.transform.parent.gameObject;
        return true;
    }

    public override bool PostPerform()
    {
        Destroy(gameObject);
        return true;
    }
}
