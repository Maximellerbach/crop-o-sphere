using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightRevolution : MonoBehaviour
{
    private float speed;

    void Start()
    {
        speed = 360f / GlobalState.dayTime;
    }
    void FixedUpdate()
    {
        transform.RotateAround(transform.position, transform.up, speed * Time.fixedDeltaTime);
    }
}
