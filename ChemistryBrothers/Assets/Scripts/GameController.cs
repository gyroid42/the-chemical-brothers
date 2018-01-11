using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum APPSTATE
{
    PLAYING,
    MAINMENU,
    LEADERBOARD,
    GAMEOVER
}

public class GameController : MonoBehaviour {

    public static GameController controller_;


    public Main_Camera_Behaviour camera_;
    public APPSTATE currentAppState_;

    public List<Vector3> stepRotations_;
    public List<Vector3> stepLocations_;

    public Vector3 mainMenuRotation_;
    public Vector3 mainMenuLocation_;

    public Vector3 leaderBoardRotation_;
    public Vector3 leaderBoardLocation_;


    private int currentStep_;
    public int totalSteps_;


    void Awake()
    {
        if (controller_ == null)
        {
            DontDestroyOnLoad(gameObject);
            controller_ = this;
        }
        else if (controller_ != this)
        {
            Destroy(gameObject);
        }
    }


    // Use this for initialization
    void Start () {

        //camera_ = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Main_Camera_Behaviour>();

        currentAppState_ = APPSTATE.MAINMENU;
	}
	
	// Update is called once per frame
	void Update () {
		
        if (currentAppState_ == APPSTATE.PLAYING)
        {
            if (Input.GetMouseButtonDown(0))
            {
                GotoNextStep();
            }
        }
        else if (currentAppState_ == APPSTATE.MAINMENU)
        {
            if (Input.GetMouseButtonDown(0))
            {
                ChangeAppState(APPSTATE.PLAYING);
            }
        }
        
	}


    public void StartGame()
    {
        currentStep_ = 0;
        camera_.GotoPosition(stepLocations_[currentStep_], stepRotations_[currentStep_]);
    }

    public void EndGame()
    {
        camera_.GotoPosition(mainMenuLocation_, mainMenuRotation_);
        ChangeAppState(APPSTATE.MAINMENU);
    }


    public void GotoNextStep()
    {
        if (currentAppState_ == APPSTATE.PLAYING)
        {

            currentStep_++;
            if (currentStep_ >= totalSteps_)
            {
                EndGame();
            }
            else
            {
                camera_.GotoPosition(stepLocations_[currentStep_], stepRotations_[currentStep_]);
            }
        }
    }


    void ChangeAppState(APPSTATE newState)
    {
        switch (currentAppState_)
        {
            case APPSTATE.LEADERBOARD:
                break;
            case APPSTATE.MAINMENU:
                break;
            case APPSTATE.PLAYING:
                break;
            case APPSTATE.GAMEOVER:
                break;
        }

        currentAppState_ = newState;

        switch (currentAppState_)
        {
            case APPSTATE.LEADERBOARD:
                break;

            case APPSTATE.MAINMENU:
                break;

            case APPSTATE.PLAYING:

                StartGame();
                break;

            case APPSTATE.GAMEOVER:
                break;
        }

    }


    public int CurrentStep()
    {
        return currentStep_;
    }

}
