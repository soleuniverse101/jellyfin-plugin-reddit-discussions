namespace Jellyfin.Plugin.RedditDiscussions.Resources;

public static class EmbeddedResources
{
    public static readonly string InjectionScript = $"{typeof(Plugin).Namespace}.Web.inject.js";

    public static Stream GetStream(string resourceName)
    {
        return typeof(EmbeddedResources).Assembly.GetManifestResourceStream(resourceName)!;
    }
}
