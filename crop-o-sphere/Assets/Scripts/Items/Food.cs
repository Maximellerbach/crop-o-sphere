using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public Food(){}

        public Food(FoodType type, int price, int quantity, string description)
        {
            FoodType = type;
            Price = price;
            Quantity = quantity;
            Description = description;
        }

        public FoodType FoodType { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
}
