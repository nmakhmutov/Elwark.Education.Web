import { Client, custom, Issuer } from 'openid-client';

import OpenIdConnectSettings from '../settings';
import OidcClientSettings from '../oidc-client-settings';

export type OidcClientFactory = () => Promise<Client>;

interface ClientSettings {
    timeout: number;
}

export default function getClient(settings: OpenIdConnectSettings): OidcClientFactory {
    let client: any = null;
    const clientSettings: OidcClientSettings = settings.oidcClient || {
        httpTimeout: 2500
    };

    return async (): Promise<Client> => {
        if (client) {
            return client;
        }

        const issuer = await Issuer.discover(settings.issuer);
        client = new issuer.Client({
            client_id: settings.clientId,
            client_secret: settings.clientSecret,
            redirect_uris: [settings.redirectUri],
            response_types: ['code']
        });

        if (clientSettings.httpTimeout) {
            const timeout = clientSettings.httpTimeout;
            client[custom.http_options] = function setHttpOptions(options: ClientSettings): ClientSettings {
                return {
                    ...options,
                    timeout
                };
            };
        }

        if (clientSettings.clockTolerance) {
            client[custom.clock_tolerance] = clientSettings.clockTolerance / 1000;
        }

        return client;
    };
}
