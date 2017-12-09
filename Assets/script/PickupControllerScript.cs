using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupControllerScript : MonoBehaviour {

    public Rigidbody2D body;

	// Use this for initialization
	void Start () {
        body = GetComponent<Rigidbody2D>();

        float spawnY = Random.Range
                (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y);
        float spawnX = Random.Range
            (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);

        body.position = new Vector2(spawnX, spawnY);

    }

    // Update is called once per frame
    void Update () {
		
	}
}
