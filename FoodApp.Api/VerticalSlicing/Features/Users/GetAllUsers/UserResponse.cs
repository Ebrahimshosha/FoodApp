namespace FoodApp.Api.VerticalSlicing.Features.Users.GetAllUsers;

public class UserResponse
{
    public string UserName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string Country { get; set; } = null!;
    public DateTime DateCreated { get; set; } 
}