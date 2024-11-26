namespace FoodApp.Api.VerticalSlicing.Features.Roles.RemoveRoleFromUser;

public class RemoveRoleFromUserRequest
{
    public string email { get; set; } = null!;
    public string roleName { get; set; } = null!;
}
