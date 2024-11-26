namespace FoodApp.Api.VerticalSlicing.Data.Repository.Specification.RecipeSpec;

public class RecipeRatingSpecification : BaseSpecification<Recipe>
{
    public RecipeRatingSpecification(bool topRated, int NumberOfRecipes) : base()
    {
        Includes.Add(r => r.Include(r => r.RecipeRatings));

        if (topRated)
        {
            AddOrderByDesc(r => r.RecipeRatings.Max(rr => rr.Rating));
        }
        else
        {
            AddOrderBy(r => r.RecipeRatings.Min(rr => rr.Rating));
        }
        ApplyPagination(0, NumberOfRecipes);
    }
}
