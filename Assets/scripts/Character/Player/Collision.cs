using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// checks if the mouse is currently inside a collider 
// draws a line from center of player to radius and see if it intersects with any colliders 
public class Collision : MonoBehaviour
{
    GameObject rocketJump;
    RocketJumpCollisionCheck rocketJumpCollisionCheck;


    public bool inCollider;    // if the mouse and rocket jump radius is inside a collider 
    [SerializeField] public LayerMask platformLayerMask;    // layer mask so the detection only happens with platforms 
    private Vector2 intersection;    // end of line, intersection between mouse and radius 
    private Vector2 startPos;    // start of line, center of player 
    private RaycastHit2D raycastHit2D;    // ray cast 

    // Start is called before the first frame update
    void Start()
    {
        rocketJump = GameObject.Find("RocketJump");
        rocketJumpCollisionCheck = rocketJump.GetComponent<RocketJumpCollisionCheck>();
    }

    // Update is called once per frame
    void Update()
    {
        inCollider = false;    // set inCollider to false to start 
        updateIntersection();    // update the player's position and line position 
        checkCollision();    // check collision and change inCollider if there is a collision 
        drawLine();    // draw the line for debug purpose 
    }

    // update the startPos and intersection 
    private void updateIntersection(){

        startPos = GameObject.Find("Character ChefBoy Default GameSize").transform.position;    // update startPos (same as character position)
        intersection.x = rocketJumpCollisionCheck.intersection1.X;    // update x and y of the point of intersection 
        intersection.y = rocketJumpCollisionCheck.intersection1.Y;
    }

    // check if the line touches any colliders 
    private void checkCollision(){

        raycastHit2D = Physics2D.Linecast(startPos, intersection, platformLayerMask);    // create a raycast
        if(raycastHit2D.collider != null){    // if the raycast hits a collider 
            inCollider = true;    // turn inCollider to true 
        }
    }

    // draw the line 
    private void drawLine(){  
        Color rayColor;    // color 
        if(raycastHit2D.collider != null){    // change the color based on whether it hits a collider or not 
            rayColor = Color.green;    // green = touching ground 
        }
        else{
            rayColor = Color.red;    // red = not touching ground 
        } 
        Debug.DrawLine(startPos, intersection, rayColor);    // draw the line from center of character to mouse/radius intersection point 
    }

}
