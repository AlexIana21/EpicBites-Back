using System.ComponentModel;

namespace Constants;

public static class Enums {
    public enum UserRole { 
        [Description("Admin")]
        Admin, 
        [Description("User")]
        User 
        }
    
    
}


//string description = Enumerations.GetEnumDescription((user)User.Admin);