using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CthulhuMovement : MonoBehaviour
{

    public Transform StartPositionCthulhu;
    public Transform EndPositionCthulhu;
    float StartTime;
    float TotalDistanceToDestination;
    public AnimationCurve velocity;


    // Use this for initialization
    protected void Start()
    {
        StartTime = Time.time;
        TotalDistanceToDestination = Vector3.Distance(StartPositionCthulhu.position, EndPositionCthulhu.position);
    }

    // Update is called once per frame
    void Update()
    {

        //float currentDuration = Time.time - StartTime;
        //float jorneyFraction = currentDuration / TotalDistanceToDestination;
        //float normalizedDistance = (transform.position - EndPositionCthulhu.position).magnitude * 0.05f;
        //transform.position = Vector3.Lerp(transform.position, EndPositionCthulhu.position, 0.017f * normalizedDistance);

        float currentDuration = Time.time - StartTime;
        float jorneyFraction = currentDuration / TotalDistanceToDestination;
        transform.position = Vector3.Lerp(StartPositionCthulhu.position, EndPositionCthulhu.position, velocity.Evaluate(currentDuration * 0.5f));

        //float currentDuration = Time.time - StartTime;
        //float jorneyFraction = currentDuration / TotalDistanceToDestination;
        //transform.position = Vector3.Lerp(StartPositionCthulhu.position, EndPositionCthulhu.position, jorneyFraction * 3);

    }

    public void SetVariables()
    {
        StartPositionCthulhu = transform;
        StartTime = Time.time;
        TotalDistanceToDestination = Vector3.Distance(StartPositionCthulhu.position, EndPositionCthulhu.position);

    }
}
