using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotatoFood : MonoBehaviour
{
    public PotatoFood()
    {
        food = new Food(FoodType.Potato, GlobalState.potatoPrice, GlobalState.tilePotatoPrice, GlobalState.potato, 0, 0);
    }

    public Food food { get; set; }
}
