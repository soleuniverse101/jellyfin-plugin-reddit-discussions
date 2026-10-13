using Jellyfin.Plugin.RedditDiscussions.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Jellyfin.Plugin.RedditDiscussions.Controllers;

[ApiController]
[Authorize]
[Route("[controller]/[action]")]
[Produces("application/json")]
public class RedditDiscussionsController(ILogger<RedditDiscussionsController> logger)
    : ControllerBase
{
    [HttpGet]
    public GetDiscussionLinkResponse GetDiscussionLink() => new("https://reddit.com/");
}
