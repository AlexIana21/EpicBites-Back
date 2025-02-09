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
        [Description("Vegetables")]
        Vegetables,
        [Description("Fruits")]
        Fruits,
        [Description("Meat")]
        Meat,
        [Description("Fish")]
        Fish,
        [Description("Dairy")]
        Dairy,
        [Description("Grains")]
        Grains,
        [Description("Legumes")]
        Legumes,
        [Description("Nuts")]
        Nuts,
        [Description("Seeds")]
        Seeds,
        [Description("Herbs")]
        Herbs,
        [Description("Spices")]
        Spices,
        [Description("Oils")]
        Oils,
        [Description("Condiments")]
        Condiments,
        [Description("Sweets")]
        Sweets,
        [Description("Beverages")]
        Beverages
    }

    public enum Unit {
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
