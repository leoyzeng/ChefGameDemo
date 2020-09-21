using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class MoveCharacter : MonoBehaviour{
    public float moveSpeed = 5f;
    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        jump();
        move();
    }

    void move(){
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * moveSpeed;
    }

    void jump(){
        if (Input.GetButtonDown("Jump")){
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 5f), ForceMode2D.Impulse);
        }   
    }
}
