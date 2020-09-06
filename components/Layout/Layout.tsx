import makeStyles from '@material-ui/core/styles/makeStyles';
import Sidebar from 'components/Sidebar/Sidebar';
import TopBar from 'components/TopBar/TopBar';
import {useFetchUser, UserProvider} from 'lib/user';
import Head from 'next/head';
import React, {useState} from 'react';
import {ProfileProvider, useFetchProfile} from 'lib/profile';

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
    links?: string[];
}

const DefaultLayout: React.FC<MainLayoutProps> = (props) => {
    const classes = useStyles();
    const [openNavBarMobile, setOpenNavBarMobile] = useState(false);
    const user = useFetchUser();
    const profile = useFetchProfile();

    const handleNavBarMobileOpen = () => setOpenNavBarMobile(true);

    const handleNavBarMobileClose = () => setOpenNavBarMobile(false);

    const {children, title, links} = props;

    return (
        <UserProvider value={{user: user.user, loading: user.loading}}>
            <ProfileProvider value={{profile: profile.profile, loading: profile.loading}}>
                <Head>
                    <title>{title}</title>
                    {links?.map(((href, index) => <link key={index} href={href} rel="stylesheet"/>))}
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
                            {children}
                        </main>
                    </div>
                </div>
            </ProfileProvider>
        </UserProvider>
    );
};

DefaultLayout.defaultProps = {
    links: []
}

export default DefaultLayout;
