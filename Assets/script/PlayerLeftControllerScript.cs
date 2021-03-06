﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerLeftControllerScript : MonoBehaviour {

    // Object
    public int points = 0;
    public int level = 1;
    public Rigidbody2D body;
    // Nodes
    public int currentNode = 0;
    public ArrayList pentagramNodes = new ArrayList();
    public ArrayList pentagramNodeButtons = new ArrayList();
    public GameObject node;
    public Dictionary<int, ArrayList> nodeMap = new Dictionary<int, ArrayList>();
    // Related boss
    public DragoatMove dr;
    // Buttons
    public Sprite yButton;
    public Sprite xButton;
    public Sprite aButton;
    public Sprite bButton;
    // Audio
    public AudioClip collisionSound;
    private AudioSource audioSource;
    // Candles
    public Sprite candleOn;
    public Sprite candleOff;

    // Use this for initialization
    void Start () {
        body = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        buildNodeTable();
        buildNodeButtonsTable();
        Debug.Log("Created Player 1!");
        spawnPickups();
        clearButtonRoutes();
        updateButtonRoutes(nodeMap[currentNode]);
    }

    // Update is called once per frame
    void Update () {

        ArrayList availableNodes = nodeMap[currentNode];

        foreach (KeyCode kcode in Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(kcode))
            {
                switch(kcode)
                {
                    case KeyCode.A:
                        node = availableNodes[1] as GameObject;
                        currentNode = pentagramNodes.IndexOf(node);
                        availableNodes = nodeMap[currentNode];
                        body.position = new Vector2(node.transform.position.x, node.transform.position.y);

                        break;

                    case KeyCode.W:
                        node = availableNodes[0] as GameObject;
                        currentNode = pentagramNodes.IndexOf(node);
                        availableNodes = nodeMap[currentNode];
                        body.position = new Vector2(node.transform.position.x, node.transform.position.y);

                        break;

                    case KeyCode.D:
                        node = availableNodes[2] as GameObject;
                        currentNode = pentagramNodes.IndexOf(node);
                        availableNodes = nodeMap[currentNode];
                        body.position = new Vector2(node.transform.position.x, node.transform.position.y);

                        break;

                    case KeyCode.S:
                        node = availableNodes[3] as GameObject;
                        currentNode = pentagramNodes.IndexOf(node);
                        availableNodes = nodeMap[currentNode];
                        body.position = new Vector2(node.transform.position.x, node.transform.position.y);

                        break;
                }

                clearButtonRoutes();
                updateButtonRoutes(availableNodes);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {

        if (coll.gameObject.CompareTag("Pickup"))
        {
            // Play audio
            audioSource.PlayOneShot(collisionSound, 0.7F);

            // Destroy old pickup

            GameObject nodeToLightCandle = coll.gameObject.GetComponent<PickupControllerScript>().spawnNode;
            nodeToLightCandle.GetComponent<SpriteRenderer>().sprite = candleOn;
            Destroy(coll.gameObject);
            points++;

            // Validate points
            if(points >= 4)
            {
                points = 0;                
                level++;
                dr.LeftPlayerScored(1);
                spawnPickups();
                Debug.Log("Player 1 level: " + level);
            }
        }

    }

    private void buildNodeTable()
    {

        // Map all node positions
        pentagramNodes.Add(GameObject.Find("PentagramLeft/Node0"));
        pentagramNodes.Add(GameObject.Find("PentagramLeft/Node1"));
        pentagramNodes.Add(GameObject.Find("PentagramLeft/Node2"));
        pentagramNodes.Add(GameObject.Find("PentagramLeft/Node3"));
        pentagramNodes.Add(GameObject.Find("PentagramLeft/Node4"));
        pentagramNodes.Add(GameObject.Find("PentagramLeft/Node5"));
        pentagramNodes.Add(GameObject.Find("PentagramLeft/Node6"));
        pentagramNodes.Add(GameObject.Find("PentagramLeft/Node7"));
        pentagramNodes.Add(GameObject.Find("PentagramLeft/Node8"));
        pentagramNodes.Add(GameObject.Find("PentagramLeft/Node9"));

        // Neighbourgh list for every node
        ArrayList listOf0 = new ArrayList();
        ArrayList listOf1 = new ArrayList();
        ArrayList listOf2 = new ArrayList();
        ArrayList listOf3 = new ArrayList();
        ArrayList listOf4 = new ArrayList();
        ArrayList listOf5 = new ArrayList();
        ArrayList listOf6 = new ArrayList();
        ArrayList listOf7 = new ArrayList();
        ArrayList listOf8 = new ArrayList();
        ArrayList listOf9 = new ArrayList();

        listOf0.Add(pentagramNodes[1]);
        listOf0.Add(pentagramNodes[2]);
        listOf0.Add(pentagramNodes[3]);
        listOf0.Add(pentagramNodes[4]);

        listOf1.Add(pentagramNodes[0]);
        listOf1.Add(pentagramNodes[2]);
        listOf1.Add(pentagramNodes[5]);
        listOf1.Add(pentagramNodes[8]);
    
        listOf2.Add(pentagramNodes[0]);
        listOf2.Add(pentagramNodes[1]);
        listOf2.Add(pentagramNodes[3]);
        listOf2.Add(pentagramNodes[5]);

        listOf3.Add(pentagramNodes[0]);
        listOf3.Add(pentagramNodes[2]);
        listOf3.Add(pentagramNodes[4]);
        listOf3.Add(pentagramNodes[6]);

        listOf4.Add(pentagramNodes[0]);
        listOf4.Add(pentagramNodes[3]);
        listOf4.Add(pentagramNodes[6]);
        listOf4.Add(pentagramNodes[9]);
    
        listOf5.Add(pentagramNodes[1]);
        listOf5.Add(pentagramNodes[2]);
        listOf5.Add(pentagramNodes[7]);
        listOf5.Add(pentagramNodes[8]);

        listOf6.Add(pentagramNodes[3]);
        listOf6.Add(pentagramNodes[4]);
        listOf6.Add(pentagramNodes[7]);
        listOf6.Add(pentagramNodes[9]);

        listOf7.Add(pentagramNodes[5]);
        listOf7.Add(pentagramNodes[6]);
        listOf7.Add(pentagramNodes[8]);
        listOf7.Add(pentagramNodes[9]);

        listOf8.Add(pentagramNodes[1]);
        listOf8.Add(pentagramNodes[5]);
        listOf8.Add(pentagramNodes[7]);
        listOf8.Add(pentagramNodes[9]);

        listOf9.Add(pentagramNodes[4]);
        listOf9.Add(pentagramNodes[6]);
        listOf9.Add(pentagramNodes[7]);
        listOf9.Add(pentagramNodes[8]);


        nodeMap.Add(0, listOf0);
        nodeMap.Add(1, listOf1);
        nodeMap.Add(2, listOf2);
        nodeMap.Add(3, listOf3);
        nodeMap.Add(4, listOf4);
        nodeMap.Add(5, listOf5);
        nodeMap.Add(6, listOf6);
        nodeMap.Add(7, listOf7);
        nodeMap.Add(8, listOf8);
        nodeMap.Add(9, listOf9);

    }

    private void buildNodeButtonsTable()
    {
        pentagramNodeButtons.Add(GameObject.Find("PentagramLeft/Node0Button") as GameObject);
        pentagramNodeButtons.Add(GameObject.Find("PentagramLeft/Node1Button") as GameObject);
        pentagramNodeButtons.Add(GameObject.Find("PentagramLeft/Node2Button") as GameObject);
        pentagramNodeButtons.Add(GameObject.Find("PentagramLeft/Node3Button") as GameObject);
        pentagramNodeButtons.Add(GameObject.Find("PentagramLeft/Node4Button") as GameObject);
        pentagramNodeButtons.Add(GameObject.Find("PentagramLeft/Node5Button") as GameObject);
        pentagramNodeButtons.Add(GameObject.Find("PentagramLeft/Node6Button") as GameObject);
        pentagramNodeButtons.Add(GameObject.Find("PentagramLeft/Node7Button") as GameObject);
        pentagramNodeButtons.Add(GameObject.Find("PentagramLeft/Node8Button") as GameObject);
        pentagramNodeButtons.Add(GameObject.Find("PentagramLeft/Node9Button") as GameObject);
    }

    private void spawnPickups()
    {
        var rng = new System.Random();

        GameObject node0 = pentagramNodes[rng.Next(0, 10)] as GameObject;
        (Instantiate(GameObject.Find("PentagramLeft/PickupLeft") as GameObject)).GetComponent<PickupControllerScript>().setRelatedNode(node0);
        node0.GetComponent<SpriteRenderer>().sprite = candleOff;

        GameObject node1 = pentagramNodes[rng.Next(0, 10)] as GameObject;
        (Instantiate(GameObject.Find("PentagramLeft/PickupLeft") as GameObject)).GetComponent<PickupControllerScript>().setRelatedNode(node1);
        node1.GetComponent<SpriteRenderer>().sprite = candleOff;

        GameObject node2 = pentagramNodes[rng.Next(0, 10)] as GameObject;
        (Instantiate(GameObject.Find("PentagramLeft/PickupLeft") as GameObject)).GetComponent<PickupControllerScript>().setRelatedNode(node2);
        node2.GetComponent<SpriteRenderer>().sprite = candleOff;

        GameObject node3 = pentagramNodes[rng.Next(0, 10)] as GameObject;
        (Instantiate(GameObject.Find("PentagramLeft/PickupLeft") as GameObject)).GetComponent<PickupControllerScript>().setRelatedNode(node3);
        node3.GetComponent<SpriteRenderer>().sprite = candleOff;

    }

    private void updateButtonRoutes(ArrayList availableNodes)
    {

        Debug.Log("Updating buttons");
        (pentagramNodeButtons[pentagramNodes.IndexOf(availableNodes[0])] as GameObject).GetComponent<SpriteRenderer>().sprite = yButton;
        (pentagramNodeButtons[pentagramNodes.IndexOf(availableNodes[1])] as GameObject).GetComponent<SpriteRenderer>().sprite = xButton;
        (pentagramNodeButtons[pentagramNodes.IndexOf(availableNodes[2])] as GameObject).GetComponent<SpriteRenderer>().sprite = aButton;
        (pentagramNodeButtons[pentagramNodes.IndexOf(availableNodes[3])] as GameObject).GetComponent<SpriteRenderer>().sprite = bButton;

    }

    private void clearButtonRoutes()
    {
        foreach (GameObject button in pentagramNodeButtons)
        {
            button.GetComponent<SpriteRenderer>().sprite = new Sprite();
        }
    }

    public float getLevel()
    {
        return level;
    }

    private void clearCandles()
    {
        foreach(GameObject node in pentagramNodes)
        {
            node.GetComponent<SpriteRenderer>().sprite = candleOn;
        }
    }

}