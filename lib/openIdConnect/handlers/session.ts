import {NextApiRequest} from 'next';

import {SessionInterface} from '../session/session';
import {SessionStoreInterface} from '../session/store';

export default function sessionHandler(sessionStore: SessionStoreInterface) {
    return (req: NextApiRequest): Promise<SessionInterface | null | undefined> => {
        if (!req) {
            throw new Error('Request is not available');
        }

        return sessionStore.read(req);
    };
}
