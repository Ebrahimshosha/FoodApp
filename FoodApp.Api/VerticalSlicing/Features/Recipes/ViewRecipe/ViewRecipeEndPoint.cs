namespace FoodApp.Api.VerticalSlicing.Features.Recipes.ViewRecipe;

public class ViewRecipeEndPoint : BaseController
{
    public ViewRecipeEndPoint(ControllerParameters controllerParameters) : base(controllerParameters) { }

    [HttpGet("Recipe/ViewRecipe/{RecipeId}")]
    public async Task<Result<RecipeResponse>> GetRecipeById(int RecipeId)
    {
        var Query = new GetRecipeByIdQuery(RecipeId);
        var result = await _mediator.Send(Query);
        var recipe = result.Data;
        var recipeResponse = recipe.Map<RecipeResponse>();

        return Result.Success(recipeResponse);
    }
}