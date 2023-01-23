using EduHome.Business.DTOs.Auth;
using EduHome.Business.Exceptions;
using EduHome.Business.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EduHomeAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly IAuthService _authService;

    public AccountController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Register(RegisterDto registerDto)
    {
        try
        {
            await _authService.RegisterAsync(registerDto);
            return Ok();
        }
        catch (UserCreateFailedException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (AddRoleFailedException)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError);
        }
        catch (Exception)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError);
        }
    }


}
