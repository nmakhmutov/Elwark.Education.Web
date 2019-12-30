import {Avatar, Drawer, Hidden, Paper} from '@material-ui/core';
import Divider from '@material-ui/core/Divider';
import makeStyles from '@material-ui/core/styles/makeStyles';
import Typography from '@material-ui/core/Typography';
import clsx from 'clsx';
import {useRouter} from 'next/router';
import React from 'react';
import Storage from '../../../../api/storage';
import {Link, Navigation} from '../../../../components';
import Pages from '../../../../navigationConfig';

const useStyles = makeStyles((theme) => ({
    root: {
        height: '100%',
        overflowY: 'auto',
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
    divider: {
        marginTop: theme.spacing(2),
    },
    navigation: {
        marginTop: theme.spacing(2),
    },
}));

export interface SidebarProps {
    onMobileClose: () => void;
    openMobile: boolean;
    className?: string;
}

const Sidebar: React.FC<SidebarProps> = (props) => {
    const {openMobile, onMobileClose, className, ...rest} = props;
    const classes = useStyles();
    const router = useRouter();

    const navbarContent = (
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
    );

    return (
        <>
            <Hidden lgUp>
                <Drawer
                    anchor="left"
                    onClose={onMobileClose}
                    open={openMobile}
                    variant="temporary"
                >
                    <div
                        {...rest}
                        className={clsx(classes.root, className)}
                    >
                        {navbarContent}
                    </div>
                </Drawer>
            </Hidden>
            <Hidden mdDown>
                <Paper
                    {...rest}
                    className={clsx(classes.root, className)}
                    elevation={1}
                    square
                >
                    {navbarContent}
                </Paper>
            </Hidden>
        </>
        // <Drawer
        //     anchor={'left'}
        //     classes={{paper: classes.drawer}}
        //     onClose={onClose}
        //     open={open}
        //     variant={variant}
        // >
        //     <div
        //         {...rest}
        //         className={clsx(classes.root, className)}
        //     >
        //         <div className={classes.content}>
        //             <div className={classes.profile}>
        //                 <Avatar
        //                     alt="Person"
        //                     className={classes.avatar}
        //                     component={Link}
        //                     src={Storage.Static.Icons.User.Default}
        //                     href="/profile/1/timeline"
        //                 />
        //                 <Typography
        //                     className={classes.name}
        //                     variant="h4"
        //                 >
        //                     Elwark Ink.
        //                 </Typography>
        //                 <Typography variant="body2">Cafe navigator</Typography>
        //             </div>
        //             <Divider className={classes.divider}/>
        //             <nav className={classes.navigation}>
        //                 {Pages.map((list) => (
        //                     <Navigation
        //                         component="div"
        //                         key={list.title}
        //                         pages={list.pages}
        //                         title={list.title}
        //                     />
        //                 ))}
        //             </nav>
        //         </div>
        //     </div>
        // </Drawer>
    );
};

export default Sidebar;
