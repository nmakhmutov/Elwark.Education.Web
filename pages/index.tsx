import {Links} from 'lib/utils';
import {useFetchUser} from 'lib/utils/user';
import {NextPage} from 'next';
import * as React from 'react';

interface Props {
    userAgent: string;
}

const Home: NextPage<Props> = () => {
    const {user, loading} = useFetchUser();
    if (!loading && user) {
        window.location.href = Links.Subjects;
        return null;
    }

    return (
        <div>
            Main page
        </div>
    );
};

export default Home;
