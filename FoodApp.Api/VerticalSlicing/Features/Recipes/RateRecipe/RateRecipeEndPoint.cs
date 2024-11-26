namespace FoodApp.Api.VerticalSlicing.Features.Recipes.RateRecipe;

public class RateRecipeEndPoint : BaseController
{
    public RateRecipeEndPoint(ControllerParameters controllerParameters) : base(controllerParameters) { }

    [Authorize]
    [HttpPost("Recipe/RateReipe")]
    public async Task<Result> RateRecipe(RateRecipeRequest request)
    {
        var commad = request.Map<RateRecipeCommand>();
        var result = await _mediator.Send(commad);
        return result;
    }
}