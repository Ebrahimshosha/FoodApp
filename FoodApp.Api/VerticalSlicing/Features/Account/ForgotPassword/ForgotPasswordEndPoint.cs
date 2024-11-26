namespace FoodApp.Api.VerticalSlicing.Features.Account.ForgotPassword;
public class ForgotPasswordEndPoint : BaseController
{
    public ForgotPasswordEndPoint(ControllerParameters controllerParameters) : base(controllerParameters) { }

    [HttpPost("Account/ForgotPassword")]
    public async Task<Result<bool>> ForgotPassword(ForgetPasswordRequest request)
    {
        var command = request.Map<ForgotPasswordCommand>();

        var response = await _mediator.Send(command);

        return response;
    }
}
