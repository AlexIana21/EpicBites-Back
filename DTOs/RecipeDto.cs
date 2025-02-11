using Constants;

public class RecipeDto
{

    public string Name { get; set; }
    public string Description { get; set; }
    public Enums.Meal Meal { get; set; }
    public Enums.Diet Diet { get; set; }
    public Enums.Flavour Flavour { get; set; }
    public int Time { get; set; }
    public int Calories { get; set; }
    public  Enums.Difficulty Difficulty { get; set; }
    public string Image { get; set; }

    public RecipeDto () {}
   
}
