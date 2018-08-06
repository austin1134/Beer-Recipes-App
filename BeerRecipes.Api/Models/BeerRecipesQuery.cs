﻿using AutoMapper;
using GraphQL.Types;
using System.Collections.Generic;

namespace BeerRecipes.Api.Models
{
    public class BeerRecipesQuery : ObjectGraphType
    {
        public BeerRecipesQuery() { }

        public BeerRecipesQuery(Core.Data.IBeerRecipeRepository beerRepository, Core.Data.IIngredientRepository ingredientRepository, IMapper mapper)
        {
            Name = "Query";

            Field<ListGraphType<BeerRecipeType>>(
                "beerRecipes",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "name", Description = "name of the beer recipe" }
                ),
                resolve: context =>
                {
                    var name = context.GetArgument<string>("name");
                    var beerRecipes = beerRepository.GetBeerRecipes(name).Result;
                    var mapped = mapper.Map<ICollection<BeerRecipe>>(beerRecipes);
                    return mapped;
                }
                );

            Field<ListGraphType<BeerRecipeType>>(
                "allBeerRecipes",
                resolve: context => beerRepository.GetAll());


            Field<ListGraphType<IngredientType>>(
                "ingredients",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "name", Description = "name of the ingredient" }
                ),
                resolve: context =>
                {
                    var name = context.GetArgument<string>("name");
                    var ingredients = ingredientRepository.GetIngredients(name).Result;
                    var mapped = mapper.Map<ICollection<Ingredient>>(ingredients);
                    return mapped;
                }
                );

            Field<ListGraphType<IngredientType>>(
                "getAllIngredients",
                resolve: context => ingredientRepository.GetAll());
        }
    }
}
