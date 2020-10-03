using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

// move the character left/right/jump
public class MoveCharacter : MonoBehaviour{

    [SerializeField] private LayerMask platformLayerMask;
    //private Player_Base playerBase;
    private Rigidbody2D rigidbody2d;
    private BoxCollider2D boxCollider2d;

    void Awake(){
        //playerBase = gameObject.GetComponent<Player_Base>();
        rigidbody2d = transform.GetComponent<Rigidbody2D>();
        boxCollider2d = transform.GetComponent<BoxCollider2D>();
    }

    public float moveSpeed = 10f;    // movement speed 
    // public bool isGrounded = false;    // whether the character is touching the ground or not 
    // Start is called before the first frame update
    void Start(){
        
    }

    // FixedUpdate is called once per physics frame
    void FixedUpdate(){
        move();    // move must be in FixedUpdate to not mess with rigidbody and jitter
    }

    // Update is called once per frame
    void Update(){
        jump();    // if jump is in FixedUpdate, otherwise you can't jump???
        isGrounded();
    }

    // move the character left / right based on player input 
    void move(){
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);    // horizontal 
        transform.position += movement * Time.deltaTime * moveSpeed;    // add movement 
    }

    void jump(){
        if (Input.GetButtonDown("Jump") && isGrounded()){    // if player press jump and character is touching ground
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 5f), ForceMode2D.Impulse);    // jump up 
        }   
    }

    
    // check if the character is on the ground 
    // creates a boxcast below the character and checks if the boxcast intersects with any platform colliders 
    // returns true if it is touching a platform 
    private bool isGrounded(){
        float extraHeight = 0.01f;    // small extra value so that the boxcast extends farther than the player's collider 
        Vector3 size = boxCollider2d.bounds.size;    // size of the box cast 
        size.x -= 0.1f;    // make the x value slighty smaller than player's collider x so that the boxcast does not trigger when the player is next to a vertical wall 
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider2d.bounds.center, size, 0f, Vector2.down, extraHeight, platformLayerMask);    // create the boxcast pointing down 
        Color rayColor;    // color 
        if(raycastHit.collider != null){    // change the color based on whether it hits a collider or not 
            rayColor = Color.green;    // green = touching ground 
        }
        else{
            rayColor = Color.red;    // red = not touching ground 
        }
        // draw the box cast 
        Debug.DrawRay(boxCollider2d.bounds.center + new Vector3(boxCollider2d.bounds.extents.x-0.1f, 0), Vector2.down * (boxCollider2d.bounds.extents.y + extraHeight), rayColor);
        Debug.DrawRay(boxCollider2d.bounds.center - new Vector3(boxCollider2d.bounds.extents.x-0.1f, 0), Vector2.down * (boxCollider2d.bounds.extents.y + extraHeight), rayColor);
        Debug.DrawRay(boxCollider2d.bounds.center - new Vector3(boxCollider2d.bounds.extents.x-0.1f, boxCollider2d.bounds.extents.y ), Vector2.right * (boxCollider2d.bounds.extents), rayColor);
        
        Debug.Log(raycastHit.collider);
        return raycastHit.collider != null;    // return whether character is touching ground/platform 
    }
}
