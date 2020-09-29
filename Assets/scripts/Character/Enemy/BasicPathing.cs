using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// move a enemy side to side 
public class BasicPathing : MonoBehaviour
{

    public float moveSpeed = 1;
    public float startX;
    public float endX;
    public string direction;
    

    // Start is called before the first frame update
    void Start()
    {
        direction = "right";
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    public void moveSideToSide(){

        var position = transform.position;

        if(direction == "right"){
            position.x += Time.deltaTime * moveSpeed;
            transform.position = position;
        }
        else if(direction == "left"){
            position.x -= Time.deltaTime * moveSpeed;
            transform.position = position;
        }
        if(position.x > endX){
            direction = "left";
        }
        if(position.x < startX){
            direction = "right";
        }
    }
}
