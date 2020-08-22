import base64url from 'base64url';
import { randomBytes } from 'crypto';

export function createState(payload?: Record<string, any>): string {
    const stateObject = payload || {};
    stateObject.nonce = createNonce();
    return encodeState(stateObject);
}

function createNonce(): string {
    return randomBytes(16).toString('hex');
}

function encodeState(stateObject: Record<string, any>): string {
    return base64url.encode(JSON.stringify(stateObject));
}

export function decodeState(stateValue: string): Record<string, any> {
    const decoded = base64url.decode(stateValue);

    // Backwards compatibility
    if (decoded.indexOf('{') !== 0) {
        return { nonce: stateValue };
    }

    return JSON.parse(base64url.decode(stateValue));
}
