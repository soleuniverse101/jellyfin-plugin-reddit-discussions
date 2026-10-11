namespace Jellyfin.Plugin.RedditDiscussions.Resources;

public class InjectionScript
{
    private static readonly string InjectionScriptResourceName =
        $"{typeof(Plugin).Namespace}.Web.inject.js";

    private static readonly Lazy<string> LazyContent = new(LoadContent);

    public static string Content => LazyContent.Value;

    private static string LoadContent()
    {
        using var stream =
            typeof(InjectionScript).Assembly.GetManifestResourceStream(InjectionScriptResourceName)
            ?? throw new InvalidOperationException("Injection script not found.");
        using var reader = new StreamReader(stream);

        return reader.ReadToEnd();
    }
}
