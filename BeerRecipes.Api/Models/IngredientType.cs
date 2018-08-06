using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using GraphQL.Types;

namespace BeerRecipes.Api.Models
{
    public class IngredientType : ObjectGraphType<Ingredient>
    {
        public IngredientType(Core.Data.IIngredientRepository ingredientRepository, IMapper mapper)
        {
            Name = "Ingredient";
            Description = "An ingredient for creating a beer recipe.";

            Field(x => x.Id).Description("The Id of the ingredient.");
            Field(x => x.Name, nullable: true).Description("The name of the ingredient.");
            Field(x => x.BeerRecipeId, nullable: true).Description("The beer recipe id this ingredient is associated with.");
            Field(d => d.Quantity, nullable: true).Description("The quantity of the ingredient.");
            Field(d => d.QuantityUnit, nullable: true).Description("The unit type of the quantity. Ex. gram.");

            Field<ListGraphType<IngredientInterface>>(
                "ingredient",
                resolve: context =>
                {
                    var ingredient = ingredientRepository.GetIngredient(int.Parse(context.Source.Name)).Result;
                    return ingredient;
                }
            );

            Interface<IngredientInterface>();
        }
    }
}
