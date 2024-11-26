namespace FoodApp.Api.VerticalSlicing.Features.Roles.RemoveRoleFromUser;

public class RemoveRoleFromUserRequestValidator : AbstractValidator<RemoveRoleFromUserRequest>
{
    public RemoveRoleFromUserRequestValidator()
    {
        RuleFor(x => x.email)
             .NotEmpty().WithMessage("RoleName is required");
        RuleFor(x => x.roleName)
            .NotEmpty().WithMessage("UserId Is required");
    }
}