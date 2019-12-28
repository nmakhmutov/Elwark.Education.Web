import {
    ExpansionPanel,
    ExpansionPanelDetails,
    ExpansionPanelSummary,
    InputLabel,
    makeStyles,
    Select,
    Typography,
    useMediaQuery,
} from '@material-ui/core';
import ExpandMoreIcon from '@material-ui/icons/ExpandMore';
import React, {useState} from 'react';
import {Map, TileLayer, withLeaflet, ZoomControl} from 'react-leaflet';
import defaultTheme from '../../../../theme';
import {LeafletControl} from './LeafletControl';

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
}));

const defaultCoordinates = '0,0,2';
const attribution =
    '&copy; <a href="https://www.openstreetmap.org/copyright" target="_blank">OpenStreetMap</a> contributors ' +
    '&copy; <a href="https://carto.com/attributions" target="_blank">CARTO</a>';

const Leaflet = () => {
    const parseStringCenter = (value: string | null) => {
        if (!value) {
            value = defaultCoordinates;
        }

        localStorage.setItem('map-city', value);

        const [lat, lng, zoom] = value.split(',');
        return {lat: Number(lat), lng: Number(lng), zoom: Number(zoom)};
    };

    const isDesktop = useMediaQuery(defaultTheme.breakpoints.up('lg'), {
        defaultMatches: true,
    });
    const classes = useStyles();
    const FilterPanel = withLeaflet(LeafletControl);
    const [center, setCenter] = useState(parseStringCenter(localStorage.getItem('map-city')));

    const updateCenter = (event: React.ChangeEvent<{ value: unknown }>) => {
        const data = parseStringCenter(event.target.value as string);
        setCenter(data);
    };

    return (
        <div className={classes.root}>
            <Map center={[center.lat, center.lng]} zoom={center.zoom} className={classes.map} zoomControl={false}>
                <TileLayer attribution={attribution}
                           url="https://{s}.basemaps.cartocdn.com/rastertiles/voyager/{z}/{x}/{y}{r}.png"/>
                <ZoomControl position={'bottomright'}/>
                <FilterPanel position={'topleft'}>
                    <ExpansionPanel square={true} defaultExpanded={isDesktop} className={classes.filterPanel}>
                        <ExpansionPanelSummary expandIcon={<ExpandMoreIcon/>}>
                            <Typography className={classes.heading}>Filter</Typography>
                        </ExpansionPanelSummary>
                        <ExpansionPanelDetails>
                            <div>
                                <InputLabel htmlFor="age-native-simple">City</InputLabel>
                                <Select
                                    native={true}
                                    value={`${center.lat},${center.lng},${center.zoom}`}
                                    onChange={updateCenter}>
                                    <option value={defaultCoordinates}/>
                                    <option value={'55.7517311,37.617877,13'}>Moscow</option>
                                    <option value={'51.507423,-0.1278582,13'}>London</option>
                                    <option value={'48.8594695,2.3492151,13'}>Paris</option>
                                </Select>
                            </div>
                        </ExpansionPanelDetails>
                    </ExpansionPanel>
                </FilterPanel>
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
