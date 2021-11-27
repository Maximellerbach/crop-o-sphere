using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateMission : MonoBehaviour
{

    GameObject tractor;
    Inventory inventory;

    public MenuCity menuCity;
    Text text;
    City city;
    public string foodType = "";
    public int index = 0;
    public int amount = 0;
    public int tot_price = 0;

    void Start()
    {
        tractor = GameObject.FindGameObjectWithTag("tractor");
        inventory = tractor.GetComponent<Inventory>();
        text = gameObject.GetComponentInChildren<Text>();
        UpdateText();
    }

    public void SetCity(City _city)
    {
        city = _city;
        GetMission();
        UpdateText();
    }

    public void GetMission()
    {
        amount = city.missions[index];
        tot_price = inventory.GetPriceByIndex(index) * amount;
    }

    void UpdateText()
    {
        string txt = $"Sell {amount} {foodType} \n for {tot_price} coins";
        text.text = txt;
        Debug.Log("Updating text ! ");
    }

    public void ValidateMission(int index)
    {
        city.ValidateMission(index);
    }
}
