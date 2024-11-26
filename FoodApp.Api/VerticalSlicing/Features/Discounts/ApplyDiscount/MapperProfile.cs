namespace FoodApp.Api.VerticalSlicing.Features.Discounts.ApplyDiscount;

public class MapperProfile:Profile
{
    public MapperProfile()
    {
        CreateMap<ApplyDiscountRequest, ApplyDiscountCommand>();
    }
}