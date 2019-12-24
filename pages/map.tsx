import {NextPage} from 'next';
import React from 'react';
import {MainLayout} from '../layouts/Main';

const Map: NextPage = () => {
    return (
        <MainLayout title={'Cafe map'}/>
    );
};

Map.getInitialProps = async () => {
    await new Promise((resolve) => {
        setTimeout(resolve, 30000);
    });
    return {};
};

export default Map;
