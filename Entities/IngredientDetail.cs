using Constants;

public class IngredientDetail {
    public int Id { get; set; }
    public int RecipeId { get; set; }
    public int IngredientId { get; set; }
    public double Quantity { get; set; }
    public Enums.Unit Unit { get; set; }
}