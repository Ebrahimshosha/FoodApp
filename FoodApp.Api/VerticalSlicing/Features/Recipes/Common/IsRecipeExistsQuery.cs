namespace FoodApp.Api.VerticalSlicing.Features.Recipes.Common;

public record IsRecipeExistsQuery(string RecipeName) : IRequest<Result<bool>>;

public class IsRecipeExistsQueryHandler : BaseRequestHandler<IsRecipeExistsQuery, Result<bool>>
{
    public IsRecipeExistsQueryHandler(RequestParameters requestParameters) : base(requestParameters) { }

    public override async Task<Result<bool>> Handle(IsRecipeExistsQuery request, CancellationToken cancellationToken)
    {
        var isExist = await _unitOfWork.Repository<Recipe>().AnyAsync(r => r.Name.ToLower() == request.RecipeName.ToLower());
        if (!isExist)
        {
            return Result.Failure<bool>(RecipeErrors.RecipeNotFound);
        }

        return Result.Success(true);
    }
}