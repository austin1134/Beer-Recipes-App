using GraphQL.Types;

namespace BeerRecipes.Api.Models
{
    public class BeerRecipeInterface : InterfaceGraphType<BeerRecipe>
    {
        public BeerRecipeInterface()
        {
            Name = "BeerRecipe";

            Field(d => d.Id).Description("The id of the beer recipe.");
            Field(d => d.Name, nullable: true).Description("The name of the beer recipe.");
            Field<ListGraphType<IngredientInterface>>("ingredients");
        }
    }
}
