import { initOpenIdConnect } from 'lib/openIdConnect';

export default initOpenIdConnect({
    issuer: process.env.AUTH_ISSUER || '',
    clientId: process.env.AUTH_CLIENT_ID || '',
    clientSecret: process.env.AUTH_CLIENT_SECRET,
    scope: process.env.AUTH_SCOPE || 'openid',
    redirectUri: process.env.AUTH_REDIRECT_URI || '/',
    postLogoutRedirectUri: process.env.AUTH_LOGOUT_REDIRECT_URI || '/',
    session: {
        storeAccessToken: true,
        storeRefreshToken: true,
        cookieName: 'oidc:session',
        cookieSecret: process.env.AUTH_SESSION_COOKIE_SECRET || ''
    }
});
