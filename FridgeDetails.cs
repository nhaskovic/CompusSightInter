using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleKitchen.Models
{
    public class FridgeDetails
    {

        [Key]
        public int Id { set; get; }
        public double Quantity { get; set; }
       public virtual Ingredient Ingredient { get; set; }

    }
}