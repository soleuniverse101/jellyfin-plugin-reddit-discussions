using Jellyfin.Plugin.RedditDiscussions.Configuration;
using MediaBrowser.Common.Configuration;
using MediaBrowser.Common.Plugins;
using MediaBrowser.Model.Serialization;

namespace Jellyfin.Plugin.RedditDiscussions;

public class Plugin : BasePlugin<PluginConfiguration>
{
    public Plugin(IApplicationPaths applicationPaths, IXmlSerializer xmlSerializer)
        : base(applicationPaths, xmlSerializer)
    {
        Instance = this;
    }

    public static Plugin Instance { get; private set; } = null!;

    public override string Name => "Reddit Discussions";
    public override Guid Id => Guid.Parse("2b1b24ce-7bf3-4869-b62a-80a9fffe0a35");
}
