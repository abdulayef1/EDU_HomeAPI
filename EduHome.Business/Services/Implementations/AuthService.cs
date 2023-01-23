using EduHome.Business.DTOs.Auth;
using EduHome.Business.Exceptions;
using EduHome.Business.Services.Interfaces;
using EduHome.Core.Entities.Identity;
using EduHome.Core.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace EduHome.Business.Services.Implementations;

public class AuthService : IAuthService
{

    private readonly UserManager<AppUser> _userManager;
    private readonly IConfiguration _configuration;
    public AuthService(UserManager<AppUser> userManager,
       IConfiguration configuration)
    {
        _userManager = userManager;
        _configuration = configuration; 
    }

    public async Task RegisterAsync(RegisterDto registerDto)
    {

        AppUser user = new AppUser
        {
            UserName = registerDto.UserName,
            Email = registerDto.Email,
        };

        var identityResult = await _userManager.CreateAsync(user, registerDto.Password);

        if (!identityResult.Succeeded)
        {
            int count = 0;
            string msg = string.Empty;
            foreach (var error in identityResult.Errors)
            {
                msg += count == 0 ? $"{error}" : $",{error}";
                count++;
            }
            throw new UserCreateFailedException(msg);
        }

        var result = await _userManager.AddToRoleAsync(user, Roles.Member.ToString());

        if (!result.Succeeded)
        {
            int count = 0;
            string msg = string.Empty;
            foreach (var error in result.Errors)
            {
                msg += count == 0 ? $"{error}" : $",{error}";
                count++;
            }
            throw new AddRoleFailedException(msg);
        }

    }


    public async Task Login(LoginDto loginDto)
    {
        var user = await _userManager.FindByNameAsync(loginDto.UserName);
        if (user is null) throw new NotFoundException("Valid username or password");

        var result = await _userManager.CheckPasswordAsync(user, loginDto.Password);
        if (!result) throw new NotFoundException("Valid username or password");

        var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);


    }

}
