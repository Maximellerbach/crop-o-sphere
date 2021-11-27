using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Food[] foods = new Food[4];
    void Start()
    {
        FoodType[] values = (FoodType[]) Enum.GetValues(typeof(FoodType));
        for (int i = 0; i < foods.Length; i++)
        {
            FoodType f = values[i];
            foods[i] = new Food (f, 5, 0);
        }
    }

    public int GetValue(string foodType)
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

    public void AddValue(string foodType, int number)
    {
        
        foreach (Food f in foods)
        {
            if (f.FoodType.ToString() == foodType)
            {
                f.Quantity += number;
            }
        }
        Debug.LogError("Could not find " + foodType);
    }
}
