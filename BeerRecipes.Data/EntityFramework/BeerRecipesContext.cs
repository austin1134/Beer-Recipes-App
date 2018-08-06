using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Logging;
using BeerRecipes.Core.Models;

namespace BeerRecipes.Data.EntityFramework
{
    public class BeerRecipesContext : DbContext
    {
        public readonly ILogger _logger;
        private bool _migrations;

        public BeerRecipesContext() {
            _migrations = true;
        }
        public BeerRecipesContext(DbContextOptions options, ILogger<BeerRecipesContext> logger)
            : base(options)
        {
            _logger = logger;
            //Database.EnsureCreated();
            //Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (_migrations)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BeerRecipes;Integrated Security=SSPI;integrated security=true;MultipleActiveResultSets=True;");
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // https://docs.microsoft.com/en-us/ef/core/modeling/relationships
            // http://stackoverflow.com/questions/38520695/multiple-relationships-to-the-same-table-in-ef7core

            // ingredients
            modelBuilder.Entity<Ingredient>().HasKey(c => c.Id);
            modelBuilder.Entity<Ingredient>().Property(e => e.Id).ValueGeneratedNever();

            // beerrecipes
            modelBuilder.Entity<BeerRecipe>().HasKey(c => c.Id);
            modelBuilder.Entity<BeerRecipe>().Property(e => e.Id).ValueGeneratedNever();

            // beerrecipe-ingredient
            modelBuilder.Entity<BeerRecipeIngredient>().HasKey(t => new { t.BeerRecipeId, t.IngredientId});

            modelBuilder.Entity<BeerRecipeIngredient>()
                .HasOne(cf => cf.BeerRecipe)
                .WithMany(c => c.BeerRecipeIngredients)
                .HasForeignKey(cf => cf.BeerRecipeId)
                .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<BeerRecipeIngredient>()
            //    .HasOne(cf => cf.Ingredient)
            //    .WithMany(t => t.FriendCharacters)
            //    .HasForeignKey(cf => cf.FriendId)
            //    .OnDelete(DeleteBehavior.Restrict);
        }

        public virtual DbSet<Ingredient> Ingredients { get; set; }
        public virtual DbSet<BeerRecipe> BeerRecipes { get; set; }
        public virtual DbSet<BeerRecipeIngredient> BeerRecipeIngredients { get; set; }
    }
}
