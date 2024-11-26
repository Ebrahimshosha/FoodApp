namespace FoodApp.Api.VerticalSlicing.Features.Recipes.UpdateRecipe;

public class UpdateRecipeEndPoint : BaseController
{
    public UpdateRecipeEndPoint(ControllerParameters controllerParameters) : base(controllerParameters) { }

    [Authorize(Roles = "Admin,Manager")]
    [HttpPut("Recipe/UpdateRecipe")]
    public async Task<Result<bool>> UpdateRecipe([FromForm] UpdateRecipeRequest request)
    {
        var command = request.Map<UpdateRecipeCommand>();
        var response = await _mediator.Send(command);
        return response;
    }
}