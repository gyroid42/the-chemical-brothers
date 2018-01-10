using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationScript : MonoBehaviour {

    public float rotationSpeed;
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0, Time.deltaTime * rotationSpeed, 0);
	}
}
