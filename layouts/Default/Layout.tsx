import makeStyles from '@material-ui/core/styles/makeStyles';
import Head from 'next/head';
import React, {useState} from 'react';
import {Sidebar, TopBar} from './components';

const useStyles = makeStyles(() => ({
    root: {
        height: '100%',
        width: '100%',
        display: 'flex',
        flexDirection: 'column',
        overflow: 'hidden',
    },
    topBar: {
        zIndex: 2,
        position: 'relative',
    },
    container: {
        display: 'flex',
        flex: '1 1 auto',
        overflow: 'hidden',
    },
    navBar: {
        zIndex: 3,
        width: 256,
        minWidth: 256,
        flex: '0 0 auto',
    },
    content: {
        overflowY: 'auto',
        flex: '1 1 auto',
    },
}));

export interface MainLayoutProps {
    title: string;
}

const Layout: React.FC<MainLayoutProps> = (props) => {
    const classes = useStyles();
    const [openNavBarMobile, setOpenNavBarMobile] = useState(false);

    const handleNavBarMobileOpen = () => {
        setOpenNavBarMobile(true);
    };

    const handleNavBarMobileClose = () => {
        setOpenNavBarMobile(false);
    };

    return (
        <>
            <Head>
                <title>{props.title}</title>
            </Head>
            <div className={classes.root}>
                <TopBar
                    className={classes.topBar}
                    onOpenNavBarMobile={handleNavBarMobileOpen}
                />
                <div className={classes.container}>
                    <Sidebar
                        className={classes.navBar}
                        onMobileClose={handleNavBarMobileClose}
                        openMobile={openNavBarMobile}
                    />
                    <main className={classes.content}>
                        {props.children}
                    </main>
                </div>
            </div>
        </>
    );
};

export default Layout;
