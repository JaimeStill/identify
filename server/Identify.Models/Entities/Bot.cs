using Identify.Models.Url;

namespace Identify.Models.Entities;

public enum ColorLevel
{
    Level50 = 50,
    Level100 = 100,
    Level200 = 200,
    Level300 = 300,
    Level400 = 400,
    Level500 = 500,
    Level600 = 600,
    Level700 = 700,
    Level800 = 800,
    Level900 = 900
}

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
    public ColorLevel? PrimaryColorLevel { get; set; }
    public ColorLevel? SecondaryColorLevel { get; set; }

    public Make Make { get; set; }

    protected override UrlBuilder GenerateUrl()
    {
        UrlBuilder builder = base.GenerateUrl();

        if (Colorful.HasValue)
            builder.AddQuery("colorful", Colorful.Value.ToString().ToLower());

        if (PrimaryColorLevel.HasValue)
            builder.AddQuery("primaryColorLevel", ((int)PrimaryColorLevel.Value).ToString());

        if (SecondaryColorLevel.HasValue)
            builder.AddQuery("secondaryColorLevel", ((int)SecondaryColorLevel.Value).ToString());

        return builder;
    }
}