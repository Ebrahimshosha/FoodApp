namespace FoodApp.Api.VerticalSlicing.Features.Users.UpdateUserProfile;

public class UpdateUserProfileEndPoint : BaseController
{
    public UpdateUserProfileEndPoint(ControllerParameters controllerParameters) : base(controllerParameters) { }

    [Authorize]
    [HttpPut("User/UpdateUserProfile")]
    public async Task<Result<bool>> UpdateUser(UpdateUserRequest viewModel)
    {
        var command = viewModel.Map<UpdateUserProfileCommand>();
        var result = await _mediator.Send(command);
        return result;
    }
}