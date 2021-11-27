using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TractorBehavior : MonoBehaviour
{
    public Sphere sphere;
    public GameObject[] frontWheels;
    public GameObject[] backWheels;

    // Collider stuff
    private bool isColliding = false;
    private float xSpeedWhenCollided = 0.0f;
    private float ySpeedWhenCollided = 0.0f;


    private Vector3 lastPos;
    private float currentXSpeed = 0.0f;
    private float currentYSpeed = 0.0f;

    private float wheelLength = 3.14f;
    private float maxAngle = 30f;

    void Start()
    {
        // init variables
        lastPos = transform.position;
    }

    void FixedUpdate()
    {
        // get user input
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");

        (xAxis, yAxis) = CollisionLogic(xAxis, yAxis);


    }

    Vector3 GetRotatePoint(float xAxis)
    {
        float turnAngle = xAxis * maxAngle;
        Vector3 basePoint = Vector3.zero;

        if (xAxis < 0.1)
        {
            
        }
        else if (xAxis > 0.1)
        {

        }
        else
        {

        }


        return basePoint;

    }

    void RotateWheels(float turnAngle, float dist)
    {
        foreach (GameObject wheel in frontWheels)
        {
            wheel.transform.RotateAround(wheel.transform.position, wheel.transform.up, turnAngle);
            wheel.transform.RotateAround(wheel.transform.position, wheel.transform.right, dist / wheelLength);
        }
        foreach (GameObject wheel in backWheels)
        {
            wheel.transform.RotateAround(wheel.transform.position, wheel.transform.right, dist / wheelLength);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject != sphere.gameObject)
        {
            isColliding = true;
            xSpeedWhenCollided = currentXSpeed;
            ySpeedWhenCollided = currentYSpeed;
        }
    }

    private void OnCollisionLeave(Collision other)
    {
        if (other.gameObject != sphere.gameObject)
        {
            isColliding = false;
        }
    }

    (float, float) CollisionLogic(float xAxis, float yAxis)
    {
        if (isColliding)
        {
            if (ySpeedWhenCollided <= 0)
            {
                if (yAxis < 0) { yAxis = 0; }
            }
            else
            {
                if (yAxis > 0) { yAxis = 0; }
            }
        }
        return (xAxis, yAxis);
    }

}
