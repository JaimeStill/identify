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

    protected override UrlBuilder GenerateUrl()
    {
        UrlBuilder builder = base.GenerateUrl();

        if (!string.IsNullOrWhiteSpace(Eyes))
            builder.AddQuery("eyes", Eyes);

        if (!string.IsNullOrWhiteSpace(Eyebrows))
            builder.AddQuery("eyebrows", Eyebrows);

        if (!string.IsNullOrWhiteSpace(Mouth))
            builder.AddQuery("mouth", Mouth);

        if (!string.IsNullOrWhiteSpace(Accessories))
            builder.AddQuery("accessoires", Accessories);

        if (AccessoriesProbability is not null)
            builder.AddQuery("accessoiresProbability", AccessoriesProbability.ToString());

        if (!string.IsNullOrWhiteSpace(Hair))
            builder.AddQuery("hair", Hair);

        if (!string.IsNullOrWhiteSpace(SkinColor))
            builder.AddQuery("skinColor", SkinColor);

        if (!string.IsNullOrWhiteSpace(HairColor))
            builder.AddQuery("hairColor", HairColor);

        return builder;
    }
}