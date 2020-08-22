import DefaultLayout from 'components/Layout';
import Presentation from 'components/Presentation/Presentation';
import Subjects from 'components/Subjects';
import {useFetchUser} from 'lib/utils/user';
import {NextPage} from 'next';
import * as React from 'react';

interface Props {
    userAgent: string;
}

const Home: NextPage<Props> = () => {
    const {user, loading} = useFetchUser(false);

    if (!loading && user) {
        return (
            <DefaultLayout title={'Subjects'}>
                <Subjects/>
            </DefaultLayout>
        );
    }

    if (!loading && !user) {
        return (
            <Presentation/>
        );
    }

    return (
        <div>Loading</div>
    );
};

export default Home;
