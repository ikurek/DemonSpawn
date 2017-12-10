using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WinCondition : MonoBehaviour
{
    private DragoatMove Dragoat;
    private Rigidbody rb;
    public Text winLeft;
    public Text winRight;
    public


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collided");

        if (collision.gameObject.CompareTag("WinLeft"))
        {
//winLeft.text = "Dragoat zniszczony!!!!!!!!!!!!!";
            winLeft.gameObject.SetActive(true);
            Debug.Log("Dragoat zniszczony!!!!!!!!!!!!!");
        }
        if (collision.gameObject.CompareTag("WinRight"))
        {
            //winRight.text = "Cthulu zniszczony!!!!!!!!!!!!!";
            winRight.gameObject.SetActive(true);
            Debug.Log("Cthulu zniszczony!!!!!!!!!!!!!");
        }
    }

}