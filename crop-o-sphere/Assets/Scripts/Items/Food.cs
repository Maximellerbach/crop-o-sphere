using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public Food(){}

        public Food(FoodType type, int price, int quantity)
        {
            FoodType = type;
            Price = price;
            Quantity = quantity;
        }

        public FoodType FoodType { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
}
