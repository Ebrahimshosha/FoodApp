namespace FoodApp.Api.VerticalSlicing.Features.Categories.ViewCategory;

public record ViewCategoryResponse(int Id,
                                    string Name,
                                    List<RecipesNamesToReturnDto> Recipes);
