using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeatFood : MonoBehaviour
{
    public MeatFood()
    {
        food = new Food(FoodType.Meat, GlobalState.meatPrice, GlobalState.tileMeatPrice, GlobalState.meat, 0, 1);
    }

    public Food food { get; set; }
}
