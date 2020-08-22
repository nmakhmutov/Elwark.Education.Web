import OpenIdConnectSettings from './settings';
import { SignInWithOpenIdConnect } from './instance';

export function initOpenIdConnect(settings: OpenIdConnectSettings): SignInWithOpenIdConnect {
    const isBrowser = typeof window !== 'undefined' || (process as any).browser;
    if (isBrowser) {
        return require('./instance.browser').default(settings);
    }

    return require('./instance.node').default(settings);
}
