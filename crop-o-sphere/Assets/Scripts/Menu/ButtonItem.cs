using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonItem : MonoBehaviour
{
    public GameObject item;
    public string name = "";
    Transform sphere;
    MenuFarm menuFarm; 

    void Start()
    {
        menuFarm = transform.GetComponentInParent<MenuFarm>();
        sphere = GameObject.FindGameObjectWithTag("sphere").transform;
    }

    public void OnPress()
    {
        menuFarm.PlaceItem(name, item, sphere);
    }

}
