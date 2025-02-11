using Constants;
public class UserDto
{
    public string Username { get; set; }
    public string Email { get; set; }
    public Enums.UserRole Role { get; set; }
    public UserDto() { }

}