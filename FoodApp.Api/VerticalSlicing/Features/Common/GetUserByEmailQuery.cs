namespace FoodApp.Api.VerticalSlicing.Features.Common;

public record GetUserByEmailQuery(string Email) : IRequest<Result<IQueryable<User>>>;

public class GetUserByEmailQueryHandler : BaseRequestHandler<GetUserByEmailQuery, Result<IQueryable<User>>>
{

    public GetUserByEmailQueryHandler(RequestParameters requestParameters) : base(requestParameters) { }

    public override async Task<Result<IQueryable<User>>> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(request.Email))
        {
            return Result.Failure<IQueryable<User>>(UserErrors.InvalidEmail);
        }

        var user = _unitOfWork.Repository<User>().GetAsync(u => u.Email == request.Email);


        if (user == null)
        {
            return Result.Failure<IQueryable<User>>(UserErrors.UserNotFound);
        }

        return Result.Success(user);
    }
}
