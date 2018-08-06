using BeerRecipes.Core.Models;

namespace BeerRecipes.Api.Models
{
    public class BeerRecipe
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public Ingredient[] Ingredients { get; set; }
    }
}
