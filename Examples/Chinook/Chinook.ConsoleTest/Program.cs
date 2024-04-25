using System.Runtime.CompilerServices;
using Chinook.Data;
using Microsoft.EntityFrameworkCore;

namespace Chinook.ConsoleTest;

internal class Program
{
    static async Task Main(string[] args)
    {
        // Delete();
        // Order();
        Procedure();
    }

    private static void Procedure()
    {
        using var context = DbContextFactory.Create();

        // var query = context.Database.ExecuteSqlInterpolated($"usp_GetSystemTime");
        // var query = context.Database.ExecuteSqlInterpolated($"usp_GetMaxId {nameof(Album)}");
        // var query = context.Database.ExecuteSqlInterpolated($"usp_GetMaxId {nameof(Album)}");
        var query = context.Database.SqlQuery<DateTime>($"usp_GetSystemTime").AsEnumerable().FirstOrDefault();
        Console.WriteLine(query);
        var query2  = context.Database.SqlQuery<int>($"usp_GetMaxId {nameof(Album)}").AsEnumerable().FirstOrDefault();
        Console.WriteLine(query2);
    }

    private static void Order()
    {
        using var context = DbContextFactory.Create();

        var query = context.Albums
            .OrderBy(x => EF.Property<object>(x, nameof(Album.Title)))
            .ToList();

        Console.WriteLine(query);


    }

    private static void Delete()
    {
        using var context = DbContextFactory.Create();

        int result = context.Tracks.Where(x => x.TrackId == 4).ExecuteDelete();
        Console.WriteLine(result);

        // Console.WriteLine(DbContextFactory.Create().Procedures.InitializeAsync().Result);
    }
}