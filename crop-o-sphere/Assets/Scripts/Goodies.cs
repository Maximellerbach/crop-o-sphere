using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goodies : MonoBehaviour
{

    public int number = 100;
    public GameObject goodie;
    public float radius = 50;

    void Start()
    {
        if (goodie == null) { return; }
        for (int i = 0; i < number; i++)
        {
            Vector3 pos = new Vector3(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f)).normalized * radius;
            GameObject go = Instantiate(gameObject, pos, Quaternion.identity);
            go.transform.parent = transform;
        }
    }

}
