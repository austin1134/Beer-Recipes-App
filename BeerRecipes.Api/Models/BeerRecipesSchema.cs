using System;
using GraphQL.Types;

namespace BeerRecipes.Api.Models
{
    public class BeerRecipesSchema : Schema
    {
        public BeerRecipesSchema(Func<Type, GraphType> resolveType)
            : base(resolveType)
        {
            Query = (BeerRecipesQuery)resolveType(typeof(BeerRecipesQuery));
            Mutation = (BeerRecipesMutation)resolveType(typeof(BeerRecipesMutation));
        }
    }
}
