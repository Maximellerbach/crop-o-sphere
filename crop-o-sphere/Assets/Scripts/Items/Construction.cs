using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Construction : MonoBehaviour
{
    public Construction(){}

        public Construction(ConstructionType type, int price, int quantity, string description)
        {
            ConstructionType = type;
            Price = price;
            Quantity = quantity;
            Description = description;
        }

        public ConstructionType ConstructionType { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
}
