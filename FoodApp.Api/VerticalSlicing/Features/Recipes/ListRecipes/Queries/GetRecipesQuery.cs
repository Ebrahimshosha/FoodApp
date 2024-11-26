namespace FoodApp.Api.VerticalSlicing.Features.Recipes.ListRecipes.Queries;

public record GetRecipesQuery(SpecParams SpecParams) : IRequest<Result<IEnumerable<RecipeResponse>>>;

public class GetRecipesQueryHandler : BaseRequestHandler<GetRecipesQuery, Result<IEnumerable<RecipeResponse>>>
{
    public GetRecipesQueryHandler(RequestParameters requestParameters) : base(requestParameters) { }

    public override async Task<Result<IEnumerable<RecipeResponse>>> Handle(GetRecipesQuery request, CancellationToken cancellationToken)
    {
        var spec = new RecipeSpecification(request.SpecParams);
        var recipe = await _unitOfWork.Repository<Recipe>().GetAllWithSpecAsync(spec);

        if (recipe == null)
        {
            return Result.Failure<IEnumerable<RecipeResponse>>(RecipeErrors.RecipeNotFound);
        }

        var response = recipe.Map<IEnumerable<RecipeResponse>>();

        return Result.Success(response);
    }
}