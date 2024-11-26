namespace FoodApp.Api.VerticalSlicing.Features.Discounts.DeactivateDiscount;

public class DeactivateDiscountEndPoint : BaseController
{
    public DeactivateDiscountEndPoint(ControllerParameters controllerParameters) : base(controllerParameters) { }

    [Authorize(Roles = "Admin,Manager")]
    [HttpPost("Discount/DeactivateDiscount/{id}")]
    public async Task<Result<bool>> DeactivateDiscount(int id)
    {
        var result = await _mediator.Send(new DeactivateDiscountCommand(id));
        return result;
    }
}