import { NextApiRequest, NextApiResponse } from 'next';
import oidc from 'lib/oidc';

export default async function login(req: NextApiRequest, res: NextApiResponse): Promise<void> {
    try {
        await oidc.handleLogin(req, res);
    } catch (error) {
        res.status(error.status || 400).end(error.message);
    }
}
