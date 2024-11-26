namespace FoodApp.Api.VerticalSlicing.Features.Users.DeleteUserProfile;

public class DeleteUserProfileEndPoint : BaseController
{
    public DeleteUserProfileEndPoint(ControllerParameters controllerParameters) : base(controllerParameters) { }

    [Authorize]
    [HttpDelete("User/DeleteUserProfile")]
    public async Task<Result<bool>> DeleteUser()
    {
        var result = await _mediator.Send(new DeleteUserProfileCommand());
        return result;
    }
}