
#region using
using Chinook.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
#endregion

namespace Chinook.Web.Controllers;


public partial class AlbumController
{
    [HttpGet("count2")]
    [Authorize]
    public virtual async Task<string> GetCount2()
    {
        var role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;

        return await Task.FromResult($"{role} <- {DateTime.Now:s}");
    }
}

