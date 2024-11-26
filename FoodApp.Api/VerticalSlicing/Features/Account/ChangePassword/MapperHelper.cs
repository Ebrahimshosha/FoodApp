using AutoMapper;
using FoodApp.Api.VerticalSlicing.Features.Account.ChangePassword.Commands;

namespace FoodApp.Api.VerticalSlicing.Features.Account.ChangePassword
{
    public class MapperHelper : Profile
    {
        public MapperHelper()
        {

            CreateMap<ChangePasswordRequest, ChangePasswordCommand>();

        }
    }
}
