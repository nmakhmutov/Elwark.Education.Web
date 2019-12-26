import {colors, Tab, Tabs} from '@material-ui/core';
import Divider from '@material-ui/core/Divider';
import makeStyles from '@material-ui/core/styles/makeStyles';
import {NextPage} from 'next';
import {useRouter} from 'next/router';
import React, {ChangeEvent} from 'react';
import Bff from '../../../api/bff';
import {CompanyModel} from '../../../interfaces';
import {MainLayout} from '../../../layouts/Main';
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

// tslint:disable-next-line:no-empty-interface
interface CompanyProps {
    id: number;
    tab: string;
    company: CompanyModel;
}

const Company: NextPage<CompanyProps> = (props) => {
    const classes = useStyles();
    const router = useRouter();
    const {id, tab, company} = props;

    const tabs = [
        {value: 'overview', label: 'Overview'},
        {value: 'cafes', label: 'Cafes'},
        {value: 'catalog', label: 'Catalog'},
    ];

    const onTabClick = (event: ChangeEvent<{}>, value: string) => {
        return router.push('/companies/[company]/[page]', `/companies/${id}/${value}`);
    };

    return (
        <MainLayout title={company.name}>
            <Header name={company.name}
                    avatar={company.logotype.square}
                    cover={'http://localhost:3000/image/random/fhd'}
                    bio={company.description}/>
            <div className={classes.inner}>
                <Tabs onChange={onTabClick} scrollButtons={'auto'} value={tab} variant={'scrollable'}>
                    {tabs.map((x) => (
                        <Tab key={x.value} label={x.label} value={x.value}/>
                    ))}
                </Tabs>
                <Divider className={classes.divider}/>
                <div className={classes.content}>
                    {tab === 'overview' && <Overview companyId={company.id}
                                                     contacts={company.contacts}
                                                     sites={company.sites}/>}
                    {tab === 'cafes' && <Cafes/>}
                    {tab === 'catalog' && <Catalog/>}
                </div>
            </div>
        </MainLayout>
    );
};

Company.getInitialProps = async ({query}) => {
    const id = +query.company;
    const tab = query.page;
    const company = await Bff.Company.Get(id);

    return {id, tab, company} as CompanyProps;
};

export default Company;
