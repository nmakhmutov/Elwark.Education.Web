import {
    ExpansionPanel,
    ExpansionPanelDetails,
    ExpansionPanelSummary,
    FormControl,
    InputLabel,
    makeStyles,
    Select,
    Typography,
    useMediaQuery,
} from '@material-ui/core';
import ExpandMoreIcon from '@material-ui/icons/ExpandMore';
import {Bff} from 'api';
import {CoffeeHouseMapPoint, CountryCityModel} from 'api/bff/types';
import L from 'leaflet';
import React, {useEffect, useState} from 'react';
import {Map, Marker, Popup, TileLayer, ZoomControl} from 'react-leaflet';
import MarkerClusterGroup from 'react-leaflet-markercluster';
import defaultTheme from 'theme';
import {LeafletControl, PopupCard} from './components';

const useStyles = makeStyles((theme) => ({
    root: {
        height: '100%',
    },
    map: {
        height: 'calc(100vh - 64px)',
        width: '100%',
    },
    filterPanel: {
        width: theme.breakpoints.values.sm / 2,
    },
    heading: {
        fontSize: theme.typography.pxToRem(15),
        fontWeight: theme.typography.fontWeightRegular,
    },
    formControl: {
        width: '100%',
    },
    popup: {},
    card: {
        maxWidth: 345,
        margin: '-14px -20px',
        boxShadow: 'none',
    },
    media: {
        height: 0,
        paddingTop: '56.25%', // 16:9
    },
    backdrop: {
        zIndex: 1002,
        color: '#fff',
    },
}));

const defaultCoordinates = '0,0,3';
const attribution =
    '&copy; <a href="https://www.openstreetmap.org/copyright" target="_blank">OpenStreetMap</a> contributors ' +
    '&copy; <a href="https://carto.com/attributions" target="_blank">CARTO</a>';
const storageKey = 'e1980037f03a43968f9591d745164ac1';

interface City {
    lat: number;
    lng: number;
    zoom: number;
    cityId?: string;
}

const CafeMap: React.FC = () => {
    const classes = useStyles();
    const [cities, setCities] = useState<CountryCityModel[]>([]);

    useEffect(() => {
        let isMounted = true;

        Bff.Cities.List().then((x) => {
            if (isMounted) {
                setCities(x);
            }
        });

        return () => {
            isMounted = false;
        };
    }, []);

    const isDesktop = useMediaQuery(defaultTheme.breakpoints.up('lg'), {
        defaultMatches: true,
    });

    const parseStringCenter = (value: string | null) => {
        if (!value) {
            value = defaultCoordinates;
        }

        const [lat = 0, lng = 0, zoom = 3, cityId] = value.split(',');
        return {
            lat: Number(lat),
            lng: Number(lng),
            zoom: Number(zoom),
            cityId,
        };
    };

    const [city, setCity] = useState<City>(parseStringCenter(localStorage.getItem(storageKey)));
    const [markers, setMarkers] = useState<CoffeeHouseMapPoint[]>([]);

    const updateCity = (event: React.ChangeEvent<{ value: unknown }>) => {
        const value = event.target.value as string;
        const data = parseStringCenter(value);

        setCity(data);
        localStorage.setItem(storageKey, value);
    };

    useEffect(() => {
        const fetchCities = (id: string) => {
            Bff.Cities.Cafes(id)
                .then((response) => setMarkers(response));
        };

        if (city.cityId !== undefined) {
            fetchCities(city.cityId);
        }

        return () => setMarkers([]);
    }, [city]);

    return (
        <div className={classes.root}>
            <Map center={[city.lat, city.lng]}
                 zoom={city.zoom}
                 minZoom={3}
                 maxZoom={22}
                 className={classes.map}
                 zoomControl={false}>
                <TileLayer attribution={attribution}
                           url="https://{s}.basemaps.cartocdn.com/rastertiles/voyager/{z}/{x}/{y}{r}.png"/>
                <ZoomControl position={'bottomright'}/>
                <LeafletControl position={'topleft'}>
                    <ExpansionPanel square={true} defaultExpanded={isDesktop} className={classes.filterPanel}>
                        <ExpansionPanelSummary expandIcon={<ExpandMoreIcon/>}>
                            <Typography className={classes.heading}>Filter</Typography>
                        </ExpansionPanelSummary>
                        <ExpansionPanelDetails>
                            <FormControl className={classes.formControl}>
                                <InputLabel htmlFor="age-native-simple">City</InputLabel>
                                <Select
                                    native={true}
                                    value={`${city.lat},${city.lng},${city.zoom},${city.cityId}`}
                                    onChange={updateCity}>
                                    <option value={defaultCoordinates}/>
                                    {cities.map((value) =>
                                        <option key={value.cityId}
                                                value={`${value.position.latitude},${value.position.longitude},12,${value.cityId}`}>
                                            {value.countryName} - {value.cityName}
                                        </option>)}
                                </Select>
                            </FormControl>
                        </ExpansionPanelDetails>
                    </ExpansionPanel>
                </LeafletControl>

                <MarkerClusterGroup>
                    {markers.map((point) => {
                        return (
                            <Marker key={point.cafeId}
                                    position={[point.position.latitude, point.position.longitude]}
                                    icon={L.icon({
                                        iconSize: [48, 48],
                                        iconUrl: 'https://img.icons8.com/nolan/64/marker.png',
                                    })}>
                                <Popup className={classes.popup} closeButton={false}>
                                    <PopupCard point={point}/>
                                </Popup>
                            </Marker>
                        );
                    })}
                </MarkerClusterGroup>
            </Map>
        </div>
    );
};

export default CafeMap;
