import oidc from 'lib/oidc';
import {NextApiRequest, NextApiResponse} from 'next';
import axios, {Method} from 'axios';
import {SERVER_BASE_URL} from 'lib/utils/constants';

export default async function call(req: NextApiRequest, res: NextApiResponse): Promise<void> {
    try {
        const tokenCache = oidc.tokenCache(req, res);
        const {accessToken} = await tokenCache.getAccessToken({refresh: true});

        const endpoint = req.headers.endpoint

        const {status, data} = await axios({
            method: req.method as Method,
            url: `${SERVER_BASE_URL}/${endpoint}`,
            headers: {
                'Content-type': req.headers['content-type'],
                Authorization: `Bearer ${accessToken}`,
                Language: 'en'
            },
            data: req.body
        })

        res.status(status).json(data);
    } catch (error) {
        res.status(error.status || 500).json({
            code: error.code,
            error: error.message
        });
    }
}
