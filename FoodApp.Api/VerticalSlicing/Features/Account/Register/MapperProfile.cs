namespace FoodApp.Api.VerticalSlicing.Features.Account.Register;

public class MapperProfile :Profile
{
    public MapperProfile()
    {
        CreateMap<RegisterRequest, RegisterCommand>();
        CreateMap<RegisterOrchestrator, RegisterCommand>();
        CreateMap<RegisterRequest, RegisterOrchestrator>();
        CreateMap<RegisterCommand, User>();
    }
}