using Identify.Models.Url;

namespace Identify.Models.Entities;

public class Bot : Identity
{
    public Bot()
    {
        ImageRootUrl = "https://avatars.dicebear.com/api/bottts/";
    }

    public int MakeId { get; set; }
    public string Model { get; set; }
    public string Colors { get; set; }
    public bool? Colorful { get; set; }
    public int? PrimaryColorLevel { get; set; }
    public int? SecondaryColorLevel { get; set; }
    public int? TextureChance { get; set; }
    public int? MouthChance { get; set; }
    public int? SidesChance { get; set; }
    public int? TopChance { get; set; }

    public Make Make { get; set; }

    protected override UrlBuilder GenerateUrl() =>
        base.GenerateUrl()            
            .AddQuery("colors", Colors)
            .AddQuery("colorful", Colorful.ToString().ToLower())
            .AddQuery("primaryColorLevel", PrimaryColorLevel?.ToString())
            .AddQuery("secondaryColorLevel", SecondaryColorLevel?.ToString())
            .AddQuery("textureChance", TextureChance?.ToString())
            .AddQuery("mouthChance", MouthChance?.ToString())
            .AddQuery("sidesChance", SidesChance?.ToString())
            .AddQuery("topChance", TopChance?.ToString());
}