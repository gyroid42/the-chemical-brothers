using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverlayManager : MonoBehaviour {
    
    private bool moleculeViewer_;

	// Use this for initialization
	void Start () {
        moleculeViewer_ = false;
        gameObject.SetActive(moleculeViewer_);
    }
	
	// Update is called once per frame
	void Update () {

	}

    // When called, alternates the state of the molecule viewer
    public void ToggleMoleculeViewer()
    {
        moleculeViewer_ = !moleculeViewer_;
        // Only render the molecule viewer when instructed
        gameObject.SetActive(moleculeViewer_);
        Debug.Log("Detected");
    }

    public bool MoleculeViewer()
    {
        return moleculeViewer_;
    }
}
