namespace FoodApp.Api.VerticalSlicing.Features.Discounts.ViewDiscount;

public class ViewDiscountEndPoint : BaseController
{
    public ViewDiscountEndPoint(ControllerParameters controllerParameters) : base(controllerParameters) { }

    [Authorize(Roles = "Admin,Manager")]
    [HttpGet("Discount/ViewDiscount/{id}")]
    public async Task<Result<DiscountResponse>> GetDiscountById(int id)
    {
        var result = await _mediator.Send(new GetDiscountByIdQuery(id));
        if (!result.IsSuccess)
        {
            return Result.Failure<DiscountResponse>(result.Error);
        }
        var discount = result.Data.Map<DiscountResponse>();
        return Result.Success(discount);
    }
}
