namespace FoodApp.Api.VerticalSlicing.Features.Account.ResetPassword;

public class ResetPasswordEndPoint : BaseController
{
    public ResetPasswordEndPoint(ControllerParameters controllerParameters) : base(controllerParameters) { }

    [HttpPost("Account/ResetPassword")]
    public async Task<Result<bool>> ResetPassword(ResetPasswordRequest request)
    {
        var command = request.Map<ResetPasswordCommand>();
        var response = await _mediator.Send(command);

        return response;
    }
}