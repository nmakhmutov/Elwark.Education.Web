import { NextApiRequest, NextApiResponse } from 'next';
import oidc from 'lib/oidc';

export default async function logout(req: NextApiRequest, res: NextApiResponse): Promise<void> {
    try {
        await oidc.handleLogout(req, res);
    } catch (error) {
        res.status(error.status || 400).end(error.message);
    }
}
