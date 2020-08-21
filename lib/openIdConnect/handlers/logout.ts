import { NextApiRequest, NextApiResponse } from 'next';

import OpenIdConnectSettings from '../settings';
import { setCookies } from '../utils/cookies';
import { IOidcClientFactory } from '../utils/oidc-client';
import CookieSessionStoreSettings from '../session/cookie-store/settings';
import { ISessionStore } from '../session/store';

export default function logoutHandler(
    settings: OpenIdConnectSettings,
    sessionSettings: CookieSessionStoreSettings,
    clientProvider: IOidcClientFactory,
    store: ISessionStore
) {
    return async (req: NextApiRequest, res: NextApiResponse): Promise<void> => {
        if (!req) {
            throw new Error('Request is not available');
        }

        if (!res) {
            throw new Error('Response is not available');
        }

        const session = await store.read(req);
        const client = await clientProvider();
        const endSessionUrl = client.endSessionUrl({
            id_token_hint: session ? session.idToken : undefined,
            post_logout_redirect_uri: encodeURIComponent(settings.postLogoutRedirectUri)
        });

        // Remove the cookies
        setCookies(req, res, [
            {
                name: 'oidc:state',
                value: '',
                maxAge: -1
            },
            {
                name: sessionSettings.cookieName,
                value: '',
                maxAge: -1,
                path: sessionSettings.cookiePath,
                domain: sessionSettings.cookieDomain
            }
        ]);

        // Redirect to the logout endpoint.
        res.writeHead(302, {
            Location: endSessionUrl
        });
        res.end();
    };
}
