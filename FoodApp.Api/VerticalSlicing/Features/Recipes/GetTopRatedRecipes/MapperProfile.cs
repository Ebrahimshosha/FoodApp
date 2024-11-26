namespace FoodApp.Api.VerticalSlicing.Features.Recipes.GetTopRatedRecipes;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<Recipe, TopRatedRecipesResponse>()
               .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));
    }
}
