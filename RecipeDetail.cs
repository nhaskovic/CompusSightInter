using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleKitchen.Models
{
    public class RecipeDetail
    {
          
        [Key]
        public int Id { set; get; }
        public virtual Ingredient Ingredient{ get; set; }
        public virtual Recipe RecipeID { get; set; }     
        public double Quantity { get; set; }
        public virtual Measure Measure { get; set; }




    }
}