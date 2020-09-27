using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawLine : MonoBehaviour
{
    private LineRenderer lineRend;
    private Vector2 mousePos;
    private Vector2 startPos;
    private float slope;
    private float rise;
    private float run;


    [SerializeField]
    private Text mouseInfo;
    private float distance; 
    // Start is called before the first frame update
    void Start()
    {
        lineRend = GetComponent<LineRenderer>();
        lineRend.positionCount = 2;
    }

    // Update is called once per frame
    void Update()
    {
        startPos = GameObject.Find("Character ChefBoy Default GameSize").transform.position;
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        lineRend.SetPosition(0, new Vector3(startPos.x, startPos.y, 0f));
        lineRend.SetPosition(1, new Vector3(mousePos.x, mousePos.y, 0f));
        distance = (mousePos - startPos).magnitude;
        rise = mousePos.y - startPos.y;
        run = mousePos.x - startPos.x;
        slope = (mousePos.y - startPos.y) / (mousePos.x - startPos.x);
        mouseInfo.text = startPos.ToString("F2") + "\n" + mousePos.ToString("F2") + "\n" + distance + "\n" + rise + "\n" + run + "\n" + slope;

    }
}
