using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potato : MonoBehaviour
{
    GameObject tractor;
    Inventory inventory;
    private float timeUntilHarvest = GlobalState.timeGrowPotato;
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
            timeUntilHarvest = GlobalState.timeGrowPotato;
        }
    }

    public void OnEnterCollideWith()
    {
        if (isGrown)
        {
            isGrown = false;
            inventory.AddQuantity("Potato", 1);
            Debug.Log(inventory.GetQuantity("Potato"));
        }

    }
    public void onExitCollideWith() { return; }
}
