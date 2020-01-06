import {colors, Tab, Tabs} from '@material-ui/core';
import Divider from '@material-ui/core/Divider';
import makeStyles from '@material-ui/core/styles/makeStyles';
import {Bff, ImageResolution, Storage} from 'api';
import {CompanyModel, CompanyStats} from 'api/bff/types';
import {DefaultLayout} from 'layouts';
import {NextPage} from 'next';
import {useRouter} from 'next/router';
import React, {ChangeEvent} from 'react';
import {Cafes, Catalog, Header, Overview} from './components';

const useStyles = makeStyles((theme) => ({
    inner: {
        width: theme.breakpoints.values.lg,
        maxWidth: '100%',
        margin: '0 auto',
        padding: theme.spacing(3),
    },
    divider: {
        backgroundColor: colors.grey[300],
    },
    content: {
        marginTop: theme.spacing(3),
    },
}));

interface CompanyProps {
    id: number;
    tab: string;
    company: CompanyModel;
    stats?: CompanyStats;
}

const Company: NextPage<CompanyProps> = (props) => {
    const classes = useStyles();
    const router = useRouter();
    const {id, tab, company: {name, sites, contacts, description, logotype}, stats} = props;

    const tabs = [
        {value: 'overview', label: 'Overview'},
        {value: 'cafes', label: 'Cafes'},
        {value: 'catalog', label: 'Catalog'},
    ];

    const onTabClick = (event: ChangeEvent<{}>, value: string) => {
        return router.push('/companies/[company]/[page]', `/companies/${id}/${value}`);
    };

    return (
        <DefaultLayout title={name}>
            <Header name={name}
                    avatar={logotype.square}
                    cover={Storage.Images.RandomByImageResolution(ImageResolution.FHD)}
                    bio={description}/>
            <div className={classes.inner}>
                <Tabs onChange={onTabClick} scrollButtons={'auto'} value={tab} variant={'scrollable'}>
                    {tabs.map((x) => (
                        <Tab key={x.value} label={x.label} value={x.value}/>
                    ))}
                </Tabs>
                <Divider className={classes.divider}/>
                <div className={classes.content}>
                    {tab === 'overview' && <Overview stats={stats!} contacts={contacts} sites={sites}/>}
                    {tab === 'cafes' && <Cafes/>}
                    {tab === 'catalog' && <Catalog/>}
                </div>
            </div>
        </DefaultLayout>
    );
};

Company.getInitialProps = async ({query}) => {
    const id = +query.company;
    const tab = query.page;
    const company = await Bff.Company.Get(id);
    let stats;

    switch (tab) {
        case 'overview':
            stats = await Bff.Company.Statistics(id);
    }

    return {id, tab, company, stats} as CompanyProps;
};

export default Company;
