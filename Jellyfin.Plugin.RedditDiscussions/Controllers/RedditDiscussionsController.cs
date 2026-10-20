using System.Net.Mime;
using Jellyfin.Plugin.RedditDiscussions.Models;
using Jellyfin.Plugin.RedditDiscussions.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Jellyfin.Plugin.RedditDiscussions.Controllers;

[ApiController]
[Authorize]
[Route("[controller]")]
[Produces("application/json")]
public class RedditDiscussionsController(ILogger<RedditDiscussionsController> logger)
    : ControllerBase
{
    [HttpGet("GetDiscussionLink")]
    public GetDiscussionLinkResponse GetDiscussionLink() => new("https://reddit.com/");

    [HttpGet("inject.js")]
    public IActionResult GetInjectionScript()
    {
        return File(
            EmbeddedResources.GetStream(EmbeddedResources.InjectionScript),
            MediaTypeNames.Text.JavaScript
        );
    }
}
