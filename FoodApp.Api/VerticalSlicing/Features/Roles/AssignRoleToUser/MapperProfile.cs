namespace FoodApp.Api.VerticalSlicing.Features.Roles.AssignRoleToUser;

public class MapperProfile :Profile
{
    public MapperProfile()
    {
        CreateMap<AssignRoleToUserRequest, AddRoleToUserCommand>();
    }
}
