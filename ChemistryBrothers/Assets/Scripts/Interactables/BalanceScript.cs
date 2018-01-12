using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalanceScript : BaseInteractable {

    int numStep = 0;


    public override void EnterWorkArea()
    {
        base.EnterWorkArea();
    }

    public override void ExitWorkArea()
    {
        numStep++;
        if (numStep > 1)
        {
            base.ExitWorkArea();
        }
    }


    public override void UpdateInteractable()
    {
        base.UpdateInteractable();
    }
}
