import {Avatar, Drawer} from '@material-ui/core';
import Divider from '@material-ui/core/Divider';
import makeStyles from '@material-ui/core/styles/makeStyles';
import Typography from '@material-ui/core/Typography';
import clsx from 'clsx';
import React from 'react';
import Storage from '../../../../api/storage';
import {Link} from '../../../../components';
import Navigation from '../../../../components/Navigation';
import Pages from '../../../../navigationConfig';

const useStyles = makeStyles((theme) => ({
    drawer: {
        width: 240,
        [theme.breakpoints.up('lg')]: {
            marginTop: 64,
            height: 'calc(100% - 64px)',
        },
    },
    root: {
        backgroundColor: theme.palette.common.white,
        display: 'flex',
        flexDirection: 'column',
        height: '100%',
        padding: theme.spacing(2),
    },
    divider: {
        margin: theme.spacing(2, 0),
    },
    nav: {
        marginBottom: theme.spacing(2),
    },

    content: {
        padding: theme.spacing(2),
    },
    profile: {
        display: 'flex',
        flexDirection: 'column',
        alignItems: 'center',
        minHeight: 'fit-content',
    },
    avatar: {
        width: 60,
        height: 60,
    },
    name: {
        marginTop: theme.spacing(1),
    },
    navigation: {
        marginTop: theme.spacing(2),
    },
}));

export interface SidebarProps {
    open: boolean;
    variant?: 'permanent' | 'persistent' | 'temporary';
    onClose: () => void;
    className?: string;
}

const Sidebar: React.FC<SidebarProps> = (props) => {
    const classes = useStyles();
    const {open, variant, onClose, className, ...rest} = props;

    return (
        <Drawer
            anchor={'left'}
            classes={{paper: classes.drawer}}
            onClose={onClose}
            open={open}
            variant={variant}
        >
            <div
                {...rest}
                className={clsx(classes.root, className)}
            >
                <div className={classes.content}>
                    <div className={classes.profile}>
                        <Avatar
                            alt="Person"
                            className={classes.avatar}
                            component={Link}
                            src={Storage.Static.Icons.User.Default}
                            href="/profile/1/timeline"
                        />
                        <Typography
                            className={classes.name}
                            variant="h4"
                        >
                            Elwark Ink.
                        </Typography>
                        <Typography variant="body2">Cafe navigator</Typography>
                    </div>
                    <Divider className={classes.divider}/>
                    <nav className={classes.navigation}>
                        {Pages.map((list) => (
                            <Navigation
                                component="div"
                                key={list.title}
                                pages={list.pages}
                                title={list.title}
                            />
                        ))}
                    </nav>
                </div>
            </div>
        </Drawer>
    );
};

export default Sidebar;
