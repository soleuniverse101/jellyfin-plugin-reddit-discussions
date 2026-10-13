import type { Api } from "@jellyfin/sdk";

interface ApiClient {
  isLoggedIn(): boolean;
  _sdk: Api;
}

declare global {
  const ApiClient: ApiClient;
}

export {};
