namespace FoodApp.Api.VerticalSlicing.Features.Recipes.Common.Helper;

public class RecipePictureUrlResolve : IValueResolver<Recipe, RecipeResponse, string>
{
    private readonly IConfiguration _configuration;

    public RecipePictureUrlResolve(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string Resolve(Recipe source, RecipeResponse destination, string destMember, ResolutionContext context)
    {
        if (!string.IsNullOrEmpty(source.ImageUrl))
        {
            return $"{_configuration["ApiBaseUrl"]}Files/Images/{source.ImageUrl}";
        }
        return string.Empty;
    }
}