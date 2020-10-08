using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// display information about the line from DrawLine
public class DisplayLineText : MonoBehaviour
{
    [SerializeField]
    public Text mouseInfo;    // text box 
    float distance;    // distance between 2 points 
    float slope;    // slope of the line 
    float rise;    // y difference 
    float run;    // x difference 

    GameObject rocketJump;
    DrawLine drawLine;
    // Start is called before the first frame update
    void Start()
    {
        rocketJump = GameObject.Find("RocketJump");
        drawLine = rocketJump.GetComponent<DrawLine>();
    }

    // Update is called once per frame
    void Update()
    {

        distance = (drawLine.mousePos - drawLine.startPos).magnitude;    // calculate distance 
        rise = drawLine.mousePos.y - drawLine.startPos.y;    // calculate rise 
        run = drawLine.mousePos.x - drawLine.startPos.x;    // calculate run 
        slope = (drawLine.mousePos.y - drawLine.startPos.y) / (drawLine.mousePos.x - drawLine.startPos.x);    // calculate slope 
        mouseInfo.text = drawLine.startPos.ToString("F2") + "\n" +
            drawLine.mousePos.ToString("F2") + "\n" + distance + 
            "\n" + rise + "\n" + run + "\n" + slope;
        // display information to text box 
    }
}
