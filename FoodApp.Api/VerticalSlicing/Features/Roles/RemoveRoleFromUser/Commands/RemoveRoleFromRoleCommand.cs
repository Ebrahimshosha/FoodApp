namespace FoodApp.Api.VerticalSlicing.Features.Roles.RemoveRoleFromUser.Commands;

public record RemoveRoleFromUserCommand(string email, string roleName) : IRequest<Result<bool>>;

public class RemoveRoleFromUserCommandHandler : BaseRequestHandler<RemoveRoleFromUserCommand, Result<bool>>
{
    public RemoveRoleFromUserCommandHandler(RequestParameters requestParameters) : base(requestParameters) { }

    public override async Task<Result<bool>> Handle(RemoveRoleFromUserCommand request, CancellationToken cancellationToken)
    {
        var role = await _unitOfWork.Repository<Role>().GetAsync(r => r.Name == request.roleName).FirstOrDefaultAsync();
        if (role is null)
        {
            return Result.Failure<bool>(RoleErrors.RoleNotFound);
        }

        var userResult = await _mediator.Send(new GetUserByEmailQuery(request.email));

        var user = userResult.Data.FirstOrDefault();

        if (!userResult.IsSuccess || user is null)
        {
            return Result.Failure<bool>(UserErrors.UserNotFound);
        }

        var userRole = _unitOfWork.Repository<UserRole>()
            .GetAsync(ur => ur.UserId == user.Id && ur.RoleId == role.Id).FirstOrDefault();

        if (userRole == null)
        {
            return Result.Failure<bool>(RoleErrors.UserNotAssignedToThatRole);
        }

        _unitOfWork.Repository<UserRole>().Delete(userRole);
        await _unitOfWork.SaveChangesAsync();

        return Result.Success(true);
    }
}
