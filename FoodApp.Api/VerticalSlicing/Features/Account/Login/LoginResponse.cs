namespace FoodApp.Api.VerticalSlicing.Features.Account.Login;

public class LoginResponse()
{
    public int Id { get; set; }
    public string Email { get; set; } = null!;
    public string Token { get; set; }= null!;
    public string RefreshToken { get; set; } = null!;
}
