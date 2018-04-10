export interface NodeDetailsResponse {
  id: string;
  name: string;
  agentHealthy: boolean;
}

export interface NodeStatusResponse {
  id: string;
  name: string;
}

export interface ScreenshotResponse {
  mediaType: string;
  imageContent: string;
}
