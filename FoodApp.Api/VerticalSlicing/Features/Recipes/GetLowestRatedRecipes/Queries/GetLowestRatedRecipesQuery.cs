namespace FoodApp.Api.VerticalSlicing.Features.Recipes.GetLowestRatedRecipes.Queries;

public record GetLowestRatedRecipesQuery(int NumberOfRecipes) : IRequest<Result<IEnumerable<LowestRatedRecipesResponse>>>;

public class GetLowestRatedRecipesQueryHandler : BaseRequestHandler<GetLowestRatedRecipesQuery, Result<IEnumerable<LowestRatedRecipesResponse>>>
{
    public GetLowestRatedRecipesQueryHandler(RequestParameters requestParameters) : base(requestParameters) { }

    public async override Task<Result<IEnumerable<LowestRatedRecipesResponse>>> Handle(GetLowestRatedRecipesQuery request, CancellationToken cancellationToken)
    {

        var spec = new RecipeRatingSpecification(false, request.NumberOfRecipes);
        var LowestRatedRecipes = await _unitOfWork.Repository<Recipe>().GetAllWithSpecAsync(spec);

        var mappedRecipes = LowestRatedRecipes.Map<IEnumerable<LowestRatedRecipesResponse>>();

        return Result.Success(mappedRecipes);
    }
}