import { NextApiRequest } from 'next';
import { parse, serialize } from 'cookie';
import { IncomingMessage, ServerResponse } from 'http';

interface Cookies {
    [key: string]: string;
}

interface Cookie {
    name: string;

    value: string;

    maxAge: number;

    path?: string;

    domain?: string;

    sameSite?: boolean | 'lax' | 'strict' | 'none' | undefined;
}

export function parseCookies(req: IncomingMessage): Cookies {
    const { cookies } = req as NextApiRequest;

    if (cookies) {
        return cookies;
    }

    const cookie = req && req.headers && req.headers.cookie;
    return parse(cookie || '');
}

function isSecureEnvironment(req: IncomingMessage): boolean {
    if (!req || !req.headers || !req.headers.host) {
        throw new Error('The "host" request header is not available');
    }

    if (process.env.NODE_ENV !== 'production') {
        return false;
    }

    const host = (req.headers.host.indexOf(':') > -1 && req.headers.host.split(':')[0]) || req.headers.host;
    return ['localhost', '127.0.0.1'].indexOf(host) <= -1;
}

function serializeCookie(cookie: Cookie, secure: boolean): string {
    return serialize(cookie.name, cookie.value, {
        maxAge: cookie.maxAge,
        expires: new Date(Date.now() + cookie.maxAge * 1000),
        httpOnly: true,
        secure,
        path: cookie.path,
        domain: cookie.domain,
        sameSite: cookie.sameSite
    });
}

export function setCookies(req: IncomingMessage, res: ServerResponse, cookies: Cookie[]): void {
    res.setHeader(
        'Set-Cookie',
        cookies.map((c) => serializeCookie(c, isSecureEnvironment(req)))
    );
}

export function setCookie(req: IncomingMessage, res: ServerResponse, cookie: Cookie): void {
    res.setHeader('Set-Cookie', serializeCookie(cookie, isSecureEnvironment(req)));
}
