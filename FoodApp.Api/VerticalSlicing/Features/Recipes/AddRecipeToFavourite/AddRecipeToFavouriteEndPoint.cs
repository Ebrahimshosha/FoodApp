namespace FoodApp.Api.VerticalSlicing.Features.Recipes.AddRecipeToFavourite;

public class AddRecipeToFavouriteEndPoint : BaseController
{
    public AddRecipeToFavouriteEndPoint(ControllerParameters controllerParameters) : base(controllerParameters) { }

    [Authorize]
    [HttpPost("Recipe/AddRecipeToFavourite")]
    public async Task<Result<bool>> AddRecipeToFavourite(AddRecipeToFavoriteRequest request)
    {
        var command = request.Map<AddRecipeToFavouritesCommand>();
        var response = await _mediator.Send(command);
        return response;
    }
}