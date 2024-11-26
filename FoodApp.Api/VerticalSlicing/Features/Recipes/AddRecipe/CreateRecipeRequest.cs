namespace FoodApp.Api.VerticalSlicing.Features.Recipes.AddRecipe;

public class CreateRecipeRequest
{
    public string Name { get; set; } = null!;
    public IFormFile ImageUrl { get; set; } = null!;
    public string Description { get; set; } = null!;
    public  decimal Price { get; set; }
    public int CategoryId { get; set; }
}
