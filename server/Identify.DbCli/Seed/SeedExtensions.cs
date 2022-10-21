using Identify.Data;

namespace Identify.DbCli.Seed;
public static class SeedExtensions
{
    public static async Task Seed(this AppDbContext db)
    {
        await Task.CompletedTask;
    }
}