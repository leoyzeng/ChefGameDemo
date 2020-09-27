using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Drawing;

public class RocketJumpCollisionCheck : MonoBehaviour
{

    public bool collision;
    public static float slope;
    public static PointF intersection1;
    public static PointF intersection2;
    private float b;
    private float radius; 
    private float intersectionX, intersectionY;
    private Vector2 mousePos;
    private Vector2 startPos;
    public static float rise;
    public static float run;

    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        startPos = GameObject.Find("Character ChefBoy Default GameSize").transform.position;
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        rise = mousePos.y - startPos.y;
        run = mousePos.x - startPos.x;
        slope = (mousePos.y - startPos.y) / (mousePos.x - startPos.x);
        
        b = (mousePos.y) / (slope * mousePos.x);
        PointF point1 = new PointF(startPos.x, startPos.y);
        PointF point2 = new PointF(mousePos.x, mousePos.y);

        FindLineCircleIntersections(startPos.x, startPos.y, 1.0f, point1, point2, out intersection1, out intersection2);



    }

    private int FindLineCircleIntersections(
    float cx, float cy, float radius,
    PointF point1, PointF point2,
    out PointF intersection1, out PointF intersection2)
{
    float dx, dy, A, B, C, det, t;

    dx = point2.X - point1.X;
    dy = point2.Y - point1.Y;

    A = dx * dx + dy * dy;
    B = 2 * (dx * (point1.X - cx) + dy * (point1.Y - cy));
    C = (point1.X - cx) * (point1.X - cx) +
        (point1.Y - cy) * (point1.Y - cy) -
        radius * radius;

    det = B * B - 4 * A * C;
    if ((A <= 0.0000001) || (det < 0))
    {
        // No real solutions.
        intersection1 = new PointF(float.NaN, float.NaN);
        intersection2 = new PointF(float.NaN, float.NaN);
        return 0;
    }
    else if (det == 0)
    {
        // One solution.
        t = -B / (2 * A);
        intersection1 =
            new PointF(point1.X + t * dx, point1.Y + t * dy);
        intersection2 = new PointF(float.NaN, float.NaN);
        return 1;
    }
    else
    {
        // Two solutions.
        t = (float)((-B + Math.Sqrt(det)) / (2 * A));
        intersection1 =
            new PointF(point1.X + t * dx, point1.Y + t * dy);
        t = (float)((-B - Math.Sqrt(det)) / (2 * A));
        intersection2 =
            new PointF(point1.X + t * dx, point1.Y + t * dy);
        return 2;
    }
}
}
