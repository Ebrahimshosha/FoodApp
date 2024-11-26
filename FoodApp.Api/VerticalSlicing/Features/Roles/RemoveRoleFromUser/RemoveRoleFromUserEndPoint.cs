namespace FoodApp.Api.VerticalSlicing.Features.Roles.RemoveRoleFromUser;

public class RemoveRoleFromUserEndPoint : BaseController
{
    public RemoveRoleFromUserEndPoint(ControllerParameters controllerParameters) : base(controllerParameters) { }

    [HttpDelete("Roles/RemoveRoleFromUser")]
    public async Task<Result<bool>> RemoveRoleFromUser(RemoveRoleFromUserRequest request)
    {
        var command = request.Map<RemoveRoleFromUserCommand>();
        var response = await _mediator.Send(command);
        return response;
    }
}
