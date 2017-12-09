using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragoatMove : MonoBehaviour {

    public Transform StartPositionDragoat;
    public Transform EndPositionDragoat;
    float StartTime;
    float TotalDistanceToDestination;
    public CthulhuMovement cthulu;


	// Use this for initialization
	protected void Start () {
        StartTime = Time.time;
        TotalDistanceToDestination = Vector3.Distance(StartPositionDragoat.position, EndPositionDragoat.position);
	}
	
	// Update is called once per frame
	void Update () {
        float currentDuration = Time.time - StartTime;
        float jorneyFraction = currentDuration / TotalDistanceToDestination;
        transform.position = Vector3.Lerp(StartPositionDragoat.position, EndPositionDragoat.position, jorneyFraction * 3);
        //if(Input.GetKeyDown("k"))
        //{
        //    EndPositionDragoat.Translate(2f, 0, 0);//(Vector3.right)
        //    StartPositionDragoat = transform;
        //    StartTime = Time.time;
        //    TotalDistanceToDestination = Vector3.Distance(StartPositionDragoat.position, EndPositionDragoat.position);
        //    cthulu.SetVariables();
        //}
        //if (Input.GetKeyDown("j"))
        //{
        //    EndPositionDragoat.Translate(-2f,0,0); //(Vector3.left)
        //    StartPositionDragoat = transform;
        //    StartTime = Time.time;
        //    TotalDistanceToDestination = Vector3.Distance(StartPositionDragoat.position, EndPositionDragoat.position);
        //    cthulu.SetVariables();
        //}
        

    }

    public void LeftPlayerScored(int score)
    {
        EndPositionDragoat.Translate(score*2f, 0, 0);//(Vector3.right)
        StartPositionDragoat = transform;
        StartTime = Time.time;
        TotalDistanceToDestination = Vector3.Distance(StartPositionDragoat.position, EndPositionDragoat.position);
        cthulu.SetVariables();
    }

    public void RightPlayerScored(int score)
    {
        EndPositionDragoat.Translate(score*-2f, 0, 0); //(Vector3.left)
        StartPositionDragoat = transform;
        StartTime = Time.time;
        TotalDistanceToDestination = Vector3.Distance(StartPositionDragoat.position, EndPositionDragoat.position);
        cthulu.SetVariables();
    }
}
