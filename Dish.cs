using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace SimpleKitchen.Models
{
    public class Dish
    {
        [Key]
        public int Id { set; get; }
        public virtual List<Recipe> SameNameDifferentRecipes { get; set; }
       
        

        

    }
}