using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using music_album_webapp.Entities;
using music_album_webapp.Models;

namespace music_album_webapp.Services;

public interface IUserService
{
    void RegisterUser(RegisterUserDto dto);
    string GenerateJwtToken(LoginDto dto);
}

public class UserService : IUserService
{
    private readonly DataContext _dataContext;
    private readonly IPasswordHasher<User> _passwordHasher;
    private readonly AuthenticationSettings _authenticationSettings;

    public UserService(DataContext dataContext, IPasswordHasher<User> passwordHasher, AuthenticationSettings authenticationSettings)
    {
        _dataContext = dataContext;
        _passwordHasher = passwordHasher;
        _authenticationSettings = authenticationSettings;
    }
    
    public void RegisterUser(RegisterUserDto dto)
    {
        var newUser = new User()
        {
            Email = dto.Email,
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            RoleId = dto.RoleId,
            DistributionId = dto.DistributionId,
        };

        var hashedPassword = _passwordHasher.HashPassword(newUser, dto.Password);

        newUser.PasswordHash = hashedPassword;
        _dataContext.Users.Add(newUser);
        _dataContext.SaveChanges();
    }

    public string GenerateJwtToken(LoginDto dto)
    {
        var user = _dataContext.Users
            .Include(u => u.Role)
            .Include(u => u.Distribution)
            .FirstOrDefault(u => u.Email == dto.Email);

        if (user is null)
        {
            throw new Exception("Invalid username or password");
        }

        var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, dto.Password);
        if (result == PasswordVerificationResult.Failed)
        {
            throw new Exception("Invalid username or password");
        }

        var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
            new Claim(ClaimTypes.Role, user.Role.Name),
            new Claim("DistributionId", user.DistributionId.ToString()),
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSettings.JwtKey));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var expires = DateTime.Now.AddDays(_authenticationSettings.JwtExpireDays);

        var token = new JwtSecurityToken(
            _authenticationSettings.JwtIssuer,
            _authenticationSettings.JwtIssuer,
            claims,
            expires: expires,
            signingCredentials: credentials
        );

        var tokenHandler = new JwtSecurityTokenHandler();
        return tokenHandler.WriteToken(token);
    }
}