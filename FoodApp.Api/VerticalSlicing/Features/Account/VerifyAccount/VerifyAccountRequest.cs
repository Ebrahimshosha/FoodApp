namespace FoodApp.Api.VerticalSlicing.Features.Account.VerifyAccount;

public class VerifyAccountRequest
{
    public string Email { get; set; } = null!;
    public string OTP { get; set; } = null!;
}
