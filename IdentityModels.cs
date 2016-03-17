using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace SimpleKitchen.Models
{
    // You can add profile data for the user by adding more properties to your User class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.


    public class RoleStoreIntPk : RoleStore<Role, int, UserRole>
    {
        public RoleStoreIntPk(ApplicationDbContext context)
            : base(context)
        {
        }
    }
    public class Role: IdentityRole<int, UserRole>
    {
        public Role() { }
        public Role(string name) { Name = name; }
    }
    public class UserLogin: IdentityUserLogin<int> { }
    public class UserRole : IdentityUserRole<int> { }
    public class UserClaim : IdentityUserClaim<int> { }

    public class UserStore : UserStore<User, Role, int, UserLogin, UserRole, UserClaim>
    {
        public UserStore(ApplicationDbContext context)
            : base(context)
        {
        }
    }
    public partial class User : IdentityUser<int, UserLogin, UserRole, UserClaim>
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(ApplicationUserManager manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this,DefaultAuthenticationTypes.ApplicationCookie);

            // Add custom user claims here
            return userIdentity;
        }

    }

    public class ApplicationDbContext : IdentityDbContext<User, Role, int,   UserLogin, UserRole, UserClaim>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public virtual System.Data.Entity.DbSet<SimpleKitchen.Models.Recipe> Recipes { get; set; }

        public virtual System.Data.Entity.DbSet<SimpleKitchen.Models.Friend> Friends { get; set; }
        public virtual System.Data.Entity.DbSet<SimpleKitchen.Models.FridgeDetails> FridgeDetail { get; set; }
        public virtual System.Data.Entity.DbSet<SimpleKitchen.Models.RecipeDetail> RecipeDetails { get; set; }
        public virtual System.Data.Entity.DbSet<SimpleKitchen.Models.Ingredient> Ingredients { get; set; }
    }
}





