using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackboardManager : MonoBehaviour {

    public GameObject MainDisplay;
    public GameObject ScoreDisplay;

    public Text gradeText;
    public List<string> grades = new List<string>   {"A+", "A", "A-", "B+", "B", "B-",
                                                    "C+", "C", "C-", "D+", "D", "D-", "F"};

    // Use this for initialization
    void Start () {
        MainDisplay.SetActive(true);
        ScoreDisplay.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if(GameController.controller_.CurrentAppState() == APPSTATE.SCORESCREEN)
        {
            SetDisplayScore();
        }
        else
        {
            SetDisplayMain();
        }
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
        UpdateGrade();
    }

    // Exit score screen to return to game
    public void ReturnToGame()
    {
        GameController.controller_.SetStateMenu();
    }

    void UpdateGrade()
    {
        int m = GameController.controller_.mistakes_;
        if (m > 12) m = 12;

        gradeText.text = grades[m];
    }
}
