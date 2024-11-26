namespace FoodApp.Api.VerticalSlicing.Features.Users.GetUserEmailByUserId.Query;

public record GetUserEmailByUserIdQuery(int UserId) : IRequest<Result<string>>;

public class GetUserEmailByUserIdQueryHandler : IRequestHandler<GetUserEmailByUserIdQuery, Result<string>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetUserEmailByUserIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<string>> Handle(GetUserEmailByUserIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _unitOfWork.Repository<User>().GetByIdAsync(request.UserId);

        if (user == null)
        {
            return Result.Failure<string>(UserErrors.UserNotFound);
        }

        return Result.Success(user.Email);
    }
}