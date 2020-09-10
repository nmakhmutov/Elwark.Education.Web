import oidc from 'lib/oidc';
import createLoginUrl from 'lib/createLoginUrl';
import {NextApiRequest, NextApiResponse} from 'next';

const TokenApi = {
    get: async (req: NextApiRequest, res: NextApiResponse): Promise<string> => {
        try {
            const tokenCache = await oidc.tokenCache(req, res);
            const {accessToken} = await tokenCache.getAccessToken({refresh: true})

            if (!accessToken)
                throw new Error('Access token is empty');

            return accessToken;
        } catch (e) {
            res.writeHead(302, {Location: createLoginUrl(req.url)});
            res.end();

            return '';
        }
    }
}

export default TokenApi;
