using System.ComponentModel;

namespace Constants;

public static class Enums
{
    public enum UserRole
    {
        [Description("Admin")]
        Admin,
        [Description("User")]
        User
    }
    public enum Meal
    {
        [Description("Breakfast")]
        Breakfast,
        [Description("MorningSnack")]
        MorningSnack,
        [Description("Lunch")]
        Lunch,
        [Description("AfternoonSnack")]
        AfternoonSnack,
        [Description("Dinner")]
        Dinner
    }
    public enum Diet
    {
        [Description("Vegetarian")]
        Vegetarian,
        [Description("GlutenFree")]
        GlutenFree,
        [Description("Vegan")]
        Vegan,
        [Description("LactoseFree")]
        LactoseFree,
        [Description("Protein")]
        Protein,
        [Description("Omnivore")]
        Omnivore,
        [Description("Mediterranean")]
        Mediterranean
    }
    public enum Flavour
    {
        [Description("Sweet")]
        Sweet,
        [Description("Spicy")]
        Spicy,
        [Description("Sour")]
        Sour,
        [Description("Bitter")]
        Bitter
    }
    public enum Difficulty
    {
        [Description("Easy")]
        Easy,
        [Description("Medium")]
        Medium,
        [Description("Hard")]
        Hard
    }
    public enum Category
    {
        [Description("Vegetable")]
        Vegetable,
        [Description("Fruit")]
        Fruit,
        [Description("Dairy")]
        Dairy,
        [Description("Meat")]
        Meat,
        [Description("Fish")]
        Fish,
        [Description("Grain")]
        Grain,
        [Description("Nut")]
        Nut,
        [Description("Legume")]
        Legumes,
        [Description("Spice")]
        Spice,
        [Description("Herb")]
        Herb,
        [Description("Oil")]
        Oil,
        [Description("Sweetener")]
        Sweetener,
        [Description("Beverage")]
        Beverage,
        [Description("Condiment")]
        Condiment,
        [Description("Other")]
        Other,
    }

    public enum Unit
    {
        [Description("g")]
        g,
        [Description("ml")]
        ml,
        [Description("l")]
        l,
        [Description("tsp")]
        tsp,
        [Description("tbsp")]
        tbsp,
        [Description("cup")]
        cup,
        [Description("piece")]
        piece
    }
}

//string description = Enumerations.GetEnumDescription((user)User.Admin);
