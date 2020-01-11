import {Card, Grid, makeStyles, Typography} from '@material-ui/core';
import EmojiFlagsIcon from '@material-ui/icons/EmojiFlags';
import LocationCityIcon from '@material-ui/icons/LocationCity';
import RestaurantIcon from '@material-ui/icons/Restaurant';
import {ImageResolution, Storage} from 'api';
import clsx from 'clsx';
import React from 'react';

const useStyles = makeStyles((theme) => ({
    root: {
        backgroundImage: `url(${Storage.Images.Random(ImageResolution.SVGA)})`,
        backgroundRepeat: 'no-repeat',
        backgroundPosition: 'center',
        backgroundSize: 'cover',
    },
    item: {
        padding: theme.spacing(3),
        textAlign: 'center',
    },
    overlay: {
        backgroundColor: 'rgba(0,0,0,0.5)',
        color: theme.palette.common.white,
    },
}));

export interface SummaryProps {
    className?: string;
    cafes: number;
    cities: number;
    countries: number;
}

const Summary: React.FC<SummaryProps> = (props) => {
    const {countries, cafes, cities, className, ...rest} = props;
    const classes = useStyles();
    return (
        <Card
            {...rest}
            className={clsx(classes.root, className)}
        >
            <div className={classes.overlay}>
                <Grid alignItems="center" container justify="space-between">
                    <Grid className={classes.item} item={true} sm={4} xs={12}>
                        <Typography variant="h2" color={'inherit'}>
                            <EmojiFlagsIcon/> {countries}
                        </Typography>
                        <Typography variant="overline" color={'inherit'}>
                            Countries
                        </Typography>
                    </Grid>
                    <Grid className={classes.item} item={true} sm={4} xs={12}>
                        <Typography variant="h2" color={'inherit'}>
                            <LocationCityIcon/> {cities}
                        </Typography>
                        <Typography variant="overline" color={'inherit'}>
                            Cities
                        </Typography>
                    </Grid>
                    <Grid className={classes.item} item={true} sm={4} xs={12}>
                        <Typography variant="h2" color={'inherit'}>
                            <RestaurantIcon/> {cafes}
                        </Typography>
                        <Typography variant="overline" color={'inherit'}>
                            Cafes
                        </Typography>
                    </Grid>
                </Grid>
            </div>
        </Card>
    );
};

export default Summary;
