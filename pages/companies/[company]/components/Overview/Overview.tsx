import {Grid} from '@material-ui/core';
import makeStyles from '@material-ui/core/styles/makeStyles';
import {CompanyStats} from 'api/bff/types';
import clsx from 'clsx';
import React from 'react';
import {CitiesTable, Contacts, Rating, Sites, Summary} from './components';

const useStyles = makeStyles((theme) => ({
    root: {},
    marginTop: {
        marginTop: theme.spacing(3),
    },
}));

export interface OverviewProps {
    className?: string;
    stats: CompanyStats;
    sites: Record<string, string>;
    contacts: Record<string, string>;
}

const Overview: React.FC<OverviewProps> = (props) => {
    const {stats, contacts, sites, className, ...rest} = props;
    const classes = useStyles();

    return (
        <Grid
            {...rest}
            className={clsx(classes.root, className)}
            container={true}
            spacing={3}
        >
            <Grid item={true} lg={8} xl={9} xs={12}>
                <Rating rating={stats.total.rating}/>
                <Summary className={classes.marginTop}
                         cafes={stats.total.cafes}
                         cities={stats.total.cities}
                         countries={stats.total.countries}/>
                <CitiesTable className={classes.marginTop} cafes={stats.cafes}/>
            </Grid>
            <Grid item={true} lg={4} xl={3} xs={12}>
                <Sites list={Object.entries(sites)}/>
                <Contacts list={Object.entries(contacts)} className={classes.marginTop}/>
            </Grid>
        </Grid>
    );
};

export default Overview;
