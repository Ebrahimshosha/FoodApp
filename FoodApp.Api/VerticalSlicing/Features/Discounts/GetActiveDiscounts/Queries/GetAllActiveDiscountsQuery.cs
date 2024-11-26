namespace FoodApp.Api.VerticalSlicing.Features.Discounts.GetActiveDiscounts.Queries;

public record GetAllActiveDiscountsQuery() : IRequest<Result<IEnumerable<ActiveDiscountsResponse>>>;

public class GetAllActiveDiscountsQueryHandler : BaseRequestHandler<GetAllActiveDiscountsQuery, Result<IEnumerable<ActiveDiscountsResponse>>>
{
    public GetAllActiveDiscountsQueryHandler(RequestParameters requestParameters) : base(requestParameters) { }

    public async override Task<Result<IEnumerable<ActiveDiscountsResponse>>> Handle(GetAllActiveDiscountsQuery request, CancellationToken cancellationToken)
    {
        var discountRepo = _unitOfWork.Repository<Discount>();
        var allDiscounts = await discountRepo.GetAllAsync();

        var activeDiscounts = allDiscounts.Where(d => d.IsActive)
                                          .ToList();

        var mappedDiscount = activeDiscounts.Map<IEnumerable<ActiveDiscountsResponse>>();

        return Result.Success(mappedDiscount);
    }
}
