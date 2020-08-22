import { NextApiRequest, NextApiResponse } from 'next';
import oidc from 'lib/oidc';

export default async function me(req: NextApiRequest, res: NextApiResponse): Promise<void> {
    try {
        await oidc.handleProfile(req, res);
    } catch (error) {
        res.status(error.status || 500).end(error.message);
    }
}
