export interface CookieSessionStoreSettingsInterface {
    cookieSecret: string;
    cookieName?: string;
    cookieSameSite?: boolean | 'lax' | 'strict' | 'none' | undefined;
    cookieLifetime?: number;
    cookiePath?: string;
    cookieDomain?: string;
    storeIdToken?: boolean;
    storeAccessToken?: boolean;
    storeRefreshToken?: boolean;
}

export default class CookieSessionStoreSettings {
    readonly cookieSecret: string;

    readonly cookieName: string;

    readonly cookieLifetime: number;

    readonly cookiePath: string;

    readonly cookieSameSite: boolean | 'lax' | 'strict' | 'none' | undefined;

    readonly cookieDomain: string;

    readonly storeIdToken: boolean;

    readonly storeAccessToken: boolean;

    readonly storeRefreshToken: boolean;

    constructor(settings: CookieSessionStoreSettingsInterface) {
        this.cookieSecret = settings.cookieSecret;
        if (!this.cookieSecret || !this.cookieSecret.length) {
            throw new Error('The cookieSecret setting is empty or null');
        }

        if (this.cookieSecret.length < 32) {
            throw new Error('The cookieSecret should be at least 32 characters long');
        }

        this.cookieName = settings.cookieName || 'a0:session';
        if (!this.cookieName || !this.cookieName.length) {
            throw new Error('The cookieName setting is empty or null');
        }

        this.cookieSameSite = settings.cookieSameSite;
        if (this.cookieSameSite === undefined) {
            this.cookieSameSite = 'lax';
        }

        this.cookieDomain = settings.cookieDomain || '';
        this.cookieLifetime = settings.cookieLifetime || 60 * 60 * 8;

        this.cookiePath = settings.cookiePath || '/';
        if (!this.cookiePath || !this.cookiePath.length) {
            throw new Error('The cookiePath setting is empty or null');
        }

        this.storeIdToken = settings.storeIdToken || false;
        this.storeAccessToken = settings.storeAccessToken || false;
        this.storeRefreshToken = settings.storeRefreshToken || false;
    }
}
