using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpSound : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        jumpSound();
        rocketJumpSound();
    }
    void jumpSound()
    {
        if (Input.GetButtonDown("Jump") && MoveCharacter.grounded)
        {
            randomPitch();
            gameObject.GetComponent<AudioSource>().Play();
        }
    }

    void rocketJumpSound()
    {
        if (Input.GetMouseButtonDown(0) && Collision.inCollider == true)
        {
            randomPitch();
            gameObject.GetComponent<AudioSource>().Play();
        }
    }
    void randomPitch()
    {
        System.Random rand = new System.Random();
        float pitch = (float) rand.NextDouble() * 0.4f + 0.8f;
        gameObject.GetComponent<AudioSource>().pitch = pitch;
    }

}
