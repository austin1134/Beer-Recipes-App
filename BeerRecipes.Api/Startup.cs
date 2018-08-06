using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using BeerRecipes.Core.Data;
using BeerRecipes.Api.Models;
using BeerRecipes.Data.EntityFramework;
using BeerRecipes.Data.EntityFramework.Seed;
using Microsoft.EntityFrameworkCore;
using BeerRecipes.Data.EntityFramework.Repositories;
using GraphQL.Types;
using GraphQL;

namespace BeerRecipes.Api
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
            Env = env;
        }

        public IConfigurationRoot Configuration { get; }
        private IHostingEnvironment Env { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();
            services.AddAutoMapper(typeof(Startup));

            services.AddScoped<BeerRecipesQuery>();
            services.AddScoped<BeerRecipesMutation>();
            services.AddScoped<BeerRecipeInputType>();
            services.AddTransient<IBeerRecipeRepository, BeerRecipeRepository>();
            services.AddTransient<IIngredientRepository, IngredientRepository>();
            if (Env.IsEnvironment("Test"))
            {
                services.AddDbContext<BeerRecipesContext>(options =>
                    options.UseInMemoryDatabase(databaseName: "BeerRecipes"));
            }
            else
            {
                services.AddDbContext<BeerRecipesContext>(options =>
                    options.UseSqlServer(Configuration["ConnectionStrings:BeerRecipesDatabaseConnection"]));
            }
            services.AddScoped<IDocumentExecuter, DocumentExecuter>();
            services.AddTransient<BeerRecipeType>();
            services.AddTransient<BeerRecipeInterface>();
            services.AddTransient<IngredientType>();
            services.AddTransient<IngredientInterface>();
            var sp = services.BuildServiceProvider();
            services.AddScoped<ISchema>(_ => new BeerRecipesSchema(type => (GraphType)sp.GetService(type)) { Query = sp.GetService<BeerRecipesQuery>(), Mutation = sp.GetService<BeerRecipesMutation>() });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,
                              ILoggerFactory loggerFactory, BeerRecipesContext db)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseStaticFiles();
            app.UseMvc();

            db.EnsureSeedData();
        }
    }
}
