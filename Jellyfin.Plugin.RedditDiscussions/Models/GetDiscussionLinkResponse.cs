using System.Text.Json.Serialization;

namespace Jellyfin.Plugin.RedditDiscussions.Models;

public record GetDiscussionLinkResponse(
    [property: JsonPropertyName("discussionLink")] string? DiscussionLink
);
