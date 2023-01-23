using EduHome.Core.Entities.Identity;
using EduHome.Core.Enums;
using EduHome.DataAccess.Exceptions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EduHome.DataAccess.Contexts;

public class AppDbContextInitializer
{
    private readonly UserManager<AppUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly AppDbContext _context;
    private readonly IConfiguration _configuration;

    public AppDbContextInitializer(UserManager<AppUser> userManager,
        RoleManager<IdentityRole> roleManager,
        AppDbContext context,
        IConfiguration configuration)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _context = context;
        _configuration = configuration;
    }

    public async Task InitializeAsync()
    {
        await _context.Database.MigrateAsync();
    }
    public async Task RoleSeedAsync()
    {
        foreach (var role in Enum.GetValues(typeof(Roles)))
        {
            if (!await _roleManager.RoleExistsAsync(role.ToString()))
            {
                await _roleManager.CreateAsync(new IdentityRole(role.ToString()));
            }
        }
    }

    public async Task UserSeedAsync()
    {
        AppUser user = new AppUser
        {
            UserName = _configuration["AdminSettings:Name"],
            Email = _configuration["AdminSettings:Email"]
        };


        await _userManager.CreateAsync(user, _configuration["AdminSettings:Password"]);

        var identityResult = await _userManager.AddToRoleAsync(user, Roles.Admin.ToString());
        if (!identityResult.Succeeded)
        {
            int count = 0;
            string msg = string.Empty;
            foreach (var error in identityResult.Errors)
            {
                msg += count == 0 ? $"{error}" : $",{error}";
                count++;
            }
            throw new AdminCreateException(msg);
        }
    }



}
