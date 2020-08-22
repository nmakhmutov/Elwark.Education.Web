import OidcClientSettings from './oidc-client-settings';
import { CookieSessionStoreSettingsInterface } from './session/cookie-store/settings';

export default interface OpenIdConnectSettings {
    issuer: string;
    audience?: string;
    clientId: string;
    clientSecret?: string;
    redirectUri: string;
    postLogoutRedirectUri: string;
    scope: string;
    session?: CookieSessionStoreSettingsInterface;
    oidcClient?: OidcClientSettings;
}
