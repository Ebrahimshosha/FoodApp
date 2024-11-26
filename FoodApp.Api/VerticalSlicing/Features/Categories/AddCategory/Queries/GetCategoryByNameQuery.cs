namespace FoodApp.Api.VerticalSlicing.Features.Categories.AddCategory.Queries;

public record GetCategoryByNameQuery(string Name) : IRequest<Result<Category>>;
public class GetCategoryByNameQueryHandler : BaseRequestHandler<GetCategoryByNameQuery, Result<Category>>
{
    public GetCategoryByNameQueryHandler(RequestParameters requestParameters) : base(requestParameters) { }

    public override async Task<Result<Category>> Handle(GetCategoryByNameQuery request, CancellationToken cancellationToken)
    {
        var category = await _unitOfWork.Repository<Category>().GetAsync(c => c.Name == request.Name).FirstOrDefaultAsync();
        if (category == null)
        {
            return Result.Failure<Category>(CategoryErrors.CategoryNotFound);
        }

        return Result.Success(category);
    }
}