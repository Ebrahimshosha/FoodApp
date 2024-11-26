namespace FoodApp.Api.VerticalSlicing.Features.Discounts.ApplyDiscount.Commands;

public record ApplyDiscountCommand(int RecipeId, int DiscountId) : IRequest<Result<decimal>>;

public class ApplyDiscountCommandHandler : BaseRequestHandler<ApplyDiscountCommand, Result<decimal>>
{
    public ApplyDiscountCommandHandler(RequestParameters requestParameters) : base(requestParameters) { }

    public async override Task<Result<decimal>> Handle(ApplyDiscountCommand request, CancellationToken cancellationToken)
    {
        var recipeResult = await _mediator.Send(new GetRecipeByIdQuery(request.RecipeId));
        if (!recipeResult.IsSuccess)
        {
            return Result.Failure<decimal>(RecipeErrors.RecipeNotFound);
        }
        var recipe = recipeResult.Data;

        var discountResult = await _mediator.Send(new GetDiscountByIdQuery(request.DiscountId));
        if (!discountResult.IsSuccess)
        {
            return Result.Failure<decimal>(DiscountErrors.DiscountNotFound);
        }
        var discount = discountResult.Data;

        var isApplied = await _mediator.Send(new IsDiscountAppliedOnRecipeQuery(request.RecipeId, request.DiscountId));
        if (isApplied.Data)
        {
            return Result.Failure<decimal>(DiscountErrors.ActiveDiscountAlreadyExists);
        }

        var recipeDiscount = new RecipeDiscount { RecipeId = recipe.Id, DiscountId = discount.Id };

        await _unitOfWork.Repository<RecipeDiscount>().AddAsync(recipeDiscount);
        await _unitOfWork.SaveChangesAsync();

        var discountedPrice = recipe.Price - recipe.Price * (discount.DiscountPercent / 100);

        return Result.Success(discountedPrice);
    }
}