using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextUpdater : MonoBehaviour
{
    public int index = 0;
    GameObject tractor;
    Inventory inventory;

    Text text;

    void Start()
    {
        tractor = GameObject.FindGameObjectWithTag("tractor");
        inventory = tractor.GetComponent<Inventory>();
        text = gameObject.GetComponent<Text>();
    }

    void Update()
    {
        int q = inventory.GetQuantityByIndex(index);
        text.text = q.ToString();
    }

}
