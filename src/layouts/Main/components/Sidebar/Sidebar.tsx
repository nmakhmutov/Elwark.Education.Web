import makeStyles from "@material-ui/core/styles/makeStyles";
import React from "react";
import {Drawer} from "@material-ui/core";
import clsx from "clsx";
import Divider from "@material-ui/core/Divider";
import {SidebarNav} from "./components";
import DashboardIcon from '@material-ui/icons/Dashboard';
import PeopleIcon from '@material-ui/icons/People';
import MapIcon from '@material-ui/icons/Map';
import TextFieldsIcon from '@material-ui/icons/TextFields';
import ImageIcon from '@material-ui/icons/Image';
import AccountBoxIcon from '@material-ui/icons/AccountBox';
import SettingsIcon from '@material-ui/icons/Settings';
import LockOpenIcon from '@material-ui/icons/LockOpen';

const useStyles = makeStyles(theme => ({
    drawer: {
        width: 240,
        [theme.breakpoints.up('lg')]: {
            marginTop: 64,
            height: 'calc(100% - 64px)'
        }
    },
    root: {
        backgroundColor: theme.palette.common.white,
        display: 'flex',
        flexDirection: 'column',
        height: '100%',
        padding: theme.spacing(2)
    },
    divider: {
        margin: theme.spacing(2, 0)
    },
    nav: {
        marginBottom: theme.spacing(2)
    }
}));

export interface SidebarProps {
    open: boolean,
    variant?: 'permanent' | 'persistent' | 'temporary',
    onClose: () => void,
    className?: string
}

const Sidebar: React.FC<SidebarProps> = (props) => {
    const classes = useStyles();
    const {open, variant, onClose, className, ...rest} = props;
    const pages = [
        {
            title: 'Home',
            href: '/',
            icon: <DashboardIcon />
        },
        {
            title: 'Map',
            href: '/map',
            icon: <MapIcon />
        },
        {
            title: 'Companies',
            href: '/companies',
            icon: <PeopleIcon />
        }
    ];

    return (
        <Drawer
            anchor="left"
            classes={{paper: classes.drawer}}
            onClose={onClose}
            open={open}
            variant={variant}
        >
            <div
                {...rest}
                className={clsx(classes.root, className)}
            >
                {/*<Profile />*/}
                {/*<Divider className={classes.divider}/>*/}
                <SidebarNav
                    className={classes.nav}
                    pages={pages}
                />
                {/*<UpgradePlan />*/}
            </div>
        </Drawer>
    );
}

export default Sidebar;