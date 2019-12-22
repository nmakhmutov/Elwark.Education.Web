import makeStyles from "@material-ui/core/styles/makeStyles";
import React, {MouseEventHandler, useState} from "react";
import Link from 'next/link';
import AppBar from "@material-ui/core/AppBar";
import clsx from "clsx";
import {Toolbar} from "@material-ui/core";
import Hidden from "@material-ui/core/Hidden";
import Badge from "@material-ui/core/Badge";
import IconButton from "@material-ui/core/IconButton";
import MenuIcon from "@material-ui/icons/Menu";
import NotificationsIcon from '@material-ui/icons/NotificationsOutlined';
import InputIcon from '@material-ui/icons/Input';

const useStyles = makeStyles(theme => ({
    root: {
        boxShadow: 'none'
    },
    flexGrow: {
        flexGrow: 1
    },
    signOutButton: {
        marginLeft: theme.spacing(1)
    }
}));

export interface TopbarProps {
    className?: string,
    onSidebarOpen: MouseEventHandler
}

const Topbar: React.FC<TopbarProps> = (props) => {
    const {className, onSidebarOpen, ...rest} = props;

    const classes = useStyles();
    const [notifications] = useState([]);

    return (
        <AppBar {...rest} className={clsx(classes.root, className)}>
            <Toolbar>
                <Link href="/">
                    <img
                        alt="Logo"
                        src="http://localhost:3000/static/images/icons/elwark/primary/48x48.png"
                    />
                </Link>
                <div className={classes.flexGrow} />
                <Hidden mdDown>
                    <IconButton color="inherit">
                        <Badge
                            badgeContent={notifications.length}
                            color="primary"
                            variant="dot"
                        >
                            <NotificationsIcon />
                        </Badge>
                    </IconButton>
                    <IconButton
                        className={classes.signOutButton}
                        color="inherit"
                    >
                        <InputIcon />
                    </IconButton>
                </Hidden>
                <Hidden lgUp>
                    <IconButton
                        color="inherit"
                        onClick={onSidebarOpen}
                    >
                        <MenuIcon />
                    </IconButton>
                </Hidden>
            </Toolbar>
        </AppBar>
    )
};

export default Topbar;