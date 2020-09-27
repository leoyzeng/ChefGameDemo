using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{

    public static bool inCollider;
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(RocketJumpCollisionCheck.intersection1.X, RocketJumpCollisionCheck.intersection1.Y);
        Debug.Log(inCollider);
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.collider.tag == "Ground"){
            inCollider = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision){
        if(collision.collider.tag == "Ground"){
            inCollider = false;
        } 
    }
}
