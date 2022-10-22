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

    protected override UrlBuilder GenerateUrl()
    {
        UrlBuilder builder = base.GenerateUrl();

        if (!string.IsNullOrWhiteSpace(Colors))
            builder.AddQuery("colors", Colors);

        if (Colorful is not null)
            builder.AddQuery("colorful", Colorful.ToString().ToLower());

        if (PrimaryColorLevel is not null)
            builder.AddQuery("primaryColorLevel", ((int)PrimaryColorLevel).ToString());

        if (SecondaryColorLevel is not null)
            builder.AddQuery("secondaryColorLevel", ((int)SecondaryColorLevel).ToString());

        if (TextureChance is not null)
            builder.AddQuery("textureChance", TextureChance.ToString());

        if (MouthChance is not null)
            builder.AddQuery("mouthChance", MouthChance.ToString());

        if (SidesChance is not null)
            builder.AddQuery("sidesChance", SidesChance.ToString());

        if (TopChance is not null)
            builder.AddQuery("topChance", TopChance.ToString());

        return builder;
    }
}