namespace FoodApp.Api.VerticalSlicing.Features.Roles.RemoveRole.Commands;

public record RemoveRoleCommand(string RoleName) : IRequest<Result<bool>>;
public class RemoveRoleCommandHandler : BaseRequestHandler<RemoveRoleCommand, Result<bool>>
{
    public RemoveRoleCommandHandler(RequestParameters requestParameters) : base(requestParameters) { }

    public override async Task<Result<bool>> Handle(RemoveRoleCommand request, CancellationToken cancellationToken)
    {
        var role = await _unitOfWork.Repository<Role>().GetAsync(r=>r.Name==request.RoleName).FirstOrDefaultAsync();
        if (role == null)
        {
            return Result.Failure<bool>(RoleErrors.RoleNotFound);
        }

        _unitOfWork.Repository<Role>().Delete(role);
        await _unitOfWork.SaveChangesAsync();

        return Result.Success(true);
    }
}
