namespace FoodApp.Api.VerticalSlicing.Features.Categories.ViewCategory;

public class ViewCategoryEndPoint : BaseController
{
    public ViewCategoryEndPoint(ControllerParameters controllerParameters) : base(controllerParameters) { }

    [HttpGet("Category/ViewCategory/{categoryId}")]
    public async Task<Result<ViewCategoryResponse>> GetCategoryById(int categoryId)
    {
        var result = await _mediator.Send(new GetCategoryByIdQuery(categoryId));
        if (!result.IsSuccess)
        {
            return Result.Failure<ViewCategoryResponse>(CategoryErrors.CategoryNotFound);
        }
        var category = result.Data.Map<ViewCategoryResponse>();
        return Result.Success(category);
    }
}