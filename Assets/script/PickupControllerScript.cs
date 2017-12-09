using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupControllerScript : MonoBehaviour
{

    public Rigidbody2D body;
    public GameObject spawnNode;

    // Use this for initialization
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setRelatedNode(GameObject node)
    {
        this.spawnNode = node;
        body.position = new Vector2(spawnNode.transform.position.x, spawnNode.transform.position.y);
    }
}