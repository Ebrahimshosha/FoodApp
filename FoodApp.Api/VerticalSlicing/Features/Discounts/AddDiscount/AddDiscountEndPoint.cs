namespace FoodApp.Api.VerticalSlicing.Features.Discounts.AddDiscount;

public class AddDiscountEndPoint : BaseController
{
    public AddDiscountEndPoint(ControllerParameters controllerParameters) : base(controllerParameters) { }

    [Authorize(Roles = "Admin,Manager")]
    [HttpPost("Discount/AddDiscount")]
    public async Task<Result<bool>> AddDiscount(AddDiscountRequest request)
    {
        var command = request.Map<AddDiscountCommand>();
        var result = await _mediator.Send(command);
        return result;
    }
}