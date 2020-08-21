import OpenIdConnectSettings from './settings';
import Instance from './instance.browser';
import { SignInWithOpenIdConnect } from './instance';

export function initOpenIdConnect(settings: OpenIdConnectSettings): SignInWithOpenIdConnect {
    return Instance();
}
