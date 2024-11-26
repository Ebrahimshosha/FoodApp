namespace FoodApp.Api.VerticalSlicing.Data.Entities;

public class RecipeDiscount : BaseEntity
{
    public int RecipeId { get; set; }
    public Recipe Recipe { get; set; } = null!;
    public int DiscountId { get; set; }
    public Discount Discount { get; set; } = null!;
}