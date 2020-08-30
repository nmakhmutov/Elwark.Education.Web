import oidc from 'lib/oidc';
import {NextApiRequest, NextApiResponse} from 'next';
import UserApi from 'lib/api/user';

export default async function callback(req: NextApiRequest, res: NextApiResponse): Promise<void> {
    try {
        console.log('callback')
        await oidc.handleCallback(req, res, {
            onUserLoaded: async (request, response, session, _) => {
                await UserApi.register(session.idToken!)
                return session;
            }
        });
    } catch (error) {
        res.status(error.status || 400).end(error.message);
    }
}
