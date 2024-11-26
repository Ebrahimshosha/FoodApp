namespace FoodApp.Api.VerticalSlicing.Features.Discounts.DeleteDiscount;

public class DeleteDiscountEndPoint : BaseController
{
    public DeleteDiscountEndPoint(ControllerParameters controllerParameters) : base(controllerParameters) { }

    [Authorize(Roles = "Admin,Manager")]
    [HttpDelete("Discount/DeleteDiscount/{id}")]
    public async Task<Result<bool>> DeleteDiscount(int id)
    {
        var result = await _mediator.Send(new DeleteDiscountCommand(id));
        return result;
    }
}