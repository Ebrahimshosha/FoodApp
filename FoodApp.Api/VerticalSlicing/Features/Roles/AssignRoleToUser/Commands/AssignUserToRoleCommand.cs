namespace FoodApp.Api.VerticalSlicing.Features.Roles.AssignRoleToUser.Commands;

public record AddRoleToUserCommand(string email, string roleName) : IRequest<Result<bool>>;

public class AddRoleToUserCommandHandler : BaseRequestHandler<AddRoleToUserCommand, Result<bool>>
{
    public AddRoleToUserCommandHandler(RequestParameters requestParameters) : base(requestParameters) { }

    public override async Task<Result<bool>> Handle(AddRoleToUserCommand request, CancellationToken cancellationToken)
    {
        var userResult = await _mediator.Send(new GetUserByEmailQuery(request.email));
        if (!userResult.IsSuccess || userResult.Data == null)
        {
            return Result.Failure<bool>(UserErrors.UserNotFound);
        }

        var user = userResult.Data.FirstOrDefault();

        var roleResult = await _mediator.Send(new GetRoleByNameQuery(request.roleName));
        if (!roleResult.IsSuccess || roleResult.Data == null)
        {
            return Result.Failure<bool>(RoleErrors.RoleNotFound);
        }
        var role = roleResult.Data;
        var userRolesResult = await _mediator.Send(new GetUserRoleByIdQuery(user!.Id, role.Id));

        if (userRolesResult.IsSuccess)
        {
            return Result.Failure<bool>(RoleErrors.RoleAlreadyExists);
        }

        var userRole = new UserRole
        {
            UserId = user.Id,
            RoleId = role.Id
        };

        await _unitOfWork.Repository<UserRole>().AddAsync(userRole);
        await _unitOfWork.SaveChangesAsync();

        return Result.Success(true);
    }
}