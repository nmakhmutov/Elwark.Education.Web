import { NextApiRequest, NextApiResponse } from 'next';
import { SessionInterface } from './session/session';
import { LoginOptions } from './handlers/login';
import { TokenCache } from './tokens/token-cache';
import { CallbackOptions } from './handlers/callback';
import { ProfileOptions } from './handlers/profile';
import { ApiRoute } from './handlers/require-authentication';

export interface SignInWithOpenIdConnect {
    handleLogin: (req: NextApiRequest, res: NextApiResponse, options?: LoginOptions) => Promise<void>;
    handleCallback: (req: NextApiRequest, res: NextApiResponse, options?: CallbackOptions) => Promise<void>;
    handleLogout: (req: NextApiRequest, res: NextApiResponse) => Promise<void>;
    handleProfile: (req: NextApiRequest, res: NextApiResponse, options?: ProfileOptions) => Promise<void>;
    getSession: (req: NextApiRequest) => Promise<SessionInterface | null | undefined>;
    requireAuthentication: (apiRoute: ApiRoute) => ApiRoute;
    tokenCache: (req: NextApiRequest, res: NextApiResponse) => TokenCache;
}
