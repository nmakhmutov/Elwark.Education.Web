export interface AccessTokenRequest {
    scopes?: string[];
    refresh?: boolean;
}

export interface AccessTokenResponse {
    accessToken?: string | undefined;
}

export interface TokenCache {
    getAccessToken(accessTokenRequest?: AccessTokenRequest): Promise<AccessTokenResponse>;
}
