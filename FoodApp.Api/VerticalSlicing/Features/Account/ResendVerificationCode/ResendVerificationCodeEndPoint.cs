namespace FoodApp.Api.VerticalSlicing.Features.Account.ResendVerificationCode;

public class ResendVerificationCodeEndPoint : BaseController
{
    public ResendVerificationCodeEndPoint(ControllerParameters controllerParameters) : base(controllerParameters) { }

    [HttpPost("Account/ResendVerificationCode")]
    public async Task<Result<bool>> ResendVerificationCode(ResendVerificationCodeRequest requset)
    {
        var command = requset.Map<SendVerificationOTP>();
        var result = await _mediator.Send(command);
        return result;
    }
}