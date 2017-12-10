using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamShake : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Invoke("ScreenShake", 2);
	}


	
	// Update is called once per frame
	void Update () {
		
	}
}
