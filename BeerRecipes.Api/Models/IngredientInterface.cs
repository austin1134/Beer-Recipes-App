using GraphQL.Types;

namespace BeerRecipes.Api.Models
{
    public class IngredientInterface : InterfaceGraphType<Ingredient>
    {
        public IngredientInterface()
        {
            Name = "Ingredient";

            Field(d => d.Id).Description("The id of the ingredient.");
            Field(d => d.Name, nullable: true).Description("The name of the ingredient.");
            Field(d => d.Quantity, nullable: true).Description("The quantity of the ingredient.");
            Field(d => d.QuantityUnit, nullable: true).Description("The unit type of the quantity. Ex. gram.");
        }
    }
}
