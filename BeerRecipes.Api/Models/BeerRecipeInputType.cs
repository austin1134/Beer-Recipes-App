using BeerRecipes.Core.Models;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerRecipes.Api.Models
{
    public class BeerRecipeInputType : InputObjectGraphType
    {
        public BeerRecipeInputType()
        {
            Name = "BeerRecipeInput";

            Field<StringGraphType>("name");
            Field<ListGraphType<IngredientType>>("ingredients");
        }
    }
}
