﻿namespace FoodApp.Api.VerticalSlicing.Features.Account.RefreshTokens.Queries;

public record GetUserByRefreshToken(string refreshToken) : IRequest<Result<User>>;

public class GetUserByRefreshTokenHandler : BaseRequestHandler<GetUserByRefreshToken, Result<User>>
{
    public GetUserByRefreshTokenHandler(RequestParameters requestParameters) : base(requestParameters) { }

    public override async Task<Result<User>> Handle(GetUserByRefreshToken request, CancellationToken cancellationToken)
    {

        var user =  _unitOfWork.Repository<User>()
                               .GetAsync(u => u.RefreshTokens
                               .Any(r => r.Token == request.refreshToken))
                               .Include(u => u.RefreshTokens)
                               .FirstOrDefault();

        if (user == null)
        {
            return Result.Failure<User>(UserErrors.InvalidRefreshToken);
        }

        var isTokenActive = user.RefreshTokens.Any(r => r.Token == request.refreshToken && r.IsActive);

        if (!isTokenActive)
        {
            return Result.Failure<User>(UserErrors.InvalidRefreshToken);
        }

        return Result.Success(user);
    }
}