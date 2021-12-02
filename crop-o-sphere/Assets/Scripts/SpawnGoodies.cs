using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGoodies : MonoBehaviour
{
    public GameObject go;
    public int number = 100;
    public int radius = 50;

    void Start()
    {
        for (int i = 0; i< number; i++)
        {
            Vector3 pos = Random.onUnitSphere * radius;
            Vector3 normal = pos.normalized;
            Quaternion rot = Quaternion.LookRotation(transform.up, normal);
            GameObject spawned = Instantiate(go, pos, rot);
            // spawned.transform.SetParent(transform);
        }
    }

}
