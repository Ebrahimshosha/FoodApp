namespace FoodApp.Api.VerticalSlicing.Features.Account.ChangePassword;

public class ChangePasswordEndPoint : BaseController
{
    public ChangePasswordEndPoint(ControllerParameters controllerParameters) : base(controllerParameters) { }

    [HttpPost("Account/ChangePassword")]
    public async Task<Result<bool>> ChangePassword(ChangePasswordRequest viewModel)
    {
        var command = viewModel.Map<ChangePasswordCommand>();
        var response = await _mediator.Send(command);
        return response;
    }
}