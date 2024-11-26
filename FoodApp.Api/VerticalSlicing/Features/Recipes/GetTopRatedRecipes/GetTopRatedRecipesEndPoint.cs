namespace FoodApp.Api.VerticalSlicing.Features.Recipes.GetTopRatedRecipes;

public class GetTopRatedRecipesEndPoint : BaseController
{
    public GetTopRatedRecipesEndPoint(ControllerParameters controllerParameters) : base(controllerParameters) { }

    [Authorize(Roles = "Admin,Manager")]
    [HttpGet("Recipe/TopRatedReipes")]
    public async Task<Result<IEnumerable<TopRatedRecipesResponse>>> GetTopRatedRecipes([FromQuery] int numberOfRecipes = 5)
    {
        var query = new GetTopRatedRecipesQuery(numberOfRecipes);
        var result = await _mediator.Send(query);

        return result;
    }
}