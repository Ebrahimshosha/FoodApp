namespace FoodApp.Api.VerticalSlicing.Features.Users.GetUserProfile;

public class GetUserProfileEndPoint : BaseController
{
    public GetUserProfileEndPoint(ControllerParameters controllerParameters) : base(controllerParameters) { }

    [Authorize]
    [HttpGet("User/GetUserProfile")]
    public async Task<Result<UserResponse>> GetUserProfile()
    {
        var command = new GetUserProfileQuery();
        var result = await _mediator.Send(command);
        return result;
    }
}
