using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleFood : MonoBehaviour
{
    public AppleFood()
    {
        food = new Food(FoodType.Apple, GlobalState.applePrice, GlobalState.tileApplePrice, GlobalState.apple, 0, 0);
    }

    public Food food { get; set; }
}
