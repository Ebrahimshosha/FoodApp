namespace FoodApp.Api.VerticalSlicing.Features.Recipes.ViewFavouriteRecipes;

public class ViewFavouriteRecipesEndPoint : BaseController
{
    public ViewFavouriteRecipesEndPoint(ControllerParameters controllerParameters) : base(controllerParameters) { }

    [HttpGet("Recipe/ViewFavouriteRecipes")]
    public async Task<Result<List<ViewFavouriteRecipesResponse>>> ViewFavouriteRecipes()
    {
        var result = await _mediator.Send(new GetFavouriteRecipesForLoggedUserQuery());
        return result;
    }
}