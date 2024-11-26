namespace FoodApp.Api.VerticalSlicing.Features.Roles.AddRole;

public class AddRoleEndPoint : BaseController
{
    public AddRoleEndPoint(ControllerParameters controllerParameters) : base(controllerParameters) { }

    [Authorize(Roles ="Admin")]
    [HttpPost("Roles/AddRole")]
    public async Task<Result<bool>> AddRoleToUser(AddRoleRequest request)
    {
        var command = request.Map<CreateRoleCommand>();
        var response = await _mediator.Send(command);
        return response;
    }
}