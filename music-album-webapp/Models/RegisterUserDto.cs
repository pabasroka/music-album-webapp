namespace music_album_webapp.Models;

public class RegisterUserDto
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }    
    public int RoleId { get; set; } = 1;
    public int DistributionId { get; set; } = 1;
}