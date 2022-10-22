using Identify.Data;
using Identify.Models.Entities;

namespace Identify.DbCli.Seed;
public class AdventurerSeeder : Seeder<Adventurer, AppDbContext>
{
    public AdventurerSeeder(AppDbContext db) : base(db) { }

    protected override async Task<List<Adventurer>> Generate()
    {
        List<Adventurer> adventurers = new()
        {
            new()
            {
                Name = "Jaime",
                FirstName = "Jaime",
                LastName = "Still"
            },
            new()
            {
                Name = "Ellie",
                FirstName = "Ellie",
                LastName = "Still",
                ImageBackground = "#ffaa44",
                ImageRadius = 4,
                Eyes = "variant23",
                Eyebrows = "variant10",
                Mouth = "variant21",
                Accessories = "glasses",
                AccessoriesProbability = 100,
                Hair = "long07",
                SkinColor = "variant02",
                HairColor = "#232323"
            }
        };

        List<AdventurerAccessory> accessories = new()
        {
            new() { Name = "sunglasses" },
            new() { Name = "glasses" },
            new() { Name = "smallGlasses" },
            new() { Name = "mustache" },
            new() { Name = "blush" },
            new() { Name = "birthmark" }
        };

        List<AdventurerEye> eyes = BuildVariants<AdventurerEye>(26);
        List<AdventurerEyebrow> eyebrows = BuildVariants<AdventurerEyebrow>(10);
        List<AdventurerMouth> mouths = BuildVariants<AdventurerMouth>(30);

        IEnumerable<AdventurerHair> hairs = BuildIteration<AdventurerHair>("short", 16)
            .Concat(BuildIteration<AdventurerHair>("long", 19));

        await db.Adventurers.AddRangeAsync(adventurers);
        await db.AdventurerAccessories.AddRangeAsync(accessories);
        await db.AdventurerEyes.AddRangeAsync(eyes);
        await db.AdventurerEyebrows.AddRangeAsync(eyebrows);
        await db.AdventurerMouths.AddRangeAsync(mouths);
        await db.AdventurerHairs.AddRangeAsync(hairs);

        await db.SaveChangesAsync();
        
        return adventurers;
    }

    static List<T> BuildVariants<T>(int end) where T : SimpleEntity =>
        BuildIteration<T>("variant", end);

    static List<T> BuildIteration<T>(string term, int end) where T : SimpleEntity
    {
        List<T> values = new();

        for (var i = 1; i <= end; i++)
        {
            T value = Activator.CreateInstance<T>();
            value.Name = $"{term}{i:00}";
            values.Add(value);
        }

        return values;
    }
}