using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public Food(){}

        public Food(FoodType type, int price, int tilePrice, int quantity, int passiveIncome, int passiveConsumption)
        {
            FoodType = type;
            Price = price;
            TilePrice = tilePrice;
            Quantity = quantity;
            PassiveIncome = passiveIncome;
            PassiveConsumption = passiveConsumption;
        }

        public FoodType FoodType { get; set; }
        public int Price { get; set; }
        public int TilePrice { get; set; }
        public int Quantity { get; set; }
        public int PassiveIncome { get; set; }
        public int PassiveConsumption { get; set; }
}
