using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConicalFlaskScript : BaseInteractable {

    int numStep = 0;

    float weight = 0.0f;

    bool isActive = false;

    Touch userTouch;

    bool userTouching = false;
    bool onScales = false;
    public GameObject scales_;


    Plane interactionPlane = new Plane(new Vector3(1.0f, 0.0f, 0.0f), new Vector3(3.09f, 1.51f, -3.9f));

    public override void Reset()
    {
        base.Reset();

        numStep = 0;
        weight = 0.0f;

        userTouching = false;
        onScales = false;
    }


    public override void EnterWorkArea()
    {
        if (numStep == 0)
        {
            base.EnterWorkArea();

            isActive = true;
        }
    }

    public override void ExitWorkArea()
    {
        numStep++;
        if (numStep > 0)
        {
            base.ExitWorkArea();

            isActive = false;
        }
    }


    public override void UpdateInteractable()
    {
        base.UpdateInteractable();

        if (numStep == 0)
        {
            if (!onScales)
            {
                if (Input.touchCount > 0)
                {
                    if (Input.GetTouch(0).phase == TouchPhase.Began)
                    {
                        userTouching = true;
                        Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                    }
                }

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

                    if (transform.position.y >= scales_.transform.position.y &&
                        transform.position.z <= -5.8 && transform.position.z >= -6.2)
                    {
                        Debug.Log("ontop of scales");
                        onScales = true;
                        transform.position = new Vector3(3.09f, 1.51f, -5.91f);
                        weight = 12.0f;

                    }


                }
            }

            if (onScales)
            {

                if (Input.GetMouseButtonDown(0))
                {
                    Vector3 buttonPos1 = Camera.main.WorldToScreenPoint(scales_.transform.position + new Vector3(-0.1219f, 0.089f, 0.0689f));
                    Vector3 buttonPos2 = Camera.main.WorldToScreenPoint(scales_.transform.position + new Vector3(-0.1717f, 0.069f, 0.0053f));
                    if (Input.mousePosition.x >= buttonPos1.x && Input.mousePosition.x <= buttonPos2.x &&
                        Input.mousePosition.y >= buttonPos2.y && Input.mousePosition.y <= buttonPos1.y)
                    {
                        weight = 0.0f;
                    }
                }
            }

        }
    }


    void OnGUI()
    {
        if (isActive)
        {
            string display = weight.ToString();


            Vector3 textPos = Camera.main.WorldToScreenPoint(scales_.transform.position + new Vector3(-0.127f, 0.0719f, -0.0138f));
            GUI.TextField(new Rect(textPos.x, textPos.y, 20, 20), display);


            if (numStep == 0)
            {
                if (onScales)
                {

                    if (GUI.Button(new Rect(0, 300, 100, 50), "Next Step"))
                    {
                        if (weight != 0.0f)
                        {
                            GameController.controller_.mistakes_++;
                        }

                        GameController.controller_.EndStep();
                        Debug.Log("number of mistakes " + GameController.controller_.mistakes_);
                    }
                }
            }
        }
    }
}
