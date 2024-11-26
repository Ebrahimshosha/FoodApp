namespace FoodApp.Api.VerticalSlicing.Features.Roles.Common;

public record GetRoleByNameQuery(string Name) : IRequest<Result<Role>>;

public class GetRoleByNameQueryHandler : BaseRequestHandler<GetRoleByNameQuery, Result<Role>>
{
    public GetRoleByNameQueryHandler(RequestParameters requestParameters) : base(requestParameters) { }
    public override async Task<Result<Role>> Handle(GetRoleByNameQuery request, CancellationToken cancellationToken)
    {
        var role =  _unitOfWork.Repository<Role>().GetAsync(u => u.Name == request.Name).FirstOrDefault();
        if (role == null)
        {
            return Result.Failure<Role>(RoleErrors.RoleNotFound);
        }

        return Result.Success(role);
    }
}