using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// display information about the line from DrawLine
public class DisplayLineText : MonoBehaviour
{
    [SerializeField]
    private Text mouseInfo;    // text box 
    float distance;    // distance between 2 points 
    float slope;    // slope of the line 
    float rise;    // y difference 
    float run;    // x difference 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distance = (DrawLine.mousePos - DrawLine.startPos).magnitude;    // calculate distance 
        rise = DrawLine.mousePos.y - DrawLine.startPos.y;    // calculate rise 
        run = DrawLine.mousePos.x - DrawLine.startPos.x;    // calculate run 
        slope = (DrawLine.mousePos.y - DrawLine.startPos.y) / (DrawLine.mousePos.x - DrawLine.startPos.x);    // calculate slope 
        mouseInfo.text =  DrawLine.startPos.ToString("F2") + "\n" +  DrawLine.mousePos.ToString("F2") + "\n" + distance + "\n" + rise + "\n" + run + "\n" + slope;
        // display information to text box 
    }
}
