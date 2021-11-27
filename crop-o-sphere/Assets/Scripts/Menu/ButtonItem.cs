using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonItem : MonoBehaviour
{
    public GameObject item;
    Transform sphere;
    MenuFarm menuFarm; 

    void Start()
    {
        menuFarm = transform.GetComponentInParent<MenuFarm>();
        sphere = GameObject.FindGameObjectWithTag("sphere").transform;
    }

    public void OnPress()
    {
        menuFarm.PlaceItem(item, sphere);

        // for the moment, just place the item
        // GameObject go = Instantiate(item);
    }

}
