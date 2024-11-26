namespace FoodApp.Api.VerticalSlicing.Features.Account.RevokeToken;

public class RevokeTokenEndPoint : BaseController
{
    public RevokeTokenEndPoint(ControllerParameters controllerParameters) : base(controllerParameters) { }

    [HttpPost("Account/RevokeToken")]
    public async Task<Result<bool>> RevokeToken(string? token)
    {
        var result = await _mediator.Send(new RevokeTokenCommand(token ?? Request.Cookies["refreshToken"]));
        if (string.IsNullOrEmpty(token))
            return Result.Failure<bool>(UserErrors.TokenIsRequired);
        return result;
    }
}