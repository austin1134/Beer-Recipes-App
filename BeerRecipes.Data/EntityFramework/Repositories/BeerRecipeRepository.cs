using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeerRecipes.Core.Models;
using Microsoft.Extensions.Logging;
using BeerRecipes.Core.Data;

namespace BeerRecipes.Data.EntityFramework.Repositories
{
    public class BeerRecipeRepository : BaseRepository<BeerRecipe, int>, IBeerRecipeRepository
    {
        public BeerRecipeRepository() { }

        public BeerRecipeRepository(BeerRecipesContext db, ILogger<BeerRecipeRepository> logger)
            : base(db, logger)
        {
        }

        public async Task<BeerRecipe> GetBeerRecipe(int id)
        {
            var beerRecipe = await Get(id);
            return beerRecipe;
        }

        public async Task<ICollection<BeerRecipe>> GetBeerRecipes(string name)
        {
            var beerRecipes = await GetAllContainsName(name);
            return beerRecipes.ToList();
        }

        public async Task<ICollection<Ingredient>> GetIngredients(int id)
        {
            var beerRecipe = await Get(id, "BeerRecipeIngredients.Ingredient");
            return beerRecipe.Ingredients.ToList();
        }
    }
}
