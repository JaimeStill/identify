using Identify.Models.Url;

namespace Identify.Models.Entities;
public abstract class Identity : Entity
{
    public int? ImageRadius { get; set; }
    public string ImageRootUrl { get; protected set; }
    public string Image { get; protected set; }
    public string ImageBackground { get; set; }

    protected virtual UrlBuilder GenerateUrl()
    {
        UrlBuilder builder = new($"{ImageRootUrl}{Url}.svg");

        if (!string.IsNullOrWhiteSpace(ImageBackground))
            builder.AddQuery("backgroundColor", ImageBackground);

        if (ImageRadius is not null)
            builder.AddQuery("radius", ImageRadius.ToString());

        return builder;
    }

    public override void Complete()
    {
        base.Complete();
        Image = GenerateUrl().Build();
    }
}