import React from 'react';
import createLoginUrl from 'lib/createLoginUrl';

// Use a global to save the user, so we don't have to fetch it again after page navigations
let userState: undefined;

const UserContext = React.createContext({user: null, loading: false});

export const fetchUser = async () => {
    if (userState !== undefined) {
        return userState;
    }

    const res = await fetch('/api/me');
    userState = res.ok ? await res.json() : undefined;
    return userState;
};

// @ts-ignore
export const UserProvider = ({value, children}) => {
    const {user} = value;

    // If the user was fetched in SSR add it to userState so we don't fetch it again
    React.useEffect(() => {
        if (!userState && user) {
            userState = user;
        }
    }, []);

    return (
        <UserContext.Provider value={value}>
            {children}
        </UserContext.Provider>
    );
};

export type OidcUser = {
    locale: string,
    gender: 'male' | 'female',
    picture: string,
    given_name?: string,
    family_name?: string,
    name: string,
    nickname: string,
    zoneinfo: string,
}

export const useFetchUser = (required = true) => {
    const [data, setUser] = React.useState<{ user?: OidcUser, loading: boolean }>({
        user: userState || undefined,
        loading: userState === undefined,
    });

    React.useEffect(() => {
        if (userState !== undefined) {
            return;
        }

        let isMounted = true;

        fetchUser()
            .then(user => {
                if (isMounted) {
                    if (required && !user) {
                        window.location.href = createLoginUrl();
                        return;
                    }

                    setUser({user, loading: false});
                }
            });

        return () => {
            isMounted = false;
        };
    }, [userState]);

    return data;
};
