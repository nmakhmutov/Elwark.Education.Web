import {colors, Tab, Tabs} from '@material-ui/core';
import Divider from '@material-ui/core/Divider';
import makeStyles from '@material-ui/core/styles/makeStyles';
import {NextPage} from 'next';
import {useRouter} from 'next/router';
import React, {ChangeEvent, useEffect, useState} from 'react';
import {Bff, Storage} from '../../../api';
import {CompanyModel, CompanyStats, ImageResolution} from '../../../interfaces';
import {DefaultLayout} from '../../../layouts';
import Cafes from './components/Cafes';
import Catalog from './components/Catalog';
import Header from './components/Header';
import Overview from './components/Overview';

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
}

const Company: NextPage<CompanyProps> = (props) => {
    const classes = useStyles();
    const router = useRouter();
    const {id, tab, company} = props;
    const [overview, setOverview] = useState<CompanyStats[]>();

    const tabs = [
        {value: 'overview', label: 'Overview'},
        {value: 'cafes', label: 'Cafes'},
        {value: 'catalog', label: 'Catalog'},
    ];

    useEffect(() => {
        switch (tab) {
            case 'overview':
                Bff.Company.Stats(id).then((x) => setOverview(x));
                break;
            case 'cafes':
                break;
            case 'catalog':
                break;
        }
    }, [tab]);

    const onTabClick = (event: ChangeEvent<{}>, value: string) => {
        return router.push('/companies/[company]/[page]', `/companies/${id}/${value}`);
    };

    return (
        <DefaultLayout title={company.name}>
            <Header name={company.name}
                    avatar={company.logotype.square}
                    cover={Storage.Images.RandomByImageResolution(ImageResolution.FHD)}
                    bio={company.description}/>
            <div className={classes.inner}>
                <Tabs onChange={onTabClick} scrollButtons={'auto'} value={tab} variant={'scrollable'}>
                    {tabs.map((x) => (
                        <Tab key={x.value} label={x.label} value={x.value}/>
                    ))}
                </Tabs>
                <Divider className={classes.divider}/>
                <div className={classes.content}>
                    {tab === 'overview' && overview && <Overview
                        companyId={company.id}
                        stats={overview}
                        contacts={company.contacts}
                        sites={company.sites}/>}
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

    return {id, tab, company} as CompanyProps;
};

export default Company;
