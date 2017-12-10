using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragoatMove : MonoBehaviour {

    public Transform StartPositionDragoat;
    public Transform EndPositionDragoat;
    float StartTime;
    float TotalDistanceToDestination;
    public CthulhuMovement cthulu;
    public AnimationCurve velocity;



    // Use this for initialization
    protected void Start () {
        StartTime = Time.time;
        TotalDistanceToDestination = Vector3.Distance(StartPositionDragoat.position, EndPositionDragoat.position);
	}
	
	// Update is called once per frame
	void Update () {
        float currentDuration = Time.time - StartTime;
        float jorneyFraction = currentDuration / TotalDistanceToDestination;
        transform.position = Vector3.Lerp(StartPositionDragoat.position, EndPositionDragoat.position, velocity.Evaluate(currentDuration * 0.5f));
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

    public IEnumerator ScaleObject()
    {
        float scaleDuration = 0.5f;                                //animation duration in seconds
        Vector3 actualScale = transform.localScale;             // scale of the object at the begining of the animation
        Vector3 targetScale = new Vector3(1.1f, 1.1f, 1.1f);     // scale of the object at the end of the animation

        for (float t = 0; t < 1; t += Time.deltaTime / scaleDuration)
        {
            transform.localScale = Vector3.Lerp(actualScale, targetScale, t);
            yield return null;
        }
    }



    public void LeftPlayerScored(int score)
    {
        EndPositionDragoat.Translate(score*2f, 0, 0);//(Vector3.right)
        StartPositionDragoat = transform;
        StartTime = Time.time;
        TotalDistanceToDestination = Vector3.Distance(StartPositionDragoat.position, EndPositionDragoat.position);
        cthulu.SetVariables();
        ScaleObject();
    }

    public void RightPlayerScored(int score)
    {
        EndPositionDragoat.Translate(score*-2f, 0, 0); //(Vector3.left)
        StartPositionDragoat = transform;
        StartTime = Time.time;
        TotalDistanceToDestination = Vector3.Distance(StartPositionDragoat.position, EndPositionDragoat.position);
        cthulu.SetVariables();
        ScaleObject();
    }
}
