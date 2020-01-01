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
import React, {useEffect, useState} from 'react';
import {Map, TileLayer, ZoomControl} from 'react-leaflet';
import {Bff} from '../../../../api';
import {CountryCityModel} from '../../../../api/bff/types';
import defaultTheme from '../../../../theme';
import LeafletControl from './LeafletControl';

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
}));

const defaultCoordinates = '0,0,2';
const attribution =
    '&copy; <a href="https://www.openstreetmap.org/copyright" target="_blank">OpenStreetMap</a> contributors ' +
    '&copy; <a href="https://carto.com/attributions" target="_blank">CARTO</a>';
const storageKey = 'map-city';

const Leaflet = () => {
    const parseStringCenter = (value: string | null) => {
        if (!value) {
            value = defaultCoordinates;
        }

        localStorage.setItem(storageKey, value);

        const [lat, lng, zoom] = value.split(',');
        return {lat: Number(lat), lng: Number(lng), zoom: Number(zoom)};
    };

    const classes = useStyles();
    const isDesktop = useMediaQuery(defaultTheme.breakpoints.up('lg'), {
        defaultMatches: true,
    });

    const [center, setCenter] = useState(parseStringCenter(localStorage.getItem(storageKey)));
    const updateCenter = (event: React.ChangeEvent<{ value: unknown }>) => {
        const data = parseStringCenter(event.target.value as string);
        setCenter(data);
    };

    const [cities, setCities] = useState<CountryCityModel[]>([]);
    useEffect(() => {
        let mounted = true;

        const fetchCities = () => {
            Bff.Cities.List().then((response) => {
                if (mounted) {
                    setCities(response);
                }
            });
        };

        fetchCities();

        return () => {
            mounted = false;
        };
    }, []);

    return (
        <div className={classes.root}>
            <Map center={[center.lat, center.lng]} zoom={center.zoom} className={classes.map} zoomControl={false}>
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
                                    value={`${center.lat},${center.lng},${center.zoom}`}
                                    onChange={updateCenter}>
                                    <option value={defaultCoordinates}/>
                                    {cities.map((value) =>
                                        <option key={value.cityId}
                                                value={`${value.position.latitude},${value.position.longitude},13`}>
                                            {value.countryName} - {value.cityName}
                                        </option>)}
                                </Select>
                            </FormControl>
                        </ExpansionPanelDetails>
                    </ExpansionPanel>
                </LeafletControl>
                {/*  <Marker*/}
                {/*      draggable={true}*/}
                {/*      onDragend={this.updatePosition}*/}
                {/*      position={markerPosition}*/}
                {/*      animate={true}*/}
                {/*      ref={this.refmarker}>*/}
                {/*      <Popup minWidth={90}>*/}
                {/*<span onClick={this.toggleDraggable}>*/}
                {/*  {this.state.draggable ? 'DRAG MARKER' : 'MARKER FIXED'}*/}
                {/*</span>*/}
                {/*      </Popup>*/}
                {/*  </Marker>*/}
                {/*  <SearchBar updateMarker={this.updateMarker}/>*/}
            </Map>
        </div>
    );
};

export default Leaflet;
