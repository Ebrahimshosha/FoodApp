namespace FoodApp.Api.VerticalSlicing.Features.Roles.RemoveRole;

public class RemoveRoleEndPoint : BaseController
{
    public RemoveRoleEndPoint(ControllerParameters controllerParameters) : base(controllerParameters) { }

    [Authorize(Roles = "Admin")]
    [HttpDelete("Roles/RemoveRole")]
    public async Task<Result<bool>> RemoveRole(string roleName)
    {
        var response = await _mediator.Send(new RemoveRoleCommand(roleName));
        return response;
    }
}
