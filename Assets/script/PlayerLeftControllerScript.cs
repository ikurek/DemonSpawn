using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLeftControllerScript : MonoBehaviour {

    public int points = 0;
    public float maxSpeed = 10;
    public Rigidbody2D body;
    public bool hasElement = false;
    public GameObject pickedObject;

	// Use this for initialization
	void Start () {
        body = GetComponent<Rigidbody2D>();
        Debug.Log("Created Player 1!");
    }

    // Update is called once per frame
    void Update () {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        body.velocity = new Vector2(x * maxSpeed, y * maxSpeed);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        // Check if object is a Pickup
        // Don't pick if already has an element picked
        if (coll.gameObject.CompareTag("Pickup")  && !hasElement)
            {
                // Mark hasElement
                hasElement = true;
                // Create another element
                pickedObject = Instantiate(coll.gameObject);
                // Destroy old pickup
                Destroy(coll.gameObject);
            }

        // Check if objcet is pickup destination
        else if (coll.gameObject.CompareTag("PickupDestination1") && hasElement)
        {
            // Remove element from player
            hasElement = false;
            // Increase points
            points++;
            Debug.Log("Player 1 Points: " + points);
        }

        else if (coll.gameObject.CompareTag("FieldLeft"))
        {
            Debug.Log("Player 1 Collided with field bounds!");
            body.velocity = new Vector2(0, 0);
        }
    }
}