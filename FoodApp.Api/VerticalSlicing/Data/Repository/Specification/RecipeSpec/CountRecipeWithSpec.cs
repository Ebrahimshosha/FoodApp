namespace FoodApp.Api.VerticalSlicing.Data.Repository.Specification.RecipeSpec;

public class CountRecipeWithSpec : BaseSpecification<Recipe>
{
    public CountRecipeWithSpec(SpecParams specParams)
        : base(p => !p.IsDeleted)
    {

    }
}