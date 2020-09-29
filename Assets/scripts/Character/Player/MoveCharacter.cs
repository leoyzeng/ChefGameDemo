﻿using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

// move the character left/right/jump
public class MoveCharacter : MonoBehaviour{
    public float moveSpeed = 10f;    // movement speed 
    public bool isGrounded = false;    // whether the character is touching the ground or not 
    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        jump();
        move();
    }

    void move(){
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);    // horizontal 
        transform.position += movement * Time.deltaTime * moveSpeed;    // add movement 
    }

    void jump(){
        if (Input.GetButtonDown("Jump") && isGrounded == true){    // if player press jump and character is touching ground
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 5f), ForceMode2D.Impulse);    // jump up 
        }   
    }
}