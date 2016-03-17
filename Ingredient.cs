using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SimpleKitchen.Models
{
    public class Ingredient
    {

        [Key]
        public int Id { set; get; }
        public string Name { get; set; }       
          
        public virtual List<FridgeDetails> Ingredients { get; set; }
      

    }
}