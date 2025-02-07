using Constants;
public class Ingredient
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Enums.Category Category { get; set; }
    public int Calories { get; set; }
    public int Allergen { get; set; }
    public string Image { get; set; }
    public Ingredient() { }

}