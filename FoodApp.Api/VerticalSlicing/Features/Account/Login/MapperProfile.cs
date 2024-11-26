namespace FoodApp.Api.VerticalSlicing.Features.Account.Login;

public class MapperProfile :Profile
{
    public MapperProfile()
    {
        CreateMap<LoginRequest, LoginCommand>();
    }
}
