using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightRevolution : MonoBehaviour
{
    public float speed = 360f / GlobalState.dayTime;
    public float angle = 0.0f;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.RotateAround(transform.position, transform.up, speed * Time.fixedDeltaTime);
    }
}
