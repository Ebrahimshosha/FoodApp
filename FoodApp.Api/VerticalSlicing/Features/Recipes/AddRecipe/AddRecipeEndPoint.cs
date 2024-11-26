namespace FoodApp.Api.VerticalSlicing.Features.Recipes.AddRecipe;

public class AddRecipeEndPoint : BaseController
{
    public AddRecipeEndPoint(ControllerParameters controllerParameters) : base(controllerParameters) { }

    [Authorize(Roles = "Admin,Manager")]
    [HttpPost("Recipe/AddRecipe")]
    public async Task<Result<bool>> AddRecipe([FromForm] CreateRecipeRequest request)
    {
        var command = request.Map<CreateRecipeCommand>();
        var response = await _mediator.Send(command);
        return response;
    }
}