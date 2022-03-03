using music_album_webapp.Models;

namespace music_album_webapp.Services;

public interface IUserService
{
    void RegisterUser(RegisterUserDto dto);
    string GenerateJwtToken(LoginDto dto);
}

public class UserService : IUserService
{
    public void RegisterUser(RegisterUserDto dto)
    {
        throw new NotImplementedException();
    }

    public string GenerateJwtToken(LoginDto dto)
    {
        throw new NotImplementedException();
    }
}