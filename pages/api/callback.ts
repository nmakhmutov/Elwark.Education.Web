import oidc from 'lib/oidc';
import {Links} from 'lib/utils';
import {NextApiRequest, NextApiResponse} from 'next';

export default async function callback(req: NextApiRequest, res: NextApiResponse): Promise<void> {
    try {
        await oidc.handleCallback(req, res, {
            redirectTo: Links.Subjects,
        });
    } catch (error) {
        res.status(error.status || 400).end(error.message);
    }
}
