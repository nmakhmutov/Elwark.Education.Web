import {DefaultLayout} from 'layouts';
import {NextPage} from 'next';
import * as React from 'react';
import Header from './components/Header';

interface Props {
    userAgent: string;
}

const Home: NextPage<Props> = ({userAgent}) => (
    <DefaultLayout title={'Elwark cafe'}>
        <Header/>
    </DefaultLayout>
);

Home.getInitialProps = async ({req, query}) => {
    const userAgent = req ? req.headers['user-agent'] : navigator.userAgent;
    return {userAgent} as Props;
};

export default Home;
