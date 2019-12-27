import {Grid} from '@material-ui/core';
import React, {useState} from 'react';
import {CompanyStats} from '../../../../../interfaces';
import {Contacts, Sites} from './components';

export interface OverviewProps {
    companyId: number;
    stats: CompanyStats[];
    sites: Record<string, string>;
    contacts: Record<string, string>;
}

const Overview: React.FC<OverviewProps> = (props) => {
    const {companyId, stats, contacts, sites, ...rest} = props;

    return (
        <Grid
            {...rest}
            container
            spacing={3}
        >
            <Grid item={true} lg={4} md={6} xl={3} xs={12}>
                <Contacts list={Object.entries(contacts)}/>
            </Grid>
            <Grid item={true} lg={4} md={6} xl={3} xs={12}>
                <Sites list={Object.entries(sites)}/>
            </Grid>
            <Grid item={true} lg={4} md={6} xl={3} xs={12}>
                {stats[0].cafeCount}
            </Grid>
            <Grid item={true} lg={4} md={6} xl={3} xs={12}>
                !
            </Grid>
        </Grid>
    );
};

export default Overview;
