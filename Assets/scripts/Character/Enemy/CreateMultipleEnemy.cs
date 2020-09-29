using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// spawns a bunch of objects 
// spawns breadBoy 
public class CreateMultipleEnemy : BreadBoy1
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject prefab = Resources.Load("Character BreadBoy Default GameSize") as GameObject;
        
        for(int i = 0 ; i < 100 ; i ++){
            GameObject go = Instantiate(prefab) as GameObject;

            go.transform.position = new Vector3(-5, 20+i, 20);



        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
