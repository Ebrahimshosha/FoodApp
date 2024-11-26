namespace FoodApp.Api.VerticalSlicing.Features.Discounts.UpdateDiscount;

public class UpdateDiscountEndPoint : BaseController
{
    public UpdateDiscountEndPoint(ControllerParameters controllerParameters) : base(controllerParameters) { }

    [Authorize(Roles = "Admin,Manager")]
    [HttpPut("Discount/UpdateDiscount/{id}")]
    public async Task<Result<bool>> UpdateDiscount(int id, UpdateDiscountRequest request)
    {
        var command = new UpdateDiscountCommand(id, request.DiscountPercent, request.StartDate, request.EndDate);
        var result = await _mediator.Send(command);
        return result;
    }
}