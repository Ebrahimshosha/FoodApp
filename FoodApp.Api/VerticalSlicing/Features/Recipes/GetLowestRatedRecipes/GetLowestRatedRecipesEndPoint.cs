namespace FoodApp.Api.VerticalSlicing.Features.Recipes.GetLowestRatedRecipes;

public class GetLowestRatedRecipesEndPoint : BaseController
{
    public GetLowestRatedRecipesEndPoint(ControllerParameters controllerParameters) : base(controllerParameters) { }

    [Authorize(Roles = "Admin,Manager")]
    [HttpGet("Recipe/LowestRatedReipes")]
    public async Task<Result<IEnumerable<LowestRatedRecipesResponse>>> GetLowestRatedRecipes([FromQuery] int numberOfRecipes = 5)
    {
        var query = new GetLowestRatedRecipesQuery(numberOfRecipes);
        var result = await _mediator.Send(query);

        return result;
    }
}