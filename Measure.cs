using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;



namespace SimpleKitchen.Models
{
    public class Measure
    {
        [Key]
        public int Id { set; get; }
        public string Name { get; set; }
        public virtual List<RecipeDetail> MeasureForIngredient { get; set; }


    }
}

