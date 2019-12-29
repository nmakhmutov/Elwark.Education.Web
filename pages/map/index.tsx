import {NextPage} from 'next';
import dynamic from 'next/dynamic';
import React from 'react';
import {DefaultLayout} from '../../layouts';

const Leaflet = dynamic(() => import('./components/Leaflet'), {
    ssr: false,
});
const mapStyles = [
    'https://unpkg.com/leaflet@1.6.0/dist/leaflet.css',
    'https://unpkg.com/leaflet-geosearch@latest/assets/css/leaflet.css',
];

const Map: NextPage = () => {
    return (
        <DefaultLayout title={'Cafe map'} links={mapStyles}>
            <Leaflet/>
        </DefaultLayout>
    );
};

export default Map;
