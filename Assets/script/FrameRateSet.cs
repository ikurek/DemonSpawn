using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameRateSet : MonoBehaviour {

    public int desiredFPS = 30;
    
    void Awake()
    {
        Application.targetFrameRate = -1;
        QualitySettings.vSyncCount = 0;
    }


    // Update is called once per frame
    void Update()
    {
        long lastTicks = DateTime.Now.Ticks;
        long currentTicks = lastTicks;
        float delay = 1f / desiredFPS;
        float elapsedTime;

        if (desiredFPS <= 0)
            return;

        while (true)
        {
            currentTicks = DateTime.Now.Ticks;
            elapsedTime = (float)TimeSpan.FromTicks(currentTicks - lastTicks).TotalSeconds;
            if (elapsedTime >= delay)
            {
                break;
            }
        }
    }
}
