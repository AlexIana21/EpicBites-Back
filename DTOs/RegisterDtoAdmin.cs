using Constants;
public class RegisterDtoAdmin {
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public Enums.UserRole Role { get; set; } = Enums.UserRole.User;
    public RegisterDtoAdmin() { }
}