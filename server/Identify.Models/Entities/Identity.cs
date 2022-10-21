using Identify.Models.Url;

namespace Identify.Models.Entities;
public abstract class Identity : Entity
{
    public string ImageRootUrl { get; protected set; }
    public string Image { get; protected set; }
    public string ImageBackground { get; set; }

    protected virtual UrlBuilder GenerateUrl()
    {
        UrlBuilder builder = new($"{ImageRootUrl}{Url}.svg");

        if (!string.IsNullOrWhiteSpace(ImageBackground))
            builder.AddQuery("backgroundColor", ImageBackground);

        return builder;
    }

    public override void Complete()
    {
        base.Complete();
        Image = GenerateUrl().Build();
    }
}