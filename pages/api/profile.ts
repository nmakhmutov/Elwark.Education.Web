import oidc from 'lib/oidc';
import {NextApiRequest, NextApiResponse} from 'next';
import UserApi from 'lib/api/user';

export default async function profile(req: NextApiRequest, res: NextApiResponse): Promise<void> {
    try {
        const tokenCache = oidc.tokenCache(req, res);
        const {accessToken} = await tokenCache.getAccessToken({refresh: true});

        const {data} = await UserApi.get(accessToken!);

        res.status(200).json(data);
    } catch (error) {
        res.status(error.status || 500).json({
            code: error.code,
            error: error.message
        });
    }
}
