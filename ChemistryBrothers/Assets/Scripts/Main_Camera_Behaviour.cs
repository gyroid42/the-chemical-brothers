using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_Camera_Behaviour : MonoBehaviour {


    public List<Vector3> cameraPositions_;
    public float speed_;

    private int currentPos_;
    private bool isMoving_;
    private Vector3 moveDir_;

	// Use this for initialization
	void Start () {

        transform.position = cameraPositions_[0];

	}
	
	// Update is called once per frame
	void Update () {
		
        if (isMoving_)
        {

            Vector3 moveDistance = moveDir_ * speed_ * Time.deltaTime;
            transform.position += moveDistance;

            if ( (cameraPositions_[currentPos_] - transform.position).sqrMagnitude <= moveDistance.sqrMagnitude )
            {

                transform.position = cameraPositions_[currentPos_];
                isMoving_ = false;
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                GotoNextPosition();
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
}
