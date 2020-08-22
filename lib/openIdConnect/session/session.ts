export interface SessionInterface {
    readonly user: ClaimsInterface;
    readonly idToken?: string | undefined;
    readonly accessToken?: string | undefined;
    readonly accessTokenExpiresAt?: number;
    readonly accessTokenScope?: string | undefined;
    readonly refreshToken?: string | undefined;
    readonly createdAt: number;
}

export interface ClaimsInterface {
    [key: string]: any;
}

export default class Session implements SessionInterface {
    user: ClaimsInterface;

    idToken?: string | undefined;

    accessToken?: string | undefined;

    accessTokenScope?: string | undefined;

    accessTokenExpiresAt?: number;

    refreshToken?: string | undefined;

    createdAt: number;

    constructor(user: ClaimsInterface, createdAt?: number) {
        this.user = user;

        if (createdAt) {
            this.createdAt = createdAt;
        } else {
            this.createdAt = Date.now();
        }
    }
}
