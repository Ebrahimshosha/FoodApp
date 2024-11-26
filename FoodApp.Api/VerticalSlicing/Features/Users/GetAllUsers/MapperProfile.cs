namespace FoodApp.Api.VerticalSlicing.Features.Users.GetAllUsers;

public class MapperProfile :Profile
{
    public MapperProfile()
    {
        CreateMap<User, UserResponse>();
    }
}