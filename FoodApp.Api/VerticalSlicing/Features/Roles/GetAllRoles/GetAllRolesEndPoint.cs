namespace FoodApp.Api.VerticalSlicing.Features.Roles.GetAllRoles;

public class GetAllRolesEndPoint : BaseController
{
    public GetAllRolesEndPoint(ControllerParameters controllerParameters) : base(controllerParameters) { }

    [Authorize(Roles = "Admin")]
    [HttpGet("Roles/GetAllRoles")]
    public async Task<Result<List<Role>>> GetAllRoles()
    {
        var response = await _mediator.Send(new GetAllRolesQuery());
        return response;
    }
}
