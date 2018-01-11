using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleculeTouchInputScript : MonoBehaviour {

    public GameObject TargetMolecule;
    public float RotationCoeff;
    
    Vector3 previousPosition;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown("Fire1"))
        {
            // Set the initial value of the cursor
            previousPosition = Input.mousePosition;
        }

		if (Input.GetButton("Fire1"))
        {
            // Calculate the distance the mouse has moved to use for rotation
            Vector3 mouseDist = previousPosition - Input.mousePosition;

            // Update rotation
            TargetMolecule.transform.Rotate(-mouseDist.y * RotationCoeff, mouseDist.x* RotationCoeff, 0, Space.World);

            // Set previous to position to current position for next pass
            previousPosition = Input.mousePosition;
        }
    }
}
