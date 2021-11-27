using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class City : MonoBehaviour, Interactable
{
    public MenuHandler menuHandler;
    public MenuCity menuCity;
    // public float 
    public int citizen;
    public int city_score = 0;
    public int[] missions = new int[4];

    void Start()
    {
        // tractor = GameObject.FindGameObjectWithTag("tractor");
        // inventory = tractor.GetComponent<Inventory>();

        citizen = (int)Random.Range(50, 100);
        GenerateMission();
    }

    void Update()
    {
        
    }


    void GenerateMission()
    {
        for (int i = 0; i < 4; i++)
        {
            missions[i] = (int)Random.Range(citizen / 6, citizen / 4);
        }
    }

    public void OnEnterCollideWith()
    {
        menuHandler.OnEnterCity();
        menuCity.SetCity(this);
    }
    public void OnExitCollideWith()
    {
        menuHandler.OnLeaveCity();
    }

    void OnEndOfCycle()
    {
        GenerateMission();
    }

}
