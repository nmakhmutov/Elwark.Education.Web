import handlers from './handlers';
import getClient from './utils/oidc-client';
import OpenIdConnectSettings from './settings';
import { SignInWithOpenIdConnect } from './instance';
import { SessionStoreInterface } from './session/store';
import CookieSessionStore from './session/cookie-store';
import CookieSessionStoreSettings from './session/cookie-store/settings';

export default function createInstance(settings: OpenIdConnectSettings): SignInWithOpenIdConnect {
    if (!settings.issuer) {
        throw new Error('A valid issuer must be provided');
    }

    if (!settings.clientId) {
        throw new Error('A valid Client ID must be provided');
    }

    if (!settings.clientSecret) {
        throw new Error('A valid Client Secret must be provided');
    }

    if (!settings.session) {
        throw new Error('The session configuration is required');
    }

    if (!settings.session.cookieSecret) {
        throw new Error('A valid session cookie secret is required');
    }

    const clientProvider = getClient(settings);

    const sessionSettings = new CookieSessionStoreSettings(settings.session);
    const store: SessionStoreInterface = new CookieSessionStore(sessionSettings);

    return {
        handleLogin: handlers.LoginHandler(settings, clientProvider),
        handleLogout: handlers.LogoutHandler(settings, sessionSettings, clientProvider, store),
        handleCallback: handlers.CallbackHandler(settings, clientProvider, store),
        handleProfile: handlers.ProfileHandler(store, clientProvider),
        getSession: handlers.SessionHandler(store),
        requireAuthentication: handlers.RequireAuthentication(store),
        tokenCache: handlers.TokenCache(clientProvider, store)
    };
}
