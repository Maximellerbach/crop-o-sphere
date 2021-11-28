using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class City : MonoBehaviour, Interactable
{
    GameObject tractor;
    Inventory inventory;

    public MenuHandler menuHandler;
    public MenuCity menuCity;
    public float timeUntilRes = GlobalState.dayTime * GlobalState.nbDays;
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
        if (timeUntilRes > 0) { timeUntilRes -= Time.deltaTime; }
        else { timeUntilRes = GlobalState.dayTime; OnEndOfCycle(); }
    }


    void GenerateMission()
    {
        for (int i = 0; i < 4; i++)
        {
            missions[i] = (int)Random.Range(citizen / 6, citizen / 4);
            validated[i] = false;
        }
    }

    public void ValidateMission(int index)
    {

        // then check if the mission was completed
        if (validated[index] == true) {return; }

        // then check if the mission can be completed
        int nObj = missions[index];

        if (inventory.GetQuantityByIndex(index) - nObj < 0) { return; }

        int price = inventory.GetPriceByIndex(index);
        int tot_price = price * missions[index];
        inventory.money += tot_price;
        inventory.foods[index].Quantity -= nObj;

        validated[index] = true;
    }

    void ProcessNumberCitizen(int city_score)
    {
        citizen = citizen + (int)((1.0f/10.0f) * city_score * citizen);
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
            city_score = 0;
            if (b) { city_score += 1; }
            else { city_score -= 1; }
        }
        GenerateMission();
        ProcessNumberCitizen(city_score);
    }

}
