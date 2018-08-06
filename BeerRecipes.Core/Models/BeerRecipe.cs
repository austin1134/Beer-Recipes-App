using BeerRecipes.Core.Data;
using System.Collections.Generic;

namespace BeerRecipes.Core.Models
{
    public class BeerRecipe : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Ingredient> Ingredients { get; set; }
        public ICollection<BeerRecipeIngredient> BeerRecipeIngredients { get; set; }
    }
}
