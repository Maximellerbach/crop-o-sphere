using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheatFood : MonoBehaviour
{
    public WheatFood()
    {
        food = new Food(FoodType.Wheat, GlobalState.wheatPrice, GlobalState.tileWheatPrice, GlobalState.wheat, 0, 0);
    }

    public Food food { get; set; }
}
