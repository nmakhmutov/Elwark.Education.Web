import oidc from 'lib/oidc';
import {NextApiRequest, NextApiResponse} from 'next';
import {SERVER_BASE_URL} from 'lib/utils/constants';

export default async function profile(req: NextApiRequest, res: NextApiResponse): Promise<void> {
    try {
        const tokenCache = oidc.tokenCache(req, res);
        const {accessToken} = await tokenCache.getAccessToken();

        const url = `${SERVER_BASE_URL}/users`;
        const response = await fetch(url, {
            headers: {
                Authorization: `Bearer ${accessToken}`
            }
        });

        res.status(200).json(await response.json());
    } catch (error) {
        res.status(error.status || 500).json({
            code: error.code,
            error: error.message
        });
    }
}
