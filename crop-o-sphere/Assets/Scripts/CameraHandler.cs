using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{

    public AnimationCurve xPosCurve;
    public AnimationCurve yPosCurve;
    public AnimationCurve rCurve;

    Vector3 basePos;
    Quaternion baseRot;

    public float offx = 10f;
    public float offy = 35f;
    public float offr = 40f;
    public float scale = 0.1f;
    private float counter = 1.0f;

    void Start()
    {
        basePos = transform.position;
        baseRot = transform.rotation;
    }

    void Update()
    {
        float scroll = Input.mouseScrollDelta.y;
        if (scroll != 0)
        {
            if (counter < 1 && scroll > 0) { counter += scroll * scale; }
            else if (counter > 0 && scroll < 0) { counter += scroll * scale; }
            if (counter > 1) { counter = 1; }
            else if (counter < 0) { counter = 0; }

            float xp = xPosCurve.Evaluate(counter) * offx;
            float yp = xPosCurve.Evaluate(counter) * offy;
            Vector3 new_pos = basePos - new Vector3(0, xp, yp);
            transform.position = new_pos;
            transform.rotation = baseRot * Quaternion.AngleAxis(rCurve.Evaluate(counter) * - offr, Vector3.right);
        }
        // Debug.Log(scroll);
    }
}
