namespace FoodApp.Api.VerticalSlicing.Features.Discounts.ViewDiscount;

public record DiscountResponse
        (int Id,
         decimal DiscountPercent,
         DateTime StartDate, 
         DateTime EndDate,
         DateTime DateCreated);