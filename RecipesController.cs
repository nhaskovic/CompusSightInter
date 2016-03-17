using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using SimpleKitchen.Repository;
using SimpleKitchen.Models;
using Microsoft.AspNet.Identity;
using System.Text.RegularExpressions;

namespace SimpleKitchen.Controllers
{
    public class RecipesController : ApiController
    {


        private IUserRepository userRepository;
        private IRecipeRepository recipeRepository;

        public RecipesController()
        {
            this.recipeRepository = new RecipeRepository(new ApplicationDbContext());
            this.userRepository = new UserRepository(new ApplicationDbContext());
        }


        public RecipesController(IRecipeRepository recipeRepository)
        {
            this.recipeRepository = recipeRepository;
        }
        [Authorize(Roles ="Admin")]
        [HttpGet]     
        public List<Recipe> Get()
        {

            return recipeRepository.GetRecipes();
        }

        // PUT: api/Recipes/5
        [ResponseType(typeof(void))]

        public IHttpActionResult PutRecipe(int id, Recipe recipe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != recipe.Id)
            {
                return BadRequest();
            }

            recipeRepository.UpdateRecipe(recipe);

            try
            {
                recipeRepository.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecipeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Recipes
        [ResponseType(typeof(Recipe))]
        [HttpPost]
        public IHttpActionResult CreateRecipe([FromBody] Recipe recipe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            recipe.Published = DateTime.Now;
            recipeRepository.InsertRecipe(recipe);
            recipeRepository.Save();

            return CreatedAtRoute("DefaultApi", new { id = recipe.Id }, recipe);
        }

        [ResponseType(typeof(Recipe))]
       [Authorize]
       [HttpPost]
        [Route("api/recipes/SearchRecipebyId")]
        public IHttpActionResult SearcRecipebyId([FromBody] int id)
        {
           
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id < 0) return StatusCode(HttpStatusCode.BadRequest);

            int Num;
            bool isNum = int.TryParse(id.ToString(), out Num);
            if (!isNum)
                return StatusCode(HttpStatusCode.BadRequest);

            int currentUserId = int.Parse(User.Identity.GetUserId());
          
            var currentUser = userRepository.GetUsers().FirstOrDefault(x => x.Id == currentUserId);

            var returnValue = recipeRepository.SearchById(id, currentUser);
            if (returnValue == null)
                return StatusCode(HttpStatusCode.NotFound);
            return Ok(returnValue);

        }
        [Authorize]
        [ResponseType(typeof(Recipe))]
        [HttpPost]
        [Route("api/recipes/SearchRecipebyName")]
        public IHttpActionResult SearchRecipebyName([FromBody] string recipe)
        {

            if (recipe == string.Empty) return StatusCode(HttpStatusCode.BadRequest);
            if (!Regex.IsMatch(recipe, @"^[a-zA-Z]+$")) return StatusCode(HttpStatusCode.BadRequest);

            int currentUserId = int.Parse(User.Identity.GetUserId());
            var currentUser = userRepository.GetUsers().FirstOrDefault(x => x.Id == currentUserId);

            var retvalue = recipeRepository.SearchByName(recipe, currentUser);
            if (retvalue.Count == 0) return StatusCode(HttpStatusCode.NotFound);

            return Ok(retvalue);

        }
        // DELETE: api/Recipes/5
        [ResponseType(typeof(Recipe))]
        public IHttpActionResult DeleteRecipe(int id)
        {

            recipeRepository.DeleteRecipe(id);
            recipeRepository.Save();

            return Ok();
        }

      
        private bool RecipeExists(int id)
        {
            return recipeRepository.GetRecipes().Count(e => e.Id == id) > 0;
        }

        private List<FilterRecipe> FilterResults(List<Recipe> TakeRecipe)
        {
            List<FilterRecipe> resultsforreturn = new List<FilterRecipe>();

            for (int i = 0; i < TakeRecipe.Count; i++)
            {
                var filter = new FilterRecipe();
                filter.Id = TakeRecipe[i].Id;
                filter.Name = TakeRecipe[i].Name;
                resultsforreturn.Add(filter);


            }
            return resultsforreturn;
        }


    }
}