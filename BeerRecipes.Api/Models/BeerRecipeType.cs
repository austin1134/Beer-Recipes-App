using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using GraphQL.Types;

namespace BeerRecipes.Api.Models
{
    public class BeerRecipeType : ObjectGraphType<BeerRecipe>
    {
        public BeerRecipeType(Core.Data.IBeerRecipeRepository beerRepository, Core.Data.IIngredientRepository ingredientRepository, IMapper mapper)
        {
            Name = "BeerRecipe";
            Description = "A recipe that contains ingredients for making a beer.";

            Field(x => x.Id).Description("The Id of the beer recipe.");
            Field(x => x.Name, nullable: true).Description("The name of the beer recipe.");
            Field<ListGraphType<IngredientType>>("ingredients",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: context => ingredientRepository.Get(int.Parse(context.Source.Id)), description: "Ingredients associated to the recipe.");

            //Field<ListGraphType<IngredientInterface>>(
            //    "ingredients",
            //    resolve: context =>
            //    {
            //        var ingredients = beerRepository.GetIngredients(int.Parse(context.Source.Id)).Result;
            //        var mapped = mapper.Map<ICollection<Ingredient>>(ingredients);
            //        return mapped;
            //    }
            //);

            Field<ListGraphType<BeerRecipeInterface>>(
                "beerRecipe",
                resolve: context =>
                {
                    var beerRecipe = beerRepository.GetBeerRecipe(int.Parse(context.Source.Id)).Result;
                    return beerRecipe;
                }
            );

            Interface<BeerRecipeInterface>();
        }
    }
}
