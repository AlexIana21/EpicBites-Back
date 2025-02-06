using System.ComponentModel;

namespace Constants;

public static class Enums {
    public enum UserRole { 
        [Description("Admin")]
        Admin, 
        [Description("User")]
        User 
    }

    public enum Meal{
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

    public enum Diet{
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

     public enum Flavour{
        [Description("Sweet")]
        Sweet,
        [Description("Spicy")]
        Spicy,
        [Description("Sour")]
        Sour,
        [Description("Bitter")]
        Bitter
    }

     public enum Difficulty{
        [Description("Easy")]
        Easy,
        [Description("Medium")]
        Medium,
        [Description("Hard")]
        Hard
    }





    
    
}


//string description = Enumerations.GetEnumDescription((user)User.Admin);
                                                                                                 