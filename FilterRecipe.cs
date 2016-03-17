using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleKitchen.Models
{
    public class FilterRecipe
    {

        public int Id { get; set; }
        public string  Name { get; set; } 

        public FilterRecipe()
        {
            Id = 0;
            Name = "";

        } 
    }
}