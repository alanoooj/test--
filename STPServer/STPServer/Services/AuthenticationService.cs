using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ConstructorGenerator.Attributes;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using STPServer.Authentication;
using STPServer.Models;

namespace STPServer.Services;

[GenerateFullConstructor]
public partial class AuthenticationService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IConfiguration _configuration;
    
    public async Task<AuthenticationResult> Login(LoginModel model)
    {
        ApplicationUser? user = await _userManager.FindByNameAsync(model.Username);
        if (user == null || !await _userManager.CheckPasswordAsync(user, model.Password)) 
            return AuthenticationResult.Failed;
        IList<string> userRoles = await _userManager.GetRolesAsync(user);

        List<Claim> authClaims =
        [
            new Claim(ClaimTypes.Name, user.UserName ?? user.Email ?? user.Id),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        ];

        foreach (string userRole in userRoles)
        {
            authClaims.Add(new Claim(ClaimTypes.Role, userRole));
        }

        SymmetricSecurityKey authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

        JwtSecurityToken token = new JwtSecurityToken(
            issuer: _configuration["JWT:ValidIssuer"],
            audience: _configuration["JWT:ValidAudience"],
            expires: DateTime.Now.AddHours(3),
            claims: authClaims,
            signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
        );
        return AuthenticationResult.Successful(token);
    }

    public async Task<RegisterResult> RegisterAccount(string username, string email, string password, UserRoles role)
    {
        if (!await _roleManager.RoleExistsAsync(UserRoles.Admin.ToString()))
            await _roleManager.CreateAsync(new IdentityRole(UserRoles.Admin.ToString()));
        if (!await _roleManager.RoleExistsAsync(UserRoles.User.ToString()))
            await _roleManager.CreateAsync(new IdentityRole(UserRoles.User.ToString()));

        if (await _userManager.FindByNameAsync(username) != null)
            return RegisterResult.Failed;
        
        ApplicationUser user = new ApplicationUser()
        {
            Email = email,
            SecurityStamp = Guid.NewGuid().ToString(),
            UserName = username
        };
        
        IdentityResult result = await _userManager.CreateAsync(user, password);
        if (!result.Succeeded)
            return RegisterResult.Failed;
        
        await _userManager.AddToRoleAsync(user, role.ToString());
        
        return RegisterResult.Successful;
    }
}

[GenerateFullConstructor]
public partial class RegisterResult
{
    public bool Success { get; }
    
    public static RegisterResult Failed { get; } = new RegisterResult(false);
    public static RegisterResult Successful { get; } = new RegisterResult(true);
}

[GenerateFullConstructor]
public partial class AuthenticationResult
{
    public bool Success { get; }
    public JwtSecurityToken Token { get; }

    public static AuthenticationResult Failed => new AuthenticationResult(false, null);
    public static AuthenticationResult Successful(JwtSecurityToken token) => new AuthenticationResult(true, token);
}