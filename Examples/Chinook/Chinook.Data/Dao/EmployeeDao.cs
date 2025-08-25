#region using
#endregion

using Microsoft.EntityFrameworkCore;

namespace Chinook.Data;

public partial class EmployeeDao
{
    public record LoadArgs(string LastName, string FirstName, int? ReportsTo, DateTime? BirthToFrom, DateTime? BirthToTo);
    public async Task<List<Employee>> Load(string lastName, string firstName, int? reportsTo, DateTime? birthToFrom, DateTime? birthToTo)
    {
        await using var context = DbContextFactory.Create();

        var query = from x in context.Employees
                    select x;

        if (lastName != null)
            query = query.Where(x => x.LastName.Contains(lastName));

        if (firstName != null)
            query = query.Where(x => x.FirstName.Contains(firstName));

        if (reportsTo != null)
            query = query.Where(x => x.ReportsTo == reportsTo);

        if (birthToFrom != null)
            query = query.Where(x => x.BirthDate >= birthToFrom);

        if (birthToTo != null)
            query = query.Where(x => x.BirthDate <= birthToTo);

        return query.ToList();
    }
    
    public record GetCountByNameArgs(string Name);
    public async Task<int> GetCountByName(string name)
    {
        await using var context = DbContextFactory.Create();

        var query = from x in context.Employees
                    select x;

        if (name != null)
            query = query.Where(x => x.FirstName.Contains(name) || x.LastName.Contains(name));

        return query.Count();
    }
}