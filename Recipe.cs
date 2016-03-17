using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SimpleKitchen.Models
{
    public class Recipe
    {
        [Key]
        public int Id { set; get; }
        public string Name { get; set; }
        public string Text { get; set; }
        public DateTime Published { get; set; }
        public virtual User Owner { get; set; }
        public virtual List<RecipeDetail> RecipeDetails { get; set; }
        public virtual List<Dish> SameNameDifferentRecipes { get; set; }
     
    }
}