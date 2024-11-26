namespace FoodApp.Api.VerticalSlicing.Features.Account.ResetPassword;

public class MapperProfile :Profile
{
    public MapperProfile()
    {
        CreateMap<ResetPasswordRequest, ResetPasswordCommand>();
    }
}