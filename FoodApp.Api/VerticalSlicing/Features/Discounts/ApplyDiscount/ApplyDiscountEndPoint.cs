namespace FoodApp.Api.VerticalSlicing.Features.Discounts.ApplyDiscount;

public class ApplyDiscountEndPoint : BaseController
{
    public ApplyDiscountEndPoint(ControllerParameters controllerParameters) : base(controllerParameters) { }

    [Authorize(Roles = "Admin,Manager")]
    [HttpPost("Discount/ApplyDiscount")]
    public async Task<Result<decimal>> ApplyDiscount(ApplyDiscountRequest request)
    {
        var command = request.Map<ApplyDiscountCommand>();
        var result = await _mediator.Send(command);
        return result;
    }
}