import React, {useState} from "react";
import makeStyles from "@material-ui/core/styles/makeStyles";
import useTheme from "@material-ui/core/styles/useTheme";
import {useMediaQuery} from "@material-ui/core";
import clsx from 'clsx';
import Topbar from "./components/Topbar";
import Head from "next/head";
import Sidebar from "./components/Sidebar";

const useStyles = makeStyles(theme => ({
    root: {
        paddingTop: 56,
        height: '100%',
        [theme.breakpoints.up('sm')]: {
            paddingTop: 64
        }
    },
    shiftContent: {
        paddingLeft: 240
    },
    content: {
        height: '100%'
    }
}));

export interface MainLayoutProps {
    title: string
}
const Layout: React.FC<MainLayoutProps> = (props) => {
    const classes = useStyles();
    const theme = useTheme();
    const isDesktop = useMediaQuery(theme.breakpoints.up('lg'), {
        defaultMatches: true
    });
    const [openSidebar, setOpenSidebar] = useState(false);

    const handleSidebarOpen = () => {
        setOpenSidebar(true);
    };

    const handleSidebarClose = () => {
        setOpenSidebar(false);
    };

    const shouldOpenSidebar = isDesktop ? true : openSidebar;

    return (
        <>
            <Head>
                <title>{props.title}</title>
            </Head>
            <div
                className={clsx({
                    [classes.root]: true,
                    [classes.shiftContent]: isDesktop
                })}
            >
                <Topbar onSidebarOpen={handleSidebarOpen}/>
                <Sidebar
                    onClose={handleSidebarClose}
                    open={shouldOpenSidebar}
                    variant={isDesktop ? 'persistent' : 'temporary'}
                />
                <main className={classes.content}>
                    {props.children}
                    {/*<Footer/>*/}
                </main>
            </div>
        </>
    )
};

export default Layout;