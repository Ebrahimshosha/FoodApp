using FluentValidation;

namespace FoodApp.Api.VerticalSlicing.Features.Roles.AssignRoleToUser
{

    public class AssignRoleToUserRequestValidator : AbstractValidator<AssignRoleToUserRequest>
    {
        public AssignRoleToUserRequestValidator()
        {
            RuleFor(x => x.roleName)
                 .NotEmpty().WithMessage("RoleName is required");
            RuleFor(x => x.email)
                .NotEmpty().WithMessage("UserId Is required");
        }
    }
}
