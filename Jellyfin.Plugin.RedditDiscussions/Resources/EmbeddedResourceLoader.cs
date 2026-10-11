namespace Jellyfin.Plugin.RedditDiscussions.Resources;

public class EmbeddedResourceLoader(string resourceName)
{
    private readonly Lazy<string> _content = new(() => LoadContent(resourceName));

    public string Content => _content.Value;

    private static string LoadContent(string resourceName)
    {
        using var stream =
            typeof(EmbeddedResourceLoader).Assembly.GetManifestResourceStream(resourceName)
            ?? throw new InvalidOperationException($"Resource not found. ({resourceName})");
        using var reader = new StreamReader(stream);

        return reader.ReadToEnd();
    }
}
