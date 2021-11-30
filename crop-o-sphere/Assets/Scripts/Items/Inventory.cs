using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int money;
    private float timeUntilCycle;
    public Food[] foods = new Food[4];
    void Start()
    {
        money =  GlobalState.baseMoney;
        timeUntilCycle = GlobalState.cycleTime;

        foods[0] = new WheatFood().food;
        foods[1] = new PotatoFood().food;
        foods[2] = new AppleFood().food;
        foods[3] = new MeatFood().food;
    }

    void Update()
    {
        if (timeUntilCycle > 0) { timeUntilCycle -= Time.deltaTime; }
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
                f.PassiveIncome += GlobalState.passiveIncome;
                money -= f.TilePrice;
                // Debug.Log(money);
                return;
            }
        }
        Debug.Log("Could not find " + foodType);
    }

    public int GetQuantityByIndex(int index)
    {
        return foods[index].Quantity;
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

    public int GetPriceByIndex(int index)
    {
        if (foods.Length > index) { return foods[index].Price; }
        Debug.LogError("Could not find " + index.ToString());
        return -1;
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
            f.Quantity += f.PassiveIncome;
        }

        // Debug.Log(money);

    }
}
