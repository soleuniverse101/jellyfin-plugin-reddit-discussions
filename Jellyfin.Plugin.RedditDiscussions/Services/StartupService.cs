using System.Runtime.Loader;
using Jellyfin.Plugin.RedditDiscussions.Resources;
using MediaBrowser.Model.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;

namespace Jellyfin.Plugin.RedditDiscussions.Services;

public class StartupService(ILogger<StartupService> logger) : IScheduledTask
{
    public string Name => "Reddit Discussions Startup";
    public string Key => "Jellyfin.Plugin.RedditDiscussions.Startup";
    public string Description =>
        "Startup Service for Reddit Discussions. Do not configure manually.";
    public string Category => "Startup Services";

    public Task ExecuteAsync(IProgress<double> progress, CancellationToken cancellationToken)
    {
        var jsInjectorAssembly = AssemblyLoadContext
            .All.SelectMany(x => x.Assemblies)
            .FirstOrDefault(x =>
                x.FullName?.Contains("Jellyfin.Plugin.JavaScriptInjector") ?? false
            );
        if (jsInjectorAssembly == null)
        {
            logger.LogError(
                "Error loading JavaScriptInjector Assembly. Make sure JavaScript Injector Plugin is installed."
            );
            return Task.CompletedTask;
        }

        var pluginInterfaceType = jsInjectorAssembly.GetType(
            "Jellyfin.Plugin.JavaScriptInjector.PluginInterface"
        );
        if (pluginInterfaceType == null)
        {
            logger.LogError("Error using JavaScriptInjector Plugin.");
            return Task.CompletedTask;
        }

        var registerResult = pluginInterfaceType
            .GetMethod("RegisterScript")
            ?.Invoke(
                null,
                [
                    new JObject
                    {
                        { "id", "eadc071b-afde-4d86-be03-c008886a5c75" },
                        { "name", "Reddit Discussions Button Injection Script" },
                        { "script", InjectionScript.Content },
                        { "enabled", true },
                        { "requiresAuthentication", true },
                        { "pluginId", Plugin.Instance.Id.ToString() },
                        { "pluginName", Plugin.Instance.Name },
                        { "pluginVersion", Plugin.Instance.Version.ToString() },
                    },
                ]
            );

        if (registerResult is not true)
        {
            logger.LogError("Error registering Script Injection.");
        }

        return Task.CompletedTask;
    }

    public IEnumerable<TaskTriggerInfo> GetDefaultTriggers()
    {
        yield return new TaskTriggerInfo { Type = TaskTriggerInfoType.StartupTrigger };
    }
}
