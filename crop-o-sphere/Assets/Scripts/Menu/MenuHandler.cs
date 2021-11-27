using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuHandler : MonoBehaviour
{

    public GameObject goMenuFarm;
    public GameObject goMenuCity;
    public GameObject goButMenuCity;

    private bool menuFarm = false;
    private bool butMenuCity = false;
    private bool menuCity = false;

    void Start()
    {
        goMenuCity.SetActive(false);
        goButMenuCity.SetActive(false);
        goMenuFarm.SetActive(false);
    }


    // MENU FARM
    public void OnEnterFarm()
    {
        if (menuFarm) { menuFarm = false; }
        else { menuFarm = true; }
        goMenuFarm.SetActive(menuFarm);
    }


    // MENU CITY
    public void OnEnterCity() // collide obj
    {
        butMenuCity = true;
        goButMenuCity.SetActive(butMenuCity);
    }
    public void OnLeaveCity() // exit collide
    {
        butMenuCity = false;
        menuCity = false;
        goButMenuCity.SetActive(butMenuCity);
        goMenuCity.SetActive(menuCity);
    }

    public void VisitCity() // click on visit button
    {
        if (butMenuCity)
        {
            menuCity = true;
            goMenuCity.SetActive(true);
            goButMenuCity.SetActive(false);
        }
    }

    public void ExitCity() // click on exit button
    {
        if (menuCity)
        {
            menuCity = false;
            goMenuCity.SetActive(false);
            goButMenuCity.SetActive(butMenuCity);
        }

    }

}
