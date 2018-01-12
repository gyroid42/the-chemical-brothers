using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpatulaScript : BaseInteractable
{


    bool userTouching = false;

    Plane interactionPlane = new Plane(new Vector3(1.0f, 0.0f, 0.0f), new Vector3(3.09f, 1.51f, -3.9f));


    public override void Reset()
    {
        base.Reset();

        userTouching = false;
    }


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

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray))
            {

                userTouching = true;
            }
        }

        if (userTouching)
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            float rayDistance;
            if (interactionPlane.Raycast(ray, out rayDistance))
            {
                transform.position = ray.GetPoint(rayDistance);
                if (transform.position.y < 1.35)
                {
                    transform.position = new Vector3(transform.position.x, 1.35f, transform.position.z);

                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            userTouching = false;


        }
    }


}
