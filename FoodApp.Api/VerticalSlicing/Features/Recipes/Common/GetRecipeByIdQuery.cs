namespace FoodApp.Api.VerticalSlicing.Features.Recipes.Common;

public record GetRecipeByIdQuery(int RecipeId) : IRequest<Result<Recipe>>;

public class GetRecipeByIdQueryHandler : BaseRequestHandler<GetRecipeByIdQuery, Result<Recipe>>
{
    public GetRecipeByIdQueryHandler(RequestParameters requestParameters) : base(requestParameters) { }

    public override async Task<Result<Recipe>> Handle(GetRecipeByIdQuery request, CancellationToken cancellationToken)
    {
        var spec = new RecipeSpecification(request.RecipeId);
        var recipe = await _unitOfWork.Repository<Recipe>().GetByIdWithSpecAsync(spec);
        if (recipe == null)
        {
            return Result.Failure<Recipe>(RecipeErrors.RecipeNotFound);
        }

        return Result.Success(recipe);
    }
}