import {NextPage} from 'next';
import React from 'react';
import {DefaultLayout} from '../../layouts';

const Map: NextPage = () => {
    return (
        <DefaultLayout title={'Cafe map'}/>
    );
};

Map.getInitialProps = async () => {
    await new Promise((resolve) => {
        setTimeout(resolve, 10);
    });
    return {};
};

export default Map;
