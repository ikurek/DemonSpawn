using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CthulhuMovement : MonoBehaviour
{

    public Transform StartPositionCthulhu;
    public Transform EndPositionCthulhu;
    float StartTime;
    float TotalDistanceToDestination;


    // Use this for initialization
    protected void Start()
    {
        StartTime = Time.time;
        TotalDistanceToDestination = Vector3.Distance(StartPositionCthulhu.position, EndPositionCthulhu.position);
    }

    // Update is called once per frame
    void Update()
    {
        float currentDuration = Time.time - StartTime;
        float jorneyFraction = currentDuration / TotalDistanceToDestination;
        transform.position = Vector3.Lerp(StartPositionCthulhu.position, EndPositionCthulhu.position, jorneyFraction * 3);

    }

    public void SetVariables()
    {
        StartPositionCthulhu = transform;
        StartTime = Time.time;
        TotalDistanceToDestination = Vector3.Distance(StartPositionCthulhu.position, EndPositionCthulhu.position);

    }
}
