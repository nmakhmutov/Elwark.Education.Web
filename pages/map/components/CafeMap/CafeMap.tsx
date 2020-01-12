import {
    CircularProgress,
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
import L from 'leaflet';
import React, {useEffect, useReducer} from 'react';
import {Map, Marker, Popup, TileLayer, ZoomControl} from 'react-leaflet';
import MarkerClusterGroup from 'react-leaflet-markercluster';
import defaultTheme from 'theme';
import {LeafletControl, PopupCard} from './components';
import {
    cafeMapReducer,
    changeCity,
    filterRequest,
    filterSuccess,
    initialState,
    markersRequest,
    markersSuccess,
} from './reducer';

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

const attribution =
    '&copy; <a href="https://www.openstreetmap.org/copyright" target="_blank">OpenStreetMap</a> contributors ' +
    '&copy; <a href="https://carto.com/attributions" target="_blank">CARTO</a>';

const CafeMap: React.FC = () => {
    const classes = useStyles();
    const isDesktop = useMediaQuery(defaultTheme.breakpoints.up('lg'), {defaultMatches: true});
    const [state, dispatch] = useReducer(cafeMapReducer, initialState);

    useEffect(() => {
        let isMounted = true;

        dispatch(filterRequest());
        Bff.Cities.List()
            .then((response) => {
                if (isMounted) {
                    dispatch(filterSuccess(response));
                }
            });

        return () => {
            isMounted = false;
        };
    }, []);

    useEffect(() => {
        const fetchCities = (id: string) => {
            dispatch(markersRequest());
            Bff.Cities.Cafes(id)
                .then((response) => dispatch(markersSuccess(response)));
        };

        if (state.cityId) {
            fetchCities(state.cityId);
        }

        return () => dispatch(markersSuccess([]));
    }, [state.cityId]);

    const updateCity = (event: React.ChangeEvent<{ value: unknown }>) => {
        const value = event.target.value as string;

        if (!value) {
            return dispatch(changeCity('', 0, 0, 3));
        }

        const city = state.filter.data.find((x) => x.cityId === value)!;

        return dispatch(changeCity(city.cityId, city.position.latitude, city.position.longitude, 12));
    };

    return (
        <div className={classes.root}>
            <Map center={[state.lat, state.lng]}
                 zoom={state.zoom}
                 minZoom={3}
                 maxZoom={22}
                 className={classes.map}
                 zoomControl={false}>
                <TileLayer attribution={attribution}
                           url="https://{s}.basemaps.cartocdn.com/rastertiles/voyager/{z}/{x}/{y}{r}.png"/>
                <ZoomControl position={'bottomright'}/>
                <LeafletControl position={'topleft'}>
                    <ExpansionPanel square={true} defaultExpanded={isDesktop} className={classes.filterPanel}>
                        <ExpansionPanelSummary
                            expandIcon={
                                state.filter.loading || state.markers.loading
                                    ? <CircularProgress variant={'indeterminate'} style={{width: 24, height: 24}}/>
                                    : <ExpandMoreIcon/>
                            }>
                            <Typography className={classes.heading}>Filter</Typography>
                        </ExpansionPanelSummary>
                        <ExpansionPanelDetails>
                            {state.filter.data.length > 0 &&
                            <FormControl className={classes.formControl}>
                                <InputLabel htmlFor="age-native-simple">City</InputLabel>
                                <Select native={true} value={state.cityId} onChange={updateCity}>
                                    <option value=""/>
                                    {state.filter.data.map((value) =>
                                        <option key={value.cityId} value={value.cityId}>
                                            {value.countryName} - {value.cityName}
                                        </option>)}
                                </Select>
                            </FormControl>
                            }
                        </ExpansionPanelDetails>
                    </ExpansionPanel>
                </LeafletControl>

                <MarkerClusterGroup>
                    {state.markers.data.map((point) => {
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
