import { TokenCache } from './tokens/token-cache';
import { SessionInterface } from './session/session';
import { SignInWithOpenIdConnect } from './instance';

export default function createDummyBrowserInstance(): SignInWithOpenIdConnect & { isBrowser: boolean } {
    return {
        isBrowser: true,
        handleLogin: (): Promise<void> => {
            throw new Error('The handleLogin method can only be used from the server side');
        },
        handleLogout: (): Promise<void> => {
            throw new Error('The handleLogout method can only be used from the server side');
        },
        handleCallback: (): Promise<void> => {
            throw new Error('The handleCallback method can only be used from the server side');
        },
        handleProfile: (): Promise<void> => {
            throw new Error('The handleProfile method can only be used from the server side');
        },
        getSession: (): Promise<SessionInterface | null | undefined> => {
            throw new Error('The getSession method can only be used from the server side');
        },
        requireAuthentication: () => (): Promise<void> => {
            throw new Error('The requireAuthentication method can only be used from the server side');
        },
        tokenCache: (): TokenCache => {
            throw new Error('The tokenCache method can only be used from the server side');
        }
    };
}
