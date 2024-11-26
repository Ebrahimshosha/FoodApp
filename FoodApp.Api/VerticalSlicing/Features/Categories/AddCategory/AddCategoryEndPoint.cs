namespace FoodApp.Api.VerticalSlicing.Features.Categories.AddCategory;

public class AddCategoryEndPoint : BaseController
{
    public AddCategoryEndPoint(ControllerParameters controllerParameters) : base(controllerParameters) { }

    [Authorize(Roles = "Admin,Manager")]
    [HttpPost("Category/AddCategory")]
    public async Task<Result<int>> AddCateory(AddCategoryRequest request)
    {
        var command = request.Map<CreateCategoryCommand>();
        var response = await _mediator.Send(command);
        return response;
    }
}