using BeerRecipes.Core.Models;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace BeerRecipes.Data.EntityFramework.Seed
{
    public static class BeerRecipesSeedData
    {
        public static void EnsureSeedData(this BeerRecipesContext db)
        {
            db._logger.LogInformation("Seeding database");

            // beer recipes
            var testBeer = new BeerRecipe
            {
                Id = 1001,
                Name = "Test Beer",
                Ingredients = new List<Ingredient>
                {
                    new Ingredient { Id = 1, Name = "", Quantity = 0, QuantityUnit = "Grams" },
                    new Ingredient { Id = 2, Name = "", Quantity = 0, QuantityUnit = "Grams" },
                    new Ingredient { Id = 3, Name = "", Quantity = 0, QuantityUnit = "Grams" }
                }
            };
            var testBeer2 = new BeerRecipe
            {
                Id = 1002,
                Name = "Test Beer 2",
                Ingredients = new List<Ingredient>
                {
                    new Ingredient { Id = 4, Name = "", Quantity = 0, QuantityUnit = "Grams" },
                    new Ingredient { Id = 5, Name = "", Quantity = 0, QuantityUnit = "Grams" },
                    new Ingredient { Id = 6, Name = "", Quantity = 0, QuantityUnit = "Grams" }
                }
            };
            var testBeer3 = new BeerRecipe
            {
                Id = 1003,
                Name = "Test Beer 3",
                Ingredients = new List<Ingredient>
                {
                    new Ingredient { Id = 7, Name = "", Quantity = 0, QuantityUnit = "Grams" },
                    new Ingredient { Id = 8, Name = "", Quantity = 0, QuantityUnit = "Grams" },
                    new Ingredient { Id = 9, Name = "", Quantity = 0, QuantityUnit = "Grams" }
                }
            };
            var testBeer4 = new BeerRecipe
            {
                Id = 1004,
                Name = "Test Beer 4",
                Ingredients = new List<Ingredient>
                {
                    new Ingredient { Id = 10, Name = "", Quantity = 0, QuantityUnit = "Grams" },
                    new Ingredient { Id = 11, Name = "", Quantity = 0, QuantityUnit = "Grams" },
                    new Ingredient { Id = 12, Name = "", Quantity = 0, QuantityUnit = "Grams" }
                }
            };

            var beerRecipes = new List<BeerRecipe>
            {
                testBeer,
                testBeer2,
                testBeer3,
                testBeer4
            };
            if (!db.BeerRecipes.Any())
            {
                db._logger.LogInformation("Seeding beer recipes");                
                db.BeerRecipes.AddRange(beerRecipes);
                db.SaveChanges();
            }



            // ingredients
            var ingredient = new Ingredient
            {
                Id = 2000,
                Name = "Test Ingredient",
                Quantity = 0,
                QuantityUnit = "Grams"
            };
            var ingredient2 = new Ingredient
            {
                Id = 2001,
                Name = "Test Ingredient 2",
                Quantity = 0,
                QuantityUnit = "Grams"
            };
            var ingredient3 = new Ingredient
            {
                Id = 2002,
                Name = "Test Ingredient 3",
                Quantity = 0,
                QuantityUnit = "Grams"
            };
            var ingredient4 = new Ingredient
            {
                Id = 2003,
                Name = "Test Ingredient 4",
                Quantity = 0,
                QuantityUnit = "Grams"
            };

            var ingredients = new List<Ingredient>
            {
                ingredient,
                ingredient2,
                ingredient3,
                ingredient4
            };
            if (!db.Ingredients.Any())
            {
                db._logger.LogInformation("Seeding ingredients");
                db.Ingredients.AddRange(ingredients);
                db.SaveChanges();
            }


        }
    }
}
