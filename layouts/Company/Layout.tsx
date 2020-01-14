import {colors, Tab, Tabs} from '@material-ui/core';
import Divider from '@material-ui/core/Divider';
import makeStyles from '@material-ui/core/styles/makeStyles';
import {CompanyModel} from 'api/bff/types';
import {DefaultLayout} from 'layouts';
import {useRouter} from 'next/router';
import React, {ChangeEvent} from 'react';
import {Links} from 'utils';
import {CompanyTabs} from 'utils/Links';
import {Header} from './components';

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

export interface LayoutProps {
    className?: string;
    title: string;
    tab: CompanyTabs;
    company: CompanyModel;
}

const Layout: React.FC<LayoutProps> = (props) => {
    const {title, tab, company: {id, name, description, logotype}, children} = props;
    const classes = useStyles();
    const router = useRouter();

    const tabs = Object.values(CompanyTabs).map((x) => x);

    const onTabClick = (event: ChangeEvent<{}>, value: string) => {
        const link = Links.Company(id, value as CompanyTabs);
        return router.push(link.href, link.as);
    };

    return (
        <DefaultLayout title={title}>
            <Header name={name}
                    avatar={logotype.square}
                    cover={logotype.background}
                    bio={description}/>
            <div className={classes.inner}>
                <Tabs onChange={onTabClick} scrollButtons={'auto'} value={tab} variant={'scrollable'}>
                    {tabs.map((x) => (
                        <Tab key={x} label={x} value={x}/>
                    ))}
                </Tabs>
                <Divider className={classes.divider}/>
                <div className={classes.content}>
                    {children}
                </div>
            </div>
        </DefaultLayout>
    );
};

export default Layout;
