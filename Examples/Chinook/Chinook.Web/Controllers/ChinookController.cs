using Chinook.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Chinook.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ChinookController : ControllerBase
{
    [HttpPost]
    public async Task<int> Initialize()
    {
        var procedures = new ChinookContextProcedures(DbContextFactory.Create());
        return await procedures.usp_InitializeAsync();
    }
}
