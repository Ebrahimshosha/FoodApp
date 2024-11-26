namespace FoodApp.Api.VerticalSlicing.Features.Discounts.ApplyDiscount.Queries;

public record IsDiscountAppliedOnRecipeQuery(int RecipeId, int DiscountId) : IRequest<Result<bool>>;

public class IsDiscountAppliedOnRecipeQueryHandler : BaseRequestHandler<IsDiscountAppliedOnRecipeQuery, Result<bool>>
{
    public IsDiscountAppliedOnRecipeQueryHandler(RequestParameters requestParameters) : base(requestParameters) { }

    public override async Task<Result<bool>> Handle(IsDiscountAppliedOnRecipeQuery request, CancellationToken cancellationToken)
    {

        var isDiscountAppliedOnRecipe = await _unitOfWork.Repository<RecipeDiscount>()
                                                         .GetAsync(rd => rd.DiscountId == request.DiscountId && rd.RecipeId == request.RecipeId)
                                                         .AnyAsync(rd => rd.Discount.StartDate <= DateTime.UtcNow && rd.Discount.EndDate >= DateTime.UtcNow);

        return Result.Success(isDiscountAppliedOnRecipe);
    }
}