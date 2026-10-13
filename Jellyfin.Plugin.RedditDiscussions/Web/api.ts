import type { Api } from "@jellyfin/sdk";

class RedditDiscussionsApi {
  private api: Api;

  constructor(api: Api) {
    this.api = api;
  }

  async getDiscussionLink(): Promise<string | null> {
    interface GetDiscussionLinkResponse {
      discussionLink: string | null;
    }

    return (
      (
        await this.api.axiosInstance.get(
          "RedditDiscussions/GetDiscussionLink",
          {
            baseURL: this.api.basePath,
            headers: {
              Authorization: this.api.authorizationHeader,
            },
          },
        )
      ).data as GetDiscussionLinkResponse
    ).discussionLink;
  }
}

export const getRedditDiscussionsApi = (api: Api) =>
  new RedditDiscussionsApi(api);
