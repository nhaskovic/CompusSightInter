using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleKitchen.Models
{
    public class Friend 
    {
        [Key]
        public int Id { set; get; }
        public bool Accept { get; set; }
        public virtual User UserFriend { get; set;  }
        public virtual User  User { get; set; }
    }
    }
