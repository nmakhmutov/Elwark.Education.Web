import Layout from 'components/layout/Landing/Layout';
import {NextPage} from 'next';
import * as React from 'react';

interface Props {
    userAgent: string;
}

const Home: NextPage<Props> = ({userAgent}) => (
    <Layout>
        Main page {userAgent}
    </Layout>
);

Home.getInitialProps = async ({req, query}) => {
    const userAgent = req ? req.headers['user-agent'] : navigator.userAgent;
    return {userAgent} as Props;
};

export default Home;
