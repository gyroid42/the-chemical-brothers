using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackboardManager : MonoBehaviour {

    public GameObject MainDisplay;
    public GameObject ScoreDisplay;

	// Use this for initialization
	void Start () {
        MainDisplay.SetActive(true);
        ScoreDisplay.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		//if(GameController.controller_.currentAppState_ == )
        //{
        // THIS WILL CONTAIN FUNCTION FOR UI SWITCHING
        //}
	}

    // Functions to change the screen displayed on the blackboard are below
    public void SetDisplayMain()
    {
        MainDisplay.SetActive(true);
        ScoreDisplay.SetActive(false);
    }

    public void SetDisplayScore()
    {
        MainDisplay.SetActive(false);
        ScoreDisplay.SetActive(true);
    }
}
