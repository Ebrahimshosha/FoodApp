namespace FoodApp.Api.VerticalSlicing.Features.Account.Register.Queries;

public record CheckUserExistsQuery(string UserName, string Email) : IRequest<Result<bool>>;

public class CheckUserExistsQueryHandler : BaseRequestHandler<CheckUserExistsQuery, Result<bool>>
{
    public CheckUserExistsQueryHandler(RequestParameters requestParameters) : base(requestParameters) { }
    public override async Task<Result<bool>> Handle(CheckUserExistsQuery request, CancellationToken cancellationToken)
    {
        var existingUser =  _unitOfWork.Repository<User>()
                        .GetAsync(u => u.Email == request.Email || u.UserName == request.UserName).ToList();

        return Result.Success(existingUser.Any());
    }
}
