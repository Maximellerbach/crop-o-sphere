using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonItem : MonoBehaviour
{
    public GameObject item;
    public Transform sphere; // where to put the item (parent)
    MenuFarm menuFarm; 

    void Start()
    {
        menuFarm = transform.GetComponentInParent<MenuFarm>();
    }

    public void OnPress()
    {
        menuFarm.PlaceItem(item, sphere);

        // for the moment, just place the item
        // GameObject go = Instantiate(item);
    }

}
