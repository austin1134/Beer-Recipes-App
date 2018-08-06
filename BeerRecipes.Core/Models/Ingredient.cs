using BeerRecipes.Core.Data;
using System.Collections.Generic;

namespace BeerRecipes.Core.Models
{
    public class Ingredient : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BeerRecipeId { get; set; }
        public decimal Quantity { get; set; }
        public string QuantityUnit { get; set; }
    }
}
