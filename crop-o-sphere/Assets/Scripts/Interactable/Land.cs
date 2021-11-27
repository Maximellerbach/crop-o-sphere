using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Land : MonoBehaviour, Interactable
{
    private int counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCollideWith()
    {
        counter = 0;
    }
}
