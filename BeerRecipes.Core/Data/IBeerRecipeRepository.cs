using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using BeerRecipes.Core.Models;

namespace BeerRecipes.Core.Data
{
    public interface IBeerRecipeRepository : IBaseRepository<BeerRecipe, int>
    {
        Task<BeerRecipe> GetBeerRecipe(int id);
        Task<ICollection<BeerRecipe>> GetBeerRecipes(string name);
        Task<ICollection<Ingredient>> GetIngredients(int id);
    }
}
