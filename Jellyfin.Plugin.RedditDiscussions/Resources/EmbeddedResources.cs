namespace Jellyfin.Plugin.RedditDiscussions.Resources;

public static class EmbeddedResources
{
    public static readonly EmbeddedResourceLoader InjectionScript = new(
        $"{typeof(Plugin).Namespace}.Web.inject.js"
    );
}
