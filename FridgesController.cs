using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Routing;
using System.Data.SqlClient;
using System.Net.Http.Headers;
using SimpleKitchen.Repository;
using SimpleKitchen.Models;

namespace SimpleKitchen.Controllers
{
    public class FridgesController : ApiController
    {


        private IRecipeRepository recipeRepository;
        private IRecipeDetailsRepository recipedetailsRepository;
        public FridgesController(IRecipeRepository recipeRepository, IRecipeDetailsRepository recipedetailsRepository)
        {

            this.recipeRepository = recipeRepository;
            this.recipedetailsRepository = recipedetailsRepository;
        }
        public FridgesController()
        {
            this.recipeRepository = new RecipeRepository(new ApplicationDbContext());
            this.recipedetailsRepository = new RecipeDetailsRepository(new ApplicationDbContext());

        }

        [HttpPost]
        [Route("api/fridges/PostIngredient")]
        public IHttpActionResult PostIngredient([FromBody] List<ItemInFridge> ingredientInFridge)
        {
            var recipedet = recipedetailsRepository.GetRecipeDetails();
            if (ingredientInFridge.Count == 0)
                return StatusCode(HttpStatusCode.NoContent);
            {
              
                
                var recipe = from r in recipedet
                             where ingredientInFridge.Any(u => u.IngredientName.Contains(r.Ingredient.Name))
                             group r by r.RecipeID into g
                             select new { RecipeIDTa = g.Key, Value = g.ToList() };

                var ret = (from allreci in recipeRepository.GetRecipes()
                           where recipe.Any(newrecipe => allreci.RecipeDetails.Count == newrecipe.Value.Count)
                           select allreci.Name).ToList();

                if (ret.Count == 0)
                    return StatusCode(HttpStatusCode.NoContent);

                return Ok(ret);


            }
        }
    }
}