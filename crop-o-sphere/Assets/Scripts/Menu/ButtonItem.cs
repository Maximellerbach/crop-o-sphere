using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonItem : MonoBehaviour
{
    public GameObject item;
    public Transform sphere; // where to put the item (parent)
    MenuCity menuCity; 

    void Start()
    {
        menuCity = transform.GetComponentInParent<MenuCity>();
    }

    public void OnPress()
    {
        menuCity.PlaceItem(item, sphere);

        // for the moment, just place the item
        // GameObject go = Instantiate(item);
    }

}
