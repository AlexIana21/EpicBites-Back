using Constants;
public class IngredientDto
{
    public string Name { get; set; }
    public Enums.Category Category { get; set; }
    public int Calories { get; set; }
    public string Allergen { get; set; }
    public string Image { get; set; }
    public IngredientDto() { }

}