using Identify.Models.Entities;
using Identify.Models.Url;

Console.WriteLine("Testing Bots...");
Console.WriteLine("Testing Simple Bot");

Bot simpleBot = new()
{
    Name = "Jaime",
};

TestIdentity(simpleBot);

Console.WriteLine("\nTesting Complex Bot");

Bot complexBot = new()
{
    Name = "Ellie",
    ImageBackground = "#44ff99",
    ImageRadius = 4,
    Colors = "pink",
    Colorful = true,
    PrimaryColorLevel = 500,
    SecondaryColorLevel = 400,
    TextureChance=100,
    MouthChance=100,
    SidesChance=100,
    TopChance=100
};

TestIdentity(complexBot);

Console.WriteLine("\nTesting Adventurers...");
Console.WriteLine("Testing Simple Adventurer");

Adventurer simpleAd = new()
{
    Name = "Jaime"
};

TestIdentity(simpleAd);

Console.WriteLine("\nTesting Complex Adventurer");

Adventurer complexAd = new()
{
    Name = "Ellie",
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
};

TestIdentity(complexAd);

static void TestIdentity(Identity id)
{
    id.Complete();
    Console.WriteLine($"{id.Name}: {id.Image}");
}