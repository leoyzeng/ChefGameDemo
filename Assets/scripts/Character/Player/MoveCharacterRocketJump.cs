using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// character movement by rocket jumping 
public class MoveCharacterRocketJump : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && Collision.inCollider == true){    // if player click mouse and intersection point is inside a collider
            // add a for equal to opposite direction of where the player clicked 
            float run = -RocketJumpCollisionCheck.run * 1f;
            float rise = -RocketJumpCollisionCheck.rise * 0.4f + 4.5f;
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(run, rise), ForceMode2D.Impulse);
        }
    }
}
