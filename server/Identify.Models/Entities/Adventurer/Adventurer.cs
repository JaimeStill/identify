using Identify.Models.Url;

namespace Identify.Models.Entities;

public class Adventurer : Identity
{
    public Adventurer()
    {
        ImageRootUrl = "https://avatars.dicebear.com/api/adventurer/";
    }

    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string Eyes { get; set; }
    public string Eyebrows { get; set; }
    public string Mouth { get; set; }
    public string Accessories { get; set; }
    public string Hair { get; set; }
    public string SkinColor { get; set; }
    public string HairColor { get; set; }
    public int? AccessoriesProbability { get; set; }

    protected override UrlBuilder GenerateUrl() =>
        base.GenerateUrl()
            .AddQuery("eyes", Eyes)
            .AddQuery("eyebrows", Eyebrows)
            .AddQuery("mouth", Mouth)
            .AddQuery("accessoires", Accessories)
            .AddQuery("accessoiresProbability", AccessoriesProbability?.ToString())
            .AddQuery("hair", Hair)
            .AddQuery("skinColor", SkinColor)
            .AddQuery("hairColor", HairColor);
}