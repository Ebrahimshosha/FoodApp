namespace FoodApp.Api.VerticalSlicing.Features.Account.ChangePassword
{
    public class ChangePasswordRequest
    {
        public string Email { get; set; } = null!;
        public string CurrentPassword { get; set; } = null!;
        public string NewPassword { get; set; } = null!;
    }
}