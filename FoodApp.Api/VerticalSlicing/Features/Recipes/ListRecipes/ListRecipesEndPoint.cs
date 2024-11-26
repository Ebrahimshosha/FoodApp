namespace FoodApp.Api.VerticalSlicing.Features.Recipes.ListRecipes;

public class ListRecipesEndPoint : BaseController
{
    public ListRecipesEndPoint(ControllerParameters controllerParameters) : base(controllerParameters) { }

    [Authorize(Roles = "Admin,Manager")]
    [HttpGet("Recipe/ListRecipes")]
    public async Task<Result<Pagination<RecipeResponse>>> GetAllRecipes([FromQuery] SpecParams spec)
    {
        var result = await _mediator.Send(new GetRecipesQuery(spec));
        if (!result.IsSuccess)
        {
            return Result.Failure<Pagination<RecipeResponse>>(result.Error);
        }

        var RecipesCount = await _mediator.Send(new GetRecipesCountQuery(spec));
        var paginationResult = new Pagination<RecipeResponse>(spec.PageSize, spec.PageIndex, RecipesCount.Data, result.Data);

        return Result.Success(paginationResult);
    }
}