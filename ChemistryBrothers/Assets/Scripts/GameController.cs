using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum APPSTATE
{
    PLAYING,
    MAINMENU,
    GAMEOVER,
    SCORESCREEN
}

public enum STEPSTATE
{
    WORKING,
    STARTSCREEN,
    TRANSITIONINGTOSTART,
    TRANSITIONINGTOWORKING
}

public class GameController : MonoBehaviour {

    public static GameController controller_;

    public List<BaseInteractable> interactables_;
    private List<List<int>> stepInteractables_;
    private List<BaseInteractable> activeInteractables_;

    public int mistakes_;

    public Main_Camera_Behaviour camera_;
    public APPSTATE currentAppState_;
    private STEPSTATE currentStepState_;

    public List<Vector3> stepRotations_;
    public List<Vector3> stepLocations_;

    public Vector3 mainMenuRotation_;
    public Vector3 mainMenuLocation_;


    private int currentStep_;
    public int totalSteps_;


    // on awake make sure there is only one instance of the object containing this script
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

        // set camera to start position
        camera_.transform.position = mainMenuLocation_;
        camera_.transform.eulerAngles = mainMenuRotation_;

        // set all the interactables for each step
        stepInteractables_ = new List<List<int>>();
        stepInteractables_.Add(new List<int> { 0, 1 });
        stepInteractables_.Add(new List<int> { 0, 1, 2, 3 });
        stepInteractables_.Add(new List<int> { 0 });
        stepInteractables_.Add(new List<int> { 1 });
        stepInteractables_.Add(new List<int> { 0 });
        stepInteractables_.Add(new List<int> { 1 });
        stepInteractables_.Add(new List<int> { 0 });
        stepInteractables_.Add(new List<int> { 1 });
        stepInteractables_.Add(new List<int> { 0 });
        stepInteractables_.Add(new List<int> { 1 });
        stepInteractables_.Add(new List<int> { 0 });
        activeInteractables_ = new List<BaseInteractable>();

        // set app state to main menu
        currentAppState_ = APPSTATE.MAINMENU;
	}
	
	// Update is called once per frame
	void Update () {
		
        // if the game is playing
        if (currentAppState_ == APPSTATE.PLAYING)
        {

            // goto update method for current game state
            switch (currentStepState_)
            {
                case STEPSTATE.STARTSCREEN:
                    StartStepUpdate();
                    break;

                case STEPSTATE.WORKING:
                    StepUpdate();
                    break;


                case STEPSTATE.TRANSITIONINGTOSTART:
                    if (camera_.FinishedMove())
                    {
                        currentStepState_ = STEPSTATE.STARTSCREEN;
                    }
                    break;

                case STEPSTATE.TRANSITIONINGTOWORKING:
                    if (camera_.FinishedMove())
                    {
                        currentStepState_ = STEPSTATE.WORKING;
                    }
                    break;

            }

        }

        //
        else if (currentAppState_ == APPSTATE.MAINMENU)
        {
            
        }
        
	}


    public void StartGame()
    {
        currentStep_ = 0;
        currentStepState_ = STEPSTATE.STARTSCREEN;
        camera_.GotoPosition(stepLocations_[0], stepRotations_[0]);
    }

    public void EndGame()
    {

        for (int i = 0; i < interactables_.Count; i++)
        {
            interactables_[i].Reset();
        }
        camera_.GotoPosition(mainMenuLocation_, mainMenuRotation_);
        ChangeAppState(APPSTATE.SCORESCREEN);
    }


    void ChangeAppState(APPSTATE newState)
    {
        switch (currentAppState_)
        {
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

    public APPSTATE CurrentAppState()
    {
        return currentAppState_;
    }

    // Determine if game is in PLAYING state for UI rendering
    public bool GamePlaying()
    {
        if (currentAppState_ == APPSTATE.PLAYING)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void StepUpdate()
    {

        for (int i = 0; i < activeInteractables_.Count; i++)
        {
            activeInteractables_[i].UpdateInteractable();
        }

        if ( Input.GetMouseButtonDown(0))
        {
        }
    }

    private void StartStepUpdate()
    {

        if (Input.GetMouseButtonDown(0))
        {
            activeInteractables_.Clear();
            for (int i = 0; i < stepInteractables_[currentStep_].Count; i++) {

                activeInteractables_.Add(interactables_[stepInteractables_[currentStep_][i]]);

                interactables_[stepInteractables_[currentStep_][i]].EnterWorkArea();
            }
            camera_.GotoPosition(stepLocations_[1], stepRotations_[1]);
            currentStepState_ = STEPSTATE.TRANSITIONINGTOWORKING;
        }
    }

    public void EndStep()
    {
        if (currentAppState_ == APPSTATE.PLAYING)
        {
            currentStep_++;

            for (int i = 0; i < activeInteractables_.Count; i++)
            {
                activeInteractables_[i].ExitWorkArea();
            }

            if (currentStep_ >= totalSteps_)
            {
                EndGame();
            }
            else
            {
                camera_.GotoPosition(stepLocations_[0], stepRotations_[0]);
                currentStepState_ = STEPSTATE.TRANSITIONINGTOSTART;

            }
        }
    }


    // The functions below are hard coded functions for state switching based on user input
    // They trigger once buttons are pressed on the interfaces
    public void SetStatePlaying()
    {
        ChangeAppState(APPSTATE.PLAYING);
    }

    public void SetStateMenu()
    {
        ChangeAppState(APPSTATE.MAINMENU);
    }

    public void SetStateGameOver()
    {
        ChangeAppState(APPSTATE.GAMEOVER);
    }

    // When this is called, the game will close
    public void ExitGame()
    {
        Application.Quit();
    }


}
