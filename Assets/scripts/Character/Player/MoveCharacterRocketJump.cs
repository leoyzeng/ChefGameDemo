using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// character movement by rocket jumping 
public class MoveCharacterRocketJump : MonoBehaviour
{

    GameObject chefBoy;
    Collision collision;

    GameObject rocketJump;
    RocketJumpCollisionCheck rocketJumpCollisionCheck;

    // Start is called before the first frame update
    void Start()
    {
        chefBoy = GameObject.Find("Character ChefBoy Default GameSize");
        collision = chefBoy.GetComponent<Collision>();

        rocketJump = GameObject.Find("RocketJump");
        rocketJumpCollisionCheck = rocketJump.GetComponent<RocketJumpCollisionCheck>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && collision.inCollider == true){    // if player click mouse and intersection point is inside a collider
            // add a for equal to opposite direction of where the player clicked 
            float run = -rocketJumpCollisionCheck.run;
            float rise = -rocketJumpCollisionCheck.rise;
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(run, rise), ForceMode2D.Impulse);
        }
    }
}
