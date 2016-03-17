using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Web.Security;

namespace SimpleKitchen.Models
{

    public partial class User 

    {     
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual List<Recipe> Recipes { get; set; }
        public virtual List<Friend> FriendsID { get; set; }

    }
}