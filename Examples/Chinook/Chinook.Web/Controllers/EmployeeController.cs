#region
using System.Text.Json;
using Chinook.Data;
using Microsoft.AspNetCore.Mvc;
#endregion

namespace Chinook.Web.Controllers;

public partial class EmployeeController
{
    [HttpGet($"{nameof(Load)}/{{json}}")]
    public virtual async Task<List<Employee>> Load(string json)
    {
        var args = JsonSerializer.Deserialize<EmployeeDao.LoadArgs>(json);
        return await Dao.Employee.Load(args.LastName, args.FirstName, args.ReportsTo, args.BirthToFrom, args.BirthToTo);
    }

    [HttpGet($"{nameof(GetCountByName)}/{{json}}")]
    public virtual async Task<int> GetCountByName(string json)
    {
        var args = JsonSerializer.Deserialize<EmployeeDao.GetCountByNameArgs>(json);
        return await Dao.Employee.GetCountByName(args.Name);
    }
}