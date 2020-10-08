using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Drawing;

// check whether a rock jump should happen 
public class RocketJumpCollisionCheck : MonoBehaviour
{

    // public static bool collision;    // whether the intersection point is inside a collider 
    public float slope;    // slope of the line from center of character to mouse 
    public PointF intersection1;    // point of intersection of radius circle and line 
    public PointF intersection2;
    private float b;    // b value of y = m * x + b of line
    private float radius;    // rocket jump dection radius 
    private Vector2 mousePos;    // current mouse position 
    private Vector2 startPos;    // current character position 
    public float rise;    // y difference of 2 points 
    public float run;    // x difference of 2 points 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 screenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);    // find mouse position 
        mousePos = GetWorldPositionOnPlane(screenPosition, 20);    // update mouse position 
        startPos = GameObject.Find("Character ChefBoy Default GameSize").transform.position;    // update character position
        // mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);    // update mouse position 
        rise = mousePos.y - startPos.y;    // calculate rise 
        run = mousePos.x - startPos.x;    // calculate run 
        slope = (mousePos.y - startPos.y) / (mousePos.x - startPos.x);    // calculate slope 
        b = (mousePos.y) / (slope * mousePos.x);    // calculate b
        PointF point1 = new PointF(startPos.x, startPos.y);    // convert character's position to point
        PointF point2 = new PointF(mousePos.x, mousePos.y);    // convert mouse's position to point

        FindLineCircleIntersections(startPos.x, startPos.y, 1.0f, point1, point2, out intersection1, out intersection2);
        // only intersection1 is needed for program (actual intersection between circle and line, not opposite side)
        
    }

    // convert perspective camera mouse position to orthrographic, calculate for mouse.z = plane of characters 
    public Vector3 GetWorldPositionOnPlane(Vector3 screenPosition, float z) 
    {
        Ray ray = Camera.main.ScreenPointToRay(screenPosition);
        Plane xy = new Plane(Vector3.forward, new Vector3(0, 0, z));
        float distance;
        xy.Raycast(ray, out distance);
        return ray.GetPoint(distance);
    }

    // method that takes circle center x, y, radius, point1 of line, point2 of line
    // returns 2 intections of the line and circle 
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
