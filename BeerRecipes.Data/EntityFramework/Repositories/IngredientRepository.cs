using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeerRecipes.Core.Models;
using Microsoft.Extensions.Logging;
using BeerRecipes.Core.Data;

namespace BeerRecipes.Data.EntityFramework.Repositories
{
    public class IngredientRepository : BaseRepository<Ingredient, int>, IIngredientRepository
    {
        public IngredientRepository() { }

        public IngredientRepository(BeerRecipesContext db, ILogger<IngredientRepository> logger)
            : base(db, logger)
        {
        }

        public async Task<Ingredient> GetIngredient(int id)
        {
            var ingredient = await Get(id);
            return ingredient;
        }

        public async Task<Ingredient> GetIngredient(string name)
        {
            var ingredient = await Get(name);
            return ingredient;
        }

        public async Task<ICollection<Ingredient>> GetIngredients()
        {
            var ingredients = await GetAll();
            return ingredients.ToList();
        }

        public async Task<ICollection<Ingredient>> GetIngredients(string name)
        {
            var ingredients = await GetAllContainsName(name);
            return ingredients.ToList();
        }
    }
}
