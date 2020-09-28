using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// draws a line from center of character to where the mouse is pointing 
public class DrawLine : MonoBehaviour
{
    private LineRenderer lineRend;    // line renderer to draw line 
    public static Vector2 mousePos;    // current mouse position
    public static Vector2 startPos;    // current character position 
    
    // Start is called before the first frame update
    void Start()
    {
        lineRend = GetComponent<LineRenderer>();
        lineRend.positionCount = 2;    // 2 points to create the line 
    }

    // Update is called once per frame
    void Update()
    {
        startPos = GameObject.Find("Character ChefBoy Default GameSize").transform.position;    // pudate character's current position 
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);    // update mouse's current position 
        lineRend.SetPosition(0, new Vector3(startPos.x, startPos.y, 0f));    // draw line 
        lineRend.SetPosition(1, new Vector3(mousePos.x, mousePos.y, 0f));
    }
}
