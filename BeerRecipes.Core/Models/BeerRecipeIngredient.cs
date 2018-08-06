namespace BeerRecipes.Core.Models
{
    public class BeerRecipeIngredient
    {
        public int BeerRecipeId { get; set; }
        public BeerRecipe BeerRecipe { get; set; }

        public int IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }
    }
}
