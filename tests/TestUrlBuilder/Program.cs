using Identify.Models.Entities;
using Identify.Models.Url;

Bot user1 = new()
{
    Name = "Jaime",
    Colorful = true,
    PrimaryColorLevel = ColorLevel.Level400
};

Bot user2 = new()
{
    Name = "Ellie",
    ImageBackground = "#ffaacc"
};

user1.Complete();
user2.Complete();

Console.WriteLine($"{user1.Name}: {user1.Image}");
Console.WriteLine($"{user2.Name}: {user2.Image}");