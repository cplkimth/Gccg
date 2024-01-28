
#region using
using Chinook.Data;
using Microsoft.AspNetCore.Mvc;
#endregion

namespace Chinook.Web.Controllers;


public partial class AlbumController
{
    [HttpPost("initialize")]
    public virtual async Task<int> InitializeAsync()
    {
        var procedures = new ChinookContextProcedures(DbContextFactory.Create());
        OutputParameter<int> output = new();
        await procedures.InitializeAsync(output);
        return output.Value;
    }
}

