using System.Runtime.CompilerServices;
using Chinook.Data;
using Microsoft.EntityFrameworkCore;

namespace Chinook.ConsoleTest;

internal class Program
{
    static async Task Main(string[] args)
    {
        var count = Dao.Initialize();
        Console.WriteLine(count);
    }

}