import DefaultLayout from 'components/Layout';
import Presentation from 'components/Presentation/Presentation';
import Subjects from 'components/Subjects';
import {GetServerSideProps, GetServerSidePropsContext, NextApiRequest, NextPage} from 'next';
import * as React from 'react';
import oidc from 'lib/oidc';

interface Props {
    isLoggedIn: boolean;
}

const Home: NextPage<Props> = (props) => {
    const {isLoggedIn} = props;
    if (isLoggedIn) {
        return (
            <DefaultLayout title={'Subjects'}>
                <Subjects/>
            </DefaultLayout>
        );
    }

    return (
        <Presentation/>
    );
};

export const getServerSideProps: GetServerSideProps<Props> = async ({req}: GetServerSidePropsContext) => {
    const session = await oidc.getSession(req as NextApiRequest);

    return !session || !session.user
        ? {props: {isLoggedIn: false}}
        : {props: {isLoggedIn: true}};
}

export default Home;
