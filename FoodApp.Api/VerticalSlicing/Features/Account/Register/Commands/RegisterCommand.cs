namespace FoodApp.Api.VerticalSlicing.Features.Account.Register.Commands;

public record RegisterCommand(string UserName,
                              string Email,
                              string Country,
                              string PhoneNumber,
                              string Password,
                              string ConfirmPassword) : IRequest<Result>;

public class RegisterCommandHandler : BaseRequestHandler<RegisterCommand, Result>
{
    public RegisterCommandHandler(RequestParameters requestParameters) : base(requestParameters) { }
    public override async Task<Result> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var userExists = await _mediator.Send(new CheckUserExistsQuery(request.UserName, request.Email));

        if (userExists.Data)
        {
            return Result.Failure<bool>(UserErrors.UserAlreadyExists);
        }

        var user = request.Map<User>();

        if (request.Password != request.ConfirmPassword)
            return Result.Failure<bool>(UserErrors.PasswordsDoNotMatch);

        user.PasswordHash = PasswordHasher.HashPassword(request.Password);

        var userRepo = _unitOfWork.Repository<User>();

        await userRepo.AddAsync(user);
        await userRepo.SaveChangesAsync();

        return Result.Success();
    }
}
