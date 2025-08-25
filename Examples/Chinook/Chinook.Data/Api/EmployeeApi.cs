#region using
#endregion

#region
using System.Net.Http.Json;
using System.Text.Json;
using Chinook.Data.Utilities;
#endregion

namespace Chinook.Data;

public partial class EmployeeApi
{
    public virtual async Task<List<Employee>> Load(string lastName, string firstName, int? reportsTo, DateTime? birthToFrom, DateTime? birthToTo)
    {
        var json = JsonSerializer.Serialize(new EmployeeDao.LoadArgs(lastName, firstName, reportsTo, birthToFrom, birthToTo), JsonHelper.DefaultOptions);

        using var http = CreateHttpClient();
        var address = GetAddress(nameof(Load), json);
        return await http.GetFromJsonAsync<List<Employee>>(address);
    }

    public virtual async Task<int> GetCountByName(string name)
    {
        var json = JsonSerializer.Serialize(new EmployeeDao.GetCountByNameArgs(name), JsonHelper.DefaultOptions);

        using var http = CreateHttpClient();
        var address = GetAddress(nameof(GetCountByName), json);
        return await http.GetFromJsonAsync<int>(address);
    }
}