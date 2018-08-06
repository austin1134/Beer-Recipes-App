using BeerRecipes.Core.Models;

namespace BeerRecipes.Api.Models
{
    public class Ingredient
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int BeerRecipeId { get; set; }
        public decimal Quantity { get; set; }
        public string QuantityUnit { get; set; }
    }
}
