namespace FoodApp.Api.VerticalSlicing.Features.Discounts.GetActiveDiscounts;

public class GetActiveDiscountsEndPoint : BaseController
{
    public GetActiveDiscountsEndPoint(ControllerParameters controllerParameters) : base(controllerParameters) { }

    [HttpGet("Discount/GetActiveDiscounts")]
    public async Task<Result<IEnumerable<ActiveDiscountsResponse>>> GetAllActiveDiscounts()
    {
        var result = await _mediator.Send(new GetAllActiveDiscountsQuery());
        return result;
    }
}