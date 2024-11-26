namespace FoodApp.Api.VerticalSlicing.Features.Categories.AddCategory;

public class MapperProfile :Profile
{
    public MapperProfile()
    {
        CreateMap<AddCategoryRequest, CreateCategoryCommand>();
        CreateMap<CreateCategoryCommand, Category>();
    }
}