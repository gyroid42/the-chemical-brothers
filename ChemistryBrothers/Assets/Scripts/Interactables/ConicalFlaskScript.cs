using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConicalFlaskScript : BaseInteractable {


    Touch userTouch;
    bool userTouching = false;


    public override void EnterWorkArea()
    {
        base.EnterWorkArea();
    }

    public override void ExitWorkArea()
    {
        base.ExitWorkArea();
    }


    public override void UpdateInteractable()
    {
        base.UpdateInteractable();

        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                userTouching = true;
                //if ()
            }
        }
        
    }
}
