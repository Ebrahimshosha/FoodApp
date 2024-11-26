namespace FoodApp.Api.VerticalSlicing.Features.Discounts.GetActiveDiscounts
{

    public record ActiveDiscountsResponse
        (int Id, 
        decimal DiscountPercent, 
        DateTime StartDate, DateTime EndDate,
        DateTime DateCreated);

}
