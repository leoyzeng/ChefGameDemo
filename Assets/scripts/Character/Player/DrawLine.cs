using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// draws a line from center of character to where the mouse is pointing 
public class DrawLine : MonoBehaviour
{
    private LineRenderer lineRend;    // line renderer to draw line 
    public Vector2 mousePos;    // current mouse position
    public Vector2 startPos;    // current character position 
    float characterPlane = 0f;    // z position of the character (line should be on same plane)
    
    // Start is called before the first frame update
    void Start()
    {
        
        lineRend = GetComponent<LineRenderer>();
        lineRend.positionCount = 2;    // 2 points to create the line 
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 screenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        mousePos = GetWorldPositionOnPlane(screenPosition, characterPlane);
        startPos = GameObject.Find("Character ChefBoy Default GameSize").transform.position;    // pudate character's current position 
        //mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);    // update mouse's current position 
        lineRend.SetPosition(0, new Vector3(startPos.x, startPos.y, characterPlane));    // draw line 
        lineRend.SetPosition(1, new Vector3(mousePos.x, mousePos.y, characterPlane));
        // Debug.DrawLine(startPos, mousePos, Color.blue);    // draw the line from center of character to mouse 

    }

    // convert mouse position to game position at z = 0
    public Vector3 GetWorldPositionOnPlane(Vector3 screenPosition, float z) 
    {
        Ray ray = Camera.main.ScreenPointToRay(screenPosition);
        Plane xy = new Plane(Vector3.forward, new Vector3(0, 0, z));
        float distance;
        xy.Raycast(ray, out distance);
        return ray.GetPoint(distance);
    }
}
