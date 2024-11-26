namespace FoodApp.Api.VerticalSlicing.Features.Account.ForgotPassword;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<ForgetPasswordRequest, ForgotPasswordCommand>();
    }
}
