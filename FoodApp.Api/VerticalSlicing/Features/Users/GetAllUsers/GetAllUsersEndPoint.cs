namespace FoodApp.Api.VerticalSlicing.Features.Users.GetAllUsers;

public class GetAllUsersEndPoint : BaseController
{
    public GetAllUsersEndPoint(ControllerParameters controllerParameters) : base(controllerParameters) { }

    [Authorize(Roles = "Admin")]
    [HttpGet("User/GetAllUsers")]
    public async Task<Result<Pagination<UserResponse>>> GetAllUsers([FromQuery] SpecParams spec)
    {
        var result = await _mediator.Send(new GetAllUsersQuery(spec));
        if (!result.IsSuccess)
        {
            return Result.Failure<Pagination<UserResponse>>(result.Error);
        }

        var UsertCount = await _mediator.Send(new GetUserCountQuery(spec));
        var paginationResult = new Pagination<UserResponse>(spec.PageSize, spec.PageIndex, UsertCount.Data, result.Data);
        return Result.Success(paginationResult);
    }
}