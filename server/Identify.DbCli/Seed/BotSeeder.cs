using Identify.Data;
using Identify.Models.Entities;

namespace Identify.DbCli.Seed;
public class BotSeeder : Seeder<Bot, AppDbContext>
{
    public BotSeeder(AppDbContext db) : base(db) { }

    protected override async Task<List<Bot>> Generate()
    {
        List<Bot> bots = new()
        {
            new()
            {
                Name = "Jaime",
                Model = "RX-323",
                Make = new()
                {
                    Name = "Ryujin Industries"
                }
            },
            new()
            {
                Name = "Ellie",
                Model = "EJX-47C",
                ImageBackground = "#44ff99",
                ImageRadius = 4,
                Colors = "pink",
                Colorful = true,
                PrimaryColorLevel = 500,
                SecondaryColorLevel = 400,
                TextureChance=100,
                MouthChance=100,
                SidesChance=100,
                TopChance=100,
                Make = new()
                {
                    Name = "Freestar Collective"
                }
            }
        };

        List<BotColor> colors = new()
        {
            new() { Name = "amber" },
            new() { Name = "blue" },
            new() { Name = "blueGrey" },
            new() { Name = "brown" },
            new() { Name = "cyan" },
            new() { Name = "deepOrange" },
            new() { Name = "deepPurple" },
            new() { Name = "green" },
            new() { Name = "grey" },
            new() { Name = "indigo" },
            new() { Name = "lightBlue" },
            new() { Name = "lightGreen" },
            new() { Name = "lime" },
            new() { Name = "orange" },
            new() { Name = "pink" },
            new() { Name = "purple" },
            new() { Name = "red" },
            new() { Name = "teal" },
            new() { Name = "yellow" }
        };

        await db.Bots.AddRangeAsync(bots);
        await db.BotColors.AddRangeAsync(colors);

        await db.SaveChangesAsync();

        return bots;
    }
}