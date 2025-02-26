using System.IdentityModel.Tokens.Jwt;
using ConstructorGenerator.Attributes;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using STPServer.Authentication;
using STPServer.Models;
using STPServer.Services;

namespace STPServer.Controllers;

[ApiController]
[Route("api/[controller]")]
[GenerateFullConstructor]
public partial class AuthenticateController : ControllerBase
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IConfiguration _configuration;
    private readonly AuthenticationService _authenticationService;

    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login([FromBody] LoginModel model)
    {
        AuthenticationResult authenticationResult = await _authenticationService.Login(model);
        if (!authenticationResult.Success)
            return Unauthorized();
        
        return Ok(new
        {
            token = new JwtSecurityTokenHandler().WriteToken(authenticationResult.Token),
            expiration = authenticationResult.Token.ValidTo
        });
    }

    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> Register([FromBody] RegisterModel model)
    {
        RegisterResult result = await _authenticationService.RegisterAccount(model.Username, model.Email, model.Password, UserRoles.User);
        if (!result.Success)
            return BadRequest();
        return Ok();
    }

    [HttpPost]
    [Route("register-admin")]
    public async Task<IActionResult> RegisterAdmin([FromBody] RegisterModel model)
    {
        if(_configuration["AllowAdminRegistration"] != "true")
            return StatusCode(418);
        RegisterResult result = await _authenticationService.RegisterAccount(model.Username, model.Email, model.Password, UserRoles.Admin);
        if (!result.Success)
            return BadRequest();
        return Ok();
    }
}