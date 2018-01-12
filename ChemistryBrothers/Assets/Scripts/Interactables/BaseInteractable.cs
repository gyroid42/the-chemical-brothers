using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseInteractable : MonoBehaviour {

    public Vector3 workAreaPosition_;
    public Vector3 startPosition_;
    public Vector3 endPosition_;
    private Vector3 gotoPosition_;
    private Vector3 moveDir_;
    protected float speed_;
    protected bool isMoving_;

	// Use this for initialization
	void Start () {

        speed_ = 1.0f;
        isMoving_ = false;
	}

    void Update()
    {
        if (isMoving_)
        {

            Vector3 moveDistance = moveDir_ * speed_ * Time.deltaTime;
            transform.position += moveDir_ * speed_ * Time.deltaTime;
            if ((gotoPosition_ - transform.position).sqrMagnitude <= moveDistance.sqrMagnitude)
            {
                transform.position = gotoPosition_;
                isMoving_ = false;
            }
        }
    }
	
	// Update is called once per frame
	public virtual void UpdateInteractable() {
	}

    public virtual void EnterWorkArea()
    {
        gotoPosition_ = workAreaPosition_;
        moveDir_ = gotoPosition_ - transform.position;
        moveDir_.Normalize();
        isMoving_ = true;

        Debug.Log(gotoPosition_);

    }

    public virtual void ExitWorkArea()
    {
        gotoPosition_ = endPosition_;
        moveDir_ = gotoPosition_ - transform.position;
        moveDir_.Normalize();
        isMoving_ = true;

        Debug.Log(gotoPosition_);
    }

    public virtual void Reset()
    {
        transform.position = startPosition_;
        isMoving_ = false;
    }


}
