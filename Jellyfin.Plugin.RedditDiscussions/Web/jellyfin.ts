import type { Api } from "@jellyfin/sdk";
import { waitFor } from "./utils";

export async function waitForApi(): Promise<Api> {
  await waitFor(() => ApiClient.isLoggedIn(), 100);
  return ApiClient._sdk;
}
