using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Chinook.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Chinook.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    public IConfiguration _configuration;

    public AuthController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpPost("Login")]
    [Produces("text/plain")]
    public async Task<string> Login([FromBody] LoginInfo loginInfo)
    {
        var jwtSettings = _configuration.GetSection("Jwt").Get<JwtSettings>();

        int employeeId = int.Parse(loginInfo.Username);
        var employee = await Dao.Employee.GetFirstAsync(x => x.EmployeeId == employeeId);

        if (employee == null)
            return "";

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
        {
            new(ClaimTypes.Sid, employee.EmployeeId.ToString()),
            new(ClaimTypes.Name, employee.FirstName),
            new(ClaimTypes.Role, employee.LastName),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var token = new JwtSecurityToken(
            issuer: jwtSettings.Issuer,
            audience: jwtSettings.Audience,
            claims: claims,
            expires: DateTime.Now.AddHours(24),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    [HttpGet("Identify")]
    [Authorize]
    public async Task<string> Identify()
    {
        var id = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid)?.Value;
        var name = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;
        var role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
        
        return await Task.FromResult($"{id} / {name} / {role}");
    }
}

public class JwtSettings
{
    public string Key { get; set; } = string.Empty;
    public string Issuer { get; set; } = string.Empty;
    public string Audience { get; set; } = string.Empty;
}

