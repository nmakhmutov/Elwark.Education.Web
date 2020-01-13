import {DefaultLayout} from 'layouts';
import {NextPage} from 'next';
import React from 'react';

interface OverviewProps {
    cafeId: number;
}

const Overview: NextPage<OverviewProps> = (props) => {
    const {cafeId} = props;

    return (
        <DefaultLayout title={`Cafe ${cafeId}`}/>
    );
};

Overview.getInitialProps = async ({query}) => {
    return ({
        cafeId: +query.cafe,
    });
};
export default Overview;
