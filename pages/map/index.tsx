import {NextPage} from 'next';
import dynamic from 'next/dynamic';
import React from 'react';
import {DefaultLayout} from '../../layouts';

const Leaflet = dynamic(() => import('./components/Leaflet'), {
    ssr: false,
});

const Map: NextPage = () => {
    return (
        <DefaultLayout title={'Cafe map'} links={[
            'https://cdnjs.cloudflare.com/ajax/libs/leaflet/1.3.1/leaflet.css',
            'https://unpkg.com/leaflet-geosearch@latest/assets/css/leaflet.css',
        ]}>
            <Leaflet/>
        </DefaultLayout>
    );
};

export default Map;
