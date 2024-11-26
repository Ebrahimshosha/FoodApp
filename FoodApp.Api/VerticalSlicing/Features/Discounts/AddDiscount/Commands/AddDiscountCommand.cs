namespace FoodApp.Api.VerticalSlicing.Features.Discounts.AddDiscount.Commands;

public record AddDiscountCommand(decimal DiscountPercent, DateTime StartDate, DateTime EndDate) : IRequest<Result<bool>>;

public class AddDiscountCommandHandler : BaseRequestHandler<AddDiscountCommand, Result<bool>>
{
    public AddDiscountCommandHandler(RequestParameters requestParameters) : base(requestParameters) { }

    public async override Task<Result<bool>> Handle(AddDiscountCommand request, CancellationToken cancellationToken)
    {
        if (request.DiscountPercent <= 0 || request.DiscountPercent > 100)
        {
            return Result.Failure<bool>(DiscountErrors.DiscountPercentageNotValid);
        }

        if (request.EndDate <= request.StartDate)
        {
            return Result.Failure<bool>(DiscountErrors.DatesNotValid);
        }

        var discount = request.Map<Discount>();

        var discountRepo = _unitOfWork.Repository<Discount>();
        await discountRepo.AddAsync(discount);
        await discountRepo.SaveChangesAsync();

        return Result.Success(true);
    }
}