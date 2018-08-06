using BeerRecipes.Api.Models;

using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerRecipes.Api.Models
{
    public class BeerRecipesMutation : ObjectGraphType
    {
        public BeerRecipesMutation() { }
        public BeerRecipesMutation(Core.Data.IBeerRecipeRepository beerRecipeRepository)
        {
            Name = "Mutation";

            Field<BeerRecipeType>(
                  "createBeerRecipe",
                  arguments: new QueryArguments(
                  new QueryArgument<BeerRecipeInputType> { Name = "beerRecipe", Description = "The name of the beer recipe." }
            ),
            resolve: context =>
            {
                var beerRecipe = context.GetArgument<Core.Models.BeerRecipe>("beerRecipe");
                return beerRecipeRepository.Add(beerRecipe);
            });
        }
    }
}
