using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{

    public void RotateSphere(Transform t, float rot, float dist)
    {
        transform.RotateAround(transform.position, t.up, rot);
        transform.RotateAround(transform.position, t.right, dist);
        transform.position = Vector3.zero;
        // if (rot != 0)
        // {
        //     transform.RotateAround(transform.position, t.up, rot);
        // }
        // else
        // {
        //     transform.RotateAround(transform.position, t.right, dist);
        // }
        // if (basePoint.x > 0)
        // {
        //     transform.RotateAround(transform.position, t.position + basePoint, dist);
        // }
        // else
        // {
        //     transform.RotateAround(transform.position, t.position + basePoint, -dist);
        // }
    }
}
