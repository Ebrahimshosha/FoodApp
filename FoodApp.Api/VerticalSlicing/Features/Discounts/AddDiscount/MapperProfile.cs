namespace FoodApp.Api.VerticalSlicing.Features.Discounts.AddDiscount;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<AddDiscountCommand, Discount>();
        CreateMap<AddDiscountRequest, AddDiscountCommand>();
    }
}