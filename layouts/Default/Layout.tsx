import {useMediaQuery} from '@material-ui/core';
import makeStyles from '@material-ui/core/styles/makeStyles';
import clsx from 'clsx';
import Head from 'next/head';
import React, {useState} from 'react';
import theme from '../../theme';
import {Sidebar, TopBar} from './components';

const useStyles = makeStyles(() => ({
    root: {
        paddingTop: 56,
        height: '100%',
        [theme.breakpoints.up('sm')]: {
            paddingTop: 64,
        },
    },
    shiftContent: {
        paddingLeft: 240,
    },
    content: {
        height: '100%',
    },
}));

export interface MainLayoutProps {
    title: string;
    links?: string[];
}

const Layout: React.FC<MainLayoutProps> = (props) => {
    const classes = useStyles();
    const isDesktop = useMediaQuery(theme.breakpoints.up('lg'), {
        defaultMatches: true,
    });
    const [openNavBarMobile, setOpenNavBarMobile] = useState(!isDesktop);

    const handleNavBarMobileOpen = () => {
        setOpenNavBarMobile(true);
    };

    const handleNavBarMobileClose = () => {
        setOpenNavBarMobile(false);
    };

    const shouldOpenSidebar = isDesktop ? true : openNavBarMobile;
    const {children, title, links} = props;

    return (
        <>
            <Head>
                <title>{title}</title>
                {links && links.map(((value, index) =>
                    <link key={index} href={value} rel="stylesheet"/>))}
            </Head>
            <div className={clsx({
                [classes.root]: true,
                [classes.shiftContent]: isDesktop,
            })}>
                <TopBar onOpenNavBarMobile={handleNavBarMobileOpen}/>
                <Sidebar
                    onClose={handleNavBarMobileClose}
                    open={shouldOpenSidebar}
                    variant={isDesktop ? 'persistent' : 'temporary'}
                />
                <main className={classes.content}>
                    {children}
                    {/*<Footer/>*/}
                </main>
            </div>
        </>
    );
};

export default Layout;
