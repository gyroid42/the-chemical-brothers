using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GradeScript : MonoBehaviour {

    public Text gradeText;
    public List<string> grades = new List<string>   {"A+", "A", "A-", "B+", "B", "B-",
                                                    "C+", "C", "C-", "D+", "D", "D-", "F"};

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void UpdateGrade()
    {
        int m = GameController.controller_.mistakes_;
        if (m > 12) m = 12;
        
        gradeText.text = grades[m];
    }
}
