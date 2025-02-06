using Constants;

public class User
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public Enums.UserRole Role { get; set; }
    public User () {}
   
}