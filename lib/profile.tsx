import React from 'react';
import createLoginUrl from 'lib/utils/login-url';

// Use a global to save the user, so we don't have to fetch it again after page navigations
let profileState: undefined;

export const ProfileContext = React.createContext<{ profile?: Profile, loading: boolean }>({
    profile: undefined,
    loading: false
});

export const fetchUser = async () => {
    if (profileState !== undefined) {
        return profileState;
    }

    const res = await fetch('/api/profile');
    profileState = res.ok ? await res.json() : undefined;
    return profileState;
};

// @ts-ignore
export const ProfileProvider = ({value, children}) => {
    const {profile} = value;

    // If the user was fetched in SSR add it to userState so we don't fetch it again
    React.useEffect(() => {
        if (!profileState && profile) {
            profileState = profile;
        }
    }, []);

    return (
        <ProfileContext.Provider value={value}>
            {children}
        </ProfileContext.Provider>
    );
};

export type Profile = {
    id: number,
    name: string,
    life: {
        points: number,
        nextIncreaseAt?: Date
    },
    subscription: {
        type: 'regular' | 'premium',
        expiredAt?: Date
    }
}

export const useFetchProfile = () => {
    const [data, setProfile] = React.useState<{ profile?: Profile, loading: boolean }>({
        profile: profileState || undefined,
        loading: profileState === undefined,
    });

    React.useEffect(() => {
        if (profileState !== undefined) {
            return;
        }

        let isMounted = true;

        fetchUser()
            .then(profile => {
                if (isMounted) {
                    if (!profile) {
                        window.location.href = createLoginUrl();
                        return;
                    }

                    setProfile({profile, loading: false});
                }
            });

        return () => {
            isMounted = false;
        };
    }, [profileState]);

    return data;
};
