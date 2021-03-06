using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheat : MonoBehaviour, Interactable
{

    GameObject tractor;
    Inventory inventory;
    private float timeUntilHarvest = GlobalState.timeGrowWheat;
    private bool isGrown = false;

    void Start()
    {
        tractor = GameObject.FindGameObjectWithTag("tractor");
        inventory = tractor.GetComponent<Inventory>();
    }

    void Update()
    {
        if (timeUntilHarvest > 0)
        {
            timeUntilHarvest -= Time.deltaTime;
        }
        else if (isGrown == false)
        {
            isGrown = true;
            timeUntilHarvest = GlobalState.timeGrowWheat;
        }
    }

    public void OnEnterCollideWith()
    {
        if (isGrown)
        {
            isGrown = false;
            inventory.AddQuantity("Wheat", 1);
            Debug.Log(inventory.GetQuantity("Wheat"));
        }

    }
    public void OnExitCollideWith() { return; }
}
