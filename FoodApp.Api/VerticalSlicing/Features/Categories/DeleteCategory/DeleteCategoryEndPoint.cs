namespace FoodApp.Api.VerticalSlicing.Features.Categories.DeleteCategory;

public class DeleteCategoryEndPoint : BaseController
{
    public DeleteCategoryEndPoint(ControllerParameters controllerParameters) : base(controllerParameters) { }

    [Authorize(Roles = "Admin,Manager")]
    [HttpDelete("Category/DeleteCategory/{categoryId}")]
    public async Task<Result<bool>> DeleteCategory(int categoryId)
    {
        var command = new DeleteCategoryCommand(categoryId);
        var response = await _mediator.Send(command);
        return response;
    }
}