import {NextApiRequest, NextApiResponse} from 'next';

import OpenIdConnectSettings from '../settings';
import {decodeState} from '../utils/state';
import {SessionInterface} from '../session/session';
import {parseCookies} from '../utils/cookies';
import {SessionStoreInterface} from '../session/store';
import {OidcClientFactory} from '../utils/oidc-client';
import getSessionFromTokenSet from '../utils/session';

export type CallbackOptions = {
    redirectTo?: string;
    onUserLoaded?: (
        req: NextApiRequest,
        res: NextApiResponse,
        session: SessionInterface,
        state: Record<string, any>
    ) => Promise<SessionInterface>;
};

export default function callbackHandler(
    settings: OpenIdConnectSettings,
    clientProvider: OidcClientFactory,
    sessionStore: SessionStoreInterface
) {
    return async (req: NextApiRequest, res: NextApiResponse, options?: CallbackOptions): Promise<void> => {
        if (!res) {
            throw new Error('Response is not available');
        }

        if (!req) {
            throw new Error('Request is not available');
        }

        const cookies = parseCookies(req);

        const state = cookies['oidc:state'];
        if (!state) {
            throw new Error('Invalid request, an initial state could not be found');
        }

        const client = await clientProvider();

        const params = client.callbackParams(req);
        const tokenSet = await client.callback(settings.redirectUri, params, {state});
        const decodedState = decodeState(state);

        let session = getSessionFromTokenSet(tokenSet);

        if (options && options.onUserLoaded) {
            session = await options.onUserLoaded(req, res, session, decodedState);
        }

        await sessionStore.save(req, res, session);

        const redirectTo = (options && options.redirectTo) || decodedState.redirectTo || '/';
        res.writeHead(302, {
            Location: redirectTo
        });
        res.end();
    };
}
