import { IncomingMessage, ServerResponse } from 'http';

import { SessionInterface } from './session';

export interface SessionStoreInterface {
    read(req: IncomingMessage): Promise<SessionInterface | null | undefined>;

    save(req: IncomingMessage, res: ServerResponse, session: SessionInterface): Promise<SessionInterface | null | undefined>;
}
