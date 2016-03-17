using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleKitchen.Models
{
    public class ItemInFridge
    {

        public string IngredientName { get; set; }
        public double Quantity { get; set; }
        public string Measure { get; set; }
    }
}