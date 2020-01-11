import {Grid} from '@material-ui/core';
import makeStyles from '@material-ui/core/styles/makeStyles';
import {Bff} from 'api';
import {CompanyModel, CompanyStats} from 'api/bff/types';
import {CompanyLayout} from 'layouts';
import {NextPage} from 'next';
import React from 'react';
import {CompanyTabs} from 'utils/Links';
import {CitiesTable, Contacts, Rating, Sites, Summary} from './components';

const useStyles = makeStyles((theme) => ({
    root: {},
    marginTop: {
        marginTop: theme.spacing(3),
    },
}));

interface OverviewProps {
    company: CompanyModel;
    stats: CompanyStats;
}

const Overview: NextPage<OverviewProps> = (props) => {
    const {company, stats} = props;
    const classes = useStyles();

    return (
        <CompanyLayout title={`Cafe company ${company.name} overview`} tab={CompanyTabs.Overview} company={company}>
            <Grid className={classes.root} container={true} spacing={3}>
                <Grid item={true} lg={8} xl={9} xs={12}>
                    <Rating rating={stats.total.rating}/>
                    <Summary className={classes.marginTop}
                             cafes={stats.total.cafes}
                             cities={stats.total.cities}
                             countries={stats.total.countries}/>
                    <CitiesTable className={classes.marginTop} cafes={stats.cafes}/>
                </Grid>
                <Grid item={true} lg={4} xl={3} xs={12}>
                    <Sites list={Object.entries(company.sites)}/>
                    <Contacts list={Object.entries(company.contacts)} className={classes.marginTop}/>
                </Grid>
            </Grid>
        </CompanyLayout>
    );
};

Overview.getInitialProps = async ({query}) => {
    const companyId = +query.company;
    const company = await Bff.Company.Get(companyId);
    const stats = await Bff.Company.Statistics(companyId);

    return {company, stats} as OverviewProps;
};

export default Overview;
