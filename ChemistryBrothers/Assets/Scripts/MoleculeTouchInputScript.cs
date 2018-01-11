﻿using System.Collections;
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

        if (Input.GetButtonDown("Fire1") && CursorContained(Input.mousePosition))
        {
            // Set the initial value of the cursor
            previousPosition = Input.mousePosition;
        }

		if (Input.GetButton("Fire1"))
        {
            // Calculate the distance the mouse has moved to use for rotation
            Vector3 mouseDist = previousPosition - Input.mousePosition;

            // Update rotation
            TargetMolecule.transform.Rotate(0, mouseDist.x* RotationCoeff, -mouseDist.y* RotationCoeff, Space.World);

            // Set previous to position to current position for next pass
            previousPosition = Input.mousePosition;
        }
    }

    bool CursorContained (Vector3 pos)
    {
        float x = pos.x;
        float y = pos.y;

        

        return true;
    }
}
