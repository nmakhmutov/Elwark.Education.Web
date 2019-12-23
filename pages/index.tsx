import {NextPage} from 'next';
import * as React from 'react';
import {MainLayout} from '../components/layouts/Main';

interface Props {
    userAgent: string;
}

const Home: NextPage<Props> = ({userAgent}) => (
    <MainLayout title={'Main page'}>
        <h1>Hello world! - user agent:</h1>
        <h5>{userAgent}</h5>
    </MainLayout>
);

Home.getInitialProps = async ({req, query}) => {
    const userAgent = req ? req.headers['user-agent'] : navigator.userAgent;
    return {userAgent} as Props;
};

export default Home;
