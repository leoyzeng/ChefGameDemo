using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// checks if the mouse is currently inside a collider 
// put a collider at the position of intersection
// check if this collider is in another collider 
public class Collision : MonoBehaviour
{

    public static bool inCollider;    // if the mouse and rocket jump radius is inside a collider 

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(RocketJumpCollisionCheck.intersection1.X, RocketJumpCollisionCheck.intersection1.Y);    // update collider position 
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.collider.tag == "Ground"){    // if this collider touches another collider 
            inCollider = true;    // incollider is true 
        }
    }
    private void OnCollisionExit2D(Collision2D collision){
        if(collision.collider.tag == "Ground"){
            inCollider = false;
        } 
    }
}
