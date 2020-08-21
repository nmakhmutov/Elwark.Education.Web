import { NextApiRequest, NextApiResponse } from 'next';
import OpenIdConnectSettings from '../settings';
import isRelative from '../utils/url-helpers';

import { setCookies } from '../utils/cookies';
import { createState } from '../utils/state';
import { IOidcClientFactory } from '../utils/oidc-client';

export interface AuthorizationParameters {
    acr_values?: string;
    audience?: string;
    display?: string;
    login_hint?: string;
    max_age?: string;
    prompt?: string;
    scope?: string;
    state?: string;
    ui_locales?: string;
    [key: string]: unknown;
}

export interface LoginOptions {
    getState?: (req: NextApiRequest) => Record<string, any>;
    authParams?: AuthorizationParameters;
    redirectTo?: string;
}

export default function loginHandler(settings: OpenIdConnectSettings, clientProvider: IOidcClientFactory) {
    return async (req: NextApiRequest, res: NextApiResponse, options?: LoginOptions): Promise<void> => {
        if (!req) {
            throw new Error('Request is not available');
        }

        if (!res) {
            throw new Error('Response is not available');
        }

        if (req.query.redirectTo) {
            if (typeof req.query.redirectTo !== 'string') {
                throw new Error('Invalid value provided for redirectTo, must be a string');
            }

            if (!isRelative(req.query.redirectTo)) {
                throw new Error('Invalid value provided for redirectTo, must be a relative url');
            }
        }

        const opt = options || {};
        const getLoginState =
            opt.getState ||
            function getLoginState(): Record<string, any> {
                return {};
            };

        const {
            state = createState({
                redirectTo: req.query?.redirectTo || options?.redirectTo,
                ...getLoginState(req)
            }),
            ...authParams
        } = (opt && opt.authParams) || {};

        const client = await clientProvider();

        const authorizationUrl = client.authorizationUrl({
            redirect_uri: settings.redirectUri,
            scope: settings.scope,
            response_type: 'code',
            audience: settings.audience,
            state,
            ...authParams
        });

        setCookies(req, res, [
            {
                name: 'oidc:state',
                value: state,
                maxAge: 60 * 60
            }
        ]);

        res.writeHead(302, {
            Location: authorizationUrl
        });
        res.end();
    };
}
