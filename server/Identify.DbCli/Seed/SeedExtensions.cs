using Identify.Data;

namespace Identify.DbCli.Seed;
public static class SeedExtensions
{
    public static async Task Seed(this AppDbContext db)
    {
        Console.WriteLine("Seeding Adventurer Schema");
        AdventurerSeeder adSeeder = new(db);
        await adSeeder.Seed();

        Console.WriteLine("Seeding Bot Schema");
        BotSeeder botSeeder = new(db);
        await botSeeder.Seed();
    }
}