import {colors, Tab, Tabs} from '@material-ui/core';
import Divider from '@material-ui/core/Divider';
import makeStyles from '@material-ui/core/styles/makeStyles';
import {NextPage} from 'next';
import {useRouter} from 'next/router';
import React from 'react';
import {MainLayout} from '../../../layouts/Main';
import Cafes from './components/Cafes';
import Catalog from './components/Catalog';
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

}

const Company: NextPage<CompanyProps> = (props) => {
    const classes = useStyles();
    const router = useRouter();
    const {company: id, page: tab} = router.query;

    const tabs = [
        {value: 'overview', label: 'Overview'},
        {value: 'cafes', label: 'Cafes'},
        {value: 'catalog', label: 'Catalog'},
    ];

    return (
        <MainLayout title={`Cafes: ${id} ${tab}`}>
            <div className={classes.inner}>
                <Tabs
                    onChange={(event, value) => router.push('/companies/[company]/[page]', `/companies/${id}/${value}`)}
                    scrollButtons="auto"
                    value={tab}
                    variant="scrollable"
                >
                    {tabs.map((x) => (
                        <Tab
                            key={x.value}
                            label={x.label}
                            value={x.value}
                        />
                    ))}
                </Tabs>
                <Divider className={classes.divider}/>
                <div className={classes.content}>
                    {tab === 'overview' && <Overview/>}
                    {tab === 'cafes' && <Cafes/>}
                    {tab === 'catalog' && <Catalog/>}
                </div>
            </div>
        </MainLayout>
    );
};

Company.getInitialProps = () => {
    return {} as CompanyProps;
};

export default Company;
