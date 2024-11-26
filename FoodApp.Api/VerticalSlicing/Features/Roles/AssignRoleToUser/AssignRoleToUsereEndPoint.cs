namespace FoodApp.Api.VerticalSlicing.Features.Roles.AssignRoleToUser;

public class AssignRoleToUsereEndPoint : BaseController
{
    public AssignRoleToUsereEndPoint(ControllerParameters controllerParameters) : base(controllerParameters) { }

    [Authorize(Roles = "Admin")]
    [HttpPost("Roles/AssignRoleToUser")]
    public async Task<Result<bool>> AssignRoleToUser(AssignRoleToUserRequest request)
    {
        var command = request.Map<AddRoleToUserCommand>();
        var response = await _mediator.Send(command);
        return response;
    }
}
