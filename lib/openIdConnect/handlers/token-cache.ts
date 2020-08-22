import {NextApiRequest, NextApiResponse} from 'next';

import {SessionStoreInterface} from '../session/store';
import SessionTokenCache from '../tokens/session-token-cache';
import {TokenCache} from '../tokens/token-cache';
import {OidcClientFactory} from '../utils/oidc-client';

export default function tokenCacheHandler(clientProvider: OidcClientFactory, sessionStore: SessionStoreInterface) {
    return (req: NextApiRequest, res: NextApiResponse): TokenCache => {
        if (!req) {
            throw new Error('Request is not available');
        }

        if (!res) {
            throw new Error('Response is not available');
        }

        return new SessionTokenCache(sessionStore, clientProvider, req, res);
    };
}
