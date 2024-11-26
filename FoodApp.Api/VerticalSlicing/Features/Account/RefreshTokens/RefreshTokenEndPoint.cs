namespace FoodApp.Api.VerticalSlicing.Features.Account.RefreshTokens;

public class RefreshTokenEndPoint : BaseController
{
    public RefreshTokenEndPoint(ControllerParameters controllerParameters) : base(controllerParameters) { }

    [HttpPost("Account/RefreshToken")]
    public async Task<Result<LoginResponse>> RefreshToken()
    {
        var refreshToken = CookieHelper.GetRefreshTokenCookie(Request);
        var result = await _mediator.Send(new RefreshTokenCommand(refreshToken));
        if (!result.IsSuccess)
            return Result.Failure<LoginResponse>(UserErrors.InvalidRefreshToken);
        CookieHelper.SetRefreshTokenCookie(Response, result.Data.RefreshToken);

        return result;
    }
}