namespace FoodApp.Api.VerticalSlicing.Features.Recipes.RemoveRecipeFromFavourite;

public class RemoveRecipeFromFavouriteEndPoint : BaseController
{
    public RemoveRecipeFromFavouriteEndPoint(ControllerParameters controllerParameters) : base(controllerParameters) { }

    [Authorize]
    [HttpDelete("Recipe/RemoveRecipeFromFavourite/{RecipeId}")]
    public async Task<Result<bool>> RemoveRecipeFromFavourite(int RecipeId)
    {
        var response = await _mediator.Send(new RemoveRecipeFromFavouritesCommand(RecipeId));
        return response;
    }
}
