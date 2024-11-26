namespace FoodApp.Api.VerticalSlicing.Features.Account.Login.Queries;

public record GetUserActiveRefreshTokensQuery(int userId) : IRequest<Result<List<RefreshToken>>>;
public class GetUserRefreshTokensQueryHandler : BaseRequestHandler<GetUserActiveRefreshTokensQuery, Result<List<RefreshToken>>>
{

    public GetUserRefreshTokensQueryHandler(RequestParameters requestParameters) : base(requestParameters) { }

    public override async Task<Result<List<RefreshToken>>> Handle(GetUserActiveRefreshTokensQuery request, CancellationToken cancellationToken)
    {
        var refreshTokens =  _unitOfWork.Repository<RefreshToken>()
                .GetAsync(r => r.UserId == request.userId).ToList();

        if (refreshTokens is null)
        {
            return Result.Failure<List<RefreshToken>>(UserErrors.UserNotFound);
        }

        var activeRefreshTokens = refreshTokens.Where(r => r.IsActive).ToList();

        if (activeRefreshTokens == null || !activeRefreshTokens.Any())
        {
            return Result.Failure<List<RefreshToken>>(UserErrors.NoRefreshTokensFound);
        }

        return Result.Success((List<RefreshToken>)refreshTokens);
    }
}

