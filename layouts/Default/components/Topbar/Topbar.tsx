import {Toolbar} from '@material-ui/core';
import AppBar from '@material-ui/core/AppBar';
import Badge from '@material-ui/core/Badge';
import Hidden from '@material-ui/core/Hidden';
import IconButton from '@material-ui/core/IconButton';
import makeStyles from '@material-ui/core/styles/makeStyles';
import InputIcon from '@material-ui/icons/Input';
import MenuIcon from '@material-ui/icons/Menu';
import NotificationsIcon from '@material-ui/icons/NotificationsOutlined';
import clsx from 'clsx';
import Link from 'next/link';
import React, {MouseEventHandler, useState} from 'react';
import Storage from '../../../../api/storage/Storage';

const useStyles = makeStyles((theme) => ({
    root: {
        boxShadow: 'none',
    },
    flexGrow: {
        flexGrow: 1,
    },
    signOutButton: {
        marginLeft: theme.spacing(1),
    },
}));

export interface TopbarProps {
    className?: string;
    onSidebarOpen: MouseEventHandler;
}

const Topbar: React.FC<TopbarProps> = (props) => {
    const {className, onSidebarOpen, ...rest} = props;

    const classes = useStyles();
    const [notifications] = useState([]);

    return (
        <AppBar {...rest} className={clsx(classes.root, className)}>
            <Toolbar>
                <Link href="/">
                    <img alt="Logo" src={Storage.Static.Icons.Elwark.White.Size48x48}/>
                </Link>
                <div className={classes.flexGrow}/>
                <Hidden mdDown>
                    <IconButton color="inherit">
                        <Badge badgeContent={notifications.length} color="primary" variant="dot">
                            <NotificationsIcon/>
                        </Badge>
                    </IconButton>
                    <IconButton className={classes.signOutButton} color="inherit">
                        <InputIcon/>
                    </IconButton>
                </Hidden>
                <Hidden lgUp>
                    <IconButton color="inherit" onClick={onSidebarOpen}>
                        <MenuIcon/>
                    </IconButton>
                </Hidden>
            </Toolbar>
        </AppBar>
    );
};

export default Topbar;
