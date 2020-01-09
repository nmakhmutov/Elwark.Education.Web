import {DefaultLayout} from 'layouts';
import {NextPage} from 'next';
import dynamic from 'next/dynamic';
import React from 'react';

const CafeMap = dynamic(() => import('./components/CafeMap'), {
    ssr: false,
});
const mapStyles = [
    'https://unpkg.com/leaflet@1.6.0/dist/leaflet.css',
    'https://unpkg.com/leaflet-geosearch@latest/assets/css/leaflet.css',
    '/static/leaflet-cluster.css',
];

const Map: NextPage = () => {
    return (
        <DefaultLayout title={'Cafe map'} links={mapStyles}>
            <CafeMap/>
        </DefaultLayout>
    );
};

export default Map;
