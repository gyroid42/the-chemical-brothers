using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_Camera_Behaviour : MonoBehaviour {


    public List<Vector3> cameraPositions_;
    public float speed_;


    private float yaw = 0.0f;
    private float pitch = 0.0f;

    private float rotSpeed_;
    private Vector3 gotoRot_;
    private Vector3 gotoPos_;
    private int currentPos_;
    private bool isMoving_;
    private Vector3 rotDir_;
    private Vector3 moveDir_;

	// Use this for initialization
	void Start () {

        //transform.position = cameraPositions_[0];
	}
	
	// Update is called once per frame
	void Update () {
		
        if (isMoving_)
        {

            Vector3 moveDistance = moveDir_ * speed_ * Time.deltaTime;
            transform.position += moveDistance;

            transform.eulerAngles += rotDir_ * rotSpeed_ * Time.deltaTime;

            if ( (gotoPos_ - transform.position).sqrMagnitude <= moveDistance.sqrMagnitude )
            {

                transform.position = gotoPos_;
                transform.eulerAngles = gotoRot_;
                isMoving_ = false;
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                //GotoNextPosition();
            }
        }

	}



    public void GotoNextPosition()
    {

        currentPos_++;
        currentPos_ %= cameraPositions_.Count;

        isMoving_ = true;

        moveDir_ = cameraPositions_[currentPos_] - transform.position;
        moveDir_.Normalize();
    }


    public void GotoPosition(Vector3 newPos, Vector3 newRot)
    {
        gotoPos_ = newPos;
        gotoRot_ = newRot;

        moveDir_ = gotoPos_ - transform.position;
        moveDir_.Normalize();

        rotDir_ = gotoRot_ - transform.rotation.eulerAngles;
        rotDir_.Normalize();

        float time = ((gotoPos_ - transform.position) / speed_).magnitude;

        rotSpeed_ = (gotoRot_ - transform.rotation.eulerAngles).magnitude / time;

        isMoving_ = true;
    }


    public bool FinishedMove()
    {
        return !isMoving_;
    }
}
