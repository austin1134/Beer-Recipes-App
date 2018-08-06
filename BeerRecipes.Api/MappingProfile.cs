using AutoMapper;
using BeerRecipes.Api.Models;

namespace BeerRecipes.Api
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Beer Recipe
            CreateMap<Core.Models.BeerRecipe, BeerRecipe>(MemberList.Destination)
                .ForMember(
                dest => dest.Ingredients, 
                opt => opt.MapFrom(src => src.Ingredients)
            );

            CreateMap<Core.Models.Ingredient, Ingredient>(MemberList.Destination);
        }
    }
}
