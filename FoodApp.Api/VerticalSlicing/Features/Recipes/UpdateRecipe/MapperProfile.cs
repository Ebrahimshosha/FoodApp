namespace FoodApp.Api.VerticalSlicing.Features.Recipes.UpdateRecipe;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<UpdateRecipeRequest, UpdateRecipeCommand>();

        CreateMap<UpdateRecipeCommand, Recipe>()
             .ForMember(dest => dest.ImageUrl, opt => opt.Ignore())
             .AfterMap(async (src, dest) =>
             {
                 dest.ImageUrl = await DocumentSettings.UploadFileAsync(src.ImageUrl, "Images");
             });
    }
}
