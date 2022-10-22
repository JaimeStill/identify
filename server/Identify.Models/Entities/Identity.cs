using Identify.Models.Url;

namespace Identify.Models.Entities;
public abstract class Identity : Entity
{
    public int? ImageRadius { get; set; }
    public string ImageRootUrl { get; protected set; }
    public string Image { get; protected set; }
    public string ImageBackground { get; set; }

    protected virtual UrlBuilder GenerateUrl() =>
        new UrlBuilder($"{ImageRootUrl}{Url}.svg")
            .AddQuery("backgroundColor", ImageBackground)
            .AddQuery("radius", ImageRadius?.ToString());

    public override void Complete()
    {
        base.Complete();
        Image = GenerateUrl().Build();
    }
}