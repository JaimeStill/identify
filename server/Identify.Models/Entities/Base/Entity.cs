using Identify.Models.Url;

namespace Identify.Models.Entities;
public abstract class Entity : SimpleEntity
{
    public string Url { get; private set; }

    protected static string Encode(string prop) => UrlEncoder.Encode(prop);

    public virtual void Complete() => Url = Encode(Name);
}