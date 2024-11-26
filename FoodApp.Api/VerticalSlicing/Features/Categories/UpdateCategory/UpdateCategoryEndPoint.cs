namespace FoodApp.Api.VerticalSlicing.Features.Categories.UpdateCategory;

public class UpdateCategoryEndPoint : BaseController
{
    public UpdateCategoryEndPoint(ControllerParameters controllerParameters) : base(controllerParameters) { }

    [Authorize(Roles = "Admin,Manager")]
    [HttpPut("Category/UpdateCategory/{categoryId}")]
    public async Task<Result<bool>> UpdateCategory(int categoryId, UpdateCategoryRequest request)
    {
        var command = new UpdateCategoryCommand(categoryId, request.Name);
        var response = await _mediator.Send(command);
        return response;
    }
}