using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class City : MonoBehaviour, Interactable
{
    GameObject tractor;
    Inventory inventory;

    public MenuHandler menuHandler;
    public MenuCity menuCity;
    public float timeUntilCycle = GlobalState.cycleTime;
    public int citizen;
    public int city_score = 0;
    public int[] missions;
    public bool[] validated = new bool[4];

    void Start()
    {
        tractor = GameObject.FindGameObjectWithTag("tractor");
        inventory = tractor.GetComponent<Inventory>();

        citizen = (int)Random.Range(50, 100);
        GenerateMission();
    }

    void Update()
    {
        if (timeUntilCycle > 0) { timeUntilCycle -= Time.deltaTime; }
        else { timeUntilCycle = GlobalState.cycleTime; OnEndOfCycle(); }
    }


    void GenerateMission()
    {
        for (int i = 0; i < 4; i++)
        {
            missions[i] = (int)Random.Range(citizen / 6, citizen / 4);
        }
    }

    public void ValidateMission(int index)
    {
        // first check if the mission can be completed
        int nObj = missions[index];

        if (inventory.GetQuantityByIndex(index) - nObj < 0) { return; }

        int price = inventory.GetPriceByIndex(index);
        int tot_price = price * missions[index];
        inventory.money += tot_price;
        inventory.foods[index].Quantity -= nObj;

        validated[index] = true;
    }

    void ProcessNumberCitizen()
    {

    }

    public void OnEnterCollideWith()
    {
        if (missions == null) { Start(); }

        menuHandler.OnEnterCity();
        menuCity.SetCity(this);
    }
    public void OnExitCollideWith()
    {
        menuHandler.OnLeaveCity();
    }

    void OnEndOfCycle()
    {
        foreach (bool b in validated)
        {
            if (b) { city_score += 1; }
            else { city_score -= 1; }
        }
        GenerateMission();
    }

}
