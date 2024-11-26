namespace FoodApp.Api.VerticalSlicing.Features.Recipes.GetTopRatedRecipes.Queries;

public record GetTopRatedRecipesQuery(int NumberOfRecipes) : IRequest<Result<IEnumerable<TopRatedRecipesResponse>>>;

public class GetTopRatedRecipesQueryHandler : BaseRequestHandler<GetTopRatedRecipesQuery, Result<IEnumerable<TopRatedRecipesResponse>>>
{
    public GetTopRatedRecipesQueryHandler(RequestParameters requestParameters) : base(requestParameters) { }

    public async override Task<Result<IEnumerable<TopRatedRecipesResponse>>> Handle(GetTopRatedRecipesQuery request, CancellationToken cancellationToken)
    {
        var spec = new RecipeRatingSpecification(true,request.NumberOfRecipes);
        var topRatedRecipes = await _unitOfWork.Repository<Recipe>().GetAllWithSpecAsync(spec);

        var mappedRecipes = topRatedRecipes.Map<IEnumerable<TopRatedRecipesResponse>>();

        return Result.Success(mappedRecipes);
    }
}