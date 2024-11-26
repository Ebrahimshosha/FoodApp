namespace FoodApp.Api.VerticalSlicing.Features.Account.VerifyAccount;

public class VerifyAccountEndPoint : BaseController
{
    public VerifyAccountEndPoint(ControllerParameters controllerParameters) : base(controllerParameters) { }

    [HttpPost("Account/VerifyAccount")]
    public async Task<Result<bool>> Verify(VerifyAccountRequest request)
    {
        var command = request.Map<VerifyOTPCommand>();
        var result = await _mediator.Send(command);
        return result;
    }
}