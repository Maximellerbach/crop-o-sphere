using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int money = GlobalState.baseMoney;
    private float timeUntilCycle = GlobalState.cycleTime;
    public Food[] foods = new Food[4];
    void Start()
    {
        foods[0] = new Food(FoodType.Wheat, GlobalState.wheatPrice, GlobalState.tileWheatPrice, 0, 0, 0);
        foods[1] = new Food(FoodType.Potato, GlobalState.potatoPrice, GlobalState.tilePotatoPrice, 0, 0, 0);
        foods[2] = new Food(FoodType.Apple, GlobalState.applePrice, GlobalState.tileApplePrice, 0, 0, 0);
        foods[3] = new Food(FoodType.Meat, GlobalState.meatPrice, GlobalState.tileMeatPrice, 0, 0, 1);

    }

    void Update()
    {
        if (timeUntilCycle > 0) {timeUntilCycle -= Time.deltaTime; }
        else { timeUntilCycle = GlobalState.cycleTime; OnEndOfCycle(); }
    }

    public bool HasEnoughRessources(string foodType)
    {
        foreach (Food f in foods)
        {
            if (f.FoodType.ToString() == foodType)
            {
                if ((money - f.TilePrice) >= 0 && (foods[0].PassiveIncome - f.PassiveConsumption) >= 0)
                { return true; }
                else { return false; }
            }
        }
        return false;
    }

    public void ApplyTile(string foodType)
    {
        foreach (Food f in foods)
        {
            if (f.FoodType.ToString() == foodType)
            {
                foods[0].PassiveIncome -= f.PassiveConsumption;
                f.PassiveIncome += 1;
                money -= f.TilePrice;
                // Debug.Log(money);
                return;
            }
        }
        Debug.Log("Could not find " + foodType);
    }

    public int GetQuantity(string foodType)
    {
        foreach (Food f in foods)
        {
            if (f.FoodType.ToString() == foodType)
            {
                return f.Quantity;
            }
        }
        Debug.LogError("Could not find " + foodType);
        return 0;
    }

    public int GetPrice(string foodType)
    {
        foreach (Food f in foods)
        {
            if (f.FoodType.ToString() == foodType)
            {
                return f.Price;
            }
        }
        Debug.LogError("Could not find " + foodType);
        return 0;
    }

    public void AddQuantity(string foodType, int number)
    {

        foreach (Food f in foods)
        {
            if (f.FoodType.ToString() == foodType)
            {
                f.Quantity += number;
                return;
            }
        }
        Debug.LogError("Could not find " + foodType);
    }

    public void OnEndOfCycle()
    {
        foreach (Food f in foods)
        {
            money += f.PassiveIncome;
        }

        // Debug.Log(money);

    }
}
