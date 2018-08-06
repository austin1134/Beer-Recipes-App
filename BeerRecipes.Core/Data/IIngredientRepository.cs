using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using BeerRecipes.Core.Models;

namespace BeerRecipes.Core.Data
{
    public interface IIngredientRepository : IBaseRepository<Ingredient, int>
    {
        Task<Ingredient> GetIngredient(int Id);

        Task<Ingredient> GetIngredient(string name);
        Task<ICollection<Ingredient>> GetIngredients();
        Task<ICollection<Ingredient>> GetIngredients(string name);
    }
}
