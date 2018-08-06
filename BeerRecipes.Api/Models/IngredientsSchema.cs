using System;
using GraphQL.Types;

namespace BeerRecipes.Api.Models
{
    public class IngredientsSchema : Schema
    {
        public IngredientsSchema(Func<Type, GraphType> resolveType)
            : base(resolveType)
        {
            Query = (IngredientsQuery)resolveType(typeof(IngredientsQuery));
        }
    }
}
