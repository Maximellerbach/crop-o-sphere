using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TractorBehavior : MonoBehaviour
{
    Sphere sphere;
    Rigidbody rb;
    public GameObject sphereObject;
    public GameObject[] frontWheels;
    public GameObject[] backWheels;

    // Collider stuff
    private bool isColliding = false;
    private float xSpeedWhenCollided = 0.0f;
    private float ySpeedWhenCollided = 0.0f;


    private Vector3 lastPos;
    private float currentYSpeed = 0.0f;

    private static float distFrontWheel = 1f;
    private static float wheelLength = 3.14f;
    private static float maxAngle = 60f;
    private static float maxSpeed = 10f;

    void Start()
    {
        // init variables
        rb = gameObject.GetComponent<Rigidbody>();
        sphere = sphereObject.GetComponent<Sphere>();
        lastPos = transform.position;
    }

    void FixedUpdate()
    {
        // get user input
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");

        (xAxis, yAxis) = CollisionLogic(xAxis, yAxis);
        float dist = yAxis * maxSpeed * Time.fixedDeltaTime;

        sphere.RotateSphere(transform, - xAxis * maxAngle * Time.fixedDeltaTime, dist);
        RotateWheels(xAxis * maxAngle, dist);

        currentYSpeed = dist;
    }

    void RotateWheels(float turnAngle, float dist)
    {
        foreach (GameObject wheel in frontWheels)
        {
            // wheel.transform.RotateAround(wheel.transform.position, wheel.transform.up, turnAngle);
            // wheel.transform.rotation.SetAxisAngle(wheel.transform.up, turnAngle);
            wheel.transform.RotateAround(wheel.transform.position, wheel.transform.up, -(dist / wheelLength) * 180);
        }
        foreach (GameObject wheel in backWheels)
        {
            wheel.transform.RotateAround(wheel.transform.position, wheel.transform.up, -(dist / wheelLength) * 180);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Debug.Log(other.gameObject.name);
        if (other.gameObject != sphere.gameObject)
        {
            isColliding = true;
            ySpeedWhenCollided = currentYSpeed;
        }

        if (other.gameObject.tag == "building")
        {
            // do something like open menu
        }
    }

    private void OnTriggerStay(Collider other)
    {
        // Debug.Log(other.gameObject.name);
        if (other.gameObject != sphere.gameObject)
        {
            isColliding = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Debug.Log(other.gameObject.name);
        if (other.gameObject != sphere.gameObject)
        {
            isColliding = false;
        }
    }

    (float, float) CollisionLogic(float xAxis, float yAxis)
    {
        if (isColliding)
        {
            if (ySpeedWhenCollided < 0)
            {
                if (yAxis < 0) { yAxis = 0; }
            }
            else
            {
                if (yAxis >= 0) { yAxis = 0; }
            }
        }
        return (xAxis, yAxis);
    }
}
