using Microsoft.AspNetCore.WebUtilities;

namespace Identify.Models.Url;
public class UrlBuilder
{
    public string BaseUrl { get; private set; }
    readonly List<KeyValuePair<string, string>> Query = new();

    public UrlBuilder(string url)
    {
        BaseUrl = url;
    }

    public UrlBuilder AddQuery(string key, string value)
    {
        if (!string.IsNullOrWhiteSpace(value))
            Query.Add(new(key, value));

        return this;
    }

    public string Build()
    {
        string url = BaseUrl;

        if (Query.Count > 0)
        {
            foreach (KeyValuePair<string, string> query in Query)
                url = QueryHelpers.AddQueryString(url, query.Key, query.Value);
        }

        return url;
    }
}