import {IncomingMessage, ServerResponse} from 'http';

import {SessionInterface} from '../session';
import {SessionStoreInterface} from '../store';

export default class MemoryStore implements SessionStoreInterface {
    private session: SessionInterface | null;

    constructor(session?: SessionInterface) {
        if (session === undefined) {
            this.session = null;
        } else {
            this.session = session;
        }
    }

    async read(): Promise<SessionInterface | null> {
        return this.session;
    }

    async save(_req: IncomingMessage, _res: ServerResponse, session: SessionInterface): Promise<SessionInterface> {
        this.session = session;
        return session;
    }
}
