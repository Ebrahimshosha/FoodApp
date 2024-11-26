namespace FoodApp.Api.VerticalSlicing.Features.Recipes.DeleteRecipe;

public class DeleteRecipeEndPoint : BaseController
{
    public DeleteRecipeEndPoint(ControllerParameters controllerParameters) : base(controllerParameters) { }

    [Authorize(Roles = "Admin,Manager")]
    [HttpDelete("Recipe/DeleteRecipe")]
    public async Task<Result<bool>> DeleteRecipe(int RecipeId)
    {
        var command = new DeleteRecipeCommand(RecipeId);
        var response = await _mediator.Send(command);
        return response;
    }
}