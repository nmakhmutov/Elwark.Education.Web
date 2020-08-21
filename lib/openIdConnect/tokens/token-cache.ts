export interface AccessTokenRequest {
    scopes?: string[];
}

export interface AccessTokenResponse {
    accessToken?: string | undefined;
}

export interface TokenCache {
    getAccessToken(accessTokenRequest?: AccessTokenRequest): Promise<AccessTokenResponse>;
}
