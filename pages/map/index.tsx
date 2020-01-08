import {Bff} from 'api';
import {CountryCityModel} from 'api/bff/types';
import {DefaultLayout} from 'layouts';
import {NextPage} from 'next';
import dynamic from 'next/dynamic';
import React from 'react';

const Leaflet = dynamic(() => import('./components/Leaflet'), {
    ssr: false,
});
const mapStyles = [
    'https://unpkg.com/leaflet@1.6.0/dist/leaflet.css',
    'https://unpkg.com/leaflet-geosearch@latest/assets/css/leaflet.css',
    '/static/leaflet-cluster.css',
];

export interface MapProps {
    cities: CountryCityModel[];
}

const Map: NextPage<MapProps> = (props) => {
    return (
        <DefaultLayout title={'Cafe map'} links={mapStyles}>
            <Leaflet cities={props.cities}/>
        </DefaultLayout>
    );
};

Map.getInitialProps = async () => {
    const cities = await Bff.Cities.List();
    return {cities} as MapProps;
};

export default Map;
