import {TokenSet} from 'openid-client';
import {SessionInterface} from '../session/session';

export default function getSessionFromTokenSet(tokenSet: TokenSet): SessionInterface {
    const claims = {...tokenSet.claims(), aud: null, exp: null, iat: null, iss: null};

    // Create the session.
    return {
        user: {
            ...claims
        },
        idToken: tokenSet.id_token,
        accessToken: tokenSet.access_token,
        accessTokenScope: tokenSet.scope,
        accessTokenExpiresAt: tokenSet.expires_at,
        refreshToken: tokenSet.refresh_token,
        createdAt: Date.now()
    };
}
